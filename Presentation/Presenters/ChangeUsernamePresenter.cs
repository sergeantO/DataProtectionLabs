using System;
using MVP.DomainModel;
using MVP.Presentation.Common;
using MVP.Presentation.Views;

namespace MVP.Presentation.Presenters
{
    public class ChangeUsernamePresenter : BasePresenter<IChangeUsernameView, User>
    {
        private User _user;
        
        public ChangeUsernamePresenter(IApplicationController controller, IChangeUsernameView view) : base(controller, view)
        {
            View.Save += () => ChangeUsername(View.Username);
        }

        private void ChangeUsername(string username)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (username != string.Empty)
            {
                _user.Name = username;
                View.Close();
            }
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Show();
        }
    }
}