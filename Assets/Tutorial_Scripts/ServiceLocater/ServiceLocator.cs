using UnityEngine;
using System.Collections.Generic;
using System;
public class ServiceLocator
{
    private static ServiceLocator _instance;

    private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static ServiceLocator Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ServiceLocator();
            }

            return _instance;
        }
    }

    // Register services
    public void Register<T>(T service)
    {
        Type type = typeof(T);

        if (_services.ContainsKey(type))
        {
            Debug.LogWarning($"Service of type {type.Name} is already registered.");
            //if you want to overwrite it,
            _services[type] = service;
        }
        else
        {
            _services.Add(type, service);
            Debug.Log($"Service of type {type.Name} registered!");
        }
    }

    // Get services

    public T GetService<T>()
    {
        Type type = typeof(T);

        if(_services.TryGetValue(type, out object services))
        {
            return (T)services;
        }

        Debug.LogError($"Did not find the service of type {type.Name}");
        return default(T);
    } 
}
