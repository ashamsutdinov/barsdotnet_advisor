using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public interface IUserManager
    {
        User Register(string login, string password);

        User Verify(string login, string password);

        User GetById(int id);
    }
}
