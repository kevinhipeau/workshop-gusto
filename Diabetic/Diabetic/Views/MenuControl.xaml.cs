using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diabetic.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuControl : StackLayout
    {
        public MenuControl()
        {
            InitializeComponent();
            ReturnCommand = new Command(Return);
            BindingContext = this;

        }
        public Command ReturnCommand { get; set; }

        public void Return()
        {

            this.Navigation.PushAsync(this.Navigation.NavigationStack[0]);


        }
        
    }

   

    
}
