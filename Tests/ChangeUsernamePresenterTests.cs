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
    public class ChangeUsernamePresenterTests
    {
        private IApplicationController _controller;
        private IChangeUsernameView _view;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>();
            _user = new User { Name = "admin", Password = "password" };
            _view = Substitute.For<IChangeUsernameView>();
            var presenter = new ChangeUsernamePresenter(_controller, _view);
            presenter.Run(_user);
        }
        
        [Test]
        public void InvalidUsername()
        {
            _view.Username.Returns("");
            _view.Save += Raise.Event<Action>();
            Assert.AreEqual(_user.Name, "admin");
            _view.DidNotReceive().Close();
        }

        [Test]
        public void ValidUsername()
        {
            _view.Username.Returns("username");
            _view.Save += Raise.Event<Action>();
            Assert.AreEqual(_user.Name, "username");
            _view.Received().Close();
        }
    }
}