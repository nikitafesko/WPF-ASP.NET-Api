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
	/// Interaction logic for EditCardWindow.xaml
	/// </summary>
	public partial class EditCardWindow : Window
	{
		public EditCardWindow()
		{
			InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			using (HttpClient client = new HttpClient())
			{
				int steps;
				int rank;
				bool result = Int32.TryParse(stepsTextBox.Text.Trim(), out steps);
				if (result)
				{
					bool res = Int32.TryParse(rankTextBox.Text.Trim(), out rank);
					if (res)
					{
						var newUser = new CardModel()
						{
							Rank = rank,
							Status = statusTextBox.Text,
							Steps = steps,
							User = usernameTextBox.Text
						};

						string json = JsonConvert.SerializeObject(newUser);
						StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

						var response = await client.PostAsync($"https://localhost:44366/editModel", httpContent);

						response.EnsureSuccessStatusCode();
						if (response.IsSuccessStatusCode)
						{
							resultLabel.Content = "Success";
						}
						else
						{
							resultLabel.Content = "Something Wrong";
						}
					}
					else
					{
						rankTextBox.Text = "Input number!";
					}
					
				}
				else
				{
					stepsTextBox.Text = "Input number!";
				}
				

			}
		}
	}
}
