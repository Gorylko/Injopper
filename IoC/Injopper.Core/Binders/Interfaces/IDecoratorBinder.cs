namespace Injopper.Core.Binders.Interfaces
{
    public interface IDecoratorBinder<T> : IDependencyBinder<T>
    {
        void Decorate<TDecorator>();
    }
}
