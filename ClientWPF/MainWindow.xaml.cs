using ClientWPF.Models;
using ClientWPF.Models.Input;
using ClientWPF.Models.Output;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ClientService clientService;
        private string path;
        private static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("https://localhost:7054/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
           
            clientService= new ClientService(client);
        }

        private async void GetClients_Click(object sender, RoutedEventArgs e)
        {
            path = "/api/Client/AllClients";
            List<ClientOutputDTO> clients = await clientService.GetClients(path);
            ClientsDatagrid.ItemsSource = clients;

        }
        private async void AddClient_Click(object sender, RoutedEventArgs e)
        {
            path = "/api/Client/AddClient";
            ClientInputDTO client = new ClientInputDTO(Name.Text, 
                new ContactInfoInputDTO(Email.Text, PhoneNumber.Text),
                new LocationInputDTO(Convert.ToInt32(PostalCode.Text),Commune.Text,StreetName.Text,HouseNumber.Text));

            await clientService.CreateClient(path,client);

        
        }

    }
}