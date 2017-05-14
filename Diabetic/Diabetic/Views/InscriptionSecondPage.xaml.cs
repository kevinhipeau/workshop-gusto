using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
    public partial class InscriptionSecondPage : ContentPage
    {
        private bool _okPtDej;
        private bool _okLaunch;
        private bool _okGrouter;
        private bool _okSoir;

        public InscriptionSecondPage()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
          
        }
     
        public bool OkPtDej
        {
            get { return _okPtDej; }
            set
            {
                _okPtDej = value;
                OnPropertyChanged();
            }
        }

        public bool OkLaunch
        {
            get { return _okLaunch; }
            set
            {
                _okLaunch = value;
                OnPropertyChanged();
            }
        }

        public bool OkGrouter
        {
            get { return _okGrouter; }
            set
            {
                _okGrouter = value;
                OnPropertyChanged();
            }
        }

        public bool OkSoir
        {
            get { return _okSoir; }
            set
            {
                _okSoir = value; 
                OnPropertyChanged();
            }
        }

        public void Calc(int id)
        {
            if (id == 1)
            {
                OkPtDej = true;
            }else if (id == 2)
            {
                OkLaunch = true;
            }else if (id == 3)
            {
                OkGrouter = true;
            }else if (id == 4)
            {
                OkSoir = true;
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            DataBase.Database.SaveItem(Setting.User);
           
            Navigation.PushAsync(new RestaurantChoicePage());
        }

        private async void TapGestureRecognizerPetitDej_OnTapped(object sender, EventArgs e)
        {
           await Navigation.PushPopupAsync(new PopUpInscriptionPage(1,this));
         
        }

        private async void TapGestureRecognizerMidi_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new PopUpInscriptionPage(2, this));
        }

        private async void TapGestureRecognizerGouter_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new PopUpInscriptionPage(3, this));
        }

        private async void TapGestureRecognizerDine_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new PopUpInscriptionPage(4, this));
        }
    }

   
}
