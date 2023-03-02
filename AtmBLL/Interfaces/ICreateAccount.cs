using AtmDAL.Enums;

namespace AtmBLL.Interfaces
{
    public interface ICreateAccount
    {
        string GetFullName();
        string UserName();
        string PhoneNumber();
        string GetEmail();
        string AccountNumber();
        AccountType GetAccountType();
        string GetPassword();
        string ConfirmPassword();
        string GetPin();
    }
}
