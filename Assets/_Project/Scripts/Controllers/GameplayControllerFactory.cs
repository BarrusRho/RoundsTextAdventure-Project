using System;

namespace RoundsTextAdventure
{
    public static class GameplayControllerFactory
    {
        public static IGameplayController Create(GameplayControllerType type, IGameplayView view = null)
        {
            return type switch
            {
                GameplayControllerType.PlayerController => CreateWithView<PlayerController>(view),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }
        
        private static T CreateWithView<T>(IGameplayView view) where T : IGameplayController, new()
        {
            var controller = new T();
            controller.Init((GameplayViewBase)view);
            return controller;
        }
    }

}
