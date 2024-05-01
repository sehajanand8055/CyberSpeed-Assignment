using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyHandler : MonoBehaviour
{
    private static DependencyHandler _instance;
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

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

    public void RegisterDependency<T>(object serviceObj)
    {
        services[typeof(T)] = serviceObj;
    }

    public T GetService<T>()
    {
        Debug.Log($"count of service dictionary is {services.Count}");
        if (services.TryGetValue(typeof(T), out object service))
        {
            return (T)service;
        }
        throw new Exception($"Service of type {typeof(T)} not registered!");
    }

}
