using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Command.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            enterButton.Clicked += enterButton_Clicked;
        }
        private async void enterButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un usuario", "Aceptar");
                userEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(passEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una contraseña", "Aceptar");
                passEntry.Focus();
                return;
            }

            waitActivityIndicator.IsRunning = true;
            enterButton.IsEnabled = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost");
            string url = string.Format("/command/session.php?{0}/{1}", userEntry, passEntry);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;
            enterButton.IsEnabled = true;
            waitActivityIndicator.IsRunning = false;

            if (string.IsNullOrEmpty(result)|| result== "null")
            {
                await DisplayAlert("Error", "Usuario o clave no validos", "Aceptar");
                passEntry.Text = string.Empty;
                passEntry.Focus();
                return;
            }

            await Navigation.PushAsync(new CommandPage());
        }
    }
}