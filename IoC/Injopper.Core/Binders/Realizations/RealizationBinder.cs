using System;
using System.Collections;
using System.Collections.Generic;
using Injopper.Core.Binders.Interfaces;
using Injopper.Core.Entities;

namespace Injopper.Core.Binders.Realizations
{
    public class RealizationBinder<T> : DependencyBinder<T>, IRealizationBinder<T>
    {
        public RealizationBinder(IDictionary<Type, RegisteredType> dictionaryForBind) : base(dictionaryForBind)
        {
        }

        public void Register<TRealization>() where TRealization : T
        {
            RegisterDependency<TRealization>(false);
        }

        public void RegisterSingleton<TRealization>() where TRealization : T
        {
            RegisterDependency<TRealization>(true);
        }
    }
}
