using Injopper.Data;

namespace Injopper.Business
{
    public class UserService : IService
    {
        private IDataContext _dataContext;

        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string GetUserName()
        {
            return _dataContext.GetUser().Name;
        }
    }
}
