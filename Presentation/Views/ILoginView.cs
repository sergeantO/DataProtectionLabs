using System;
using MVP.Presentation.Common;

namespace MVP.Presentation.Views
{
    // контракт, по которому представитель будет взаимодействовать с формой
    public interface ILoginView : IView
    {
        string Username { get; }
        string Password { get; }
        event Action Login; // событие "пользователь пытается авторизоваться"
    }
}