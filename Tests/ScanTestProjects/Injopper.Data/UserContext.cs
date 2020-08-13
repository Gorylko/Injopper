namespace Injopper.Data
{
    public class UserContext : IDataContext
    {
        public User GetUser()
        {
            return new User()
            {
                Name = "Volodya",
                Gender = "combat helicopter I-20"
            };
        }
    }
}
