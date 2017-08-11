using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForeignExchangeTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ConvertButton.Clicked += ConvertButton_Clicked;
        }

        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PesosEntry.Text))
            {
                DisplayAlert("ERROR", "You must enter a value in pesos...", "Accept");
                return;
            }

            decimal Pesos = 0;
            if(!decimal.TryParse(PesosEntry.Text, out Pesos))
            {
                DisplayAlert("ERROR", "You must enter a value numeric in pesos...", "Accept");
                PesosEntry.Text = null;
                PesosEntry.Focus();
                return;
            }

            var dollars = Pesos / 2976.19048M;
            var euros = Pesos / 3518.85417M;
            var pounds = Pesos / 3873.125M;

            DollarsEntry.Text = string.Format("${0:N2}", dollars);
            EurosEntry.Text = string.Format("€{0:N2}", euros);
            PoundsEntry.Text = string.Format("£{0:N2}", pounds);
        }
    }
}
