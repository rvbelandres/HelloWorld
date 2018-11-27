namespace NumberToWords.Helpers
{
    public static class InputNoStringExt
    {
        public static bool IsNumeric(this string inputNo)
        {
            return double.TryParse(inputNo, out double test);
        }
    }
}
