using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;

namespace ContactsPlayNiceSpike
{
    public partial class GetContacts : PhoneApplicationPage
    {
        public GetContacts()
        {
            InitializeComponent();
        }

        private void btnGetContacts_Click(object sender, RoutedEventArgs e)
        {
            Contacts cons = new Contacts();

            //Identify the method that runs after the asynchronous search completes.
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);

            //Start the asynchronous search.
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
        }

        private void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            try
            {
                //Bind the results to the user interface.
                ContactResultsData.DataContext = e.Results;
            }
            catch (System.Exception)
            {
                //No results
            }

            if (ContactResultsData.Items.Any())
            {
                ContactResultsLabel.Text = "results";
            }
            else
            {
                ContactResultsLabel.Text = "no results";
            }

        }

        public void enumerateContacts()
        {
           // System.Text.StringBuilder sb = new System.Text.StringBuilder();
           //
           // foreach (Contact con in e.Results)
           // {
           //     sb.AppendLine(con.DisplayName);
           // }
           //
           // MessageBox.Show(sb.ToString());
        }
    }
}