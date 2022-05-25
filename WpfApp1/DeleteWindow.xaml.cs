using Newtonsoft.Json;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for DeleteWindow.xaml
	/// </summary>
	public partial class DeleteWindow : Window
	{
		public DeleteWindow()
		{
			InitializeComponent();
		}
		//del
		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			using (HttpClient client = new HttpClient())
			{
				int id;

				bool result = Int32.TryParse(textBox.Text.Trim(), out id);
				if (result)
				{
					var response = await client.DeleteAsync($"https://localhost:44366/deleteModel/{id}");
					response.EnsureSuccessStatusCode();
					if (response.IsSuccessStatusCode)
					{
						textBox.Text = "Success";
					}
					else
					{
						textBox.Text = "Error";
					}
				}
				else
				{
					textBox.Text="Input number!";
				}

				
			}
		}
	}
}
