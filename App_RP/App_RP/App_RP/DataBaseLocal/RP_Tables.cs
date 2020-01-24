using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace App_RP.DataBaseLocal
{
    public class Perfil
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;}
        public int  PerfilId { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

    }
}

