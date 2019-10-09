namespace MVP.Presentation.Common
{
    /// <summary>
    /// Интерфейс контроллера приложения
    /// интерфейсу получиает объект реализации
    /// </summary>
    public interface IApplicationController
    {
        /// <summary>
        /// Регистрация представления
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        /// <summary>
        /// регистрация экземпляра объекта
        /// </summary>
        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        /// <summary>
        /// регистрация сервиса
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <returns></returns>
        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        /// <summary>
        /// Запуск зарегистрированной сущности
        /// </summary>
        /// <typeparam name="TPresenter"></typeparam>
        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        /// <summary>
        /// Запуск зарегистрированной сущности с парамметром
        /// </summary>
        /// <typeparam name="TPresenter"></typeparam>
        /// <typeparam name="TArgumnent"></typeparam>
        /// <param name="argumnent"></param>
        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}