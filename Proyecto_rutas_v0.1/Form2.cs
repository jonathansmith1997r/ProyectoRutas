using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Threading;

namespace Proyecto_rutas_v0._1
{
    public partial class Form2 : Form
    {
        Bitmap bmpMarker = (Bitmap)Image.FromFile("img/camion.png");
        List<PointLatLng> punto = new List<PointLatLng>();
        Ruta simula = new Ruta();
        GMapOverlay simulac = new GMapOverlay("Ruta");

        Thread hiloCamion, refresh;

        public Form2()
        {
            InitializeComponent();
        }

        private void cRuta()
        {
            simula.Archivo = "Simula.txt";
            simula.CargaRutaF();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
            this.Close();
        }


        public void cargaPng()
        {
            for (int i = 0; i < 5; i++)
            {
                MessageBox.Show(simula.puntos[i].ToString());
                GMapMarker marcador = new GMarkerGoogle(simula.puntos[i], bmpMarker);
                GMapOverlay marcadores = new GMapOverlay("marcadores");

                marcadores.Markers.Add(marcador);
                gMapControl1.Overlays.Add(marcadores);
                //gMapSimula.Zoom = gMapSimula.Zoom + 1;
                actualizaMap();
                Thread.Sleep(5000);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA5dEbbeqn3GkB4V0B9S-3n8Yy0kQXQwkM";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.CacheLocation = @"cache";
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(22.150528, -100.991706); //Tequisquiapan
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 100;
            gMapControl1.Zoom = 14;
            gMapControl1.ShowCenter = false;

            cRuta();

            //cargaPng();
            //tTiempo.Start();

            hiloCamion = new Thread(cargaPng);
            hiloCamion.Start();

            refresh = new Thread(actualizaMap);
            refresh.Start();
        }

        private void actualizaMap()
        {
            for (int i = 0; i < 200; i++)
            {
                gMapControl1.Zoom = gMapControl1.Zoom + 1; //Actualiza mapa
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
                Thread.Sleep(3000);
            }
        }
    }
}
