using System;
using MVP.DomainModel;
using MVP.Presentation.Common;
using MVP.Presentation.Presenters;
using MVP.Presentation.Views;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LoginPresenterTests
    {
        private IApplicationController _controller;
        private ILoginView _view;
        private IMessageService _messageService;
        
        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>(); 
            _view = Substitute.For<ILoginView>(); // заглушка для представления
            _messageService = Substitute.For<IMessageService>();
            var service = Substitute.For<ILoginService>(); // заглушка для сервиса

            // авторизуется только пользователь admin/password
            service.Login(Arg.Any<User>())
                .Returns(info => info.Arg<User>().Name == "admin" && info.Arg<User>().Password == "password");
            var presenter = new LoginPresenter(_controller, _view, service, _messageService);

            presenter.Run();
        }
        
        [Test]
        public void InvalidUser()
        {
            _view.Username.Returns("Vladimir");
            _view.Password.Returns("VladimirPass");
            _view.Login += Raise.Event<Action>();
            _messageService.Received().ShowError(Arg.Any<string>()); // этот метод должен вызваться с текстом ошибки
            _controller.DidNotReceive().Run<MainPresener, User>(Arg.Any<User>());
        }

        [Test]
        public void ValidUser()
        {
            _view.Username.Returns("admin");
            _view.Password.Returns("password");
            _view.Login += Raise.Event<Action>();
            _messageService.DidNotReceive().ShowError(Arg.Any<string>()); // а в этом случае все ОК
            _controller.Received().Run<MainPresener, User>(Arg.Is<User>(user => user.Name == "admin" && user.Password == "password"));
        }
    }
}