using LibraryManager.BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class MemberSearchPage : Page
    {
        ObservableCollection<Member> members = new ObservableCollection<Member>();

        public MemberSearchPage()
        {
            this.InitializeComponent();

            LoadAllMembers();

            //this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        //Loads all members
        private void LoadAllMembers()
        {
            members.Clear();
            foreach (var member in MemberStore.Instance.members)
            {
                members.Add(member);
            }
        }

        //TODO: Load searched members

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MembersListView.SelectedIndex < 0) return;
            Member mb = members[MembersListView.SelectedIndex];
            this.Frame.Navigate(typeof(MemberLoanPage), mb.id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            members.Clear();
            foreach (var member in MemberStore.Instance.members)
            {
                if (member.name.ToLower().Contains(txtBoxName.Text.ToLower()) && member.id.Contains(txtBoxID.Text.ToLower()))
                { 
                    members.Add(member);
                }
            }
        }
    }
}
