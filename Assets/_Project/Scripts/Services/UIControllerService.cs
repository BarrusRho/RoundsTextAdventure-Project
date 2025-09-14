using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoundsTextAdventure
{
    public class UIControllerService: IDisposable
    {
        private readonly Dictionary<UIViewType, IUIController> controllers = new();

        public UIControllerService(UIViewRegistry uiViewRegistry)
        {
            foreach (var viewEntry in uiViewRegistry.views)
            {
                if (viewEntry.uiView is not IUIView uiView)
                {
                    Debug.LogError(
                        $"Skipped registration — {viewEntry.uiView?.GetType().Name ?? "null"} is not an IUIView for {viewEntry.uiViewType}");
                    continue;
                }

                if (controllers.ContainsKey(viewEntry.uiViewType))
                {
                    Debug.LogWarning($"Duplicate ViewType detected: {viewEntry.uiViewType}");
                    continue;
                }

                var controller = UIControllerFactory.Create(viewEntry.uiViewType, viewEntry.uiView);
                controllers[viewEntry.uiViewType] = controller;

                Debug.Log($"Registered {viewEntry.uiViewType} with {controller.GetType().Name}");
            }
        }

        public void Initialise()
        {
            EventBus.Subscribe<ViewTransitionEvent>(OnViewTransition);
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<ViewTransitionEvent>(OnViewTransition);

            Clear();
            Debug.Log($"Disposed UIControllerService and its controllers.");
        }

        private void OnViewTransition(ViewTransitionEvent viewTransitionEvent)
        {
            Debug.Log($"ViewTransitionEvent received: showing {viewTransitionEvent.UIViewToShow}");
            HideAll();
            Show(viewTransitionEvent.UIViewToShow);
        }

        public void Show(UIViewType uiViewType)
        {
            if (controllers.TryGetValue(uiViewType, out var controller))
                controller.Show();
            else
                Debug.LogWarning($"No controller for {uiViewType}");
        }

        public void Hide(UIViewType uiViewType)
        {
            if (controllers.TryGetValue(uiViewType, out var controller))
                controller.Hide();
            else
                Debug.LogWarning($"No controller for {uiViewType}");
        }

        public void HideAll()
        {
            foreach (var controller in controllers.Values)
            {
                controller.Hide();
            }
        }

        public void Clear()
        {
            if (controllers.Count == 0) return;

            foreach (var controller in controllers.Values)
            {
                if (controller is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }

            controllers.Clear();
            Debug.Log($"Cleared all UI controllers.");
        }
    }
}