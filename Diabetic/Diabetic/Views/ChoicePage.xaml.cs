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

    

public class Zoo
    {
        public ImageSource ImageUrl { get; set; }
        public string Name { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChoicePage : ContentPage
    {
        public string toto = "ff";
        private Category _categorySelected;
        private Product _product;
        private int _itemCount;
        public static ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<Product> Products2 => Products;

        public ObservableCollection<Product> ProductsSelected { get; set; } 
        public Restaurant Restaurant { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                if (value != null)
                {
                    ProductsSelected.Add(new Product(Guid.NewGuid(), value.Name, value.SlowSugar,value.RapidSugar,value.Img));
                    ItemCount = ProductsSelected.Count;
                }
            
                
            }
        }

        public Category CategorySelected
        {
            get { return _categorySelected; }
            set
            {
                _categorySelected = value;
                Products = new ObservableCollection<Product>(_categorySelected.Products);
                OnPropertyChanged(nameof(Products));
                OnPropertyChanged(nameof(Products2));
            }
        }

        public int ItemCount
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;
                OnPropertyChanged();
            }
        }

        public ChoicePage(Restaurant restaurant)
        {
         
            InitializeComponent();
            ProductsSelected = new ObservableCollection<Product>();
            Restaurant = restaurant;
            Categories = new ObservableCollection<Category>(Restaurant.Categories);
            Products = new ObservableCollection<Product>(restaurant.Categories[0].Products);
            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(Products2));

            BindingContext = this;
            Icon = ImageSource.FromResource($"Diabetic.Assets.Img.mcdo.png");
            NavigationPage.SetHasNavigationBar(this, false);
            ReturnCommand = new Command(Return);
            ParamCommand = new Command(Param);
        }

        public void Param()
        {
            Navigation.PushAsync(new InscriptionPage());
        }
        public Command ParamCommand { get; set; }
        public Command ReturnCommand { get; set; }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Product = null;
            Products = null;
            Restaurant = null;
            GC.Collect();
        }
        public void Return()
        {
            OnBackButtonPressed();
            //this.Navigation.PushAsync(this.Navigation.NavigationStack[0]);
            foreach (var page in this.Navigation.NavigationStack)
            {
                this.Navigation.RemovePage(page);
            }
            System.GC.Collect();



        }

        public ImageSource Icon { get; set; }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultPage(ProductsSelected));
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RestaurantChoicePage());
        }

        private void TapGestureRecognizerResult_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultPage(ProductsSelected));
        }

        private void TapGestureRecognizerA_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionPage());
        }
    }

    
}
