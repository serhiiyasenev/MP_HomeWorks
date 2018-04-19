using System.Linq;

namespace StringComparisonMethod
{
    public class StringHelper
    {
        public static string CompareVersions(string string1, string string2)
        {
            string relation;
            var result = Compare(string1, string2);

            if (result > 0)
                relation = "comes after";
            else if (result == 0)
                relation = "is the same as";
            else if (result < 0)
                relation = "comes before";
            else
                relation = "does not determine the order with";

            var order = "'" + string1 + "'" + " " + relation + " " + "'" + string2 + "'.";
            return order;
        }
        public static int Compare(string string1, string string2)
        {
            int result = 0;
            if (string1 == string2)
            {
                result = 0;
            }
            var string1Parts = string1.Split('.');
            var string2Parts = string2.Split('.');
            var length = new[] { string1Parts.Length, string2Parts.Length }.Max();
            for (var i = 0; i < length; i++)
            {
                if (!int.TryParse(string1Parts.ElementAtOrDefault(i), out int string1AsInt))
                {
                    string1AsInt = 0;
                }
                if (!int.TryParse(string2Parts.ElementAtOrDefault(i), out int string2AsInt))
                {
                    string2AsInt = 0;
                }

                if (string1AsInt > string2AsInt)
                {
                    result = 1;
                    break;
                }
                if (string2AsInt > string1AsInt)
                {
                    result = -1;
                    break;
                }
            }
            return result;
        }
    }
}