using TodoApi.Models;

namespace TodoApi.Helpers
{
    public static class ValidationHelper
    {
        public static string CheckPostContent(this TodoItem item)
        {
            string result = null;

            if (item == null)
            {
                result = "Item that you Posted is null!";
            }

            return result;
        }
    }
}