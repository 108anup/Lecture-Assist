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
    public sealed partial class MainWelcomePage : Page
    {
        public MainWelcomePage()
        {
            this.InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(signUp));
        }

        private async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            
            string Input_UserName = usernameInput.Text;
            string Input_Password = Passwordinput.Password;
            List<users> allusers = await App.MobileService.GetTable<users>().ToListAsync();
            bool ready = false;

            foreach (users u in allusers)
            {

                if (u.username == Input_UserName)
                {

                    if (u.password == Input_Password)
                    {
                        ready = true;
                        errMsg.Text += "Verified";

                        if (u.type == "Student")
                        {
                            App.CurrentUser = u.username;
                            errMsg.Text += "User Set";
                            Frame.Navigate(typeof(studFeed));
                        }
                        if (u.type == "Professor")
                        {
                            App.CurrentUser = u.username;
                            errMsg.Text += "User Set";
                            Frame.Navigate(typeof(profWelcomePage));
                        }
                    }
                    else
                    {
                        errMsg.Text += "Invalid Username and (or) Password";
                    }
                }
            }
        }         
    }
}