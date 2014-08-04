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
    public partial class GetContactsWithImages : PhoneApplicationPage
    {
        public GetContactsWithImages()
        {
            InitializeComponent();
        }

        private void ButtonManyPictures_Click(object sender, RoutedEventArgs e)
        {
            Contacts cons = new Contacts();

            //Identify the method that runs after the asynchronous search completes.
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted_Many);

            //Start the asynchronous search.
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #3 Picture");
        }

        private void Contacts_SearchCompleted_Many(object sender, ContactsSearchEventArgs e)
        {
            try
            {
                ContactResultsData1.DataContext =
                    from Contact con in e.Results
                    from Account a in con.Accounts
                    where a.Name.Contains("AccountName") // change the string to any account name 
                    select con;
            }

            catch (System.Exception)
            {
                //No results
            }
        }
    }

    public class ContactPictureConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Contact c = value as Contact;
            if (c == null) return null;

            System.IO.Stream imageStream = c.GetPicture();
            if (null != imageStream)
            {
                return Microsoft.Phone.PictureDecoder.DecodeJpeg(imageStream);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}