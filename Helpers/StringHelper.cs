
namespace Helpers
{
    public static class StringExtensions
    {
        public static string Prefix(this string value, int length, int numberToRemove)
        {
            if (value.Length > length)
                {
                    return value;
            }

            return value.Substring(0, length - numberToRemove);
        }
    }

}