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
    public sealed partial class userSettings : Page
    {
        public userSettings()
        {
            this.InitializeComponent();
        }

        

        private async void ChangePass_Button_Click(object sender, RoutedEventArgs e)
        {

            errorMsg.Text = "";

            bool ready = true;

            string account_cpass = cpassInput.Password;
            string account_oldpass = oldpassInput.Password;
            string account_newpass = passInput.Password;


            List<users> allusers = await App.MobileService.GetTable<users>().ToListAsync();
            foreach (users u in allusers)
            {
                if (App.CurrentUser == u.username && account_oldpass != u.password)
                {
                    errorMsg.Text = errorMsg.Text + "Wrong Password";
                    ready = false;
                }
            }

            if (account_cpass != account_newpass)
            {
                errorMsg.Text = errorMsg.Text + "Passwords Don't Match.";
                ready = false;
            }

            if (ready)
            {
                //Modify Password
                Frame.Navigate(typeof(MainWelcomePage));
            }
        }
    }
}
