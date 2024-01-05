namespace Dotnet_Interview.Refactoring
{
    internal static class DateHelpers
    {

        public static string Format(this DateTime time)
        {
            return time.ToString("ddd MMM dd HH:mm tt");
        }
    }
}