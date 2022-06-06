using BLL;
using ENTITY;
using System;
using System.Windows.Forms;
namespace Psoft
{
    public partial class FrmRegistarproducto : Form
    {




        public FrmRegistarproducto()
        {
            InitializeComponent();
            LlenarTabla();



        }


        private void LlenarTabla()
        {
            dtgProducto.DataSource = null;
            dtgProducto.DataSource = ProductoService.ConsultarTodos();
        }

        private double valorUtilidad(double valorCosto, double valorVenta)
        {

            double valorUtilidad = valorVenta - valorCosto;

            return valorUtilidad;

        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {




            ProductoService service = new ProductoService();
            Producto producto = new Producto();
            producto.nombre = txtNombre.Text.Trim();
            producto.valorCosto = double.Parse(txtCosto.Text.Trim());
            producto.valorVenta = double.Parse(txtVenta.Text.Trim());
            producto.utilidad = valorUtilidad(double.Parse(txtCosto.Text), double.Parse(txtVenta.Text));
            string mensaje = service.Guardar(producto);
            MessageBox.Show(mensaje, "MENSAJE DE GUARDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            LlenarTabla();


        }

        private void FrmRegistarproducto_Load(object sender, EventArgs e)
        {

        }


    }
}
