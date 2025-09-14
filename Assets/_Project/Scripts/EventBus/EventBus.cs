using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoundsTextAdventure
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, List<Delegate>> _listeners = new();

        public static void Subscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (!_listeners.ContainsKey(type))
                _listeners[type] = new List<Delegate>();

            if (!_listeners[type].Contains(callback))
            {
                _listeners[type].Add(callback);
                Debug.Log($"Subscribed to {type.Name}");
            }
        }

        public static void Unsubscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (_listeners.TryGetValue(type, out var list) && list.Remove(callback))
            {
                Debug.Log($"Unsubscribed from {type.Name}");
            }
        }
        
        public static void Fire<T>(T evt)
        {
            if (_listeners.TryGetValue(typeof(T), out var list))
            {
                Debug.Log($"Fired event: {typeof(T).Name}");

                var copy = list.ToList();
                foreach (var callback in copy.Cast<Action<T>>())
                {
                    callback.Invoke(evt);
                }
            }
            else
            {
                Debug.LogWarning($"Fired event with no listeners: {typeof(T).Name}");
            }
        }

        public static void Clear()
        {
            _listeners.Clear();
            
            Debug.Log($"All listeners cleared.");
        }
    }
}
