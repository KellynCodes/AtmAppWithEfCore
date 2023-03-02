using AtmBLL.Interfaces;
using AtmBLL.Utilities;

namespace AtmBLL.Implementation
{
    public class ContinueOrEndProcess : IContinueOrEndProcess
    {
        private readonly IAuthService authService = new AuthService();


        public async Task EndProcess()
        {
            Console.WriteLine("Please wait.");
            await Task.Delay(2000);
            Console.WriteLine($"Collect your Card. Thank you for using {GetAtmData.GetData.Name}");
        }

        public async Task ContinueProcess()
        {
            await authService.Login();
        }

        public async Task Answer()
        {
             IMessage message = new Message();
        Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        question: message.Alert("Would like to End or Continue transactions. Enter [YES/NO]");
            string answer = Console.ReadLine() ?? string.Empty;
            if (answer.Trim().ToUpper() == "YES")
            {
                 await EndProcess();
            }else if(answer.Trim().ToUpper() == "NO")
            {
               await MainMethod.GetUserChoice();
            }
            else
            {
                message.Error("Please enter yes or no for us to be sure you wanted to close the application.");
                goto question;
            }
        }
    }
}
