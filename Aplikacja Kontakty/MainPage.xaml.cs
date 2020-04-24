using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Aplikacja_Kontakty
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Człowiek> ludzie = new ObservableCollection<Człowiek>();
        public MainPage()
        {
            this.InitializeComponent();
            ludzie.Add(new Człowiek("Sebastian", "Kładź", "Styrzyniec","ms-appx:///Assets//Square44x44Logo.scale-200.png" ));
            ludzie.Add(new Człowiek("Grzegorz", "Wojtjuk", "Biała Podlaska", "ms-appx:///Assets//Square44x44Logo.scale-200.png"));
            ludzie.Add(new Człowiek("Łukasz", "Cydejko", "Studzianka", "ms-appx:///Assets//Square44x44Logo.scale-200.png"));
            ListaLudzi.ItemsSource = ludzie;
        }

        //private void SelectionChanged_ListaLudzi(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ListaLudzi.SelectedItem != null)
        //    {
        //        Człowiek ludz = (Człowiek)ListaLudzi.SelectedItem;
        //        Imie_TB.Text = ludz.Imie;
        //        Nazwisko_TB.Text = ludz.Nazwisko;
        //        Adres_TB.Text = ludz.Miasto;
        //    }
            
        //}

        private void ZaktualizujListe()
        {
            ListaLudzi.ItemsSource = null;
            ListaLudzi.ItemsSource = ludzie;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            ludzie.Add(new Człowiek(Imie_TB.Text, Nazwisko_TB.Text, Adres_TB.Text, "ms-appx:///Assets//Square44x44Logo.scale-200.png"));
            //ZaktualizujListe();
        }

        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            Człowiek edycyjnyCzłowiek = (Człowiek)ListaLudzi.SelectedItem;
            edycyjnyCzłowiek.Imie = Imie_TB.Text;
            edycyjnyCzłowiek.Nazwisko = Nazwisko_TB.Text;
            edycyjnyCzłowiek.Miasto = Adres_TB.Text;
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            Człowiek martwyCzłowiek = (Człowiek) ListaLudzi.SelectedItem;
            ludzie.Remove(martwyCzłowiek);
            //ZaktualizujListe();
        }

        private void Szczegoly_Click(object sender, RoutedEventArgs e)
        {
            Człowiek osoba = (Człowiek)ListaLudzi.SelectedItem;
             ShowNewWindow(sender, e, osoba);
        }

        AppWindow appWindow;
        Frame appWindowFrame = new Frame();
        private async void ShowNewWindow(object sender, RoutedEventArgs e, Człowiek osoba)
        {
            // Create a new window
            appWindow = await AppWindow.TryCreateAsync();
            // Navigate our frame to the page we want to show in the new window
            appWindowFrame.Navigate(typeof(Sczegoly), osoba);
            // Attach the XAML content to our window
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowFrame);
            // Show the window
            appWindow.Closed += delegate
            {
                appWindowFrame.Content = null;
                appWindow = null;
            };
            await appWindow.TryShowAsync();
            
        }
    }
}
