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
using InfraEstructura;

namespace Psoft
{
    public partial class FrmVenta : Form
    {

        ClienteService clienteService = new ClienteService();
        FacturaService facturaService=new FacturaService();
        DetalledeFacturaService detalledeFacturaService = new DetalledeFacturaService();
        Cliente cliente = new Cliente();
        Factura factura = new Factura();
        Producto producto = new Producto();
        List<DetalledeFactura> detalledeFacturas = new List<DetalledeFactura>();
        List<Factura> facturas = new List<Factura>();
        Email email = new Email();
        private DataTable dt;
        public FrmVenta()
        {
            InitializeComponent();
            Llenartabla();
            dateFecha.Enabled = false;
            cmboTipopago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Llenartabla()
        {
            dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Valor");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Valor Total");

            dtgVenta.DataSource = dt;
        }

        private double valortotal(double valor, int cantidad)
        {

            double valorTotal = valor * cantidad;

            return valorTotal;

        }

        private void Sum()
        {
            this.lbltotalcompra.Text = Convert.ToString(dtgVenta.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Valor Total"].Value)));
        }

        private void btonregistrarventa_Click(object sender, EventArgs e)
        {

            AgregarCiente();
            AgregarFactura();
            foreach (DataGridViewRow row in dtgVenta.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    AgregarDetalle(row);
                }

            }
            clienteService.Guardar(cliente);
            email.EnviarEmail(cliente);
            detalledeFacturaService.GuardarEnRango(detalledeFacturas);
            facturaService.GuardarFactura(factura);


        }

        private void AgregarCiente()
        {
            cliente.identificacion = txtidentificacion.Text.Trim();
            cliente.nombre = txtnombre.Text.Trim();
            cliente.telefono = txtelefono.Text.Trim();
            cliente.direccion = txtDireccion.Text.Trim();
            cliente.email = txtcorreo.Text.Trim();
        }

        private void AgregarFactura()
        {
            int idfactura = 1;

            factura.idfactura = idfactura;
            factura.Fecha = dateFecha.Text.Trim();
            factura.tipoPago = cmboTipopago.Text;
            factura.ValorTotalFactura = double.Parse(lbltotalcompra.Text.Trim());
            factura.nombreCliente = txtnombre.Text.Trim();
            factura.direccion = txtDireccion.Text.Trim();

                

        }

        private void AgregarDetalle(DataGridViewRow row)
        {
            detalledeFacturas.Add(new DetalledeFactura()
            {
                CodigoVenta = factura.idfactura,
                Cantidad = int.Parse(row.Cells[3].Value.ToString()),
                descripcionProducto = row.Cells[1].Value.ToString(),
                PrecioProducto = double.Parse(row.Cells[2].Value.ToString()),
                
            });
        }

        private void btnañadirtabla_Click(object sender, EventArgs e)
        {
            
            DataRow row = dt.NewRow();

            row["Codigo"] = txtidproducto.Text;
            row["Producto"] = txtNombrepro.Text;
            row["Valor"] = txtvalorunitario.Text;
            row["Cantidad"] = txtcantidad.Text;
            row["Valor Total"] = valortotal(double.Parse(txtvalorunitario.Text), int.Parse(txtcantidad.Text));
            dt.Rows.Add(row);

            Sum();


        }

        private void btneliminartabla_Click(object sender, EventArgs e)
        {
            dtgVenta.Rows.Remove(dtgVenta.CurrentRow);
           
            this.lbltotalcompra.Text = Convert.ToString(dtgVenta.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Valor Total"].Value)));


        }
    }
}
