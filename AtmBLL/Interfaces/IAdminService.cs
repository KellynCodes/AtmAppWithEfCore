using AtmDAL.Models;
using System.Threading.Tasks;

namespace AtmBLL.Interfaces
{
    public interface IAdminService
    {
       Task LoginAdmin();
       Task ReloadCash();
       Task SetCashLimit();
    }
}
