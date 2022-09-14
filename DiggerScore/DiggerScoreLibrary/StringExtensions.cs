namespace Validation
{
    public static class StringExtensions
    {
        public static string ToHiddenString(this string _) =>
            _[0]+string.Concat(Enumerable.Repeat("*", _.Length-2))+_[_.Length-1];

        public static string WithCurrentThreadId(this string _) =>
            _+$" << Tread is [ {Environment.CurrentManagedThreadId} ] >>";
    }
}