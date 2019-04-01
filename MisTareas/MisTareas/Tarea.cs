using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisTareas
{
    class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
