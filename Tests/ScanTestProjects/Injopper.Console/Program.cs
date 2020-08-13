using System;
using System.Diagnostics;

using Injopper.Business;
using Injopper.Core;
using Injopper.Core.Scanners.Realizations;

namespace Injopper.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var jopper = new Jopper();

            var userService = jopper.Resolve<IService>();

            var name = userService.GetUserName();
        }
    }
}
