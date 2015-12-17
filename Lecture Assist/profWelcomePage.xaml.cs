using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lecture_Assist
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class profWelcomePage : Page
    {
        public profWelcomePage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(profSessions));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (settings.IsSelected)
                MyFrame.Navigate(typeof(userSettings));
            if (sessions.IsSelected)
                MyFrame.Navigate(typeof(profSessions));
            if (LogOut.IsSelected)
            {
                App.CurrentSession = "";
                App.CurrentUser = "";
                App.CurrentSessionPass = "";
                Frame.Navigate(typeof(MainWelcomePage));
            }

        }
    }

    
}
