namespace MVP.Presentation.Common
{
    /// <summary>
    /// ��������� ����������� ����������
    /// ���������� ��������� ������ ����������
    /// </summary>
    public interface IApplicationController
    {
        /// <summary>
        /// ����������� �������������
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        /// <summary>
        /// ����������� ���������� �������
        /// </summary>
        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        /// <summary>
        /// ����������� �������
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        /// <summary>
        /// ������ ������������������ ��������
        /// </summary>
        /// <typeparam name="TPresenter"></typeparam>
        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        /// <summary>
        /// ������ ������������������ �������� � �����������
        /// </summary>
        /// <typeparam name="TPresenter"></typeparam>
        /// <typeparam name="TArgumnent"></typeparam>
        /// <param name="argumnent"></param>
        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}