using System.Threading.Tasks;

namespace AtmBLL.Interfaces
{
    public interface IContinueOrEndProcess
    {
        Task EndProcess();
        Task ContinueProcess();
        Task Answer();
    }
}
