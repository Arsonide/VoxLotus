using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace VoxLotus
{
    public static class Utilities
    {
        private static readonly TextInfo textInfo;
        private static readonly PluralizationService pluralizer;

        static Utilities()
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            textInfo = cultureInfo.TextInfo;
            pluralizer = PluralizationService.CreateService(cultureInfo);
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
    }
}
