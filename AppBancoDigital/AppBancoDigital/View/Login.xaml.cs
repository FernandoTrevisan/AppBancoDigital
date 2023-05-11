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
    public partial class Login : ContentPage
    {
        App PropriedadesApp;

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            logo1.Source = ImageSource.FromResource("AppBancoDigital.Imagens.logo1.png");
            PropriedadesApp = (App)Application.Current;
        }

        private void btn_criar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new View.CriarConta());

        }

        private async void btn_criar_Unfocused(object sender, FocusEventArgs e)
        {

            try
            {
                string cpf = txt_cpf.Text;
                string senha = txt_senha.Text;

                if (PropriedadesApp.list_usuarios.Any(i => (i.Cpf == cpf && i.Senha == senha)))
                {
                    App.Current.Properties.Add("usuario_logado", cpf);
                    App.Current.MainPage = new FormAdd();
                }
                else
                    throw new Exception("Dados incorretos, tente novamente.");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops, ocorreu um erro...", ex.Message, "OK");
            }

        }
    }
}