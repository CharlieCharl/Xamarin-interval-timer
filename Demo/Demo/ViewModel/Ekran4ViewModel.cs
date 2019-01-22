using AdvancedTimer.Forms.Plugin.Abstractions;
using Demo.Helpers;
using Demo.View;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Demo.ViewModel
{

    class Ekran4ViewModel : BaseViewModel
    {
        

        private string _kolor= "#e85151";     
        private int _serie;
        private int _praca;
        private int _odpoczynek;
        private int pomP;
        private int pomO;
        private bool _widocznoscPraca;
        private bool _widocznoscOdpoczynek;
        private bool _widocznoscSerie= true;
        private bool _widocznoscKoniec = false;
        private string _Textklawisz = "anuluj";

        public IAdvancedTimer timerOdpoczynek = DependencyService.Get<IAdvancedTimer>(DependencyFetchTarget.NewInstance);
        public IAdvancedTimer timerPraca = DependencyService.Get<IAdvancedTimer>(DependencyFetchTarget.NewInstance);

        #region properties
        public string Kolor
        {
            get { return _kolor; }
            set
            {
                if (_kolor != value)
                {
                    _kolor = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool widocznoscPraca
        {
            get { return _widocznoscPraca; }
            set
            {
                if (_widocznoscPraca != value)
                {
                    _widocznoscPraca = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool widocznoscKoniec
        {
            get { return _widocznoscKoniec; }
            set
            {
                if (_widocznoscKoniec != value)
                {
                    _widocznoscKoniec = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Textklawisz
        {
            get { return _Textklawisz; }
            set
            {
                if (_Textklawisz != value)
                {
                    _Textklawisz = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool widocznoscOdpoczynek
        {
            get { return _widocznoscOdpoczynek; }
            set
            {
                if (_widocznoscOdpoczynek != value)
                {
                    _widocznoscOdpoczynek = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool widocznoscSerie
        {
            get { return _widocznoscSerie; }
            set
            {
                if (_widocznoscSerie != value)
                {
                    _widocznoscSerie = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Odpoczynek
        {
            get { return _odpoczynek; }
            set
            {
                if (_odpoczynek != value)
                {
                    _odpoczynek = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Praca
        {
            get { return _praca; }
            set
            {
                if (_praca != value)
                {
                    _praca = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Serie
        {
            set
            {
                if (_serie != value)
                {
                    _serie = value;
                    OnPropertyChanged();
                }
            }
            get
            { return _serie; }
        }
        #endregion properties

        public Ekran4ViewModel()
        {
            MessagingCenter.Subscribe<Ekran3ViewModel, Tabata>(this, "Hi", (sender, arg) =>
            {
                Serie = arg.serie;
                Praca = arg.praca;
                Odpoczynek = arg.odpoczynek;
                pomO = arg.odpoczynek;
                pomP = arg.praca;
            });
            timerPraca.initTimer(1000, timerPracaHandler, true);
            timerOdpoczynek.initTimer(1000, timerOdpoczynekHandler, true);


            MessagingCenter.Subscribe<ekran4, bool>(this, "odpowiedz", (sender, values) => {
                if (values == true) { App.Navigation.PopAsync(); }
            });

        }
        public void  Trening()
        {
            Serie--;
            CrossTextToSpeech.Current.Speak("Work");

            Praca = pomP;
            if (Serie == 0)
            { Odpoczynek = 0; }
            else
            { Odpoczynek = pomO; }
            timerPraca.startTimer();
            Kolor = "#e85151";
            widocznoscPraca = true;

            if (Praca == 0 && timerOdpoczynek.isTimerEnabled() == false)
            { timerPraca.stopTimer();}
        }

        private void timerPracaHandler(object sender, EventArgs e)
        {
            if (Praca == 0)
            {
                widocznoscPraca = false;
                timerPraca.stopTimer();
                widocznoscOdpoczynek = true;
                Kolor = "#82d845";
                CrossTextToSpeech.Current.Speak("Rest");
                timerOdpoczynek.startTimer();
            }
            else
            {
                Praca--;
                if (Praca <= 3)
                {CrossTextToSpeech.Current.Speak(Praca.ToString());}
            }
        }
        private void timerOdpoczynekHandler(object sender, EventArgs e)
        {
            if (Odpoczynek == 0)
            {
                timerOdpoczynek.stopTimer();
                widocznoscOdpoczynek = false;
                if ((Praca == 0 && Odpoczynek == 0 && Serie == 0) == true)
                {
                    timerPraca.stopTimer();
                    timerOdpoczynek.stopTimer();
                    widocznoscSerie = false;
                    widocznoscKoniec = true;
                    Textklawisz = "OK Zakończ";
                    { CrossTextToSpeech.Current.Speak("Trening zakończony"); }
                }
                else { Trening(); }
            }
            else
            {
                Odpoczynek--;
                if (Odpoczynek <= 3)
                {CrossTextToSpeech.Current.Speak(Odpoczynek.ToString());}
            }
        }
        }
    }




