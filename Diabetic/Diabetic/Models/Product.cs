using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Diabetic.Annotations;
using Xamarin.Forms;


namespace Diabetic.Models
{
    public class Product : INotifyPropertyChanged
    {
        private bool _firstVisible;
        private bool _secondVisible;
        private bool _treeVisible;
        private bool _quadrupleVisible;
        public Guid Guid { get; set; } 
        public string Name { get; set; }
        public ImageSource Img { get; set; }
        public double SlowSugar { get; set; }
        public double RapidSugar { get; set; }
        
        public bool FirstVisible
        {
            get { return _firstVisible; }
            set
            {
                _firstVisible = value; 
                OnPropertyChanged();
            }
        }

        public bool SecondVisible
        {
            get { return _secondVisible; }
            set
            {
                _secondVisible = value;
                OnPropertyChanged();
            }
        }

        public bool TreeVisible
        {
            get { return _treeVisible; }
            set
            {
                _treeVisible = value;
                OnPropertyChanged();
            }
        }

        public bool QuadrupleVisible
        {
            get { return _quadrupleVisible; }
            set
            {
                _quadrupleVisible = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<int> SelectedPortion { get; set; }

        public Tuple<Double,Double> Calc()
        {

            var dd = SlowSugar/4;
            var rapid = RapidSugar/4;
            return new Tuple<double, double>(dd*SelectedPortion.DefaultIfEmpty().Max(),rapid * SelectedPortion.DefaultIfEmpty().Max());
        }
      

        public Product(Guid guid, string name, double slowSugar, double rapidSugar, ImageSource img)
        {
            Guid = guid;
            Name = name;
            SlowSugar = slowSugar;
            RapidSugar = rapidSugar;
            
            SlowSugar = slowSugar - rapidSugar;
            if (SlowSugar < 0)
            {
                SlowSugar = 0;
            }
            Img = img;
            SelectedPortion = new ObservableCollection<int>();
            FirstVisible = true;
            SecondVisible = true;
            TreeVisible = true;
            QuadrupleVisible = true;
            SelectedPortion.Add(1);
            SelectedPortion.Add(2);
            SelectedPortion.Add(3);
            SelectedPortion.Add(4);


        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}