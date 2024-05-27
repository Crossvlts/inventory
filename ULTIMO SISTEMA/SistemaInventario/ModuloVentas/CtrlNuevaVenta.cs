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

namespace SistemaInventario.ModuloVentas
{
    public partial class CtrlNuevaVenta : DevExpress.XtraEditors.XtraForm
    {
        int ventaID = 0;
        public CtrlNuevaVenta()
        {
            InitializeComponent();
        }

        decimal Impuesto = 0;
        int clienteIDSel = 0;
        bool procesada = false;

        ventasEntities db = new ventasEntities();

        // Metodo Botón Salir
        private void Salir()
        {

            DialogResult result = MessageBox.Show("¿Desea cerrar la venta?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                this.Close();
            }

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Salir();
        }

        private void CtrlNuevaCompra_Load(object sender, EventArgs e)
        {


        }

        // LKistar Impuesto 
        private void CargarImpuesto()
        {
            var Objeto = db.Configuracion.FirstOrDefault();
            Impuesto = Objeto.Impuesto.Value;
        }

        // Buscar producto
        private void BuscarProducto(string producto)
        {
            try
            {
                // Buscar por nombre / descripcion / Codigo de barras
                var item = db.Productos.Where(x => x.codBarras.Contains(producto) || x.nombre.Contains(producto) || x.descripcion.Contains(producto)).ToList();
                if (item.Count == 0)
                {
                    MessageBox.Show("No hay resultados", "Advertencia");
                    return;
                }
                else
                {
                    //txtBuscarProducto.Text = item.FirstOrDefault().codBarras + "-" + item.FirstOrDefault().nombre.ToString();
                    seleccionarCantidad();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void BuscarProductoLista(string producto)
        {
            // Buscar por nombre / descripcion / Codigo de barras
            var item = db.Stock
                    .GroupBy(l => l.productoID)
                    .Select(cl => new
                    {
                        ProductoID = cl.FirstOrDefault().productoID,
                        Nombre = cl.FirstOrDefault().Productos.nombre,
                        Descripcion = cl.FirstOrDefault().Productos.descripcion,
                        Unidad = cl.FirstOrDefault().Productos.UnidadesMedidas.nombre,
                        CodigoBarras = cl.FirstOrDefault().Productos.codBarras,
                        Cantidad = cl.Sum(c
                        => c.cantidad).ToString(),
                    }).Where(x => x.Nombre.Contains(producto) || x.CodigoBarras.Contains(producto) || x.Descripcion.Contains(producto)).ToList();

            int i = 0;
            if (item.Count > 0)
            {
                listView2.Visible = true;
                foreach (var b in item)
                {
                    try
                    {
                        string[] row = { b.ProductoID.ToString(), b.Nombre.ToString(), b.Unidad, b.Cantidad.ToString() };
                        var listViewRow = new ListViewItem(row);
                        listView2.Items.Add(listViewRow);
                        i++;
                    }
                    catch (Exception)
                    {
                    }
                }
                listView2.Select();
            }
            else
            {

            }

        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            buscarItemListado();
        }

        private void searchControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Al presionar ENTER
            if (e.KeyChar == (char)13)
            {
                buscarItemBarcode();
            }
        }


        private void AgregarItem()
        {
            try
            {
                string[] BarrasSplit = textEdit1.Text.Split('-');
                string CodigoBarras = BarrasSplit[0];
                var objeto = db.Productos.Where(x => x.codBarras == CodigoBarras).FirstOrDefault();

                decimal subTotal = 0;
                decimal Total = 0;
                decimal cantidad = 0;
                cantidad = txtCantidad.Text != "" ? Convert.ToDecimal(txtCantidad.Text) : 0;
                subTotal = objeto.precioVenta != null ? objeto.precioVenta.Value : 0;
                CargarImpuesto();
                subTotal = subTotal * cantidad;
                if (objeto.exento != true)
                {
                    CargarImpuesto();
                    if (Impuesto == 0)
                    {
                        Total = subTotal;
                    }
                    else
                    {
                        Total = (((Impuesto * subTotal) / 100) + subTotal);

                    }
                }
                else {

                    Total = subTotal;
                }

                string[] row = { objeto.productoID.ToString(), objeto.nombre.ToString(), objeto.UnidadesMedidas.nombre.ToString(), txtCantidad.Text, subTotal.ToString(Comun.formatoMoneda), Total.ToString(Comun.formatoMoneda) };

                //string[] row = { objeto.productoID.ToString(), objeto.nombre.ToString(), txtCantidad.Text, subTotal.ToString(Comun.formatoMoneda), Total.ToString(Comun.formatoMoneda) };
                var listViewRow = new ListViewItem(row);
                listView1.Items.Add(listViewRow);
                lblCantidadItem.Text = listView1.Items.Count.ToString();

                listView2.Visible = false;
                textEdit1.Text = "";
                textEdit1.Enabled = true;
                txtCantidad.Text = "";
                textEdit1.Select();
                textEdit1.Focus();
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void calcularTotal()
        {
            try
            {
                decimal Total = 0;
                decimal Subotal = 0;
                int i = 0;

                foreach (ListViewItem item in listView1.Items)
                {
                    string valorItem = item.SubItems[5].Text;
                    Total += Convert.ToDecimal(valorItem);

                    string valorItemSub = item.SubItems[4].Text;
                    Subotal += Convert.ToDecimal(valorItemSub);
                }
                lblSubtotal.Text = Subotal.ToString(Comun.formatoMoneda);
                lblTotal.Text = Total.ToString(Comun.formatoMoneda);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Al presionar ENTER
            if (e.KeyChar == (char)13)
            {
                agregarAlistado();
            }
        }

        private void agregarAlistado()
        {
            try
            {
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    MessageBox.Show("Ingrese una cantidad mayor a cero (0)", "Advertencia");
                    return;
                }
                if (string.IsNullOrEmpty(textEdit1.Text))
                {
                    MessageBox.Show("Ingrese el producto", "Advertencia");
                    return;
                }

                AgregarItem();
                textEdit1.Focus();
                textEdit1.Select();
            }
            catch (Exception)
            {
            }

        }
        private void buscarItemListado()
        {
            try
            {
                if (textEdit1.Text != "")
                {

                    if (textEdit1.Text.Length > 3)
                    {
                        listView2.Items.Clear();
                        BuscarProductoLista(textEdit1.Text);
                        listView2.Visible = true;
                        listView2.Focus();
                        if (listView2.SelectedItems.Count > 0)
                        {
                            var item = listView2.SelectedItems[0];
                            //rest of your logic
                        }
                    }
                    else
                    {
                        listView2.Items.Clear();
                        listView2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void buscarItemBarcode()
        {
            try
            {
                if (textEdit1.Text == "")
                {
                    MessageBox.Show("Ingrese un producto", "Advertencia");
                    return;
                }
                else
                {
                    BuscarProducto(textEdit1.Text);
                }
            }
            catch (Exception)
            {
            }

        }
        private void seleccionarCantidad()
        {
            txtCantidad.Focus();
            txtCantidad.Select();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            agregarAlistado();
        }

        private void listView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Al presionar ENTER
            if (e.KeyChar == (char)13)
            {
                PasarParametros();
            }
        }
        private void PasarParametros()
        {
            try
            {

                ProductoSeleccionado productoSeleccionado = new ProductoSeleccionado();
                ListViewItem item = listView2.SelectedItems[0];
                int ID = Convert.ToInt32(item.SubItems[0].Text);
                var objeto = db.Productos.Where(x => x.productoID == ID).FirstOrDefault();
                var StockCantidad = db.Stock.Where(x => x.productoID == ID).Sum(c
                    => c.cantidad);
                if (StockCantidad.Value < 0)
                {
                    if (!objeto.venderBajoCero.Value)
                    {
                        MessageBox.Show("Producto no disponible", "Advertencia");
                        return;
                    }
                    lblDisponible.ForeColor = Color.Red;
                }
                else
                {
                    lblDisponible.Text = StockCantidad.Value.ToString();
                }

                textEdit1.Text = objeto.codBarras + "-" + objeto.nombre;
                txtCantidad.Text = "1";
                txtCantidad.Select();
                txtCantidad.Focus();
                textEdit1.Enabled = false;

            }
            catch (Exception ex)
            {

            }
            listView2.Visible = false;
            seleccionarCantidad();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        // ---------------- Limpiar formulario ------------------------//
        public void Limpiar()
        {
            textEdit1.Text = "";
            txtCantidad.Text = "0";
            lblCantidadItem.Text = "0";
            lblSubtotal.Text = "0.0";
            lblTotal.Text = "0.0";
            lblCliente.Text = "-";
            lblDisponible.Text = "0";
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView2.Visible = false;
            lblCliente.Focus();
            txtCliente.Text = "";
        }

        private void Guardar()
        {
            try
            {

                string[] cliente = lblCliente.Text.Split('-');
                Ventas venta = new Ventas();
                venta.estatus = false; // compra aún no procesada
                venta.fecha = DateTime.Now;
                venta.clienteID = clienteIDSel;
                venta.usuarioID = Comun.usuarioID;
                db.Ventas.Add(venta);
                db.SaveChanges();
                procesada = true;
            }
            catch (Exception)
            {

            }

        }

        private void GuardarDetalle()
        {
            if (procesada)
            {
                try
                {
                    // Obtener el ultimo registro de la venta 
                    var ultimoRegistro = db.Ventas.OrderByDescending(x => x.ventaID).FirstOrDefault();
                    ventaID = ultimoRegistro.ventaID;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        VentasDetalle vD = new VentasDetalle();
                        vD.ventaID = ultimoRegistro.ventaID;
                        vD.productoID = Convert.ToInt32(item.SubItems[0].Text);
                        vD.cantidad = Convert.ToDecimal(item.SubItems[3].Text);
                        db.VentasDetalle.Add(vD);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                MessageBox.Show("Error al guardar el detalle de la compra", "Advertencia");
                return;

            }
        }

        private void CtrlNuevaVenta_Load(object sender, EventArgs e)
        {

            txtCliente.Select();
            txtCliente.Focus();
        }

        private void txtCLiente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCLiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Al presionar ENTER
            if (e.KeyChar == (char)13)
            {
                if (txtCliente.Text == "")
                {
                    txtCliente.Select();
                    return;
                }
                buscarCliente(txtCliente.Text);
            }
        }

        private void buscarCliente(string clienteID)
        {
            try
            {
                var existe = db.Clientes.Where(x => x.IDFiscal == clienteID).Count();
                if (existe > 0)
                {
                    var cliente = db.Clientes.Where(x => x.IDFiscal == clienteID).FirstOrDefault();
                    lblCliente.Text = cliente.IDFiscal + "-" + cliente.primerNombre + " " + cliente.primerApellido;
                    clienteIDSel = cliente.clienteID;
                    textEdit1.Select();
                    textEdit1.Focus();
                }
                else
                {
                    nuevoCliente nuevo = new nuevoCliente();
                    Comun.ItemSeleccionado = txtCliente.Text;
                    nuevo.Show();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtBuscarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Salir();
        }

        private void CtrlNuevaVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F5)
            {
                procesarVenta();
            }
            if (e.KeyCode == Keys.F2)
            {
                textEdit1.Enabled = true;
            }
            if (e.KeyCode == Keys.F1)
            {
                Limpiar();
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            procesarVenta();
        }


        private void procesarVenta()
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto", "Advertencia");
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de procesar la venta?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Guardar compra principal 

                Guardar();

                // Guardar Compra detalle 
                GuardarDetalle();

                // Desplegar ventana para procesar el pago 
                ctrlPagoVenta frm = new ctrlPagoVenta(ventaID);
                frm.ShowDialog();

                Limpiar();
            }
        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "" || txtCantidad.Text == "0")
            {
                txtCantidad.Text = "1";
                txtCantidad.Enabled = true;
                txtCantidad.Select();
                txtCantidad.Focus();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PasarParametros();
            txtCantidad.Select();
            txtCantidad.Focus();
        }

        private void txtBuscarProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Seleccione un cliente", "Error");
                textEdit1.Text = "";
                txtCantidad.Text = "0";
                txtCliente.Select();
                txtCliente.Focus();
                return;
            }
            buscarItemListado();
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            textEdit1.Enabled = true;
        }

        private void textEdit1_DoubleClick(object sender, EventArgs e)
        {
            textEdit1.Enabled = true;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit1.Enabled = true;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Limpiar();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lblCliente.Text == "-" || lblCliente.Text == "")
                {
                    MessageBox.Show("Seleccione un cliente", "Error");
                    lblCliente.Select();
                    return;
                }
                agregarAlistado();
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            if (lblCliente.Text == "-" || lblCliente.Text == "")
            {
                MessageBox.Show("Seleccione un cliente", "Error");
                lblCliente.Select();
                return;
            }
            agregarAlistado();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            buscarCliente(txtCliente.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    using (ventasEntities db = new ventasEntities())
                    {
                        ListViewItem item = listView2.SelectedItems[0];

                        DialogResult result = MessageBox.Show("¿Desea eliminar el item?", "Eliminar", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    using (ventasEntities db = new ventasEntities())
                    {
                        ListViewItem item = listView2.SelectedItems[0];

                        DialogResult result = MessageBox.Show("¿Desea eliminar el item?", "Eliminar", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void lblSubtotal_Click(object sender, EventArgs e)
        {

        }
    }



    class ProductoSeleccionado
    {
        public int productoID { get; set; }
        public string nombre { get; set; }

        public string codBarras { get; set; }
        public decimal precioCosto { get; set; }
        public decimal cantidad { get; set; }

        public decimal subtotal { get; set; }
        public decimal total { get; set; }
    }

}
