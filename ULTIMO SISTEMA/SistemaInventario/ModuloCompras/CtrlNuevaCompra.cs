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

namespace SistemaInventario.ModuloCompras
{
    public partial class CtrlNuevaCompra : DevExpress.XtraEditors.XtraForm
    {

        int compraID = 0;
        public CtrlNuevaCompra()
        {
            InitializeComponent();
        }
        decimal Impuesto = 0;
        bool procesada = false;

        ventasEntities db = new ventasEntities();


        // Metodo Botón Salir
        private void Salir()
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar la compra?", "Eliminar", MessageBoxButtons.YesNo);
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
            LlenarProveedores();
            dtFecha.DateTime = DateTime.Now;
        }
        // Listar proveedores activos
        private void LlenarProveedores()
        {
            var objeto = db.Proveedores.Where(x => x.estatus == true).ToList();
            if (objeto.Count > 0)
            {
                foreach (var item in objeto)
                {
                    cmbProveedores.Properties.Items.Add(item.proveedorID + "-" + item.empresa);
                }
            }
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
                    txtBuscarProducto.Text = item.FirstOrDefault().codBarras + "-" + item.FirstOrDefault().nombre.ToString();
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
                        string[] row = { b.ProductoID.ToString(), b.Nombre.ToString(), b.Cantidad.ToString() };
                        var listViewRow = new ListViewItem(row);
                        listView2.Items.Add(listViewRow);
                        i++;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {

            }

        }
        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedores.Text == "")
            {
                MessageBox.Show("Seleccione un proveedor", "Error");
                txtBuscarProducto.Text = "";
                txtCantidad.Text = "0";
                cmbProveedores.Select();
                cmbProveedores.Focus();
                return;
            }
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

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {


        }
        private void AgregarItem()
        {
            try
            {
                string[] BarrasSplit = txtBuscarProducto.Text.Split('-');
                string CodigoBarras = BarrasSplit[0];
                var objeto = db.Productos.Where(x => x.codBarras == CodigoBarras).FirstOrDefault();

                decimal subTotal = 0;
                decimal Total = 0;
                decimal cantidad = 0;
                cantidad = txtCantidad.Text != "" ? Convert.ToDecimal(txtCantidad.Text) : 0;
                subTotal = objeto.precioCompra != null ? objeto.precioCompra.Value : 0;
                // CargarImpuesto();
                subTotal = subTotal * cantidad;
                Total = subTotal;
                //string[] row = { objeto.productoID.ToString(), objeto.nombre.ToString(), objeto.UnidadesMedidas.nombre.ToString(), txtCantidad.Text, subTotal.ToString(Comun.formatoMoneda), Total.ToString(Comun.formatoMoneda) };

                string[] row = { objeto.productoID.ToString(), objeto.nombre.ToString(), txtCantidad.Text, subTotal.ToString(Comun.formatoMoneda), Total.ToString(Comun.formatoMoneda) };
                var listViewRow = new ListViewItem(row);
                listView1.Items.Add(listViewRow);
                lblCantidadItem.Text = listView1.Items.Count.ToString();

                listView2.Visible = false;
                txtBuscarProducto.Text = "";
                txtBuscarProducto.Enabled = true;
                txtCantidad.Text = "";
                txtBuscarProducto.Select();
                txtBuscarProducto.Focus();
                calcularTotal();
            }
            catch (Exception ex)
            {
            }

        }

        private void calcularTotal()
        {
            try
            {
                decimal Subotal = 0;
                decimal Total = 0;
                int i = 0;

                foreach (ListViewItem item in listView1.Items)
                {

                    string valorItemsub = item.SubItems[3].Text;
                    Subotal += Convert.ToDecimal(valorItemsub);

                    string valorItem = item.SubItems[4].Text;
                    Total += Convert.ToDecimal(valorItem);


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

        private void txtCodigoFactura_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarProducto_EditValueChanged(object sender, EventArgs e)
        {
            buscarItemListado();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PasarParametros();

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void barListItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void agregarAlistado()
        {
            try
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Ingrese una cantidad mayor a cero (0)", "Advertencia");
                    return;
                }
                if (txtCantidad.Text == "0")
                {
                    MessageBox.Show("Ingrese el producto", "Advertencia");
                    return;
                }

                AgregarItem();
                txtBuscarProducto.Focus();
                txtBuscarProducto.Select();
            }
            catch (Exception)
            {
            }

        }
        private void buscarItemListado()
        {
            try
            {
                if (txtBuscarProducto.Text != "")
                {

                    if (txtBuscarProducto.Text.Length > 3)
                    {
                        listView2.Items.Clear();
                        BuscarProductoLista(txtBuscarProducto.Text);
                        listView2.Visible = true;
                        listView2.Select();
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
                if (txtBuscarProducto.Text == "")
                {
                    MessageBox.Show("Ingrese un producto", "Advertencia");
                    return;
                }
                else
                {
                    BuscarProducto(txtBuscarProducto.Text);
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
                if (listView2.SelectedItems.Count > 0)
                {
                    ProductoSeleccionado productoSeleccionado = new ProductoSeleccionado();
                    ListViewItem item = listView2.SelectedItems[0];
                    int ID = Convert.ToInt32(item.SubItems[0].Text);
                    var objeto = db.Productos.Where(x => x.productoID == ID).FirstOrDefault();
                    txtBuscarProducto.Text = objeto.codBarras + "-" + objeto.nombre;
                }
            }
            catch (Exception ex)
            {

            }
            listView2.Visible = false;
            seleccionarCantidad();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            procesarCompra();
        }

        private void procesarCompra()
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto", "Advertencia");
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de procesar la compra?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Guardar compra principal 

                Guardar();

                // Guardar Compra detalle 
                GuardarDetalle();

                // Desplegar ventana para procesar el pago 
                ctrlPago frm = new ctrlPago(compraID);
                frm.ShowDialog();
                Limpiar();
            }
        }
        // ---------------- Limpiar formulario ------------------------//
        public void Limpiar()
        {
            cmbProveedores.Text = "";
            dtFecha.Text = "";
            txtCodigoFactura.Text = "";
            txtBuscarProducto.Text = "";
            txtCantidad.Text = "0";
            lblCantidadItem.Text = "";
            lblSubtotal.Text = "0.0";
            lblTotal.Text = "0.0";
            listView1.Items.Clear();
            listView2.Items.Clear();
        }

        private void Guardar()
        {
            try
            {
                // Guardar compra
                string[] proveedor = cmbProveedores.Text.Split('-');
                int proveedorID = Convert.ToInt32(proveedor[0]);
                Compras compra = new Compras();
                compra.codigofactura = txtCodigoFactura.Text != "" ? txtCodigoFactura.Text : "n/a";
                compra.estatus = false; // compra aún no procesada
                compra.fecha = dtFecha.DateTime != null ? dtFecha.DateTime : DateTime.Now;
                compra.proveedorID = proveedorID;
                compra.usuarioID = Comun.usuarioID;
                db.Compras.Add(compra);
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
                    // Obtener el ultimo registro de la compra 
                    var ultimoRegistro = db.Compras.OrderByDescending(x => x.compraID).FirstOrDefault();
                    compraID = ultimoRegistro.compraID;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        ComprasDetalle cD = new ComprasDetalle();
                        cD.compraID = ultimoRegistro.compraID;
                        cD.productoID = Convert.ToInt32(item.SubItems[0].Text);
                        cD.cantidad = Convert.ToDecimal(item.SubItems[2].Text);
                        db.ComprasDetalle.Add(cD);
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

        private void CtrlNuevaCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                procesarCompra();
            }

            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
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