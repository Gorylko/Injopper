using System;
using System.Collections.Generic;

namespace Injopper.Core.Entities
{
    public class DependencyContext
    {
        public IDictionary<Type, RegisteredType> DictionaryForBindDependency { get; }

        public IDictionary<Type, RegisteredType> DictionaryForBindDecorator { get; }

        public DependencyContext()
        {
            DictionaryForBindDependency = new Dictionary<Type, RegisteredType>();
            DictionaryForBindDecorator = new Dictionary<Type, RegisteredType>();
        }
    }
}
