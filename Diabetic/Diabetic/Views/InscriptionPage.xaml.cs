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
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diabetic.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionPage : ContentPage
    {
        public InscriptionPage()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
            if (Setting.User != null)
            {
                prenom.Text = Setting.User.FirstName;
                name.Text = Setting.User.LastName;
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Setting.User = new User(prenom.Text, name.Text, new DateTime(),Gender.Feminin);
            Navigation.PushAsync(new InscriptionSecondPage());
        }
    }

  
}
