using System;
using System.Collections.Generic;

using Injopper.Core.Entities;

namespace Injopper.Core.Registrations.Interfaces
{
    public interface IJopRegistry
    {
        IDictionary<Type, RegisteredType> GetRegistrations();
    }
}
