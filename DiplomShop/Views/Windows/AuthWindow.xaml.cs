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
using System.Windows.Shapes;

namespace DiplomShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static HttpClient httpClient = new HttpClient();
        public static Users users;
        
        public class UserData
        {
            public string login { get; set; }
            public string password { get; set; }
        }
        public AuthWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaton/json"));
            var contet = new UserData { login = txtLogin.Text, password = txtPassword.Password };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
            HttpResponseMessage message = await httpClient.PostAsync("http://localhost:63230/auth", httpContent);
            if (message.IsSuccessStatusCode)
            {
                var curContent = await message.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<Users>(curContent);
                
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка Входа");
            }
        }
    }
}
