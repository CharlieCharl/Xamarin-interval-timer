using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.View;
using Xamarin.Forms;
using Demo.Helpers;
using Plugin.TextToSpeech;
using System.Threading;
using System.Windows.Input;

namespace Demo.ViewModel
{
    class Ekran3ViewModel : BaseViewModel
    {
        ekran4 Ekran4 = new ekran4();
        public async void Load()
        {
            for (; 0 < Przygotowanie;)
            {
                await Task.Factory.StartNew(() =>
                {
                    Przygotowanie--;
                });
                CrossTextToSpeech.Current.Speak(Przygotowanie.ToString());
                await Task.Delay(1000);
            }
            if (Przygotowanie == 0)
            {
                await App.Navigation.PushAsync(Ekran4);
            }
        }

        public static void NawigujEkran4(ekran4 ekran)
        {
            App.Navigation.PushAsync(ekran);
        }
        public Ekran3ViewModel()
        {  
            MessagingCenter.Subscribe<Ekran2ViewModel, Tabata>(this, "Hi", (sender, arg) => {
                MessagingCenter.Send<Ekran3ViewModel, Tabata>(this, "Hi", arg);
            });
            //   Load();  
        }

        private int _przygotowanie = 5;
        public int Przygotowanie
        {
            set
            {
                if (_przygotowanie != value)
                {
                    _przygotowanie = value;
                    OnPropertyChanged();
                }
            }
            get
            { return _przygotowanie; }
        }
    }
}