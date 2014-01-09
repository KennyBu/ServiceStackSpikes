using System;

namespace OrmLiteConsole
{
    public static class StringExtensions
    {
        public static Guid ToGuid(this String input)
        {
            Guid guidValue;
            Guid.TryParse(input, out guidValue);
            return guidValue;
        }

        public static string SearchExpressionToSql(this String input)
        {
            var result = input.Replace("*", "%");
            result += "%";

            result = result.RemoveDuplicates("%");

            return result;
        } 

        public static string RemoveDuplicates(this String input, string stringToRemoveDuplicates)
        {
            var search = string.Concat(stringToRemoveDuplicates, stringToRemoveDuplicates);
            
            if (input.IndexOf(search, StringComparison.Ordinal) > 0)
            {
                input = input.Replace(search, stringToRemoveDuplicates);
                return input.RemoveDuplicates(stringToRemoveDuplicates);
            }

            return input;
        }
    }
}