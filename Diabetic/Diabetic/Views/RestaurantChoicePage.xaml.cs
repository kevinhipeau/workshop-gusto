using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Diabetic.Models;
using Diabetic.Utils;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diabetic.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantChoicePage : ContentPage
    {
        public RestaurantChoicePage()
        {
            InitializeComponent();
            BindingContext = this;
            mcdo.GestureRecognizers.Add(new TapGestureRecognizer(view => McdoClick()));
            kfc.GestureRecognizers.Add(new TapGestureRecognizer(view => KfcClick()));
            ReturnCommand = new Command(Return);
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
        public Command ReturnCommand { get; set; }

        public void Return()
        {

            this.Navigation.PushAsync(this.Navigation.NavigationStack[0]);


        }
      
        public  void McdoClick()
        {
            Setting.CurrentRestaurant = 0;
              
             Navigation.PushPopupAsync(new PopupChoice());
            base.OnDisappearing();
         

        }

        public async void KfcClick()
        {
            Setting.CurrentRestaurant = 1;
           await  Navigation.PushPopupAsync(new PopupChoice());
            base.OnDisappearing();

        }
    }

   
}
