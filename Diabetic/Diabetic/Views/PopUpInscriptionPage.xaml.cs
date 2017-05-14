using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Diabetic.Utils;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diabetic.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpInscriptionPage : PopupPage
    {
        public InscriptionSecondPage Page;
        public int Type;
        public PopUpInscriptionPage(int type, InscriptionSecondPage page)
        {
            InitializeComponent();
            BindingContext = this;
            Page = page;
            Type = type;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Page.Calc(Type);
            if (Type == 1)
            {
                Setting.User.FastSugarMorning = int.Parse(fast.Text);
                Setting.User.SlowSugarMorning = int.Parse(slow.Text);
            }
            else if (Type == 2)
            {
                Setting.User.FastSugarLaunch = int.Parse(fast.Text);
                Setting.User.SlowSugarMorning = int.Parse(slow.Text);
            }
            else if (Type == 3)
            {
                Setting.User.FastSugarMorning = int.Parse(fast.Text);
                Setting.User.SlowSugarMorning = int.Parse(slow.Text);
            }
            else if (Type == 4)
            {
                Setting.User.FastSugarEve= int.Parse(fast.Text);
                Setting.User.SlowSugarEve = int.Parse(slow.Text);
            }
         
            PopupNavigation.PopAsync();
        }
    }

   
}
