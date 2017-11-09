using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Client
{
    class Parser
    {
        public static bool IsUsersList(string message, out List<string> list)
        {
            list = null;

            string temp = message;
            Regex regex = new Regex("[0-2][0-9]:[0-6][0-9] ");
            MatchCollection matches = regex.Matches(temp);
            if (matches.Count == 0)
            {
                string[] substrings = temp.Split(';');
                list = substrings.ToList();
                return true;
            }
            return false;
        }

        public static bool IsImage(string message, out string img)
        {
            img = null;
            string temp = message;
            if (temp.Trim(new char[] { '#', '&' }).Length - temp.Length == 4)
            {
                img = temp.Trim(new char[] { '#', '&' });
                return true;
            }
            return false;
        }
    }
}
