using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal static class LanguageHelper
    {
        public static void ApplyCulture(string cultureCode, Control rootControl, Type resourceType)
        {
            if (string.IsNullOrWhiteSpace(cultureCode))
                throw new ArgumentException("Language code must not be null or empty.", nameof(cultureCode));

            var culture = new CultureInfo(cultureCode);

            // Apply culture to the current thread
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // Load resources
            var resources = new ComponentResourceManager(resourceType);

            // Recursively update all controls
            UpdateControlTexts(rootControl, resources, culture);
        }

        private static void UpdateControlTexts(Control control, ComponentResourceManager resources, CultureInfo culture)
        {
            resources.ApplyResources(control, control.Name, culture);

            foreach (Control child in control.Controls)
            {
                UpdateControlTexts(child, resources, culture);
            }
        }
    }
}
