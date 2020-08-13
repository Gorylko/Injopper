using System;
using System.Collections.Generic;
using Injopper.Core.Entities;
using Injopper.Core.Registrations.Interfaces;

namespace Injopper.Data
{
    public class DataRegistry : IJopRegistry
    {
        public IDictionary<Type, RegisteredType> GetRegistrations()
        {
            return new Dictionary<Type, RegisteredType>
            {
                { typeof(IDataContext),  new RegisteredType(typeof(UserContext), false) },
            };
        }
    }
}
