using System;

namespace RoundsTextAdventure
{
    public interface IController: IDisposable
    {
        void Init(IView view);
        void Show();
        void Hide();
    }
}
