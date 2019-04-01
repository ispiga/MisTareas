using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MisTareas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NuevaTarea : ContentPage
	{
		public NuevaTarea ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked (object sender, EventArgs e)
        {
            //DisplayAlert("Success", "Tarea correctamente guardada.", "¡Bien!");

            //Creamos una tarea y a continuacion se conectara con la base de datos para crear una tabla e insertar la tarea creada.
            Tarea tarea = new Tarea()
            {
                Nombre = nombreTarea.Text
            };

            //Utilizamos un using sentence, de modo que la variable conn solo existe en este contexto y al finalizar la ejecucion del bloque, la variable conn
            //es 'disposed' de forma equivalente que usar conn.Dispose().
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                //Creamos la tabla si no existe, y se inserta la nueva tarea. Si se inserta la fila con exito, se mostrara.
                conn.CreateTable<Tarea>();
                var numeroFilas = conn.Insert(tarea);

                if (numeroFilas > 0)
                    DisplayAlert("Success", "Tarea correctamente guardada.", "¡Bien!");
                else
                    DisplayAlert("Failure", "Fallo al guardar la tarea.", "¡Lo sentimos!");
            }
        }
	}
}