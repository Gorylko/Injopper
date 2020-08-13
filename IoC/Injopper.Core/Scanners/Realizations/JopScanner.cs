using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Injopper.Core.Entities;
using Injopper.Core.Scanners.Interfaces;

using MoreLinq;

namespace Injopper.Core.Scanners.Realizations
{
    public class JopScanner : IJopScanner
    {
        private readonly IEnumerable<string> _assembliesForScanning;

        public JopScanner() : this(default)
        {
        }

        public JopScanner(IEnumerable<string> assembliesForScanning)
        {
            _assembliesForScanning = assembliesForScanning;
        }

        public RegisteredType ScanType<T>()
        {
            return this.ScanType(typeof(T));
        }

        public RegisteredType ScanType(Type type)
        {
            var foundType = (_assembliesForScanning == null
                ? AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                : _assembliesForScanning.SelectMany(assembly => Assembly.Load(assembly).GetTypes()))
                    .First(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            return new RegisteredType(foundType, false);
        }
    }
}
