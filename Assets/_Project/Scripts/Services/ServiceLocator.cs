using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoundsTextAdventure
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                Debug.LogWarning($"Service of type {type.FullName} is already registered. Overwriting.");
            }
            _services[type] = service;
        }

        public static void RegisterOnce<T>(T service) where T : class
        {
            var type = typeof(T);
            if (!_services.ContainsKey(type))
            {
                _services[type] = service;
            }
        }

        public static T Get<T>() where T : class
        {
            var type = typeof(T);
            if (_services.TryGetValue(type, out var service))
            {
                return service as T;
            }
            
            throw new InvalidOperationException($"Service of type {type.FullName} has not been registered.");
        }

        public static T TryGetService<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var serviceInstance))
            {
                return serviceInstance as T;
            }
            
            Debug.LogError($"[ServiceLocator] Service of type {typeof(T).FullName} has not been registered.");
            return null;
        }
        
        public static void Unregister<T>() where T : class
        {
            var type = typeof(T);
            if (_services.Remove(type))
            {
                Debug.Log($"Unregistered service: {type.Name}");
            }
            else
            {
                Debug.LogError($"Attempted to unregister non-existent service: {type.Name}");
            }
        }
    }
}
