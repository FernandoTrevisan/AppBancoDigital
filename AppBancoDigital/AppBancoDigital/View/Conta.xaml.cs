using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conta : ContentPage
    {
        public Conta()
        {
           
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem certeza?", "Desconectar sua conta?", "Sim", "Não");

                if (confirm)
                {
                    App.Current.Properties.Remove("usuario_logado");
                    App.Current.MainPage = new Login();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }

        }
    }
}