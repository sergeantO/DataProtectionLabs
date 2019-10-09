using System;
using MVP.Presentation.Common;

namespace MVP.Presentation.Views
{
    public interface IChangeUsernameView : IView
    {
        string Username { get; }

        event Action Save;
    }
}