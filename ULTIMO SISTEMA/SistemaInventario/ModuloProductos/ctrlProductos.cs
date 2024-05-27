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

namespace SistemaInventario.ModuloProductos
{
    public partial class ctrlProductos : DevExpress.XtraEditors.XtraForm
    {
        public ctrlProductos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ctrlProductos_Load(object sender, EventArgs e)
        {
            Limpiar();
            Llenar();
            LlenarCategorias();
            LlenarUnidadMedidas();
        }


        // ------------------------------------------ Metodos y funciones ----------------------- //
        // ---------------- Llenar formulario ------------------------//
        private void Llenar()
        {
            using (ventasEntities db = new ventasEntities())
            {
                var Categorias = (from productos in db.Productos
                                  select new
                                  {
                                      ID = productos.productoID,
                                      nombre = productos.nombre,
                                      estatus = productos.estatus
                                  }).ToList();


                int i = 0;
                foreach (var b in Categorias)
                {
                    try
                    {
                        string[] row = { b.ID.ToString(), b.nombre.ToString(), b.estatus.Value ? "Si" : "No" };
                        var listViewRow = new ListViewItem(row);
                        listView1.Items.Add(listViewRow);
                        i++;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        // ---------------- Limpiar formulario ------------------------//
        private void Limpiar()
        {
            listView1.Items.Clear();
            //--------------------- Txtbox --------------------
            txtCodigoBarras.Text = "";
            barCodeControl1.Text = "0";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            checkEstatus.Checked = false;
            Exento.Checked = false;
            checkVenderBajoCero.Checked = false;
            cmbCategoria.Text = "";
            cmbUnidad.Text = "";
            txtCosto.Text = "0";
            txtVenta.Text = "0";
            txtUtilidad.Text = "0";
            txtInventarioInicial.Text = "";
            txtNivelPedido.Text = "";
            btnAceptar.Text = "Aceptar";
            listView2.Items.Clear();

        }
        // ---------------- Salir del módulo ----------------------------//
        private void Salir()
        {
            this.Close();
        }


        private void LlenarCategorias()
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var objeto = db.Categorias.Where(x => x.estatus == true).ToList();
                    foreach (var item in objeto)
                    {
                        cmbCategoria.Properties.Items.Add(item.categoriaID + "-" + item.nombre);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void LlenarUnidadMedidas()
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var objeto = db.UnidadesMedidas.Where(x => x.estatus == true).ToList();
                    foreach (var item in objeto)
                    {
                        cmbUnidad.Properties.Items.Add(item.unidadMedidaID + "-" + item.nombre);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private int ValidarProductos(string name)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Productos.Where(x => x.nombre == name).Count();
                    return existe;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void ActualizarCrear()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Nombre de producto vacío", "Imposible continuar");
                return;
            }
            if (txtCodigoBarras.Text == "")
            {
                MessageBox.Show("Código de barras de producto vacío", "Imposible continuar");
                return;
            }
            if (cmbUnidad.Text == "")
            {
                MessageBox.Show("Unidad de venta del producto vacío", "Imposible continuar");
                return;
            }
            if (cmbCategoria.Text == "")
            {
                MessageBox.Show("Categoría del producto vacía", "Imposible continuar");
                return;
            }
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "n/a";
            }
            if (txtCosto.Text == "")
            {
                MessageBox.Show("Precio costo de producto vacío", "Imposible continuar");
                return;
            }
            if (txtVenta.Text == "")
            {
                MessageBox.Show("Precio venta del producto vacío", "Imposible continuar");
                return;
            }
            if (txtUtilidad.Text == "")
            {
                MessageBox.Show("Utilidad del producto vacío", "Imposible continuar");
                return;
            }
            if (btnAceptar.Text == "Aceptar")
            {
                if (txtInventarioInicial.Text == "")
                {
                    MessageBox.Show("Debe indicar el inventario inicial del producto", "Imposible continuar");
                    return;
                }
                using (ventasEntities db = new ventasEntities())
                {
                    try
                    {
                        if (ValidarProductos(txtNombre.Text) > 0)
                        {
                            MessageBox.Show("El Producto ya Existe", "Advertencia");
                            return;
                        }
                        string[] CatID = cmbCategoria.Text.Split('-');
                        string[] UnDMedidaID = cmbUnidad.Text.Split('-');
                        Modelos.Productos item = new Modelos.Productos();
                        item.categoriaID = Convert.ToInt32(CatID[0]);
                        item.unidadMedidaID = Convert.ToInt32(UnDMedidaID[0]);
                        item.estatus = checkEstatus.Checked;
                        item.nombre = txtNombre.Text;
                        item.codBarras = txtCodigoBarras.Text;
                        item.descripcion = txtDescripcion.Text;
                        item.exento = Exento.Checked;
                        // Precios 
                        item.precioCompra = Convert.ToDecimal(txtCosto.Text);
                        item.precioVenta = Convert.ToDecimal(txtVenta.Text);
                        item.utilidad = Convert.ToDecimal(txtUtilidad.Text);
                        db.Productos.Add(item);
                        db.SaveChanges();
                        var ultimoProducto = db.Productos.ToList().OrderByDescending(x => x.productoID).FirstOrDefault();
                        // Almacenar el primer registro del stock
                        Modelos.Stock itemStock = new Modelos.Stock();
                        itemStock.cantidad = Convert.ToDecimal(txtInventarioInicial.Text);
                        itemStock.fecha = DateTime.Now;
                        itemStock.productoID = ultimoProducto.productoID;
                        db.Stock.Add(itemStock);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado con éxito", "Éxito");
                        Limpiar();
                        Llenar();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error");
                    }

                }
            }
            else
            {
                using (ventasEntities db = new ventasEntities())
                {
                    try
                    {
                        if (ValidarProductos(txtNombre.Text) > 1)
                        {
                            MessageBox.Show("El Producto ya Existe", "Advertencia");
                            return;
                        }
                        int ID = Convert.ToInt32(txtID.Text);
                        string[] CatID = cmbCategoria.Text.Split('-');
                        string[] UnDMedidaID = cmbUnidad.Text.Split('-');
                        var item = db.Productos.Where(x => x.productoID == ID).FirstOrDefault();
                        item.categoriaID = Convert.ToInt32(CatID[0]);
                        item.unidadMedidaID = Convert.ToInt32(UnDMedidaID[0]);
                        item.estatus = checkEstatus.Checked;
                        item.nombre = txtNombre.Text;
                        item.codBarras = txtCodigoBarras.Text;
                        item.descripcion = txtDescripcion.Text;
                        item.venderBajoCero = checkVenderBajoCero.Checked;
                        item.nivelAlerta = Convert.ToDecimal(txtNivelPedido.Text);
                        item.fechaRegistro = DateTime.Now;
                        item.exento = Exento.Checked;
                        // Precios 
                        item.precioCompra = Convert.ToDecimal(txtCosto.Text);
                        item.precioVenta = Convert.ToDecimal(txtVenta.Text);
                        item.utilidad = Convert.ToDecimal(txtUtilidad.Text);
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show("Registro actualizado con éxito", "Éxito");
                        Limpiar();
                        Llenar();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error");
                    }

                }
            }

        }
        private void Eliminar()
        {
            using (ventasEntities db = new ventasEntities())
            {
                try
                {
                    int ID = Convert.ToInt32(txtID.Text);
                    var item = db.Productos.Where(x => x.productoID == ID).FirstOrDefault();
                    db.Entry(item).State = EntityState.Deleted;
                    db.SaveChanges();
                    MessageBox.Show("Registro eliminar con éxito", "Éxito");
                    Limpiar();
                    Llenar();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error");
                }

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Llenar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Eliminar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string Mensaje = "";
            if (btnAceptar.Text == "Aceptar")
            {
                Mensaje = "¿Está seguro de crear este producto?";
            }
            else
            {
                Mensaje = "¿Está seguro de actualizar este producto?";
            }


            DialogResult result = MessageBox.Show(Mensaje, "Eliminar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ActualizarCrear();
            }

        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    using (ventasEntities db = new ventasEntities())
                    {

                        ListViewItem item = listView1.SelectedItems[0];
                        txtID.Text = item.SubItems[0].Text;
                        int ID = Convert.ToInt32(item.SubItems[0].Text);
                        await validarStockProducto(ID);
                        var objeto = db.Productos.Where(x => x.productoID == ID).FirstOrDefault();
                        txtCodigoBarras.Text = objeto.codBarras;
                        barCodeControl1.Text = objeto.codBarras;
                        txtNombre.Text = objeto.nombre;
                        txtDescripcion.Text = objeto.descripcion;
                        checkEstatus.Checked = objeto.estatus.Value;
                        cmbCategoria.Text = objeto.Categorias.categoriaID + "-" + objeto.Categorias.nombre;
                        cmbUnidad.Text = objeto.UnidadesMedidas.unidadMedidaID + "-" + objeto.UnidadesMedidas.nombre;
                        txtCosto.Text = objeto.precioCompra.Value.ToString();
                        txtVenta.Text = objeto.precioVenta.Value.ToString();
                        txtUtilidad.Text = objeto.utilidad.Value.ToString();
                        txtNivelPedido.Text = objeto.nivelAlerta != null ? objeto.nivelAlerta.Value.ToString() : "0";
                        checkVenderBajoCero.Checked = objeto.venderBajoCero != null ? objeto.venderBajoCero.Value: false;
                        Exento.Checked = objeto.exento != null ? objeto.exento.Value : false;
                        btnAceptar.Text = "Modificar";

                    }
                }
            }
            catch (Exception)
            {
            }
        }

        async private Task validarStockProducto(int ProductoID)
        {
            try
            {
                listView2.Items.Clear();
                using (ventasEntities db = new ventasEntities())
                {

                    var objeto = await db.Stock.Where(x => x.productoID == ProductoID).ToListAsync();
                    int i = 0;
                    foreach (var b in objeto)
                    {
                        try
                        {
                            string[] row = { b.stockID.ToString(), b.Productos.nombre.ToString(), b.cantidad.ToString(), b.fecha.Value.ToString() };
                            var listViewRow = new ListViewItem(row);
                            listView2.Items.Add(listViewRow);
                            i++;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoBarras_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                barCodeControl1.Text = txtCodigoBarras.Text;
            }
            catch (Exception)
            {

            }
        }

        private void txtUtilidad_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCosto.Text != "" && txtUtilidad.Text != "")
                {
                    Decimal PrecioCosto = Convert.ToDecimal(txtCosto.Text);
                    Decimal PrecioUtilidad = Convert.ToDecimal(txtUtilidad.Text);
                    Decimal Resultado = ((PrecioCosto * PrecioUtilidad) / 100) + PrecioCosto;
                    txtVenta.Text = Resultado.ToString();


                }


            }
            catch (Exception)
            {

            }
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}