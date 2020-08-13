using System;
using Injopper.Core.Entities;

namespace Injopper.Core.Scanners.Interfaces
{
    public interface IJopScanner
    {
        RegisteredType ScanType<T>();

        RegisteredType ScanType(Type type);
    }
}
