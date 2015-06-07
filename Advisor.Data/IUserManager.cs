using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public interface IUserManager
    {
        //регистрация
        User Register(string login, string password, string name, string sirname, string email, string info);

        //удостоверение личности
        User Verify(string login, string password);

        //получить пользователя по Id
        User Get(int id); 
        User Get(string login);

        User ChangeData(int id, string newName, string newSirname, string newEmail, string newInfo);
        
        User ChangeLogin(int id, string newLogin);
        
        User ChangePassword(int id, string oldPassword, string newPassword);
    }
}
