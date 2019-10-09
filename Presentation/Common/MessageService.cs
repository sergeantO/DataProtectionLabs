using System.Windows.Forms;

namespace MVP.Presentation.Common
{
    public interface IMessageService
    {
        void ShowMessage(string text);
        void ShowExclamation(string text);
        void ShowError(string text);
    }

    public class MessageService : IMessageService
    {
        public void ShowMessage(string text)
        {
            MessageBox.Show(text, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowExclamation(string text)
        {
            MessageBox.Show(text, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
