
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealMTest
{
    public class Product : RealmObject
    {
        public string Name { get; set; }
    }

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static string LocalPath = "";
        public MainPage()
        {
            InitializeComponent();
            var realm = Realm.GetInstance(Path.Combine(LocalPath, "RealmSample.realm"));
            realm.Write(() =>
            {
                realm.Add(new Product()
                {
                    Name = "Test"
                });
            });
            BindingContext = realm.All<Product>().FirstOrDefault();  
        }
    }
}
