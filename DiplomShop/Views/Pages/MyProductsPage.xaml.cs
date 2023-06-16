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
        List<Models.ProductsView> usersProducts = new List<Models.ProductsView>();
        public static UsersProducts products;
        private System.Timers.Timer timer;
        public class UserData1
        {
            public int id { get; set; }
        }
        public MyProductsPage()
        {
            InitializeComponent();
            this.Loaded += UserWindow_Loaded;
        }
        private void UserWindow_Loaded(object sender, RoutedEventArgs e)
        {


            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                GetInfo();
            });
        }
        public async void GetInfo()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(usersProducts), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.GetAsync($"http://localhost:63230/myProducts?IdUser={1}");
                if (message.IsSuccessStatusCode)
            {
                var curContent = await message.Content.ReadAsStringAsync();
                usersProducts = JsonConvert.DeserializeObject<List<Models.ProductsView>>(curContent);
                dataGrid.ItemsSource = usersProducts;
            }
        }
        public  async void ScanImitate()
        {
            if (string.IsNullOrEmpty(txtBoxBarcode.Text))

            {
                MessageBox.Show("Поля Ввода не заполнены");
            }
            else
            {
                
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var contet = new UserData1 { id = 1 };
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
                HttpResponseMessage message = await httpClient.PutAsync($"http://localhost:63230/changeValue?barcode=" + txtBoxBarcode.Text, httpContent);

                if (message.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("В системе такого товара нет");
                }
            }
           
            
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {
            ScanImitate();
            txtBoxBarcode.Text = string.Empty;
            
        }
    }
}
