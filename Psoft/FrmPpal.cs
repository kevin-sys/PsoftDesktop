using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY;
using BLL;
namespace Psoft
{
    public partial class FrmPpal : Form
    {

        ClienteService clienteService = new ClienteService();
        public FrmPpal()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
         
        }

        private void abrirformve(Form f)
        {

            if (this.panelcontenedor.Controls.Count > 0)
            {

                this.panelcontenedor.Controls.RemoveAt(0);
            }
            f.TopLevel = false;
            this.panelcontenedor.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();

        }

        private void btonCasa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirformve(new FrmRegistarproducto());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            abrirformve(new FrmVenta());
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas cerrar la aplicacion?", "Advertencia",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            abrirformve(new FrmContabilidad());
        }
    }
}
