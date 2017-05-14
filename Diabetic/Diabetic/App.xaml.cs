using System;
using System.Collections.Generic;
using System.Linq;
using Diabetic.Helpers;
using Diabetic.Models;
using Diabetic.Utils;
using Diabetic.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Diabetic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        
            SetMainPage();
        }

        public static void SetMainPage()
        {
            List<Zoo> tmp = new List<Zoo>()
            {
                  new Zoo
            {
                ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                Name = "Woodland Park Zoo"
            },
                new Zoo
            {
                ImageUrl =    "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                Name = "Cleveland Zoo"
                },
            new Zoo
            {
                ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                Name = "Phoenix Zoo"
            }
            };
            List<Page> tmpPage = new List<Page>();
            new DataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("data.db3"));

            var contact =DataBase.Database.GetContacts();
            if (contact.Count>0)
            {
                Setting.User = contact.First();
                Current.MainPage = new NavigationPage(new FirstPage());
            }
            else
            {
                Current.MainPage = new NavigationPage(new InscriptionPage());
            }
          
         

        }


    }
}
