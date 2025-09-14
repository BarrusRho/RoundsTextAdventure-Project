using System.Threading;
using UnityEngine;

namespace RoundsTextAdventure
{
    public abstract class UIViewBase : MonoBehaviour, IUIView
    {
        protected bool IsDestroyed { get; private set; }

        private CancellationTokenSource transitionCts;

        private bool _isViewVisible = false;
        public virtual bool IsVisible => _isViewVisible;

        public virtual void Show()
        {
            if (IsVisible)
            {
                Debug.LogWarning($"Show() skipped — already visible: {GetType().Name}");
                return;
            }
            
            Debug.Log($"Show() called — activating GameObject.");

            CancelTransitionIfRunning();
            gameObject.SetActive(true);
            _isViewVisible = true;
            OnShow();
        }

        public virtual void Hide()
        {
            if (!IsVisible)
            {
                Debug.LogWarning($"Hide() skipped — already hidden: {GetType().Name}");
                return;
            }
            
            Debug.Log($"Hide() called — deactivating GameObject.");

            CancelTransitionIfRunning();
            _isViewVisible = false;
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnShow() { }
        protected virtual void OnHide() { }

        protected virtual void OnDestroy()
        {
            Debug.Log($"ViewBase destroyed — cleaning up transitions.");
            CancelTransitionIfRunning();
            IsDestroyed = true;
        }

        private void CancelTransitionIfRunning()
        {
            if (transitionCts != null)
            {
                Debug.Log($"Cancelling in-progress transition.");

                if (!transitionCts.IsCancellationRequested)
                {
                    transitionCts.Cancel();
                }
                
                transitionCts.Dispose();
                transitionCts = null;
            }
        }
    }
}
