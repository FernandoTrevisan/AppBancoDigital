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
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                Correntista co = await DataServiceCorrentista.Cadastrar(new Correntista
                {
                    Nome = txt_nome.Text,
                    Cpf = Convert.ToInt32(txt_cpf.Text), 
                    Data_Nasc = dtpck_data_nasc.Date,
                    Senha = txt_senha.Text
                });

                string msg = $"Correntista inserido com sucesso. Código gerado: {co.Id} ";

                await DisplayAlert("Sucesso!", msg, "OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsRunning = false;
                act_carregando.IsVisible = false;
            }
        }

        private void btn_cadastrar_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_logout_Clicked(object sender, EventArgs e)
        {

        }
    }
}
