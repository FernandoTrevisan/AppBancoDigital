using AppBancoDigital.Model;
using AppBancoDigital.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Properties.ContainsKey("usuario_logado"))
                MainPage = new FormAdd();
            else
                MainPage = new Login();

            MainPage = new NavigationPage(new View.Login());
        }

        public List<DadosDoUsuario> list_usuarios = new List<DadosDoUsuario>
        {
            new DadosDoUsuario()
            {
                Cpf = "123.456.789-10",
                Senha = "12345678910"
            }
        };

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
