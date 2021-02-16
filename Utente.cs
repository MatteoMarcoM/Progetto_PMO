namespace PasswordManager
{
    public class Utente
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Utente(string user, string password)
        {
            UserName = user;
            Password = password;
        }
    }
}
