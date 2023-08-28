using AppBancoDigital.Model;
using AppBancoDigital.Service;
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
    public partial class FormAdd : ContentPage
    {
        public FormAdd()
        {

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            logo1.Source = ImageSource.FromResource("AppBancoDigital.Imagens.logo1.png");
        }

        private async void btn_cadastrar_Clicked_1(object sender, EventArgs e)
        {
            string[] cpf_pontuado = txt_cpf.Text.Split('.', '-');
            string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
            try
            {
                Model.Correntista c = await DataServiceCorrentista.SaveAsync(new Model.Correntista
                {
                    Nome = txt_nome.Text,
                    Data_Nascimento = dtpck_data_nasc.Date,
                    Email = txt_email.Text,
                    Cpf = cpf_digitado,
                    Senha = txt_senha.Text,
                });

                if (c.Id != null)
                {

                    App.DadosCorrentista = c;

                    await Navigation.PushAsync(new View.Login());
                }
                else
                    throw new Exception("Ocorreu um erro ao salvar seu cadastro.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                await DisplayAlert("Ops!", ex.Message, "OK");
            }

        }


        private async void btn_logout_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new Login());
            }


            catch (Exception ex)
            {
                await DisplayAlert("Ops, ocorreu um erro...", ex.Message, "OK");
            }

        }
    }
}