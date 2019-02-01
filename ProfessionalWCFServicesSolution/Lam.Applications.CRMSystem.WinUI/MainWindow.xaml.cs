using Lam.Libraries.SOA.Proxies.CRMSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Lam.Applications.CRMSystem.WinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICustomerService customerServiceProxy = default(ICustomerService);

        public MainWindow()
        {
            InitializeComponent();

            this.customerServiceProxy = new CustomerServiceClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchString = this.txtCustomerName.Text;
                var possibleKeywords = new string[] { "*", "", "all", "everything" };
                var customerRecords = default(IEnumerable<Customer>);

                if (possibleKeywords.Contains(searchString))
                {
                    customerRecords = await this.customerServiceProxy.GetAllCustomersAsync();
                }
                else
                {
                    customerRecords = await this.customerServiceProxy.FindCustomersAsync(searchString);
                }

                this.dgCustomers.AutoGenerateColumns = true;
                this.dgCustomers.ItemsSource = customerRecords;
            }
            catch (FaultException<ServiceError> serviceException)
            {
                MessageBox.Show($"Error Occurred, Details : {serviceException.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.txtCustomerName.Text = string.Empty;
            this.dgCustomers.ItemsSource = default(IEnumerable<Customer>);
        }
    }
}
