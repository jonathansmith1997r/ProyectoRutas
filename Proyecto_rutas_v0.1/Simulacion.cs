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
    public partial class Simulacion : Form
    {
        Bitmap bmpMarker = (Bitmap)Image.FromFile("img/camion.png");
        Bitmap bmpPatch = (Bitmap)Image.FromFile("img/parch.jpg");
        Bitmap bmpinv = (Bitmap)Image.FromFile("img/invisi.png");  //Agrega imagenes al proyecto para la simulación

        List<PointLatLng> punto = new List<PointLatLng>(); //Crea lista de puntos lat lnt
        Ruta simula = new Ruta(); //Instancia la clase de ruta que lee las coordenadas en txt
        GMapOverlay simulac = new GMapOverlay("Ruta"); //Añade el overlay a nuestro mapa
        

        Thread hiloCamion, refresh; //Creacion de 2 hilos para refrescar el mapa y añadir la imagen

        public Simulacion()
        {
            InitializeComponent();
        }

        /* Añade las coordenadas leyendolas desde la clase Ruta y las carga a la simulacion*/
        private void cRuta()
        {
            simula.Archivo = "Simula.txt";
            simula.CargaRutaF();
        }

        /*Nos regresa al menu principal*/
        private void label1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            menu.Show();
            this.Close();
        }

        /*Este hilo permite hacer una refresh del mapa, teniendo como objetivo dibujar los markers*/
        private void hilo()
        {
            refresh = new Thread(new ThreadStart(() =>
            {
                for (int n = 0; n < 100; n++)
                {
                    Thread.Sleep(3000); //Tiempo en milisegundos

                }
            }
            ));

            refresh.Start();
        }

        /*Carga todo lo necesario al form de simulacion como los mapas, zoom y todo lo demas*/
        private void Simulacion_Load(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA5dEbbeqn3GkB4V0B9S-3n8Yy0kQXQwkM"; //Llave que nos permite dibujar rutas en el mapa
            GMaps.Instance.Mode = AccessMode.ServerAndCache; //Modo de acceso al servidor de googleMaps
            gMapSimula.CacheLocation = @"cache"; //Accesa al servidor de googleMaps
            gMapSimula.MapProvider = GMapProviders.GoogleMap; 
            gMapSimula.Position = new PointLatLng(22.150528, -100.991706); //Tequisquiapan
            gMapSimula.MinZoom = 5; //minimo de acercamiento al mapa
            gMapSimula.MaxZoom = 100;
            gMapSimula.Zoom = 13;
            gMapSimula.ShowCenter = false; //Nos esconde las cruz roja del mapa

            cRuta();

            //cargaPng();
            //tTiempo.Start();

            hiloCamion = new Thread(new ThreadStart(cargaPng)); //Crea el hilo que maneja el control de imagenes en la simulación
            hiloCamion.Start();
            hilo();

            /*refresh = new Thread(actualizaMap);
            refresh.Start();*/
        }

        /*Funcion main de simular
         * Comienza haciendo un ciclo de los puntos que hay en nuestro archivo txt
         * apartir de eso agrega una imagen png sola, ya que el mapa al ser la primea imagen 
         no se puede controlar donde se pone.
         por eso despues que agrego una, se agrega el png del camion al mapa, por medio de markers, se añaden 
         al overlays y al final, se hace un parche para que la imagen del bus no se vea por donde pasa en todo el tiempo
         y de la impresion de una animacion de verdad*/
        public void cargaPng()
        {
            for (int i = 0; i < 43; i++)
            {
                //gMapSimula.MarkersEnabled = true;
                //MessageBox.Show(simula.puntos[i].ToString());

                GMapMarker marcador = new GMarkerGoogle(simula.puntos[i], bmpinv);
                GMapOverlay marcadores = new GMapOverlay("marcadores");
                marcadores.Markers.Add(marcador);
                gMapSimula.Overlays.Add(marcadores);
                if (i >= 2)
                {
                    GMapMarker patch = new GMarkerGoogle(simula.puntos[i - 2], bmpPatch);
                    marcadores.Markers.Add(patch);
                }
                if (i > 0)
                {
                    GMapMarker camion = new GMarkerGoogle(simula.puntos[i - 1], bmpMarker);
                    marcadores.Markers.Add(camion);
                    gMapSimula.ZoomAndCenterMarkers(" marcadores");
                }

                //actualizaMap();
                //elimina = true;
                Thread.Sleep(5000);
            }
            /*refresh = new Thread(new ThreadStart(actualizaMap));
            refresh.Start();*/
        }

        private void actualizaMap()
        {
            /*for (int i = 0; i < 200; i++)
            {
                gMapSimula.Zoom = gMapSimula.Zoom + 1; //Actualiza mapa
                gMapSimula.Zoom = gMapSimula.Zoom - 1;
                Thread.Sleep(3000);
            }*/
        }

        private void tTiempo_Tick(object sender, EventArgs e)
        {

        }

        private void Simulacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //tTiempo.Stop();
        }
    }
}
