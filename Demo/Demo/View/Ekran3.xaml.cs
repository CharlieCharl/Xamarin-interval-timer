using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ViewModel;
using Xamarin.Forms;

namespace Demo.View
{
    public partial class Ekran3 : ContentPage
    {
 
        public Ekran3()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new Ekran3ViewModel(); 
        }
        protected override void OnAppearing()
        {
          //  base.OnAppearing();
            
            ((Ekran3ViewModel)BindingContext).Load();
        }
        protected override void OnDisappearing()
        {
            //     MessagingCenter.Unsubscribe<MainPage, string>(this, "Hi");
            App.Navigation.RemovePage(this);
        }
    }
  
}

