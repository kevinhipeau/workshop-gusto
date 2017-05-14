using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ResultPage : ContentPage, INotifyPropertyChanged
    {
        private Product _selectedProduct;
        public ObservableCollection<Product> Products { get; set; }

        public string Diabete { get; set; }
        public Command<Product> RemovePortion { get; set; }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (value != null)
                {
                    _selectedProduct = value;
                }

            }
        }

        public Command<Product> AddPortionCommand { get; set; }

        public ResultPage(ObservableCollection<Product> products)
        {
            Products = new ObservableCollection<Product>(products);
            InitializeComponent();
            AddPortionCommand = new Command<Product>(AddPortion);
            RemovePortion = new Command<Product>(RemoveProduct);

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;
            Task.Run(() => Calc());
         
            Multi = 1;


            //leftColumnLayoutFast.IsVisible = false;
            //rightColumnLayoutFast.IsVisible = false;

        }


        public void AddPortion(Product product)
        {

            try
            {
                if (product.SelectedPortion.Count < 4)
                {
                    if (product.SelectedPortion.Count < 1)
                    {
                        product.FirstVisible = true;
                    }
                    else if (product.SelectedPortion.Count < 2)
                    {
                        product.FirstVisible = true;
                        product.SecondVisible = true;
                    }
                    else if (product.SelectedPortion.Count < 3)
                    {
                        product.FirstVisible = true;
                        product.SecondVisible = true;
                        product.TreeVisible = true;

                    }
                    else
                    {
                        product.QuadrupleVisible = true;
                    }
                }
                if (product.SelectedPortion.DefaultIfEmpty().Max() < 4)
                {
                    product.FirstVisible = true;
                    product.SelectedPortion.Add(product.SelectedPortion.DefaultIfEmpty().Max() + 1);



                }
                Calc();
            }
            catch (Exception ex)
            {

                var ee = ex;
            }

            //  Calc();

        }

        public void RemoveProduct(Product product)
        {
            if (product.SelectedPortion.Count >= 0)
            {
                int dd = product.SelectedPortion.DefaultIfEmpty().Max();
                product.SelectedPortion = new ObservableCollection<int>(product.SelectedPortion.Where(c => c != dd));
                if (product.SelectedPortion.Count >= 3)
                {
                    product.QuadrupleVisible = false;
                }
                else if (product.SelectedPortion.Count >= 2)
                {

                    product.TreeVisible = false;
                }
                else if (product.SelectedPortion.Count >= 1)
                {
                    product.SecondVisible = false;

                }
                else
                {
                    product.FirstVisible = false;
                }
                Calc();

            }
        }

        double columnSize1Slow = 0.0;
        double columnSize2Slow = 0.0;

        double columnSize1Fast = 0.0;
        double columnSize2Fast = 0.0;

        double sugarValueSlow = 5;

        double sugarValueFast = 23;
        private double _multi;
        double valueUser => Setting.DataSugarChoice.SlowSugar * Multi;
        double valueUserFast => Setting.DataSugarChoice.FastSugar * Multi;


        double size = 0.0;
         double  oldValue = 0;
        public void setColumnSize(double value)
        {
            if (value > oldValue)
            {
                size = value;
            }
            else
            {
                size = value;
            }
            oldValue = value;
           
            


            if (valueUser - size <= 0.0)
            {
                rightColumn.Width = new GridLength(0, GridUnitType.Absolute);
                if (valueUser == 0)
                {
                    leftColumn.Width = new GridLength(0);
                }
                else
                {
                    leftColumn.Width = new GridLength(valueUser, GridUnitType.Star);
                }
               
                size = valueUser;
            }
            else if (size < 0.0)
            {
                rightColumn.Width = new GridLength(1, GridUnitType.Star);
                leftColumn.Width = new GridLength(0, GridUnitType.Absolute);
                size = 0;
            }
            else
            {
                if (valueUser - size < 1)
                {
                    rightColumn.Width = new GridLength(0);
                }
                else
                {
                    rightColumn.Width = new GridLength(valueUser - size, GridUnitType.Star);
                }
                if (size == 0)
                {
                    leftColumn.Width = new GridLength(0);
                }
                else
                {
                    leftColumn.Width = new GridLength(size, GridUnitType.Star);
                }
               
            }

        }
        public void setColumnSizeFast(double value)
        {
            if (value > oldValue)
            {
                size = value;
            }
            else
            {
                size = value;
            }
            oldValue = value;




            if (valueUserFast - size <= 0.0)
            {
                rightColumnFast.Width = new GridLength(0, GridUnitType.Absolute);
                if (valueUserFast == 0)
                {
                    leftColumnFast.Width = new GridLength(0);
                }
                else
                {
                    leftColumnFast.Width = new GridLength(valueUserFast, GridUnitType.Star);
                }

                size = valueUserFast;
            }
            else if (size < 0.0)
            {
                rightColumnFast.Width = new GridLength(1, GridUnitType.Star);
                leftColumnFast.Width = new GridLength(0, GridUnitType.Absolute);
                size = 0;
            }
            else
            {
                if (valueUser - size < 1)
                {
                    rightColumnFast.Width = new GridLength(0);
                }
                else
                {
                    rightColumnFast.Width = new GridLength(valueUser - size, GridUnitType.Star);
                }
                if (size == 0)
                {
                    leftColumnFast.Width = new GridLength(0);
                }
                else
                {
                    leftColumnFast.Width = new GridLength(size, GridUnitType.Star);
                }

            }

        }


        public string Slow
        {
            get
            {
                return low + "/" + Setting.DataSugarChoice.SlowSugar * Multi + " gr";
            }
            set
            {
               OnPropertyChanged();
            }
        }
        public string Fast
        {
            get
            {
                return rapid + "/" + Setting.DataSugarChoice.FastSugar * Multi + " gr";
            }
            set
            {
                OnPropertyChanged();
            }
        }
        private double low;
        double rapid ;
        public void Calc()
        {
             low = 0;
             rapid = 0;
            foreach (var item in Products)
            {
                low += item.Calc().Item1;
                rapid += item.Calc().Item2;

            }
            //setColumnFast(rapid);
            Slow = "";
            Fast = "";
            setColumnSize(low);
            setColumnSizeFast(rapid);
      }

      

        public double Multi
        {
            get { return _multi; }
            set
            {
                _multi = value;
                Calc();
                OnPropertyChanged();

            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChoicePage(Generate.GenerateRestaurant()[Setting.CurrentRestaurant]));
        }

        private void TapGestureRecognizerAddMulti_OnTapped(object sender, EventArgs e)
        {
            if (Multi < 3)
            {
                if (Multi == 1)
                {
                    Multi = 1.5;
                }
                else if (Multi == 1.5)
                {
                    Multi = 2;
                }
                else if (Multi == 2)
                {
                    Multi = 3;
                }
            }
        }

        private void TapGestureRecognizerRemoveMulti_OnTapped(object sender, EventArgs e)
        {
            if (Multi > 1)
            {
                if (Multi == 3)
                {
                    Multi = 2;
                }
                else if (Multi == 2)
                {
                    Multi = 1.5;
                }
                else if (Multi == 1.5)
                {
                    Multi = 1;
                }
            }
        }
    }
}
