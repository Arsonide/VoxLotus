using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VoxLotus
{
    public static class Utilities
    {
        private static readonly TextInfo textInfo;
        private static readonly PluralizationService pluralizer;

        public static readonly string DirectoryLocation;
        public static readonly string ErrorLogLocation;
        public static readonly string DebugLogLocation;

        static Utilities()
        {
            // Anything other than English throws off the pluralizer.
            CultureInfo cultureInfo = new CultureInfo("en-US");
            textInfo = cultureInfo.TextInfo;
            pluralizer = PluralizationService.CreateService(cultureInfo);
            DirectoryLocation = Environment.CurrentDirectory;
            ErrorLogLocation = DirectoryLocation + "\\error.log";
            DebugLogLocation = DirectoryLocation + "\\debug.log";
        }

        public static void DebugLog(string line)
        {
            if (!ConfigurationManager.Instance.Settings.EnableDebugLog)
                return;

            using (StreamWriter writer = new StreamWriter(DebugLogLocation, true))
            {
                writer.WriteLine($"[{DateTime.Now:G}] {line}");
                writer.Close();
            }
        }

        #region Invocations

        public delegate void InvokeDelegate();

        public static void SafeInvoke(this Control control, InvokeDelegate invokeDelegate)
        {
            if (control == null)
                return;

            if (control.InvokeRequired)
                control.Invoke(invokeDelegate);
            else
                invokeDelegate();
        }

        public static T SafeInvoke<T>(this Control control, Func<T> function)
        {
            if (control == null)
                return default(T);

            if (control.InvokeRequired)
                return (T)control.Invoke(function, new object[] { });
            else
                return function();
        }

        #endregion

        #region Pluralization

        public static void AddPluralization(string singular, string plural)
        {
            ICustomPluralizationMapping pluralizerWords = pluralizer as ICustomPluralizationMapping;

            if (pluralizerWords == null)
                return;

            singular = singular.ToLowerInvariant();
            plural = plural.ToLowerInvariant();
            pluralizerWords.AddWord(singular, plural);

            if (textInfo == null)
                return;

            singular = textInfo.ToTitleCase(singular);
            plural = textInfo.ToTitleCase(plural);
            pluralizerWords.AddWord(singular, plural);
        }

        public static string Pluralize(string noun)
        {
            return pluralizer.Pluralize(noun);
        }

        public static string Singularize(string noun)
        {
            return pluralizer.Singularize(noun);
        }

        #endregion

        public static string ItemDescription(string item, string prefix = "a", decimal amount = 1)
        {
            return amount == 1 ? $"{prefix} {Singularize(item)}" : $"{amount:N0} {Pluralize(item)}";
        }

        public static string ReadableTimeSpan(TimeSpan span, bool includeSeconds = true)
        {
            if (!includeSeconds && span.TotalMinutes < 1)
                return "Less than one minute";

            var timeStrings = new List<string>();

            int days = span.Duration().Days;
            int hours = span.Duration().Hours;
            int minutes = span.Duration().Minutes;
            int seconds = span.Duration().Seconds;

            if (days > 0)
                timeStrings.Add($"{days} {(days == 1 ? "Day" : "Days")}");

            if (hours > 0)
                timeStrings.Add($"{hours} {(hours == 1 ? "Hour" : "Hours")}");

            if (minutes > 0)
                timeStrings.Add($"{minutes} {(minutes == 1 ? "Minute" : "Minutes")}");

            if (includeSeconds && seconds > 0)
                timeStrings.Add($"{seconds} {(seconds == 1 ? "Second" : "Seconds")}");

            if (timeStrings.Count <= 0)
                return "Now";

            return string.Join(", ", timeStrings.Take(timeStrings.Count - 1)) + (timeStrings.Count <= 1 ? "" : " and ") + timeStrings.LastOrDefault();
        }

        public static string GuessIndefiniteArticle(string noun)
        {
            // Originally from https://stackoverflow.com/a/8044744
            string word;
            Match m = Regex.Match(noun, @"\w+");

            if (m.Success)
                word = m.Groups[0].Value;
            else
                return "an";

            string wordi = word.ToLower();

            foreach (string anword in new[] { "euler", "heir", "honest", "hono" })
            {
                if (wordi.StartsWith(anword))
                    return "an";
            }

            if (wordi.StartsWith("hour") && !wordi.StartsWith("houri"))
                return "an";

            char[] charList = { 'a', 'e', 'd', 'h', 'i', 'l', 'm', 'n', 'o', 'r', 's', 'x' };

            if (wordi.Length == 1)
                return wordi.IndexOfAny(charList) == 0 ? "an" : "a";

            if (Regex.Match(word, "(?!FJO|[HLMNS]Y.|RY[EO]|SQU|(F[LR]?|[HL]|MN?|N|RH?|S[CHKLMNPTVW]?|X(YL)?)[AEIOU])[FHLMNRSX][A-Z]").Success)
                return "an";

            foreach (string regex in new[] { "^e[uw]", "^onc?e\b", "^uni([^nmd]|mo)", "^u[bcfhjkqrst][aeiou]" })
            {
                if (Regex.IsMatch(wordi, regex))
                    return "a";
            }

            if (Regex.IsMatch(word, "^U[NK][AIEO]"))
                return "a";

            if (word == word.ToUpper())
                return wordi.IndexOfAny(charList) == 0 ? "an" : "a";

            if (wordi.IndexOfAny(new[] { 'a', 'e', 'i', 'o', 'u' }) == 0)
                return "an";

            if (Regex.IsMatch(wordi, "^y(b[lor]|cl[ea]|fere|gg|p[ios]|rou|tt)"))
                return "an";

            return "a";
        }
    }
}
