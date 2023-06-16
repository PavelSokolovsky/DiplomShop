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
    /// Логика взаимодействия для ChangeAmountPage.xaml
    /// </summary>
    public partial class ChangeAmountPage : Page
    {
        public static HttpClient httpClient = new HttpClient();
        public class UserData2
        {
            public string barcode { get; set; }
            public int amountMax { get; set; }
            public int amountMin { get; set; }
            public int id { get; set; }
        }
        public ChangeAmountPage()
        {
            InitializeComponent();
        }

        private async void SaveAmountBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(barcodeTextBox.Text) || string.IsNullOrEmpty(maxAmountTextBox.Text) || string.IsNullOrEmpty(minAmountTextBox.Text))

            {
                MessageBox.Show("Поля Ввода не заполнены");
            }
            else 
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaton/json"));
                var contet = new UserData2 { barcode = barcodeTextBox.Text, amountMax = Convert.ToInt32(maxAmountTextBox.Text), amountMin = Convert.ToInt32(minAmountTextBox.Text), id = 1 };
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(contet), Encoding.UTF8, "application/json");
                HttpResponseMessage message = await httpClient.PutAsync("http://localhost:63230/changeAmount", httpContent);
                if (message.IsSuccessStatusCode)
                {
                    MessageBox.Show("Настройки успешно применены, загляните в список товаров");
                }
                else 
                {
                    MessageBox.Show("Настройки не были изменены, что то пошло не так");
                }
                
            }
            

        }
    }
}
