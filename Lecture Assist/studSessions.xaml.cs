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
    public sealed partial class studSessions : Page
    {
        public studSessions()
        {
            this.InitializeComponent();
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*if (!String.IsNullOrEmpty(App.CurrentSession) && !String.IsNullOrEmpty(App.CurrentSessionPass))
            {
                try { this.Frame.Navigate(typeof(studCurrentSession)); }
                catch (NullReferenceException ex)
                { }

            }*/
        }

        private async void JoinSession_Button_Click(object sender, RoutedEventArgs e)
        {
            errorMsg.Text = "";
            string session_password = passInput.Password;
            string session_id = sessionidInput.Text;


            List<sessions> allsessions = await App.MobileService.GetTable<sessions>().ToListAsync();
            foreach (sessions s in allsessions)
            {
                if (s.sessionname == session_id)
                {

                    if (s.password == session_password)
                    {
                        errorMsg.Text = "Verified";
                        App.CurrentSession = session_id;
                        App.CurrentSessionPass = session_password;
                        Frame.Navigate(typeof(studCurrentSession));
                    }
                    else
                    {
                        errorMsg.Text = "Invalid Username and (or) Password";
                    }
                }
            }
        }
    }
}
