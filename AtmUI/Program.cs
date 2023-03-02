using AtmBLL.Implementation;
using AtmBLL.Interfaces;
using AtmBLL.Utilities;

namespace AtmUI
{
    internal class Program
    {
        private static readonly IAtmService atmService = new AtmService();
        static async Task Main()
        {
            await atmService.Start();
            await MainMethod.GetUserChoice();
        }
    }
}