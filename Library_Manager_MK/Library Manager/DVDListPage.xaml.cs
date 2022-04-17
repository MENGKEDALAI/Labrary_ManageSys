using LibraryManager.BLL;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LibraryManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DVDListPage : Page
    {
        public List<DVD> DVDs;

        //storing the member with whom the loan should be associated
        public Member selectedMember { get; set; }

        public DVDListPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                string memberID = e.Parameter.ToString();

                selectedMember = MemberStore.Instance.GetMembersByID(memberID);

                DVDs = new List<DVD>();

                foreach (DVD dvd in DVDStore.Instance.DVDs)
                {
                    if (dvd.isAvailable)
                    {
                        DVDs.Add(dvd);
                    }
                }

            }
            base.OnNavigatedTo(e);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DVD selectedDVD = DVDs[DVDsListView.SelectedIndex];
            DisplayLoanDVDDialog(selectedDVD);
        }

        //TODO: LoanBook

        private async void DisplayLoanDVDDialog(DVD dvd)
        {
            ContentDialog loanDVDDialog = new ContentDialog
            {
                Title = $"Loan DVD",
                Content = $"Wolud you like to loan the {dvd.title} DVD?",
                PrimaryButtonText = "OK",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await loanDVDDialog.ShowAsync();

            // Loan the book if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                // TODO: Loan the book
                LoanStore.Instance.CreateNewLoan(selectedMember, dvd);
                this.Frame.Navigate(typeof(MemberLoanPage), selectedMember.id);
            }
            else
            {
                // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MemberLoanPage), selectedMember.id);
        }
    }
}
