
using Demo.ViewModel;
using Demo.Helpers;
using Xamarin.Forms;

namespace Demo.View
{
    public partial class Ekran2 : ContentPage
    {
        public Ekran2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new Ekran2ViewModel();
            MessagingCenter.Subscribe<Ekran2ViewModel, Pomoc>(this, "DisplayAlert", (sender, values) => {
                DisplayAlert("Pomoc", values.pomoc,"OK");
            });
        }
        protected override void OnDisappearing()
        {

        }
    }
}


