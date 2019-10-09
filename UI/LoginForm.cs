using System;
using System.Windows.Forms;
using MVP.Presentation.Views;

namespace MVP.UI
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly ApplicationContext _context;
        public LoginForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            btnLogin.Click += (sender, args) => Invoke(Login);
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public string Username { get { return txtUsername.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public event Action Login;
        

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
