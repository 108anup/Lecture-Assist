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
    public sealed partial class studCurrentSession : Page
    {
        private async void LoadComments()
        {
            List<comments> allcomments = await App.MobileService.GetTable<comments>().ToListAsync();

            int numComments = 0;
            foreach (comments c in allcomments)
            {
                if (c.sessionid == App.CurrentSession)
                    numComments++;
            }

            int loadedcomments = 0;
            foreach (comments c in allcomments)
            {
                if (loadedcomments <= 10)
                {
                    if (c.sessionid == App.CurrentSession)
                    {
                        StackPanel c0 = new StackPanel();
                        c0.Orientation = Orientation.Vertical;
                        CommentsStackPanel.Children.Add(c0);

                        TextBlock c1 = new TextBlock();
                        c1.Text = c.content;
                        c1.HorizontalAlignment = HorizontalAlignment.Left;
                        c1.VerticalAlignment = VerticalAlignment.Top;
                        c1.Margin = new Thickness(10);
                        c0.Children.Add(c1);

                        StackPanel c_1 = new StackPanel();
                        c_1.Orientation = Orientation.Horizontal;

                        c0.Children.Add(c_1);

                        /*TextBlock c2 = new TextBlock();
                        c2.Text = "Upvotes";
                        c2.Margin = new Thickness(10,5,0,0);
                        c2.FontSize = 10;
                        c_1.Children.Add(c2);*/

                        TextBlock c3 = new TextBlock();
                        c3.Text = "By:"+c.user;
                        c3.FontSize = 10;
                        c3.Margin = new Thickness(10,5,0,0);
                        c_1.Children.Add(c3);

                        loadedcomments++;
                    }
                }
                else
                    break;
            }
        }

        public studCurrentSession()
        {
            this.InitializeComponent();
            LoadComments();
        }

        private async void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if (commentInput.Text !="")
            {
                comments cc = new comments { content=commentInput.Text,user=App.CurrentUser,upvotes="0", sessionid=App.CurrentSession };
                await App.MobileService.GetTable<comments>().InsertAsync(cc);
                this.Frame.Navigate(typeof(studCurrentSession));
            }
        }
    }
}
