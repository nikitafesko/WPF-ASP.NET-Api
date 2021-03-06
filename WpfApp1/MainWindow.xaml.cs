using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApi.Models;
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

namespace WpfApp1
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
		//Create
		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			CreateUserWindow createWinwod = new CreateUserWindow();
			createWinwod.Show();
		}
		//get All
		private async void Button_Click_1(object sender, RoutedEventArgs e)
		{
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync("https://localhost:44366/getData");
				response.EnsureSuccessStatusCode();
				if (response.IsSuccessStatusCode)
				{
					//mainGrid.DataContext = await response.Content.ReadAsStringAsync();
					var st = await response.Content.ReadAsStringAsync();
					var list = JsonConvert.DeserializeObject<List<CardModel>>(st);
					mainGrid.ItemsSource = list;
				}
				else
				{
					mainGrid.DataContext = "error";
				}
			}
		}
		//delete
		private async void Button_Click_2(object sender, RoutedEventArgs e)
		{
			DeleteWindow delWindow = new DeleteWindow();
			delWindow.Show();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			EditCardWindow editWindow = new EditCardWindow();
			editWindow.Show();
		}
	}
}
