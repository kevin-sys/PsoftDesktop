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
    public partial class FrmContabilidad : Form
    {
        List<Factura> facturas;
        FacturaService facturaService;
        
        private DataTable dt;
        public FrmContabilidad()
        {
            InitializeComponent();
            facturaService = new FacturaService();
            facturas = new List<Factura>();
            Llenartabla();
            
            
        }

        private void Llenartabla()
        {
            //Defino las columnas de las tablas
            dt = new DataTable();
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Codigo Factura");
            dt.Columns.Add("Tipo de Pago");
            dt.Columns.Add("Valor Venta");
            dt.Columns.Add("Valor Utilidad");

            dtgContabilidad.DataSource = dt;

        }

        
        private void LlenarDtg(RespuestaConsulta consultaResponse)
        {
              RespuestaConsulta respuestaConsulta = facturaService.Consultar();

            if (respuestaConsulta.Facturas !=null) {
                foreach (var item in consultaResponse.Facturas)
                {
                    dtgContabilidad.Rows.Add(
                        item.Fecha,
                        item.idfactura,
                        item.tipoPago,
                        item.ValorTotalFactura,
                        item.ValorTotalUtilidad
                        );
                }
            }

           
        }

        private void Consultar()
        {
           

        }



        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            FacturaService facturaServi = new FacturaService();
            RespuestaConsulta respuestaConsulta = facturaServi.Consultar();
            Console.WriteLine(respuestaConsulta.Mensaje);
            if (respuestaConsulta.Facturas != null)
            {
                 foreach (Factura item in respuestaConsulta.Facturas)
                {
                    MostrarDatos(item);

                }
            }
        }

        private void MostrarDatos(Factura item)
        {

            foreach (DataGridViewRow row in dtgContabilidad.Rows) {

                if (row.Cells[0].Value != null) {

                    dtgContabilidad.Rows.Add(
                                  row.Cells[1].Value = item.Fecha,
                                  row.Cells[2].Value = item.idfactura,
                                  row.Cells[3].Value = item.tipoPago,
                                  row.Cells[4].Value = item.ValorTotalFactura,
                                  row.Cells[5].Value = item.ValorTotalUtilidad
                                    );

                }
            
            }

            
        }

        private void FrmContabilidad_Load(object sender, EventArgs e)
        {

        }
    }
}
