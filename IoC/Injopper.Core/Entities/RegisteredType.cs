using System;
using System.Linq;

namespace Injopper.Core.Entities
{
    public class RegisteredType
    {
        private readonly bool _isSinglton;

        public RegisteredType(Type concreteType, bool isSingleton)
        {
            _isSinglton = isSingleton;

            ConcreteType = concreteType;
        }

        public Type ConcreteType { get; private set; }

        public object SingletonInstance { get; private set; }

        public object CreateInstance(object[] args)
        {
            var instance = args.Any()
                ? Activator.CreateInstance(ConcreteType, args)
                : Activator.CreateInstance(ConcreteType);

            if (_isSinglton)
            {
                SingletonInstance = instance;
            }

            return instance;
        }
    }
}
