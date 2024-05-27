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
    public partial class ctrlListadoCompras : DevExpress.XtraEditors.XtraForm
    {
        public ctrlListadoCompras()
        {
            InitializeComponent();
        }
        ventasEntities db = new ventasEntities();
        private void ctrlListadoCompras_Load(object sender, EventArgs e)
        {
            cargar();

        }

        private void cargarMonedas()
        {
            try
            {
                moneda.Properties.Items.Clear();
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

        public void refrescar()
        {
            var entitiesList = db.ChangeTracker.Entries().ToList();
            foreach (var entity in entitiesList)
            {
                entity.Reload();
            }
        }

        private void Listar(string busqueda, int tipoBusqueda, int monedaID)
        {
            var listado = db.Compras.ToList();
            lista.Items.Clear();
            if (busqueda == "")
            {
                switch (tipoBusqueda)
                {
                    case 0:
                        // Ventas de hoy
                        listado = listado.Where(x => x.fecha.Value.Year == DateTime.Now.Year && x.fecha.Value.Month == DateTime.Now.Month && x.fecha.Value.Day == DateTime.Now.Day).ToList();
                        break;
                    case 1:
                        // Ventas de Mes
                        listado = listado.Where(x => x.fecha.Value.Year == DateTime.Now.Year && x.fecha.Value.Month == DateTime.Now.Month).ToList();
                        break;
                    case 2:
                        // no hacer nada JAJAJA 
                        break;
                    default:
                        break;
                }
                int i = 0;
                var moneda = db.Monedas.Where(x => x.monedaID == monedaID).FirstOrDefault();
                var configur = db.Configuracion.FirstOrDefault();
                decimal impuesto = configur.Impuesto.Value;
                foreach (var b in listado)
                {

                    if (b.compraID == 1017)
                    {

                    }
                    var existePago = db.ComprasPago.Where(x => x.compraID == b.compraID).Count();
                    if (existePago > 0)
                    {
                        var pago = db.ComprasPago.Where(x => x.compraID == b.compraID).FirstOrDefault();
                        try
                        {
                            decimal cambio = 0;
                            decimal montoTotal = 0;
                            cambio = pago.cambio != null ? pago.cambio.Value : 0;
                            montoTotal = pago.monto != null ? pago.monto.Value : 0;
                            montoTotal = montoTotal - cambio;
                            string[] row = { b.compraID.ToString(), b.fecha.ToString(), b.Proveedores.IDFiscal + "-" + b.Proveedores.empresa, montoTotal.ToString(Comun.formatoMoneda), moneda.moneda, b.estatus == true ? "Procesado" : "* Por procesar", b.ComprasDetalle.Count().ToString() + " items" };
                            var listViewRow = new ListViewItem(row);
                            lista.Items.Add(listViewRow);
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message, "Error");
                        }
                    }
                    else
                    {
                        string[] row = { b.compraID.ToString(), b.fecha.ToString(), b.Proveedores.IDFiscal + "-" + b.Proveedores.empresa, Comun.formatoMoneda, "n/a", b.estatus == true ? "Procesado" : "* Por procesar", b.ComprasDetalle.Count().ToString() + " items" };
                        var listViewRow = new ListViewItem(row);
                        lista.Items.Add(listViewRow);
                    }



                }
            }
            else
            {
                listado = listado.Where(x => x.codigofactura.ToString().Contains(busqueda) || x.fecha.ToString().Contains(busqueda) || x.Proveedores.empresa.ToString().Contains(busqueda)).ToList();
                switch (tipoBusqueda)
                {
                    case 0:
                        // Ventas de hoy
                        listado = listado.Where(x => x.fecha.Value.Year == DateTime.Now.Year && x.fecha.Value.Month == DateTime.Now.Month && x.fecha.Value.Day == DateTime.Now.Day).ToList();
                        break;
                    case 1:
                        // Ventas de Mes
                        listado = listado.Where(x => x.fecha.Value.Year == DateTime.Now.Year && x.fecha.Value.Month == DateTime.Now.Month).ToList();
                        break;
                    case 2:
                        // no hacer nada JAJAJA 
                        break;
                    default:
                        break;
                }
                var moneda = db.Monedas.Where(x => x.monedaID == monedaID).FirstOrDefault();
                var configur = db.Configuracion.FirstOrDefault();
                decimal impuesto = configur.Impuesto.Value;
                int i = 0;
                foreach (var b in listado)
                {
                    if (b.ComprasPago.Count == 0)
                    {
                        string[] row = { b.compraID.ToString(), b.fecha.ToString(), b.Proveedores.IDFiscal + "-" + b.Proveedores.empresa, Comun.formatoMoneda, "n/a", b.estatus == true ? "Procesado" : "* Por procesar", b.ComprasDetalle.Count().ToString() + " items" };
                        var listViewRow = new ListViewItem(row);
                        lista.Items.Add(listViewRow);
                        continue;
                    }
                    if (b.ComprasPago.FirstOrDefault().monedaID == null)
                    {
                        continue;
                    }
                    if (b.ComprasPago.FirstOrDefault().monedaID == monedaID)
                    {
                        try
                        {
                            decimal cambio = 0;
                            decimal montoTotal = 0;
                            cambio = b.ComprasPago.Count > 0 ? b.ComprasPago.FirstOrDefault().cambio != null ? b.ComprasPago.FirstOrDefault().cambio.Value : 0 : 0;
                            montoTotal = b.ComprasPago.Count > 0 ? b.ComprasPago.FirstOrDefault().monto != null ? b.ComprasPago.FirstOrDefault().monto.Value : 0 : 0;
                            montoTotal = montoTotal - cambio;
                            string[] row = { b.compraID.ToString(), b.fecha.ToString(), b.Proveedores.IDFiscal + "-" + b.Proveedores.empresa, montoTotal.ToString(Comun.formatoMoneda), moneda.moneda, b.estatus == true ? "Procesado" : "* Por procesar", b.ComprasDetalle.Count().ToString() + " items" };
                            var listViewRow = new ListViewItem(row);
                            lista.Items.Add(listViewRow);

                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message, "Error");
                        }
                    }
                }
            }



        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {

                int valor = radioGroup1.SelectedIndex;
                string[] MonedaSeleccionada = moneda.Text.Split('-');
                int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
                Listar(searchControl1.Text, valor, monedaID);
            }
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Detallar(int? compraID)
        {
            try
            {
                var existe = db.Compras.Where(x => x.compraID == compraID).Count();
                if (existe > 0)
                {
                    var Detalle = db.Compras.Where(x => x.compraID == compraID).FirstOrDefault();
                    if (Detalle.estatus == false)
                    {
                       // Comun.IDSeleccionado = Detalle.compraID;
                        ctrlPago frm = new ctrlPago(Detalle.compraID);
                        frm.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void listVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listVentas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lista.SelectedItems.Count > 0)
                {
                    ListViewItem item = lista.SelectedItems[0];

                    if (item.SubItems[5].Text.Contains("Procesado"))
                    {
                        return;
                    }
                    using (ventasEntities db = new ventasEntities())
                    {
                        DialogResult result = MessageBox.Show("¿Desea procesar la compra?", "Procesar", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Detallar(Convert.ToInt32(item.SubItems[0].Text));
                            refrescar();
                        }
                    }
                }
               
                cargar();
            }
            catch (Exception)
            {

            }


        }

        public void cargar()
        {
            lista.Items.Clear();
            cargarMonedas();
            string[] MonedaSeleccionada = moneda.Text.Split('-');
            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
            Listar("", 2, monedaID);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = radioGroup1.SelectedIndex;
            string[] MonedaSeleccionada = moneda.Text.Split('-');
            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
            Listar(searchControl1.Text, valor, monedaID);
        }

        private void moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] MonedaSeleccionada = moneda.Text.Split('-');
            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
            Listar(searchControl1.Text, radioGroup1.SelectedIndex, monedaID);
        }
    }
}