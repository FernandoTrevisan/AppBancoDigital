using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPix : ContentPage
    {
        public AreaPix()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            
        }

        

        private void LerPix_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new View.Pix.PixLerQrCode());


        }

        

        

        private async void gerar_qr_code_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GerarQrCode());

        }

        private void btn_voltar_conta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Conta());
        }
    }
}

/* XAML
            <Grid VerticalOptions="FillAndExpand">
                    <Grid.RowDefinitions>
                    <RowDefinition Height="4*"/>
                    <RowDefinition Height="*"/>
                </Grid.RowDefinitions>

                <zxing:ZXingScannerView x:Name="zxing"
                                         VerticalOptions="FillAndExpand"/>
                <zxing:ZXingDefaultOverlay TopText="Segure o Telefone no QR CODE"
                                           BottomText="O resultado vai aparecer abaixo" />
                <Label x:Name="lblResult"
                       Grid.Row="1"
                       HorizontalOptions="Center"
                       VerticalOptions="Center"
                       HorizontalTextAlignment="Center"
                       VerticalTextAlignment="Center"/>
            </Grid> 
         
        */