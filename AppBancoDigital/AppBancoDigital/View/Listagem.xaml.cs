using AppBancoDigital.Model;
using AppBancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagem : ContentPage
    {
        ObservableCollection<Correntista> ListaCorrentistas = new ObservableCollection<Correntista>();

        public Listagem()
        {
            InitializeComponent();

            lst_correntistas.ItemsSource = ListaCorrentistas;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.FormAdd());
        }

        protected override void OnAppearing()
        {
            if (ListaCorrentistas.Count == 0)
            {
                

                System.Threading.Tasks.Task.Run(async () =>
                {
                    

                    List<Correntista> temp = await DataServiceCorrentista.GetCorrentistasAsync();

                    foreach (Correntista item in temp)
                    {
                        ListaCorrentistas.Add(item);
                    }
                });
            }
        }

        private async void getAllRows()
        {
            act_carregando.IsRunning = true;

            try
            {
                ListaCorrentistas.Clear();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                act_carregando.IsRunning = false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                List<Correntista> temp = await DataServiceCorrentista.SearchAsync(txt_q.Text);

                ListaCorrentistas.Clear();

                foreach (Correntista item in temp)
                {
                    ListaCorrentistas.Add(item);
                }
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

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            act_carregando.IsRunning = true;
            act_carregando.IsVisible = true;

            try
            {
                MenuItem menu = sender as MenuItem;
                Correntista correntista_selecionado = menu.BindingContext as Correntista;

                await DataServiceCorrentista.DeleteAsync(correntista_selecionado.Id);

                ListaCorrentistas.Remove(correntista_selecionado);
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
    }
}
