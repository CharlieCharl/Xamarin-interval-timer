using Demo.View;
using Xamarin.Forms;
using System.Windows.Input;
using System;
using System.Collections.ObjectModel;
using Demo.Helpers;

namespace Demo.ViewModel
{
    class Ekran2ViewModel : BaseViewModel
    {
        private int _czasPracySek = 10;
        private int _liczbaSerii = 5;
        private int _czasOdpoczynkuSek = 10;
        
        public int LiczbaSerii
        {
            set
            {
                if (_liczbaSerii != value)
                {
                    _liczbaSerii = value;
                    if (_liczbaSerii < 1)
                    { _liczbaSerii = 1; }
                    OnPropertyChanged();
                }
            }
            get
            { return _liczbaSerii;  }
        }
        public int CzasOdpoczynkuSek
        {
            set
            {
                if (_czasOdpoczynkuSek != value)
                {
                    _czasOdpoczynkuSek = value;
                    if (_czasOdpoczynkuSek >= 60)
                    {
                        _czasOdpoczynkuSek = 0;
                    }
                    OnPropertyChanged();
                }
            }
            get
            { return _czasOdpoczynkuSek; }
        }
        public int CzasPracysek
        {
            set
            {
                if (_czasPracySek != value)
                {
                    _czasPracySek = value;
                    if (_czasPracySek >= 60)
                    {
                        _czasPracySek = 0;
                    }
                    OnPropertyChanged();
                }
            }
            get
            { return _czasPracySek; }
        }

        Tabata tabata = new Tabata(5,10,10);

        public Ekran2ViewModel()
        {
            this.NastepnaStrona = new Command(async () =>
          {
              Ekran3 ekran3 = new Ekran3();
              MessagingCenter.Send<Ekran2ViewModel, Tabata>(this, "Hi", tabata);
              await App.Navigation.PushAsync(ekran3);
          });
        
            this.ButtonZwiekszSerie = new Command<Button>((key) =>
            {LiczbaSerii++;
             tabata.serie = LiczbaSerii;
            });
            this.ButtonZmniejszSerie = new Command<Button>((key) =>
            { LiczbaSerii--;
                tabata.serie = LiczbaSerii;
            });
            this.ButtonZwiekszPrace = new Command<Button>((key) =>
            {CzasPracysek++;
                tabata.praca = CzasPracysek;
            });
            this.ButtonZmniejszPrace = new Command<Button>((key) =>
            {CzasPracysek--;
                tabata.praca = CzasPracysek;
            });
              this.ButtonZwiekszOdpoczynek = new Command<Button>((key) =>
            { CzasOdpoczynkuSek++;
                tabata.odpoczynek = CzasOdpoczynkuSek; });
            this.ButtonZmniejszOdpoczynek = new Command<Button>((key) =>
            {CzasOdpoczynkuSek--;
                tabata.odpoczynek = CzasOdpoczynkuSek;
            });
            this.ButtonPomoc = new Command<Button>((key) =>
            {
                MessagingCenter.Send<Ekran2ViewModel, Pomoc>(this, "DisplayAlert", new Pomoc());
            });
        }

        public ICommand NastepnaStrona { get; protected set; }
        public ICommand ButtonZwiekszSerie { get; protected set; }
        public ICommand ButtonZmniejszSerie { get; protected set; }
        public ICommand ButtonZwiekszPrace { get; protected set; }
        public ICommand ButtonZmniejszPrace { get; protected set; }
        public ICommand ButtonZwiekszOdpoczynek { get; protected set; }
        public ICommand ButtonZmniejszOdpoczynek { get; protected set; }
        public ICommand ButtonPomoc { get; protected set; }
    }
}
