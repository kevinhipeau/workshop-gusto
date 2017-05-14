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
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diabetic.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupChoice : PopupPage
    {
        public PopupChoice()
        {
            InitializeComponent();
            morningLayout.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(1)));
            lunchLayout.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(2) ));
            afternoonLayout.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(3) ));
            eveningLayout.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(4)));
            morningLayout1.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(1)));
            lunchLayout1.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(2)));
            afternoonLayout1.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(3)));
            eveningLayout1.GestureRecognizers.Add(new TapGestureRecognizer(View => Choice(4)));
        }

        public void Choice(int num)
        {
            Setting.CurrentChoiceLaunch = num;

            switch (num)
            {
                case 1:
                    Setting.DataSugarChoice = new DataSugar(Setting.User.SlowSugarMorning, Setting.User.FastSugarMorning);
                    break;
                case 2:
                    Setting.DataSugarChoice = new DataSugar(Setting.User.SlowSugarLaunch, Setting.User.FastSugarLaunch);
                    break;
                case 3:
                    Setting.DataSugarChoice = new DataSugar(Setting.User.SlowSugarAfter, Setting.User.FastSugarAfter);
                    break;
                case 4:
                    Setting.DataSugarChoice = new DataSugar(Setting.User.SlowSugarEve, Setting.User.FastSugarEve);
                    break;
            }
            PopupNavigation.PopAsync();
             Navigation.PushAsync(new ChoicePage(Generate.GenerateRestaurant()[Setting.CurrentRestaurant]));
           
        }
       
       

    }

   
}
