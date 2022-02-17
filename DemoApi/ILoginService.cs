namespace DependencyInversionPrincipleDemo
{
    public interface ILoginService
    {
        string ValidateUser(string userName, string passWord);
    }
}