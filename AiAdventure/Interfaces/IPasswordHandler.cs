namespace AiAdventure.Interfaces
{
    public interface IPasswordHandler
    {
        string Encrypt(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
