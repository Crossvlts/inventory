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

namespace SistemaInventario.ModuloCompras
{
    public partial class ctrlPago : DevExpress.XtraEditors.XtraForm
    {
        int compraID = 0;
        public ctrlPago(int compra)
        {
            compraID = compra;
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
            cargarMonedas();
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

        private void CargarFormulario(bool procesarIGTF)
        {
            try
            {
                var configur = db.Configuracion.FirstOrDefault();
                decimal impuesto = configur.Impuesto.Value;
                decimal IGTF = configur.IGTF != null ? configur.IGTF.Value : 0;

                var detalle = db.ComprasDetalle.Where(x => x.compraID == compraID).ToList();
                lblID.Text = compraID.ToString();
                decimal TotalPagar = 0;
                decimal TotalImpuesto = 0;
                decimal TotalIGTF = 0;
                foreach (var item in detalle)
                {
                    decimal precioCompra = item.Productos.precioCompra.Value;
                    decimal cantidadVendida = item.cantidad.Value;

                    decimal total = (precioCompra * cantidadVendida);
                    TotalPagar = TotalPagar + total;


                    if (procesarIGTF)
                    {
                        if (IGTF != 0)
                        {
                            decimal IGTF_ = ((IGTF * TotalPagar) / 100);
                            TotalIGTF = TotalIGTF + IGTF_;
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {



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
        private void Salir()
        {

            this.Close();


        }

        private void procesarCompra()
        {
            try
            {
                string[] metodoPago = cmbMetodoPago.Text.Split('-');
                int metodoPagoID = Convert.ToInt32(metodoPago[0]);
                string[] MonedaSeleccionada = moneda.Text.Split('-');
                int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);

                // Guardar en el rgistro de pago de compra 
                ComprasPago cp = new ComprasPago();
                cp.monedaID = monedaID;
                cp.monto = Convert.ToDecimal(txtMontoPago.Text);
                cp.metodoPagoID = metodoPagoID;
                cp.compraID = compraID;
                cp.cambio = Convert.ToDecimal(lblCambio.Text);
                db.ComprasPago.Add(cp);
                db.SaveChanges();


                // desvbloquear la compra 
                var compra = db.Compras.Where(x => x.compraID == compraID).FirstOrDefault();
                compra.estatus = true;
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();


                // Actualizar el Stock 

                var compraDetalle = db.ComprasDetalle.Where(x => x.compraID == compraID).ToList();
                foreach (var item in compraDetalle)
                {
                    try
                    {

                        Stock stock = new Stock();
                        stock.cantidad = item.cantidad;
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

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtMontoPago_EditValueChanged(object sender, EventArgs e)
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

        private void ctrlPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
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


                    if (cambio < 0)
                    {
                        simpleButton1.Enabled = false;
                    }
                    else
                    {
                        simpleButton1.Enabled = true;
                    }

                    procesarCompra();
                    MessageBox.Show("Compra Registrada con Éxito", "Éxito");
                    Salir();

                }

            }
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void cmbMetodoPago_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void simpleButton1_Click_1(object sender, EventArgs e)
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


                if (cambio < 0)
                {
                    simpleButton1.Enabled = false;
                }
                else
                {
                    simpleButton1.Enabled = true;
                }

                procesarCompra();
                MessageBox.Show("Compra Registrada con Éxito", "Éxito");

                Salir();



            }

        }

        private void checkAplicarIFTG_CheckedChanged(object sender, EventArgs e)
        {
            CargarFormulario(checkAplicarIFTG.Checked);
        }

        private void txtMontoPago_EditValueChanged_1(object sender, EventArgs e)
        {
            calcularCambio();
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