using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyHandler : MonoBehaviour
{
    private static DependencyHandler _instance;

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
