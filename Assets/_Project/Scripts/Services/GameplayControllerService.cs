using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class GameplayControllerService
    {
        private readonly Dictionary<Type, IGameplayController> controllers = new();
        
        public void Initialise() { }
        
        public void Register<T>(T controller) where T : IGameplayController
        {
            var type = typeof(T);
            if (controllers.ContainsKey(type))
            {
                Debug.LogWarning($"GameplayController of type {type.Name} is already registered.");
                return;
            }

            controllers[type] = controller;
            Debug.Log($"Registered GameplayController of type {type.Name}.");
        }
    }
}


