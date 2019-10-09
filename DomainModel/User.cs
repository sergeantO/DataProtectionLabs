namespace MVP.DomainModel
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; } = "";
        public bool Blocked { get; set; } = false;
        public bool Limited { get; set; } = false;
    }
}