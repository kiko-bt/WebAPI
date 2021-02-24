using NoteApp.Models;

namespace NoteApp.Services
{
    public interface IUserService
    {
        void Register(RegisterModel model);
        UserModel Authenticate(string username, string password);
    }
}
