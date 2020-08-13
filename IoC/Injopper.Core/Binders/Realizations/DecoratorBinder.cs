using System;
using System.Collections.Generic;
using Injopper.Core.Binders.Interfaces;
using Injopper.Core.Entities;

namespace Injopper.Core.Binders.Realizations
{
    public class DecoratorBinder<T> : DependencyBinder<T>, IDecoratorBinder<T>
    {
        public DecoratorBinder(IDictionary<Type, RegisteredType> dictionaryForBind) : base(dictionaryForBind)
        {
        }

        public void Decorate<TDecorator>()
        {
            RegisterDependency<TDecorator>(false);
        }
    }
}
