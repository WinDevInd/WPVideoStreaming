using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WooqerTest.Shared
{
    public class BasePage : Page
    {
        public static readonly DependencyProperty SupportedOrientationsProperty =
        DependencyProperty.RegisterAttached("SupportedOrientations", typeof(string), typeof(BasePage), new PropertyMetadata("Portrait", OnSupportedOrientationsChanged));

        public static void SetSupportedOrientations(UIElement element, object value)
        {
            element.SetValue(SupportedOrientationsProperty, value);
        }

        public static object GetSupportedOrientations(UIElement element)
        {
            return element.GetValue(SupportedOrientationsProperty);
        }

        private static void OnSupportedOrientationsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            DisplayOrientations supportedOrientations = (DisplayOrientations)Enum.Parse(typeof(DisplayOrientations), (string)args.NewValue);

            DisplayInformation.AutoRotationPreferences = supportedOrientations;
        }
    }
}
