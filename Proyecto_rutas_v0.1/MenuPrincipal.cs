using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

//using System.Threading;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Proyecto_rutas_v0._1
{
    public partial class MenuPrincipal : Form
    {
        double LatInicial = 22.1466994;
        double LonInicial = -101.0154038;

        Timer hora;

        //Thread actua

        Ruta ruta2 = new Ruta();
        Ruta ruta10 = new Ruta();
        Ruta ruta12 = new Ruta();
        Ruta ruta24 = new Ruta();
        Ruta ruta28 = new Ruta();
        Ruta ruta31 = new Ruta();
        Ruta ruta34 = new Ruta();

        
        GMapOverlay markers = new GMapOverlay("markers");

        GMapOverlay ruta2o = new GMapOverlay("Ruta");
        GMapOverlay ruta10o = new GMapOverlay("Ruta");
        GMapOverlay ruta12o = new GMapOverlay("Ruta");
        GMapOverlay ruta24o = new GMapOverlay("Ruta");
        GMapOverlay ruta28o = new GMapOverlay("Ruta");
        GMapOverlay ruta31o = new GMapOverlay("Ruta");
        GMapOverlay ruta34o = new GMapOverlay("Ruta");

        bool simulacion = false;

        delegate void Delegado(string str);

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            GMapProviders.GoogleMap.ApiKey = @"AIzaSyA5dEbbeqn3GkB4V0B9S-3n8Yy0kQXQwkM";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.CacheLocation = @"cache";
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LonInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;
            CRutas();

            hora = new Timer();
            hora.Tick += new EventHandler(eventoTimer);
            hora.Enabled = true;




            

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /*
        private void DibujaRuta(String Rt)
        {
            Pen Stroke;
            GMapOverlay ruta = new GMapOverlay("Ruta");

            Ruta ruta27 = new Ruta();
            Stroke = new Pen(Color.DarkGreen, 2);
            ruta27.Archivo = Rt;
            ruta27.CargaRutaF();
            //MessageBox.Show(ruta27.ContLinea.ToString());
            
            try
            {
                GMapRoute rutaPts = new GMapRoute(ruta27.puntos, "Ruta");
                ruta.Routes.Add(rutaPts);
                gMapControl1.Overlays.Add(ruta);
                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR "+e.Message);
            }
 
             
           
           
        }
        */

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CRutas()
        {
        

            ruta2.Archivo = "ruta2.txt";
            ruta10.Archivo = "ruta10.txt";
            ruta12.Archivo = "ruta12.txt";
            ruta24.Archivo = "ruta24.txt";
            ruta28.Archivo = "ruta28.txt";
            ruta31.Archivo = "ruta31.txt";
            ruta34.Archivo = "ruta34.txt";

            ruta2.CargaRutaF();
            ruta10.CargaRutaF();
            ruta12.CargaRutaF();
            ruta24.CargaRutaF();
            ruta28.CargaRutaF();
            ruta31.CargaRutaF();
            ruta34.CargaRutaF();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = checkedListBox1.SelectedIndex;
            
            if (indice != -1)
            {
                
                    if (checkedListBox1.GetItemChecked(0))
                {
                        
                        GMapRoute rutaPts = new GMapRoute(ruta2.puntos, "Ruta");
                        ruta2o.Routes.Add(rutaPts);
                        gMapControl1.Overlays.Add(ruta2o);
                        gMapControl1.Update();
                        gMapControl1.Zoom = gMapControl1.Zoom + 1;
                        gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("INFO NOT AVAIBLE");


                        simulacion = true;

                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta2o);
                }
                if (checkedListBox1.GetItemChecked(1))
                {
                    GMapRoute rutaPts = new GMapRoute(ruta10.puntos, "Ruta");
                    ruta10o.Routes.Add(rutaPts);
                    gMapControl1.Overlays.Add(ruta10o);
                    gMapControl1.Update();
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("Perimetral");

                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta10o);
                    gMapControl1.Update();

                }
                if (checkedListBox1.GetItemChecked(2))
                {
                    GMapRoute rutaPts = new GMapRoute(ruta12.puntos, "Ruta");
                    ruta12o.Routes.Add(rutaPts);
                    gMapControl1.Overlays.Add(ruta12o);
                    gMapControl1.Update();
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("Las Mercedes - B. Anaya - Alameda");
                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta12o);
                    gMapControl1.Update();

                }
                if (checkedListBox1.GetItemChecked(3))
                {
                    GMapRoute rutaPts = new GMapRoute(ruta24.puntos, "Ruta");
                    ruta24o.Routes.Add(rutaPts);
                    gMapControl1.Overlays.Add(ruta24o);
                    gMapControl1.Update();
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("Jassos – Santa Rita – Pozos – Av. Industrias – Alameda");
                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta24o);
                    gMapControl1.Update();

                }
                if (checkedListBox1.GetItemChecked(4))
                {
                    GMapRoute rutaPts = new GMapRoute(ruta28.puntos, "Ruta");
                    ruta28o.Routes.Add(rutaPts);
                    gMapControl1.Overlays.Add(ruta28o);
                    gMapControl1.Update();
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("Colonia Progreso – Av. Salvador Nava – Hospital Central – Muñoz – Ma. Cecilia");
                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta28o);
                    gMapControl1.Update();

                }
                if (checkedListBox1.GetItemChecked(5))
                {
                    GMapRoute rutaPts = new GMapRoute(ruta31.puntos, "Ruta");
                    ruta31o.Routes.Add(rutaPts);
                    gMapControl1.Overlays.Add(ruta31o);
                    gMapControl1.Update();
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("Centro - Balcones Del Valle");
                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta31o);
                    gMapControl1.Update();

                }
                if (checkedListBox1.GetItemChecked(6))
                {
                    GMapRoute rutaPts = new GMapRoute(ruta34.puntos, "Ruta");
                    ruta34o.Routes.Add(rutaPts);
                    gMapControl1.Overlays.Add(ruta34o);
                    gMapControl1.Update();
                    gMapControl1.Zoom = gMapControl1.Zoom + 1;
                    gMapControl1.Zoom = gMapControl1.Zoom - 1;

                    Delegado d = new Delegado(this.CambiarInfo);
                    d("	Avenida Ferrocarril – Alameda – Constitucion – Avenida Salvador Nava – Morales");
                }
                else
                {
                    gMapControl1.Overlays.Remove(ruta34o);
                    gMapControl1.Update();

                }


            }
            

        }
      


        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void eventoTimer(object ob, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            reloj.Text = hoy.ToString("hh:mm:ss tt");
        }

        private void btSimulacion_Click(object sender, EventArgs e)
        {
            Simulacion sim = new Simulacion();

            sim.Show();
            this.Close();
        }
        private void CambiarInfo(string msg)
        {
            Inform.Text = msg;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            centroRecHEB();
            centroRecVias();

        }

        public void centroRecHEB()
        {
            PointLatLng centroRecHEB = new PointLatLng(22.148337, -101.014094); //Coordenadas centro de recarga
            GMapMarker marker = new GMarkerGoogle(centroRecHEB, GMarkerGoogleType.green_dot); //Crea marker
            GMapOverlay markers = new GMapOverlay("Marcadores");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Boletur HEB\nAv Venustiano Carranza 2365-2373\nGlorieta, San Luis, S.L.P.\nTel. 8-33-23-43");
        }

        public void centroRecVias()
        {
            PointLatLng centroRecVias = new PointLatLng(22.170856, -100.998061);
            GMapMarker marker = new GMarkerGoogle(centroRecVias, GMarkerGoogleType.green_dot); //Crea marker
            GMapOverlay markers = new GMapOverlay("Marcadores");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Boletur Aviación\nAv Hernán Cortés 230\nInd Aviación, San Luis, S.L.P.\nTel. 8-33-23-40");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Form2 rutas = new Form2();
            rutas.Show();

            this.Hide();*/
        }
    }
}
