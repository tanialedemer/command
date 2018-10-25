using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command.Models;

namespace Command
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn1_click(object sender, EventArgs e)
        {
            try
            {
                UserManager manager = new UserManager();
                var res = await manager.getUsuarios();

                if (res != null)
                {
                    lstUsuarios.ItemsSource = res;
                }
            }
            catch (Exception e1)
            {

                throw;
            }
        }
    }
}
