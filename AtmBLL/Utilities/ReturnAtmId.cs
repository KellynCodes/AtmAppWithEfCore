using AtmBLL.Implementation;
using AtmBLL.Interfaces;

namespace AtmBLL.Utilities
{
    public class ReturnAtmId
    {
    private readonly static IMessage message = new Message();
        public static int Id()
        {
            ChooseAtm: message.AlertInfo("Choose atm to operate.");
            if (!int.TryParse(Console.ReadLine(), out int ID))
            {
                message.Error("Input is not valid. Enter only numbers.");
                goto ChooseAtm;
            }
            return ID;
        }
    }
}
