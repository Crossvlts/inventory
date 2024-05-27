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
    public partial class ctrlListadoVentas : DevExpress.XtraEditors.XtraForm
    {
        int ventaID = 0;
        public ctrlListadoVentas()
        {
            InitializeComponent();
        }

        ventasEntities db = new ventasEntities();
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
        private void ctrlListadoVentas_Load(object sender, EventArgs e)
        {
            cargarMonedas();
            string[] MonedaSeleccionada = moneda.Text.Split('-');
            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
            Listar("", 2, monedaID);
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
            listVentas.Items.Clear();
            if (busqueda == "")
            {
                var listado = db.Ventas.ToList();
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
                        // no hacer nada 
                        break;
                    default:
                        break;
                }
                var moneda = db.Monedas.Where(x => x.monedaID == monedaID).FirstOrDefault();
                var configur = db.Configuracion.FirstOrDefault();
                decimal impuesto = configur.Impuesto.Value;
                foreach (var b in listado)
                {
                    var existePago = db.VentasPago.Where(x => x.ventaID == b.ventaID).Count();
                    if (existePago > 0)
                    {
                        var pago = db.VentasPago.Where(x => x.ventaID == b.ventaID).FirstOrDefault();
                        try
                        {
                            decimal cambio = 0;
                            decimal montoTotal = 0;
                            cambio = pago.cambio != null ? pago.cambio.Value : 0;
                            montoTotal = pago.monto != null ? pago.monto.Value : 0;
                            montoTotal = montoTotal - cambio;
                            string[] row = { b.ventaID.ToString(), b.fecha.ToString(), b.Clientes.IDFiscal + "-" + b.Clientes.primerNombre + " " + b.Clientes.primerApellido.ToString(), montoTotal.ToString(Comun.formatoMoneda), moneda.moneda, b.estatus == true ? "Procesado" : "* Por procesar", b.VentasDetalle.Count().ToString() + " items" };
                            var listViewRow = new ListViewItem(row);
                            listVentas.Items.Add(listViewRow);
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message, "Error");
                        }
                    }
                    else
                    {
                        string[] row = { b.ventaID.ToString(), b.fecha.ToString(), b.Clientes.IDFiscal + "-" + b.Clientes.primerNombre + " " + b.Clientes.primerApellido.ToString(), "0.00", moneda.moneda, b.estatus == true ? "Procesado" : "* Por procesar", b.VentasDetalle.Count().ToString() + " items" };
                        var listViewRow = new ListViewItem(row);
                        listVentas.Items.Add(listViewRow);
                    }

                }
            }
            else
            {
                var listado = db.Ventas.Where(x => x.Clientes.primerNombre.Contains(busqueda) || x.Clientes.primerApellido.Contains(busqueda) || x.fecha.ToString().Contains(busqueda) || x.ventaID.ToString().Contains(busqueda)).ToList();
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
                        // no hacer nada 
                        break;
                    default:
                        break;
                }
                var moneda = db.Monedas.Where(x => x.monedaID == monedaID).FirstOrDefault();
                var configur = db.Configuracion.FirstOrDefault();
                decimal impuesto = configur.Impuesto.Value;
                foreach (var b in listado)
                {

                    var existePago = db.VentasPago.Where(x => x.ventaID == b.ventaID).Count();
                    if (existePago > 0)
                    {
                        var pago = db.VentasPago.Where(x => x.ventaID == b.ventaID).FirstOrDefault();
                        try
                        {
                            decimal cambio = 0;
                            decimal montoTotal = 0;
                            cambio = pago.cambio != null ? pago.cambio.Value : 0;
                            montoTotal = pago.monto != null ? pago.monto.Value : 0;
                            montoTotal = montoTotal - cambio;
                            string[] row = { b.ventaID.ToString(), b.fecha.ToString(), b.Clientes.IDFiscal + "-" + b.Clientes.primerNombre + " " + b.Clientes.primerApellido.ToString(), montoTotal.ToString(Comun.formatoMoneda), moneda.moneda, b.estatus == true ? "Procesado" : "* Por procesar", b.VentasDetalle.Count().ToString() + " items" };
                            var listViewRow = new ListViewItem(row);
                            listVentas.Items.Add(listViewRow);
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message, "Error");
                        }
                    }
                    else
                    {
                        string[] row = { b.ventaID.ToString(), b.fecha.ToString(), b.Clientes.IDFiscal + "-" + b.Clientes.primerNombre + " " + b.Clientes.primerApellido.ToString(), "0.00", moneda.moneda, b.estatus == true ? "Procesado" : "* Por procesar", b.VentasDetalle.Count().ToString() + " items" };
                        var listViewRow = new ListViewItem(row);
                        listVentas.Items.Add(listViewRow);
                    }
                }
            }



        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = radioGroup1.SelectedIndex;
            string[] MonedaSeleccionada = moneda.Text.Split('-');
            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
            Listar(searchControl1.Text, valor, monedaID);
        }

        private void listVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] MonedaSeleccionada = moneda.Text.Split('-');
            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
            Listar(searchControl1.Text, radioGroup1.SelectedIndex, monedaID);
        }

        private void listVentas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listVentas.SelectedItems.Count > 0)
                {
                    using (ventasEntities db = new ventasEntities())
                    {
                        ListViewItem item = listVentas.SelectedItems[0];
                        if (item.SubItems[5].Text.Contains("Procesado"))
                        {
                            return;
                        }
                        DialogResult result = MessageBox.Show("¿Desea procesar la venta?", "Eliminar", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                if (listVentas.SelectedItems.Count > 0)
                                {
                                    Detallar(Convert.ToInt32(item.SubItems[0].Text));
                                    refrescar();

                                }
                            }
                            catch (Exception)
                            {

                            }
                            listVentas.Items.Clear();
                            cargarMonedas();
                            string[] MonedaSeleccionada = moneda.Text.Split('-');
                            int monedaID = Convert.ToInt32(MonedaSeleccionada[0]);
                            Listar("", 2, monedaID);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Detallar(int ventaID)
        {
            try
            {
                var existe = db.Ventas.Where(x => x.ventaID == ventaID).Count();
                if (existe > 0)
                {
                    var Detalle = db.Ventas.Where(x => x.ventaID == ventaID).FirstOrDefault();
                    if (Detalle.estatus == false)
                    {
                        ventaID = Detalle.ventaID;
                        ctrlPagoVenta frm = new ctrlPagoVenta(ventaID);
                        frm.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }


}