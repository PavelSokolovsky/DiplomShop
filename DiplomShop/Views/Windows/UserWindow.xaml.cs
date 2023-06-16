using DiplomShop.Models;
using DiplomShop.Views.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static DiplomShop.Views.Pages.MyProductsPage;

namespace DiplomShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public static MyProductsPage MyProductsPage = new MyProductsPage();
        public static ChangeAmountPage amountPage = new ChangeAmountPage();
        public static OrdersPage ordderstPage = new OrdersPage();
        public static HttpClient httpClient = new HttpClient();
        private System.Timers.Timer timer;
        OrdersPage ordersPage = new OrdersPage();
        public class UserId
        {
            public int ID { get; set; }
            
        }
        public UserWindow()
        {
            InitializeComponent();
            this.Loaded += UserWindow_Loaded;

        }
        private void UserWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            
            timer = new System.Timers.Timer();
            timer.Interval = 30000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                GetOrderResult();
                


            });
        }
        public async void GetOrderResult()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaton/json"));
            HttpResponseMessage message = await httpClient.GetAsync($"http://localhost:63230/getInfoIsActiveOrder?Id={1}");
            if (message.IsSuccessStatusCode)
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaton/json"));
                HttpResponseMessage message2 = await httpClient.GetAsync($"http://localhost:63230/getInfoCheckOrder?Id=1");
                if (message2.IsSuccessStatusCode)
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaton/json"));
                    var contet = new UserId { ID = 1 };
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
                    HttpResponseMessage message1 = await httpClient.PostAsync($"http://localhost:63230/checkOrder?Id={contet.ID}", httpContent);


                }
                else
                {
                    return;
                }
            }
            else
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaton/json"));
                var contet = new UserId{ ID = 1 };
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
                HttpResponseMessage message1 = await httpClient.PostAsync($"http://localhost:63230/postNewOrder?Id={contet.ID}", httpContent);
                if (message1.IsSuccessStatusCode)
                {
                    return;
                }
                //else
                //{
                //    MessageBox.Show("Ошибка");
                //}
            }
        }

        private void MyProducts_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = MyProductsPage;
        }

        private void ChangeAmount_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = amountPage;
        }

        private void OrdersHistory_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = ordderstPage;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
