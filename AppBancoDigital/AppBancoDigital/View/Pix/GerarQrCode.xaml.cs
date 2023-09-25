using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GerarQrCode : ContentPage
    {
        public GerarQrCode()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }

        private void gerar_qr_code_Clicked(object sender, EventArgs e)
        {
            
            string teste = "Chave da Transferência: FernandoTrevisan ";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(teste, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            img_qrcode.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));

        }

        private void voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Pix.AreaPix());
        }
    }
}