using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyHandler : MonoBehaviour
{

    private static DependencyHandler _instance;
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    private HandlerService[] initializables;

    public static DependencyHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DependencyHandler>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        initializables = FindObjectsOfType<HandlerService>(true);
        if (initializables != null)
        {
            foreach (var intializable in initializables)
            {
                intializable.Initialize();
            }
        }
    }

    private void Start()
    {
        if (initializables != null)
        {
            foreach (var intializable in initializables)
            {
                intializable.MakeRegistrations();
            }
        }
    }



    public void RegisterDependency<T>(object serviceObj)
    {
        services[typeof(T)] = serviceObj;
    }

    public T GetService<T>()
    {
        if (services.TryGetValue(typeof(T), out object service))
        {
            return (T)service;
        }
        throw new Exception($"Service of type {typeof(T)} not registered!");
    }

}
