using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MisTareas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            //Hacemos que la aplicacion muestre al principio una pagina de navegacion NavigationPage, en lugar de una pagina  principal simple.
            MainPage = new NavigationPage(new MainPage());
        }

        //Creamos una variable que almacenara el PATH de la base de datos.
        public static string DB_PATH = string.Empty;

        //Constructor el cual le pasamos como parametro la ruta de la base de datos
        public App(string DB_Path)
        {
            InitializeComponent();

            DB_PATH = DB_Path;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
