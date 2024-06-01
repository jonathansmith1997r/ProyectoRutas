using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Proyecto_rutas_v0._1
{
    class Conexion
    {
        public string cadenaconexion;
        protected string sql;
        protected int resultado;
        protected SqlConnection cnn;
        protected SqlCommand ComandoSql;
        protected string mensaje;

        public Conexion()
        {
            this.cadenaconexion = (@"data Source=(local);Initial Catalog = Usuarios; integrated security=true");
            this.cnn = new SqlConnection(this.cadenaconexion);

        }
        public string Mensaje
        {
            get
            {
                return this.mensaje;
            }
        }
    }
}
