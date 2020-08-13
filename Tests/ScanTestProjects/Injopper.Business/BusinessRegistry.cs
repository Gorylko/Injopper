using System;
using System.Collections.Generic;

using Injopper.Core.Entities;
using Injopper.Core.Registrations.Interfaces;

namespace Injopper.Business
{
    public class BusinessRegistry : IJopRegistry
    {
        public IDictionary<Type, RegisteredType> GetRegistrations()
        {
            return new Dictionary<Type, RegisteredType>
            {
                { typeof(IService),  new RegisteredType(typeof(UserService), false) },
            };
        }
    }
}
