using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Diabetic.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diabetic.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {



        bool HandleFunc1()
        {
            Navigation.PushAsync(new RestaurantChoicePage());
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);

            return false;
        }


        public FirstPage()
        {

            InitializeComponent();
            title.Text = "Bonjour, " + Setting.User.FirstName;
            NavigationPage.SetHasNavigationBar(this, false);
            title.FadeTo(0, 2000);
            Device.StartTimer(System.TimeSpan.FromSeconds(2), HandleFunc1);
          
        }
    }

 
}
