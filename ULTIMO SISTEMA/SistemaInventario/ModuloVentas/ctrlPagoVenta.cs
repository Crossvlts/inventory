using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SistemaInventario.Modelos;
using System.Data.Entity;

namespace SistemaInventario.ModuloVentas
{
    public partial class ctrlPagoVenta : DevExpress.XtraEditors.XtraForm
    {
        int ventaID = 0;
        public ctrlPagoVenta(int venta)
        {
            ventaID = venta;

            InitializeComponent();
        }
        ventasEntities db = new ventasEntities();
        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPago_Load(object sender, EventArgs e)
        {
            CargarFormulario(false);
            cargarMetodoPago();
            txtMontoPago.Select();
            txtMontoPago.Focus();
        }

        private void CargarFormulario(bool procesarIGTF)
        {
            try
            {
                var configur = db.Configuracion.FirstOrDefault();
                decimal impuesto = configur.Impuesto.Value;
                decimal IGTF = configur.IGTF != null ? configur.IGTF.Value : 0;

                var detalle = db.VentasDetalle.Where(x => x.ventaID == ventaID).ToList();
                lblID.Text = ventaID.ToString();
                decimal TotalPagar = 0;
                decimal TotalImpuesto = 0;
                decimal TotalIGTF = 0;
                foreach (var item in detalle)
                {
                    decimal precioVenta = item.Productos.precioVenta.Value;
                    decimal cantidadVendida = item.cantidad.Value;
                    if (impuesto > 0)
                    {
                        if (item.Productos.exento != true)
                        {
                            decimal subTotal = precioVenta * cantidadVendida;
                            decimal Total = (((impuesto * subTotal) / 100) + subTotal);

                            TotalPagar = TotalPagar + Total;
                            TotalImpuesto = (TotalImpuesto + (impuesto * subTotal) / 100);
                            lblImpuesto.Text = TotalImpuesto.ToString(Comun.formatoMoneda);
                        }
                        else
                        {
                            decimal total = (precioVenta * cantidadVendida);
                            TotalPagar = TotalPagar + total;
                        }
                    }
                    else
                    {
                        decimal total = (precioVenta * cantidadVendida);
                        TotalPagar = TotalPagar + total;
                    }

                    if (procesarIGTF)
                    {
                        if (IGTF != 0)
                        {
                            TotalIGTF = TotalIGTF + ((IGTF * TotalPagar) / 100);
                            lblIGTF.Text = TotalIGTF.ToString(Comun.formatoMoneda);
                            TotalPagar = TotalPagar + TotalIGTF;
                        }
                        else
                        {
                            lblIGTF.Text = "0.0";

                        }
                    }
                    else
                    {
                        lblIGTF.Text = "0.0";
                    }

                }

                lblTotal.Text = TotalPagar.ToString(Comun.formatoMoneda);
                calcularCambio();
            }
            catch (Exception ex)
            {

            }
        }

