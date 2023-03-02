using AtmDAL.Models;

namespace AtmBLL.Interfaces
{
    public interface ICrudOperation : IDisposable
    {
            Task CreateUser(User user);

            Task<long> UpdateUser(int userId, User user);

            Task DeleteUser(int UserId);

            Task<User> GetUser(int id);

            Task<IEnumerable<User>> GetUsers();
    }
}
