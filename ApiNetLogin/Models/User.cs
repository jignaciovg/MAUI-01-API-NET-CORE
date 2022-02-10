namespace ApiNetLogin.Models
{
    public class User : UserMin
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class UserMin
    {
        public string Nick { get; set; }
        public string Password { get; set; }

    }
}
