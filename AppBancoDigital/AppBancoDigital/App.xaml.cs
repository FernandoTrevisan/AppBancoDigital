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
        public static Model.Correntista DadosCorrentista { get; set; }
        public App()
        {
            InitializeComponent();

            if (Properties.ContainsKey("usuario_logado"))
                MainPage = new FormAdd();
            else
                MainPage = new Login();

            MainPage = new NavigationPage(new View.Login());
        }

       
        
       
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
