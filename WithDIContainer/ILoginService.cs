namespace DependencyInversionPrincipleDemo
{
    public interface ILoginService
    {
        bool ValidateUser(string userName, string passWord);
    }
}