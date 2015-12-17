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
    public sealed partial class signUp : Page
    {
        
        string account_type;

        public signUp()
        {
            this.InitializeComponent();
        }


        private async void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            errorMsg.Text = "";
            string account_name = nameInput.Text, account_username = usernameInput.Text;
            string account_email = emailInput.Text;
            string account_password = passInput.Password;
            string account_cpass = cpassInput.Password;
         
        bool ready = true;
            
            if (account_name == "" || account_email == "" || account_type == "") {
                errorMsg.Text = errorMsg.Text + " Please Fill All Fields.";
                ready = false;
            }
            if (account_cpass != account_password)
            {
                errorMsg.Text = errorMsg.Text + "Passwords Don't Match.";
                ready = false;
            }

            List<users> allusers = await App.MobileService.GetTable<users>().ToListAsync();
            foreach (users u in allusers)
            {

                if (account_username == u.username)
                {
                    errorMsg.Text = errorMsg.Text + "Username already taken Use another username";
                    ready = false;
                }

            }
            if (ready) {

                users u1 = new users {name=account_name,email=account_email,password=account_password,type=account_type,username=account_username};
                await App.MobileService.GetTable<users>().InsertAsync(u1);

                Frame.Navigate(typeof(MainWelcomePage));
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)studRadio.IsChecked) {
                account_type = "Student";
            }
            if ((bool)profRadio.IsChecked)
            {
                account_type = "Professor";
            }
        }

    }
}
