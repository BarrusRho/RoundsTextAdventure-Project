namespace RoundsTextAdventure
{
    public abstract class UIControllerBase<TView> : IUIController where TView : UIViewBase
    {
        protected TView View;

        public void Init(IView view)
        {
            View = (TView)view;
            OnInit();
        }

        protected abstract void OnInit();

        public virtual void Dispose() => OnDispose();
        protected virtual void OnDispose() { }
        public virtual void Show() => View.Show();
        public virtual void Hide() => View.Hide();
    }
}
