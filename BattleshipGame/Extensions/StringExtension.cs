using System;
namespace BattleshipGame.Extensions
{
    public static class StringExtension
    {
        public static int ToInt(this string stringInt)
        {
            var isParsable = Int32.TryParse(stringInt, out int number);
            if (isParsable)
                return number;
            throw new Exception($"{stringInt} can't be converted to Int");
        }
    }
}
