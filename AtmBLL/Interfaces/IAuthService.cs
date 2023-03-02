using System;
using System.Threading.Tasks;

namespace AtmBLL.Interfaces
{
    public interface IAuthService
    {
        Task Login();

        Task ResetPin();

        Task LogOut();
    }
}
