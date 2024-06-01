namespace Proyecto_rutas_v0._1
{
    partial class Simulacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gMapSimula = new GMap.NET.WindowsForms.GMapControl();
            this.tTiempo = new System.Windows.Forms.Timer(this.components);
            this.lbPrueba = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(72)))));
            this.panel1.Controls.Add(this.lbPrueba);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regresar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // gMapSimula
            // 
            this.gMapSimula.Bearing = 0F;
            this.gMapSimula.CanDragMap = true;
            this.gMapSimula.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapSimula.GrayScaleMode = false;
            this.gMapSimula.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapSimula.LevelsKeepInMemmory = 5;
            this.gMapSimula.Location = new System.Drawing.Point(12, 52);
            this.gMapSimula.MarkersEnabled = true;
            this.gMapSimula.MaxZoom = 2;
            this.gMapSimula.MinZoom = 2;
            this.gMapSimula.MouseWheelZoomEnabled = true;
            this.gMapSimula.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapSimula.Name = "gMapSimula";
            this.gMapSimula.NegativeMode = false;
            this.gMapSimula.PolygonsEnabled = true;
            this.gMapSimula.RetryLoadTile = 0;
            this.gMapSimula.RoutesEnabled = true;
            this.gMapSimula.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapSimula.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapSimula.ShowTileGridLines = false;
            this.gMapSimula.Size = new System.Drawing.Size(776, 386);
            this.gMapSimula.TabIndex = 1;
            this.gMapSimula.Zoom = 0D;
            // 
            // tTiempo
            // 
            this.tTiempo.Tick += new System.EventHandler(this.tTiempo_Tick);
            // 
            // lbPrueba
            // 
            this.lbPrueba.AutoSize = true;
            this.lbPrueba.Location = new System.Drawing.Point(203, 18);
            this.lbPrueba.Name = "lbPrueba";
            this.lbPrueba.Size = new System.Drawing.Size(0, 13);
            this.lbPrueba.TabIndex = 2;
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gMapSimula);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Simulacion";
            this.Text = "Simulacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Simulacion_FormClosing);
            this.Load += new System.EventHandler(this.Simulacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gMapSimula;
        private System.Windows.Forms.Timer tTiempo;
        private System.Windows.Forms.Label lbPrueba;
    }
}