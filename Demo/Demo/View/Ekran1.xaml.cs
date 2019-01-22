using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Demo.ViewModel;  //dodac (2)
using Xamarin.Forms;

namespace Demo.View
{
    public partial class Ekran1 : ContentPage
    {
        public Ekran1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //this.BindingContext = new Ekran1ViewModel();                //VM

            //WYBIERAMY LAYOUT -> Stack (stos), Relative (względny)
            /*StackLayout mojEkran1 = new StackLayout                           
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            */

            RelativeLayout mojEkran1 = new RelativeLayout()
            {
                BackgroundColor = Color.Blue,
            };

            double fontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

            Label naglowek = new Label
            {
                Text = " P R O J E K T   D Y P L O M O W Y ",
                TextColor = Color.Gray,
                FontSize = fontSize,
               // BackgroundColor = Color.Silver,
            };
            mojEkran1.Children.Add(naglowek, Constraint.Constant(10), Constraint.Constant(5));

            Label autor = new Label
            {
                Text = "Imie Nazwisko",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            mojEkran1.Children.Add(autor, Constraint.Constant(120), Constraint.Constant(300));

            Label wydzial = new Label
            {
                Text = "Wydział Fizyki UAM",
                TextColor = Color.Yellow,
                FontAttributes = FontAttributes.Italic,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            mojEkran1.Children.Add(wydzial, Constraint.Constant(120), Constraint.Constant(345));


            Button klawisz1 = new Button
            {
                Text = "NAZWA \nAPLIKACJI",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                BackgroundColor = Color.Blue,
                BorderColor = Color.Blue,
            };
            mojEkran1.Children.Add(klawisz1, Constraint.Constant(100), Constraint.Constant(440));

            //(prawym klawiszem na ViewModel) -> add ->Forms ContentView -> Ekran1ViewModel
            klawisz1.Clicked += Ekran1ViewModel.NawigujEkran2;

            /*------------- było w ver.(1) ------------ 
            klawisz1.Clicked += (sender, args) =>              
            {
                App.Navigation.PushAsync(new MainPage());
            };
            */

            BoxView boxView = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            mojEkran1.Children.Add(boxView,
            Constraint.Constant(0),                 //x

            Constraint.RelativeToParent((parent) =>         //y
            {
                return parent.Height / 3;
            }),

            Constraint.Constant(90),                //szer

            Constraint.RelativeToParent((parent) =>         //wys
            {
                return parent.Height * 2 / 3;
            })        

            );
            Content = mojEkran1;
        }
    }
}