        private void cargarMetodoPago()
        {
            try
            {
                var objeto = db.MetodosPago.Where(x => x.estatus == true).ToList();
                if (objeto.Count > 0)
                {
                    foreach (var item in objeto)
                    {
                        cmbMetodoPago.Properties.Items.Add(item.metodoPagoID + "-" + item.nombre);
                    }
                    cmbMetodoPago.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void Salir()
        {

            CtrlNuevaVenta frm = new CtrlNuevaVenta();

            this.Close();
        }


        private void procesarVenta()
        {
            try
            {
                string[] metodoPago = cmbMetodoPago.Text.Split('-');
                int metodoPagoID = Convert.ToInt32(metodoPago[0]);
                string[] MonedaSeleccionada = moneda.Text.Split('-');
                int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
                // Guardar en el registro de pago de ventas
                VentasPago cp = new VentasPago();
                cp.monto = Convert.ToDecimal(txtMontoPago.Text);
                cp.metodoPagoID = metodoPagoID;
                cp.ventaID = ventaID;
                cp.monedaID = monedaID;
                cp.cambio = Convert.ToDecimal(lblCambio.Text);


                db.VentasPago.Add(cp);
                db.SaveChanges();


                // desbloquear la venta 
                var venta = db.Ventas.Where(x => x.ventaID == ventaID).FirstOrDefault();
                venta.estatus = true;
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();

                // Actualizar el Stock 
                var ventaDetalle = db.VentasDetalle.Where(x => x.ventaID == ventaID).ToList();
                foreach (var item in ventaDetalle)
                {
                    try
                    {

                        Stock stock = new Stock();
                        stock.cantidad = -item.cantidad;
                        stock.fecha = DateTime.Now;
                        stock.productoID = item.productoID;
                        db.Stock.Add(stock);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception exx)
            {

            }

        }

        private void txtMontoPago_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblCambio_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPagoVenta_Load(object sender, EventArgs e)
        {
            cargarMonedas();
            CargarFormulario(false);
            cargarMetodoPago();

            txtMontoPago.Select();
            txtMontoPago.Focus();
        }
        private void cargarMonedas()
        {
            try
            {
                var objeto = db.Monedas.Where(x => x.estatus == true).ToList();
                if (objeto.Count > 0)
                {
                    foreach (var item in objeto)
                    {
                        moneda.Properties.Items.Add(item.monedaID + "-" + item.moneda);
                    }
                    moneda.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            procesar();
        }

        private void procesar()
        {
            if (cmbMetodoPago.Text == "" || txtMontoPago.Text == "0" || txtMontoPago.Text == "")
            {
                MessageBox.Show("Debe ingresar el método de pago y el monto a pagar", "Error");
                return;
            }
            else
            {
                decimal cambio = Convert.ToDecimal(lblCambio.Text);
                decimal monto = Convert.ToDecimal(lblTotal.Text);

                if (cambio > monto)
                {
                    MessageBox.Show("El cambio no puede ser mayor al monto total de la operación", "Error");
                    return;
                }
                if (cambio < 0)
                {
                    MessageBox.Show("El cambio no puede ser menor a cero", "Error");
                    return;
                }

                procesarVenta();
                MessageBox.Show("Venta Registrada con Éxito", "Éxito");
                Salir();

            }
        }
        private void lblTotal_Click_1(object sender, EventArgs e)
        {

        }

        private void txtMontoPago_EditValueChanged_1(object sender, EventArgs e)
        {
            calcularCambio();
        }
        private void calcularCambio()
        {
            try
            {
                if (txtMontoPago.Text != "")
                {

                    decimal Monto = Convert.ToDecimal(lblTotal.Text);
                    decimal Pago = Convert.ToDecimal(txtMontoPago.Text);
                    decimal totalCambio = (Pago - Monto);
                    lblCambio.Text = (totalCambio).ToString();
                    if (totalCambio < 0)
                    {
                        lblCambio.ForeColor = Color.DarkRed;
                        simpleButton1.Enabled = false;
                    }
                    else
                    {
                        lblCambio.ForeColor = Color.Black;
                        simpleButton1.Enabled = true;
                    }

                }

            }
            catch (Exception ex)
            {


            }
        }

        private void lblCambio_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMetodoPago.Text != "")
                {
                    string[] metodoPago = cmbMetodoPago.Text.Split('-');
                    int metodoPagoID = Convert.ToInt32(metodoPago[0]);

                    var ocultarImpuesto = db.MetodosPago.Where(x => x.metodoPagoID == metodoPagoID).FirstOrDefault();
                    if (ocultarImpuesto.aplicaIGTF == true)
                    {
                        panelIGTF.Visible = true;
                        checkAplicarIFTG.Checked = true;
                    }
                    else
                    {
                        panelIGTF.Visible = false;
                        checkAplicarIFTG.Checked = false;
                        CargarFormulario(false);
                    }
                }
                else
                {
                    panelIGTF.Visible = false;
                    checkAplicarIFTG.Checked = false;
                    CargarFormulario(false);
                }


            }
            catch (Exception)
            {

                panelIGTF.Visible = false;
                CargarFormulario(false);
            }
        }

        private void checkAplicarIFTG_CheckedChanged(object sender, EventArgs e)
        {
            CargarFormulario(checkAplicarIFTG.Checked);
        }

        private void ctrlPagoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                procesar();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
        }

        private void moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] MonedaSeleccionada = moneda.Text.Split('-');
                int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);

                CargarFormulario(false);
                var monedaS = db.Monedas.Where(x => x.monedaID == monedaID).FirstOrDefault();
                // Convrtir 
                lblTotal.Text = (Convert.ToDecimal(lblTotal.Text) * Convert.ToDecimal(monedaS.valor.Value)).ToString(Comun.formatoMoneda);
                calcularCambio();
            }
            catch (Exception x)
            {

            }
        }
    }
}