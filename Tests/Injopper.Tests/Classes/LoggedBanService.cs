using System.Diagnostics;

namespace Injopper.Tests.Classes
{
    public class LoggedBanService : IBanService
    {
        private IBanService _banService;

        public LoggedBanService(IBanService service)
        {
            _banService = service;
        }

        public void Ban(string playerName)
        {
            _banService.Ban(playerName);

            Debug.WriteLine(playerName);
        }
    }
}
