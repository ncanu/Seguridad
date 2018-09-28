using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CambioDeHost;
using CapaInterfazMantenimientoUsuarios;
using CapaInterfazAsignacionDePerfiles;
using CapaInterfazIngresoModulos;
using CapaInterfazMantenimientoAplicaciones;
using InicioSesion;
using gestionPerfiles;
using BITACORA;


namespace Seguridad2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  


        private void AbrirForm(object dshijo)
        { 
            if (this.panel1.Controls.Count > 2)
                this.panel1.Controls.RemoveAt(0);
            Form ds = dshijo as Form;
            ds.TopLevel = false;
            ds.Dock = DockStyle.None;
            int px = ((this.Width / 2) - (ds.Width / 2));
            int py = ((this.Height / 2) - (ds.Height / 2));
            ds.Location = new Point(px,py);
            this.panel1.Controls.Add(ds);
            this.panel1.Tag = ds;
            ds.Show();
            ds.BringToFront();


        }

        private void cambioDeServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazCambioDeHost ich = new InterfazCambioDeHost();
            AbrirForm(ich);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            this.panel1.Size = this.Size;
            InicioSesionForm inicioSes = new InicioSesionForm();
            inicioSes.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            inicioSes.ShowDialog();
            inicioSes.TopMost = true;
            inicioSes.Activate();

        }



        void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Usuario u = new Usuario();
            string nombre = u.obtenerUsuario();
            if (nombre != "")
            {
                label9.Text = nombre;
                menuStrip1.Enabled = true;
            }
            else {
                menuStrip1.Enabled = false;
                this.Close();
            }
            

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            DateTime fecha = DateTime.Now;
            this.labelFecha.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
            this.labelHora.Text = String.Format("{0:HH:mm:ss}", DateTime.Now);
            timer1.Interval = 1000;
            timer1.Start();
            panel2.Location = new Point(20, this.Height - 175);
            panel3.Location = new Point(this.Width - 300, this.Height - 115);
            /*groupBox1.Location = new Point(50, this.Height - 220);
            groupBox2.Location = new Point(this.Width - 350, this.Height - 220);*/

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.labelFecha.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
            this.labelHora.Text = String.Format("{0:hh:mm:ss}", DateTime.Now);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel2.Location = new Point(50, this.Height - 220);
            panel3.Location = new Point(this.Width - 350, this.Height - 220);
            /*groupBox1.Location = new Point(50, this.Height - 220);
            groupBox2.Location = new Point(this.Width - 350, this.Height - 220);*/
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.Size = this.Size;
        }

        private void ingresoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazCrearUsuarios imu = new InterfazCrearUsuarios();
            AbrirForm(imu);
        }

        private void consultaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interfaz_Mostrar_Usuarios imu = new Interfaz_Mostrar_Usuarios();
            AbrirForm(imu);
        }

        public void ModificarUsuario()
        {
            Interfaz_Modificar_Usuarios imu = new Interfaz_Modificar_Usuarios();
            AbrirForm(imu);
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interfaz_Modificar_Usuarios imu = new Interfaz_Modificar_Usuarios();
            AbrirForm(imu);
        }

        private void asignacionDePerfilesAUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazAsignacionDePerfiles iadp = new InterfazAsignacionDePerfiles();
            AbrirForm(iadp);
        }

        private void ingresarModuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazIngresoModulos iim = new InterfazIngresoModulos();
            AbrirForm(iim);
        }

        private void modificarModuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazModificarModulos imm = new InterfazModificarModulos();
            AbrirForm(imm);
        }

        private void consultarModuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interfaz_Consultar_Modulos imm = new Interfaz_Consultar_Modulos();
            AbrirForm(imm);
        }

        private void ingresarAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazIngrearAplicaciones imm = new InterfazIngrearAplicaciones();
            AbrirForm(imm);
        }

        private void consultarAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazMostrarAplicaciones imm = new InterfazMostrarAplicaciones();
            AbrirForm(imm);
        }

        private void modificarAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazModificarAplicaciones imm = new InterfazModificarAplicaciones();
            AbrirForm(imm);
        }

        private void ingresarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileCreate prc = new profileCreate();
            AbrirForm(prc);
        }

        private void modificarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileMantenimiento prof = new profileMantenimiento();
            AbrirForm(prof);
        }

        private void reportesDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesDeBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacora frm = new frmBitacora();
            AbrirForm(frm);
        }

        private void cambioDeContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambioContraseñaUsuarios ccu = new CambioContraseñaUsuarios();
            ccu.UsuarioActual = label9.Text;
            AbrirForm(ccu);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labelHora_Click(object sender, EventArgs e)
        {

        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            label9.Text = us.obtenerUsuario();
        }
    }
}
