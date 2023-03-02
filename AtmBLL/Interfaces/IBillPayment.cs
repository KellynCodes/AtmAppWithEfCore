using System.Threading.Tasks;

namespace AtmBLL.Interfaces
{
    public interface IBillPayment
    {
        Task Airtime();
        Task Nepa();
        Task CableTransmission();
    }
}
