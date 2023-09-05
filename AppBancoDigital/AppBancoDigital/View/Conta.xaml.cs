using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using QRCoder;
using System.IO;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conta : ContentPage
    {
        public Conta()
        {
           
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            lbl_nome.Text = "Seja bem-vindo(a)\n" + App.nome;
        }

        private async void btn_sair_Clicked(object sender, EventArgs e)
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

        

       

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Pix.AreaPix());

        }

        
    }
}