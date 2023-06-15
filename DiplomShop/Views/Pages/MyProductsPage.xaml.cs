using DiplomShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using static DiplomShop.Views.Windows.AuthWindow;

namespace DiplomShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyProductsPage.xaml
    /// </summary>
    public partial class MyProductsPage : Page
    {
        public static List<Models.UsersProducts> usersProducts { get; set; }
        public static UsersProducts products;
        public class UserData1
        {
            public int id { get; set; }
        }
        public MyProductsPage()
        {
            InitializeComponent();
            GetInfo();
        }
        public async void GetInfo()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(usersProducts), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PostAsync($"http://localhost:63230/myProducts?id={1}", httpContent);
            if (message.IsSuccessStatusCode)
            {
                var curContent = await message.Content.ReadAsStringAsync();
                usersProducts = JsonConvert.DeserializeObject<List<Models.UsersProducts>>(curContent);
                dataGrid.ItemsSource = usersProducts;
            }
        }
        public  async void ScanImitate()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var contet = new UserData1 { id  = 1 };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PutAsync($"http://localhost:63230/changeValue?barcode=" +txtBoxBarcode.Text, httpContent);
            
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {
            ScanImitate();
            txtBoxBarcode.Text = string.Empty;
            
        }
    }
}
