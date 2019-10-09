using System;
using MVP.Presentation.Common;

namespace MVP.Presentation.Views
{
    public interface IMainView : IView
    {
        void SetUserInfo(string username, string password);
        event Action ChangeUsername;
    }
}