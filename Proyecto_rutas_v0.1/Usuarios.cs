using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_rutas_v0._1
{
    class Usuarios : Conexion
    {
        private string usuario;
        private string contraseña;

        public Usuarios()
        {
            usuario = string.Empty;
            contraseña = string.Empty;
            this.sql = string.Empty;

        }
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        public string Contraseña
        {
            get { return this.contraseña; }
            set { this.contraseña = value; }

        }
        public bool Buscar()
        {
            bool Resultado = false;
            this.sql = string.Format(@"SELECT Id_Usuario FROM Usuarios Where Nickname='{0}' AND Contraseña='{1}'", this.usuario, this.contraseña);
            this.ComandoSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            SqlDataReader reg = null;
            reg = this.ComandoSql.ExecuteReader();
            if(reg.Read())
            {
                Resultado = true;
                this.mensaje = "Bienvenido";
                

            }
            else
            {
                this.mensaje = "Datos Incorrectos";

            }

            this.cnn.Close();
            return Resultado;
        }
    }
}
