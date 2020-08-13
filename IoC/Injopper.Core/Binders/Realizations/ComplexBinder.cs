using System;

using Injopper.Core.Binders.Interfaces;
using Injopper.Core.Entities;

namespace Injopper.Core.Binders.Realizations
{
    public class ComplexBinder<T> : IComplexBinder<T>
    {
        private readonly DependencyContext _dependencyContext;

        public ComplexBinder(DependencyContext context)
        {
            _dependencyContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Decorate<TDecorator>()
        {
            new DecoratorBinder<T>(_dependencyContext.DictionaryForBindDecorator).Decorate<TDecorator>();
        }

        public void Register<TRealization>() where TRealization : T
        {
            new RealizationBinder<T>(_dependencyContext.DictionaryForBindDependency).Register<TRealization>();
        }

        public void RegisterSingleton<TRealization>() where TRealization : T
        {
            new RealizationBinder<T>(_dependencyContext.DictionaryForBindDependency).RegisterSingleton<TRealization>();
        }
    }
}
