using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SpectrumSampleApp.Core
{
    public static class Settings
    {
        private const string ApiKey = "d0fd0bb43d480aefb4b8ab2704fa70fd";
        private static string APIKEY => ApiKey;

        private const string LastLoginKey = "LAST_LOGIN";
        private const string DefaultDateTime = "1/1/0001 12:00:00 AM";

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string LastSuccesfulLogin
        {
            get { return AppSettings.GetValueOrDefault(LastLoginKey, DateTime.MinValue.ToString()); }
            set { AppSettings.AddOrUpdateValue(LastLoginKey, value); }
        }
    }
}

