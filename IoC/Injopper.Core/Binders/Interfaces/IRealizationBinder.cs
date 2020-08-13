namespace Injopper.Core.Binders.Interfaces
{
    public interface IRealizationBinder<T> : IDependencyBinder<T>
    {
        void Register<TRealization>()
            where TRealization : T;

        void RegisterSingleton<TRealization>()
            where TRealization : T;
    }
}
