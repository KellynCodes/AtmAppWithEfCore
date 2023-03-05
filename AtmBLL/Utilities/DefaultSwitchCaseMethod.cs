namespace AtmBLL.Utilities
{
    public class DefaultSwitchCaseMethod
    {
        public static string SwitchCase(int inputCase)
        {
            if (inputCase == 1) return "Gt Bank";
            else
            if (inputCase == 2) return "Access Bank";
            else
            if (inputCase == 3) return "Union Bank";
            else
            if (inputCase == 4) return "Fidelity Bank";
            else
            if (inputCase == 5) return "Eco Bank";
            else
            if (inputCase == 6) return "First Bank";
            return string.Empty;
        }
    }
}
