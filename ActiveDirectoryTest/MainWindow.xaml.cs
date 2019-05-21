using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string stringDomainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                PrincipalContext PrincipalContext4 = new PrincipalContext(ContextType.Domain, stringDomainName, textboxOu.Text, ContextOptions.SimpleBind, textboxAdminUsername.Text, passwordboxAdminPassword.Password);
                UserPrincipal UserPrincipal1 = new UserPrincipal(PrincipalContext4, textboxLonOnName.Text, passwordboxUserPass.Password, true);

                UserPrincipal1.UserPrincipalName = textboxSamAccountName.Text;
                UserPrincipal1.Name = textboxName.Text;
                UserPrincipal1.GivenName = textboxGivenName.Text;
                UserPrincipal1.Surname = textboxSurname.Text;
                UserPrincipal1.DisplayName = textboxDisplayName.Text;
                UserPrincipal1.Description = textboxDescription.Text;
                if (radiobuttonEnable.IsChecked == true)
                {
                    UserPrincipal1.Enabled = true;
                }
                else
                {
                    UserPrincipal1.Enabled = false;
                }
                UserPrincipal1.Save();
                MessageBox.Show("Saved Sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            textboxOu.Text = "CN=Users,DC=Mehdi,DC=Local";
        }
    }
}
