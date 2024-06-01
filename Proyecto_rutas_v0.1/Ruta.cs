using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Threading;

namespace Proyecto_rutas_v0._1
{
    class Ruta
    {
        
        public String Archivo;
        public int ContLinea = 0;
        public List<PointLatLng> puntos = new List<PointLatLng>();



        public Ruta()
        {

        }
    
     
        public void CargaRutaF()
        {
            StreamReader lectura = File.OpenText(Archivo);
            string linea;
            string[] campos = new string[2];
            char[] separador = { ',' };
            int i = 0;

            while ((linea = lectura.ReadLine()) != null)
            {
                ContLinea += 1;
                campos = linea.Split(separador);
                puntos.Add(new PointLatLng(double.Parse(campos[i]), double.Parse(campos[i + 1])));
            }
            lectura.Close();
        }

    }
}
