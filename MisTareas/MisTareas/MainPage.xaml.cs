using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MisTareas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Al hacer click en la barra de herramientas sobre el elemento 'Añadir tarea +' naveguaremos hacia la pagina para introducir nuevas tareas
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevaTarea());
        }

        //Cada vez que se muestre la pagina inicial y hacer que se carguen los datos almacenados desde la tabla Tareas, debemos sobrescribir el metodo OnAppearing() con lo siguiente.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                //Convertiremos el contenido de la tabla en una lista, la almacenamos en una variable y se la asignamos al elemento ListView, haciendo referencia al mismo a traves de su clave x:Name.
                conn.CreateTable<Tarea>();
                var tareas = conn.Table<Tarea>().ToList();
                ListaTareasView.ItemsSource = tareas;
            }
        }
    }
}
