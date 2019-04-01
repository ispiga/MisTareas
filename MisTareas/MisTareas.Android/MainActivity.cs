using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace MisTareas.Droid
{
    [Activity(Label = "MisTareas", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            //Al cargarse la aplicacion se genera una instancia App().
            //LoadApplication(new App());

            //Lo que necesitamos es que se utilice en el lugar de la instancia anterior, otro constructor, que sera el que hemos creado en App.xaml.cs, para poder pasarle como parametro la ruta de la base de datos.
            //Añadimos tambien las siguientes variables para la ruta de la base de datos.
            string fileName = "tareas.db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLocation, fileName);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(full_path)); 
        }
    }
}