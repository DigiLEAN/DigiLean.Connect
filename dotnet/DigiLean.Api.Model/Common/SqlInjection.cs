using TimeZoneConverter;

namespace DigiLean.Api.Model.Common
{
    public class SqlInjection
    {
        public static bool CheckForSQLInjection(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput)) return false;
            if (IsIanaTimeZoneFormat(userInput))
            {
                try
                {
                    // If input is valid timezone, skip rest of check
                    var tz = TZConvert.IanaToWindows(userInput);
                    return false;
                }
                catch (Exception) { }
            }
            // Now to sqlcheck
            bool isSQLInjection = false;
            string[] sqlCheckList = { "--",
                                       ";--",
                                       ";",
                                       "/*",
                                       "*/",
                                        "@@",
                                        "@",
                                        "char",
                                       "nchar",
                                       "varchar",
                                       "nvarchar",
                                       "alter",
                                       "begin",
                                       "cast",
                                       "create ",
                                       "cursor",
                                       "declare",
                                       "delete",
                                       "drop",
                                       "end",
                                       "exec",
                                       "execute",
                                       "fetch",
                                       "insert",
                                       "kill",
                                       "select",
                                       "sys",
                                       "sysobjects",
                                       "syscolumns",
                                       "table",
                                       "update"
                                    };

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if (CheckString.IndexOf(";" + sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0)
                    isSQLInjection = true;

                if (CheckString.IndexOf(" " + sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0)
                    isSQLInjection = true;

            }

            return isSQLInjection;
        }

        private static bool IsIanaTimeZoneFormat(string input)
        {
            var format = input.Split("/"); // => Europe/Bucharesst => [Europe, Bucharest]
            return format.Length == 2;
        }
    }
}

