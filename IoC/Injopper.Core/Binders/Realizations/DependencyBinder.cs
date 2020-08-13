using System;
using System.Collections.Generic;
using Injopper.Core.Binders.Interfaces;
using Injopper.Core.Entities;

namespace Injopper.Core.Binders.Realizations
{
    public class DependencyBinder<T> : IDependencyBinder<T>
    {
        private readonly IDictionary<Type, RegisteredType> _dictionaryForBind;

        public DependencyBinder(IDictionary<Type, RegisteredType> dictionaryForBind)
        {
            this._dictionaryForBind = dictionaryForBind;
        }

        protected void RegisterDependency<TRealization>(bool isSingleton)
        {
            if (_dictionaryForBind.ContainsKey(typeof(T)))
            {
                _dictionaryForBind.Remove(typeof(T));
            }

            _dictionaryForBind.Add(typeof(T), new RegisteredType(typeof(TRealization), isSingleton));
        }
    }
}
