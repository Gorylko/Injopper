using System;
using System.Collections.Generic;
using System.Linq;
using Injopper.Core.Binders.Interfaces;
using Injopper.Core.Binders.Realizations;
using Injopper.Core.Entities;
using Injopper.Core.Scanners.Interfaces;
using Injopper.Core.Scanners.Realizations;

namespace Injopper.Core
{
    public class Jopper
    {
        private readonly IJopScanner _scanner;
        private readonly DependencyContext _dependencyContext;

        public Jopper() : this(new JopScanner())
        {
        }

        public Jopper(IJopScanner scanner)
        {
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
            _dependencyContext = new DependencyContext();
        }

        public IComplexBinder<T> For<T>()
        {
            return new ComplexBinder<T>(_dependencyContext);
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return _dependencyContext.DictionaryForBindDecorator.ContainsKey(typeof(TTypeToResolve))
                ? (TTypeToResolve) ResolveDecorator(typeof(TTypeToResolve))
                : (TTypeToResolve) ResolveObject(typeof(TTypeToResolve));
        }

        private object ResolveObject(Type type)
        {
            var registeredObj = _dependencyContext.DictionaryForBindDependency.ContainsKey(type)
                ? _dependencyContext.DictionaryForBindDependency[type]
                : _scanner.ScanType(type);

            var instance = CreateInstance(registeredObj);

            return instance;
        }

        private object ResolveDecorator(Type type)
        {
            var registeredObj = _dependencyContext.DictionaryForBindDecorator[type] ?? throw new ArgumentOutOfRangeException($"The type {type.Name} has not been registered");

            return CreateInstance(registeredObj);
        }

        private object CreateInstance(RegisteredType registeredObj)
        {
            return registeredObj.SingletonInstance ?? registeredObj.CreateInstance(ResolveConstructorParameters(registeredObj));
        }

        private object[] ResolveConstructorParameters(RegisteredType registeredObj)
        {
            var constructorInfo = registeredObj.ConcreteType.GetConstructors().First();

            return constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType)).ToArray();
        }
    }
}
