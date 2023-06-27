namespace AiAdventure.Interfaces
{
    public interface IPasswordService
    {
        string Encrypt(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
