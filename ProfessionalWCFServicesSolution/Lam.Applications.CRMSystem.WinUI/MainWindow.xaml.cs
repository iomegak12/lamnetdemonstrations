using Lam.Libraries.SOA.Proxies.Callbacks;
using Lam.Libraries.SOA.Proxies.CRMSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ICustomerDuplexService customerServiceProxy = default(ICustomerDuplexService);
        private CustomerServiceCallbackHandler callbackHandler = default(CustomerServiceCallbackHandler);

        public MainWindow()
        {
            InitializeComponent();

            this.callbackHandler = new CustomerServiceCallbackHandler();
            this.callbackHandler.NewCustomerRecordAdded += new Action<Customer>(customer =>
            {
                if (customer != default(Customer))
                {
                    if (this.dgCustomers.ItemsSource == default(ObservableCollection<Customer>))
                    {
                        var newCollection = new ObservableCollection<Customer>();

                        newCollection.Add(customer);

                        this.dgCustomers.ItemsSource = newCollection;
                    }
                    else
                    {
                        var existingCollection = this.dgCustomers.ItemsSource as ObservableCollection<Customer>;

                        existingCollection.Add(customer);
                    }
                }
            });

            this.customerServiceProxy = new CustomerDuplexServiceClient(
                new InstanceContext(callbackHandler));

            this.customerServiceProxy.RegisterUIType("GUI");
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
                    var response = await this.customerServiceProxy.GetAllCustomersAsync(
                        new GetAllCustomersRequest());

                    customerRecords = response.GetAllCustomersResult;
                }
                else
                {
                    var response = await this.customerServiceProxy.FindCustomersAsync(
                        new FindCustomersRequest { customerName = searchString });

                    customerRecords = response.FindCustomersResult;
                }

                var observableCustomerCollection = new ObservableCollection<Customer>(customerRecords);

                this.dgCustomers.AutoGenerateColumns = true;
                this.dgCustomers.ItemsSource = observableCustomerCollection;
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
