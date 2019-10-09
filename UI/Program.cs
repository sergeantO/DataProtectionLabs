using System.Windows.Forms;
using MVP.DomainModel;
using MVP.Presentation.Common;
using MVP.Presentation.Presenters;
using MVP.Presentation.Views;

namespace MVP.UI
{
    internal static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Регистрация зависимостей приложения
            var controller = new ApplicationController(new LightInjectAdapder())
                // Dependenses registration
                // Views
                .RegisterView<ILoginView, LoginForm>()
                .RegisterView<IMainView, MainForm>()
                .RegisterView<IChangeUsernameView, ChangeUsernameForm>()
                // Servises
                .RegisterService<ILoginService, StupidLoginService>()
                .RegisterService <IMessageService, MessageService>()
                // Instance
                .RegisterInstance(new ApplicationContext());

            // Run App
            controller.Run<LoginPresenter>();
        }
    }
}
