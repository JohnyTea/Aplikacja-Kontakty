using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Aplikacja_Kontakty
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Sczegoly : Page
    {
        public Sczegoly()
        {
            this.InitializeComponent();
        }
        private Człowiek osoba;
        public Człowiek nowyCzłowiek;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            osoba = (Człowiek)e.Parameter;
            imieTB.Text = osoba.Imie;
            nazwiskoTB.Text = osoba.Nazwisko;
            miastoTB.Text = osoba.Miasto;
            Obraz.Source = new BitmapImage(new Uri(osoba.Image));
            base.OnNavigatedTo(e);
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            //nowyCzłowiek = new Człowiek(imieTB.Text, nazwiskoTB.Text, miastoTB.Text);
        }

        private void edytujButton_Click(object sender, RoutedEventArgs e)
        {
            osoba.Imie = imieTB.Text;
            osoba.Nazwisko = nazwiskoTB.Text;
            osoba.Miasto = miastoTB.Text;
        }
    }
}
