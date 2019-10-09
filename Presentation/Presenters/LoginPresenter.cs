using System;
using MVP.DomainModel;
using MVP.Presentation.Common;
using MVP.Presentation.Views;

namespace MVP.Presentation.Presenters
{
    public class LoginPresenter : BasePresenter<ILoginView>
    {
        private readonly ILoginService _service;
        private readonly IMessageService _messageService;

        public LoginPresenter(IApplicationController controller, ILoginView view, ILoginService service, IMessageService messageService)
            : base(controller, view)
        {
            _service = service;
            _messageService = messageService;
            
            View.Login += () => Login(View.Username, View.Password);
        }

        private void Login(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");

            var user = new User {Name = username, Password = password};
            if (!_service.Login(user))
            {
                _messageService.ShowError("Invalid username or password");
            }
            // успешная авторизация
            else
            {
                Controller.Run<MainPresener, User>(user);
                View.Close();
            }
        }
    }
}