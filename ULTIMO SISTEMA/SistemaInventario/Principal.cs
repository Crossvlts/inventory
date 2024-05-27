using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaInventario.Categorias;
using SistemaInventario.ModeloStock;
using SistemaInventario.ModuloClientes;
using SistemaInventario.ModuloCompras;
using SistemaInventario.ModuloVentas;
using SistemaInventario.ModuloConfiguracion;
using SistemaInventario.ModuloInstrumentoPago;
using SistemaInventario.ModuloProductos;
using SistemaInventario.ModuloProveedores;
using SistemaInventario.ModuloUnidadMedida;
using SistemaInventario.ModuloUsuarios;
using SistemaInventario.ModuloMonedas;
using SistemaInventario.ModuloRespaldos;

namespace SistemaInventario
{
    public partial class Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Principal()
        {
            InitializeComponent();
        }
        public bool esAdmin;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Obtener Nombre usuario 
            lblUsuario.Caption = Comun.usuario;
            esAdmin = Comun.esAdmin;
            ValidarPermisos();

        }
        private void ValidarPermisos()
        {
            try
            {
                // Módulos
                categorias.Enabled = Comun.categorias ? true: false;
                clientes.Enabled = Comun.clientes ? true : false;
                configuracionGeneral.Enabled = Comun.configuracionGeneral ? true : false;
                instrumentoPagos.Enabled = Comun.instrumentoPago ? true : false;
                listadoCompras.Enabled = Comun.listadoCompras ? true : false;
                listadoVentas.Enabled = Comun.listadoVenta ? true : false;
                nuevaCompra.Enabled = Comun.nuevaCompra ? true : false;
                nuevaVenta.Enabled = Comun.nuevaVenta ? true : false;
                proveedores.Enabled = Comun.proveedores ? true : false;
                reporte.Enabled = Comun.reportes ? true : false;
                stock.Enabled = Comun.stock ? true : false;
                unidadMedida.Enabled = Comun.unidadMedida ? true : false;
                usuarios.Enabled = Comun.usuarios ? true : false;
                productos.Enabled = Comun.productos ? true : false;
                monedas.Enabled = Comun.monedas ? true : false;



                //Pestañas
                pestanaCompras.Visible = Comun.pestanaCompras ? true : false;
                pestanaMantenimiento.Visible = Comun.pestanaMantenimiento ? true : false;
                pestanaReportes.Visible = Comun.pestanaReporte ? true : false;
                pestanaVentas.Visible = Comun.pestanaVentas ? true : false;




            }
            catch (Exception)
            {
            }


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlUsuarios frm = new CtrlUsuarios();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            CrtlStock frm = new CrtlStock();
            frm.ShowDialog();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlClientes frm = new CtrlClientes();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlProveedor frm = new CtrlProveedor();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlInstrumentoPago frm = new CtrlInstrumentoPago();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CrtlConfiguracion frm = new CrtlConfiguracion();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                ctrlListadoVentas frm = new ctrlListadoVentas();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlCategoria frm = new CtrlCategoria();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                ctrlProductos frm = new ctrlProductos();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlUnidadMedida frm = new CtrlUnidadMedida();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlNuevaCompra frm = new CtrlNuevaCompra();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CtrlNuevaVenta frm = new CtrlNuevaVenta();
            frm.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                ctrlListadoCompras frm = new ctrlListadoCompras();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
         
        }

        private void reporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReporteCompra formCompra = new frmReporteCompra();
            formCompra.ShowDialog();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReporteVenta formVenta= new frmReporteVenta();
            formVenta.ShowDialog();
           

        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CtrlMonedas ctrlMonedas = new CtrlMonedas();
            ctrlMonedas.ShowDialog();
        }

        private void barButtonItem3_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (esAdmin)
            {
                CtrlRespaldo frm = new CtrlRespaldo();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario no autorizado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReporteClientes1 formCliente = new frmReporteClientes1();
            formCliente.ShowDialog();
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReporteProveedores formProveedores = new frmReporteProveedores();
            formProveedores.ShowDialog();
        }

        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReporteProducto formProducto = new frmReporteProducto();
            formProducto.ShowDialog();
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReporteFiltrado formfiltrador = new frmReporteFiltrado();
            formfiltrador.ShowDialog();
        }
    }
}
