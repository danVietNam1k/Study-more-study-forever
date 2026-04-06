using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator 
{
    private static Dictionary<Type, object> services = new ();
    public static void Register<T> (T service) where T : class
    {
        services[typeof (T)] = service;
    }
    public static T Get<T> () where T:class
    {
        if(services.TryGetValue(typeof(T), out object service))
        {
            return service as T;
        }
        throw new  Exception($"Service{typeof (T).Name} not found. Make sure all service are registered before accesing through the service locator.");
    }
    public static void Unregister<T> () where T : class
    {
        services.Remove(typeof (T));
    }
}
