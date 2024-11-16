using System.Text.RegularExpressions;

namespace LoginSystemApi.Utils.Validators
{
    public static class CpfValidator
    {
        public static string CleanCpf(string cpf)
        {
            return Regex.Replace(cpf, @"\D", "");
        }

        public static bool IsValid(string cpf)
        {
            if (cpf.Length != 11) return false;

            else return true;
        }

    }
}
