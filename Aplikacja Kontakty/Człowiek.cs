using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja_Kontakty
{
    public class Człowiek : INotifyPropertyChanged
    {
        private string _Imie;
        private string _Nazwisko;
        private string _Miasto;
        private string _Komentarz;
        private string _Image;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string Imie
        {
            get { return _Imie; }
            set
            {
                _Imie = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Imie"));
            }
        }
        public string Nazwisko
        {
            get { return _Nazwisko; }
            set
            {
                _Nazwisko = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nazwisko"));
            }
        }
        public string Miasto
        {
            get { return _Miasto; }
            set
            {
                _Miasto = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Miasto"));
            }
        }
        public string Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Image"));
            }
        }
        public Człowiek(string imie, string nazwisko, string miasto, string image)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Miasto = miasto;
            this.Image = image;
        }
    }
}
