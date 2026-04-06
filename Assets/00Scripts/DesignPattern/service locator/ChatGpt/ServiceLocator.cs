using System;
using System.Collections.Generic;
namespace ChatGPT
{
    public static class ServiceLocator
{
    private static readonly Dictionary<Type,object> services = new();
    
    public static void Register<T>(T service) where T : class
        {
            Type type = typeof(T);
            if(service == null)
                throw new ArgumentNullException(nameof(service));
            if(services.ContainsKey(type))
                throw new InvalidOperationException($"Service {type.Name} already registered.");

            services[type] = service;

            if(service is IService s)
            {
                s.Initialize();
            }
        }
    public static T Get<T>() where T : class
        {
            Type type = typeof(T);
            if (services.TryGetValue(type, out var service))
                
                return service as T;
            throw new InvalidOperationException($"Service {type.Name} not found.");
        }
    public static bool TryGet<T>(out T service) where T : class
        {
            if(services.TryGetValue(typeof(T),out var obj))
            {
                service = obj as T;
                return service != null;
            }
            service = null;
            return false;
        }
    public static void Unregister<T>() where T : class
        {
            Type type = typeof(T);
            if(services.TryGetValue(type, out var service))
            {
                if (service is IService s)
                    s.Dispose();
            }
            services.Remove(type);
        }
    public static void Clear()
        {
            foreach (var service in services.Values)
            {
                if(service is IService s) s.Dispose();

            }
            services.Clear();
        }
}



}
