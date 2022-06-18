﻿using Microsoft.Win32;
using System.IO;
using System.Reflection;

namespace DivaModManager
{
    public static class RegistryConfig
    {
        public static bool InstallGBHandler()
        {
            string AppPath = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".exe");
            string protocolName = $"dmm";
            try
            {
                var reg = Registry.CurrentUser.CreateSubKey(@"Software\Classes\DivaModManager");
                reg.SetValue("", $"URL:{protocolName}");
                reg.SetValue("URL Protocol", "");
                reg = reg.CreateSubKey(@"shell\open\command");
                reg.SetValue("", $"\"{AppPath}\" -download \"%1\"");
                reg.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
