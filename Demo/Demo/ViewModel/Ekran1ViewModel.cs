using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Demo.View;                //dodac (2)
using System.Windows.Input;     //dodac (2)

using Xamarin.Forms;

namespace Demo.ViewModel
{
    public class Ekran1ViewModel : BaseViewModel //to trzeba zmienić na dziedziczenie po BaseViewModel   (2)
    {
        public Ekran1ViewModel()
        {
        }        
        //tu działanie wszelkich kontrolek na Ekranie 1

        public static void NawigujEkran2(object sender, EventArgs e)
        {
            App.Navigation.PushAsync(new MainPage());
        }

    }
}
