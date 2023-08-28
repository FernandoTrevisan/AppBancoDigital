using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View.Pix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PixLerQrCode : ContentView
    {
        public PixLerQrCode()
        {
            InitializeComponent();

            zxing.OnScanResult += (result) =>
               Device.BeginInvokeOnMainThread(() =>
               {
                   lblResult.Text = result.Text;
               });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }

    }
}