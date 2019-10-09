namespace MVP.DomainModel
{
    public class StupidLoginService : ILoginService
    {
        public bool Login(User user)
        {
            return !string.IsNullOrEmpty(user.Name);
        }
    }
}