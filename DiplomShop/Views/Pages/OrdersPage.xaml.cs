﻿using DiplomShop.Models;
using DiplomShop.Views.Windows;
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
using static DiplomShop.Views.Pages.ChangeAmountPage;
using static DiplomShop.Views.Pages.MyProductsPage;
using static DiplomShop.Views.Windows.AuthWindow;

namespace DiplomShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public static HttpClient httpClient = new HttpClient();
        public static List<Models.Orders> listOrders;
        public static List<Models.OrdersSelectedDate> listOrders2;
        public static List<Models.ProductsInOrderView> productsInOrderView;
        
        
        public class UserData4
        {
            public int id { get; set; }
            public int idOrder {get; set; }
        }
        public class UserData10
        {
            public int IdUser { get; set; }
        }
        public class DateSelect
        {
            public DateTime orderDate{ get; set; }
            public int userId { get; set; }
            public int orderId { get; set; }

        }

        public OrdersPage()
        {
            InitializeComponent();
            GetOrderInfo();
            //Проверка гита
        }
        public async void GetOrderInfo()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await httpClient.GetAsync($"http://localhost:63230/myOrders?Id={AuthWindow.users.id}");
            if (message.IsSuccessStatusCode)
            {
                var curContent = await message.Content.ReadAsStringAsync();
                listOrders = JsonConvert.DeserializeObject<List<Models.Orders>>(curContent);
                dataGridOrder.ItemsSource = listOrders;
            }
        }

        private async void dataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            var selectedOrder = dataGridOrder.SelectedItem as Models.Orders;
            if (selectedOrder != null)
            {

                int orderId = selectedOrder.Id;
                int userId = selectedOrder.idUsers;
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var contet = new UserData4 { id = userId, idOrder = orderId };
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
                HttpResponseMessage message = await httpClient.PostAsync("http://localhost:63230/productsInOrders", httpContent);
                if (message.IsSuccessStatusCode)
                {
                    var curContent = await message.Content.ReadAsStringAsync();
                    productsInOrderView = JsonConvert.DeserializeObject<List<Models.ProductsInOrderView>>(curContent);
                    dataGridProducts.ItemsSource = productsInOrderView;
                }

            }
                
            }

        private async void Button_Click(object sender, RoutedEventArgs e)
        { 
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage message = await httpClient.GetAsync($"http://localhost:63230/selectedDate?userId={AuthWindow.users.id}&orderDate={datePicker.SelectedDate}");
            if (message.IsSuccessStatusCode)
            {
                var curContent = await message.Content.ReadAsStringAsync();
                listOrders2 = JsonConvert.DeserializeObject<List<Models.OrdersSelectedDate>>(curContent);
                dataGridOrder.ItemsSource = listOrders2;
            }

        }

        private void dataGridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
    
