namespace RoundsTextAdventure
{
    public interface IView
    {
        bool IsVisible { get; }
        void Show();
        void Hide();
    }
}
