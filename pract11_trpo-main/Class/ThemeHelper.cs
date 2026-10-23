using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace pract9_trpo.Class
{

    public static class ThemeHelper
    {
        private static readonly string[] _themePaths =
         {
            "pack://application:,,,/Styles/Colors/DefaultColors.xaml",
            "pack://application:,,,/Styles/Colors/DarkTheme.xaml"
        };

        public static string CurrentTheme
        {
            get => Properties.Settings.Default.ThemePath == ""
                ? _themePaths[0] : Properties.Settings.Default.ThemePath;
      
            set
            {
                Properties.Settings.Default.ThemePath = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void ApplyTheme(string themePath)
        {
          
                var newTheme = new ResourceDictionary
                {
                    Source = new Uri(themePath, UriKind.Absolute)
                };
                var oldTheme = Application.Current.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source != null &&
                                        (d.Source.OriginalString.Contains("DefaultColors.xaml") ||
                                         d.Source.OriginalString.Contains("DarkTheme.xaml")));

            if (oldTheme != null)
            {
                int index = Application.Current.Resources.MergedDictionaries.IndexOf(oldTheme);
                Application.Current.Resources.MergedDictionaries[index] = newTheme;
                CurrentTheme = themePath;
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(newTheme);
            }
            CurrentTheme = themePath;
           
        }

        public static void ApplySavedTheme()
        {
           var theme = CurrentTheme;
            ApplyTheme(theme);
        }

        public static void ToggleSvet()
        {
            var newTheme = CurrentTheme == _themePaths[0]
            ? _themePaths[0]
            : _themePaths[0];
            ApplyTheme(newTheme);
        }

        public static void ToggleTemn()
        {
            var newTheme = CurrentTheme == _themePaths[1]
            ? _themePaths[1]
            : _themePaths[1];
            ApplyTheme(newTheme);
        }
    }

}
