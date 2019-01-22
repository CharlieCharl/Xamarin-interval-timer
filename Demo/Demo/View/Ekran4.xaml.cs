using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ViewModel;
using Xamarin.Forms;
using Demo.Helpers;

namespace Demo.View
{
    public partial class ekran4 : ContentPage
    {
        public ekran4()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new Ekran4ViewModel();
        }

        async void ItemClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Przerwać?", "Czy na pewno chcesz zakończyć", "Tak", "Nie");
            MessagingCenter.Send<ekran4, bool>(this, "odpowiedz", answer);
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            ((Ekran4ViewModel)BindingContext).Trening();
        }

        protected override void OnDisappearing()
        {
            ((Ekran4ViewModel)BindingContext).timerOdpoczynek.stopTimer();
            ((Ekran4ViewModel)BindingContext).timerPraca.stopTimer();
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Przerwać?", "Czy na pewno chcesz zakończyć", "Tak", "Nie");
                if (result) await this.Navigation.PopAsync(); 
            });

            return true;
        }

    }
}
