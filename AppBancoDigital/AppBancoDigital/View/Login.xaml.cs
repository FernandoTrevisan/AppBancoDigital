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
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            logo1.Source = ImageSource.FromResource("AppBancoDigital.Imagens.logo1.png");
        }

        private void btn_criar_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_criar_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}