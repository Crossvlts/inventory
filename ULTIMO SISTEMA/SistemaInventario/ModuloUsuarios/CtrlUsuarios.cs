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

namespace SistemaInventario.ModuloUsuarios
{
    public partial class CtrlUsuarios : DevExpress.XtraEditors.XtraForm
    {
        public CtrlUsuarios()
        {
            InitializeComponent();
        }

        private void CtrlUsuarios_Load(object sender, EventArgs e)
        {
            Limpiar();
            Llenar();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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
                        var objeto = db.Usuarios.Where(x => x.usuarioID == ID).FirstOrDefault();
                        txtUsuario.Text = objeto.usuario;
                        checkEstatus.Checked = objeto.estatus.Value;
                        checkEsAdmin.Checked = objeto.esAdmin.Value;
                        btnAceptar.Text = "Modificar";

                        try
                        {
                            var existePermisos = db.UsuariosPermisos.Where(x => x.usuarioID == ID).Count();
                            if (existePermisos > 0)
                            {
                                var objetoPermisos = db.UsuariosPermisos.Where(x => x.usuarioID == ID).FirstOrDefault();
                                categorias.Checked = objetoPermisos.categorias.Value;
                                clientes.Checked = objetoPermisos.clientes.Value;
                                configuracion.Checked = objetoPermisos.configuracionGeneral.Value;
                                instrumentoPago.Checked = objetoPermisos.instrumentoPago.Value;
                                listadoCompra.Checked = objetoPermisos.listadoCompras.Value;
                                listadoVenta.Checked = objetoPermisos.listadoVenta.Value;
                                nuevaCompra.Checked = objetoPermisos.nuevaCompra.Value;
                                nuevaVenta.Checked = objetoPermisos.nuevaVenta.Value;
                                pestanaCompras.Checked = objetoPermisos.pestanaCompras.Value;
                                pestanaMantenimiento.Checked = objetoPermisos.pestanaMantenimiento.Value;
                                pestanaReporte.Checked = objetoPermisos.pestanaReporte.Value;
                                pestanaVentas.Checked = objetoPermisos.pestanaVentas.Value;
                                proveedores.Checked = objetoPermisos.proveedores.Value;
                                reporte.Checked = objetoPermisos.reportes.Value;
                                productos.Checked = objetoPermisos.productos.Value;
                                stock.Checked = objetoPermisos.stock.Value;
                                unidadMedida.Checked = objetoPermisos.unidadMedida.Value;
                                monedas.Checked = objetoPermisos.monedas.Value;
                                respaldos.Checked = objetoPermisos.respaldos.Value;
                            }
                            else
                            {
                                categorias.Checked = false;
                                clientes.Checked = false;
                                configuracion.Checked = false;
                                instrumentoPago.Checked = false;
                                listadoCompra.Checked = false;
                                listadoVenta.Checked = false;
                                nuevaCompra.Checked = false;
                                nuevaVenta.Checked = false;
                                productos.Checked = false;
                                pestanaCompras.Checked = false;
                                pestanaMantenimiento.Checked = false;
                                pestanaReporte.Checked = false;
                                pestanaVentas.Checked = false;
                                proveedores.Checked = false;
                                reporte.Checked = false;
                                stock.Checked = false;
                                unidadMedida.Checked = false;
                                monedas.Checked = false;
                                respaldos.Checked = false;
                            }

                        }
                        catch (Exception ex)
                        {


                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Salir();
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
            ActualizarCrear();
        }
        private int ValidarUsuario(string usuario)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Usuarios.Where(x => x.usuario == usuario).Count();
                    return existe;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // ------------------------------------------ Metodos y funciones ----------------------- //
        // ---------------- Llenar formulario ------------------------//
        private void Llenar()
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var Usuarios = (from Usuario in db.Usuarios
                                    select new
                                    {
                                        ID = Usuario.usuarioID,
                                        nombre = Usuario.usuario,
                                        estatus = Usuario.estatus
                                    }).ToList();


                    int i = 0;
                    foreach (var b in Usuarios)
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }
        // ---------------- Limpiar formulario ------------------------//
        private void Limpiar()
        {
            listView1.Items.Clear();
            //--------------------- Txtbox --------------------
            txtContrasena.Text = "";
            txtRepetirContrasena.Text = "";
            txtID.Text = "";
            txtUsuario.Text = "";
            checkEstatus.Checked = false;
            btnAceptar.Text = "Aceptar";
        }
        // ---------------- Salir del módulo ----------------------------//
        private void Salir()
        {
            this.Close();
        }

        private void ActualizarCrear()
        {
            if (btnAceptar.Text == "Aceptar")
            {

                if (txtUsuario.Text == "" || txtContrasena.Text == "" || txtRepetirContrasena.Text == "")
                {
                    MessageBox.Show("Ingrese un usuario y contraseña", "Advertencia");

                }
                else
                {
                    using (ventasEntities db = new ventasEntities())
                    {
                        try
                        {
                            if (ValidarUsuario(txtUsuario.Text) > 0)
                            {
                                MessageBox.Show("Nombre de Usuario Existente, Elija Otro", "Advertencia");
                                return;
                            }
                            if (txtContrasena.Text != txtRepetirContrasena.Text)
                            {
                                MessageBox.Show("Las contraseñas no coinciden", "Advertencia");
                                return;
                            }
                            if (txtContrasena.Text.Length <= 6 )
                            {
                                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Advertencia");
                                return;
                            }

                            Usuarios item = new Modelos.Usuarios();
                            item.usuario = txtUsuario.Text;
                            item.esAdmin = checkEsAdmin.Checked;
                            item.estatus = checkEstatus.Checked;
                            item.contrasena = txtContrasena.Text;
                            db.Usuarios.Add(item);
                            db.SaveChanges();

                            // Crear permisos 
                            var ultimoUsuario = db.Usuarios.OrderByDescending(x => x.usuarioID).FirstOrDefault();
                            UsuariosPermisos itemPermiso = new UsuariosPermisos();
                            itemPermiso.categorias = categorias.Checked;
                            itemPermiso.clientes = clientes.Checked;
                            itemPermiso.stock = stock.Checked;
                            itemPermiso.usuarios = usuario.Checked;
                            itemPermiso.configuracionGeneral = configuracion.Checked;
                            itemPermiso.instrumentoPago = instrumentoPago.Checked;
                            itemPermiso.listadoCompras = listadoCompra.Checked;
                            itemPermiso.listadoVenta = listadoVenta.Checked;
                            itemPermiso.nuevaCompra = nuevaCompra.Checked;
                            itemPermiso.nuevaVenta = nuevaVenta.Checked;
                            itemPermiso.pestanaCompras = pestanaCompras.Checked;
                            itemPermiso.pestanaMantenimiento = pestanaMantenimiento.Checked;
                            itemPermiso.pestanaReporte = pestanaReporte.Checked;
                            itemPermiso.pestanaVentas = pestanaVentas.Checked;
                            itemPermiso.proveedores = proveedores.Checked;
                            itemPermiso.productos = productos.Checked;
                            itemPermiso.reportes = reporte.Checked;
                            itemPermiso.unidadMedida = unidadMedida.Checked;
                            itemPermiso.monedas = monedas.Checked;
                            itemPermiso.respaldos = respaldos.Checked;
                            itemPermiso.usuarioID = ultimoUsuario.usuarioID;
                            db.UsuariosPermisos.Add(itemPermiso);
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
            }
            else
            {
                using (ventasEntities db = new ventasEntities())
                {
                    try
                    {
                        if (ValidarUsuario(txtUsuario.Text) > 1)
                        {
                            MessageBox.Show("ID Fiscal existe", "Advertencia");
                            return;
                        }
                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.Usuarios.Where(x => x.usuarioID == ID).FirstOrDefault();
                        item.estatus = checkEstatus.Checked;
                        item.esAdmin = checkEsAdmin.Checked;
                        item.usuario = txtUsuario.Text;
                        if (txtContrasena.Text != "" && txtRepetirContrasena.Text != "")
                        {
                            if (txtContrasena.Text != txtRepetirContrasena.Text)
                            {
                                MessageBox.Show("Las contraseñas no coinciden", "Advertencia");
                                return;
                            }
                            else
                            {
                                item.contrasena = txtContrasena.Text;
                            }
                        }
                        else
                        {
                            item.contrasena = item.contrasena;
                        }
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        // Editar permisos 
                        var existePermisos = db.UsuariosPermisos.Where(x => x.usuarioID == ID).Count();
                        if (existePermisos > 0)
                        {
                            var usuarioPermiso = db.UsuariosPermisos.Where(x => x.usuarioID == ID).FirstOrDefault();
                            usuarioPermiso.categorias = categorias.Checked;
                            usuarioPermiso.clientes = clientes.Checked;
                            usuarioPermiso.stock = stock.Checked;
                            usuarioPermiso.monedas = monedas.Checked;
                            usuarioPermiso.respaldos = respaldos.Checked;
                            usuarioPermiso.productos = productos.Checked;
                            usuarioPermiso.usuarios = usuario.Checked;
                            usuarioPermiso.configuracionGeneral = configuracion.Checked;
                            usuarioPermiso.instrumentoPago = instrumentoPago.Checked;
                            usuarioPermiso.listadoCompras = listadoCompra.Checked;
                            usuarioPermiso.listadoVenta = listadoVenta.Checked;
                            usuarioPermiso.nuevaCompra = nuevaCompra.Checked;
                            usuarioPermiso.nuevaVenta = nuevaVenta.Checked;
                            usuarioPermiso.pestanaCompras = pestanaCompras.Checked;
                            usuarioPermiso.pestanaMantenimiento = pestanaMantenimiento.Checked;
                            usuarioPermiso.pestanaReporte = pestanaReporte.Checked;
                            usuarioPermiso.pestanaVentas = pestanaVentas.Checked;
                            usuarioPermiso.proveedores = proveedores.Checked;
                            usuarioPermiso.reportes = reporte.Checked;
                            usuarioPermiso.unidadMedida = unidadMedida.Checked;
                            usuarioPermiso.usuarioID = ID;
                            db.Entry(usuarioPermiso).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            // CRear permisso 
                            UsuariosPermisos itemPermiso = new UsuariosPermisos();
                            itemPermiso.categorias = categorias.Checked;
                            itemPermiso.clientes = clientes.Checked;
                            itemPermiso.stock = stock.Checked;
                            itemPermiso.usuarios = usuario.Checked;
                            itemPermiso.monedas = monedas.Checked;
                            itemPermiso.respaldos = respaldos.Checked;
                            itemPermiso.productos = productos.Checked;
                            itemPermiso.configuracionGeneral = configuracion.Checked;
                            itemPermiso.instrumentoPago = instrumentoPago.Checked;
                            itemPermiso.listadoCompras = listadoCompra.Checked;
                            itemPermiso.listadoVenta = listadoVenta.Checked;
                            itemPermiso.nuevaCompra = nuevaCompra.Checked;
                            itemPermiso.nuevaVenta = nuevaVenta.Checked;
                            itemPermiso.pestanaCompras = pestanaCompras.Checked;
                            itemPermiso.pestanaMantenimiento = pestanaMantenimiento.Checked;
                            itemPermiso.pestanaReporte = pestanaReporte.Checked;
                            itemPermiso.pestanaVentas = pestanaVentas.Checked;
                            itemPermiso.proveedores = proveedores.Checked;
                            itemPermiso.reportes = reporte.Checked;
                            itemPermiso.unidadMedida = unidadMedida.Checked;
                            itemPermiso.usuarioID = ID;
                            db.UsuariosPermisos.Add(itemPermiso);
                            db.SaveChanges();
                        }

                        MessageBox.Show("Registro actualizado con éxito, se recomienda reiniciar el sistema", "Éxito");
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
                    var item = db.Usuarios.Where(x => x.usuarioID == ID).FirstOrDefault();
                    db.UsuariosPermisos.Where(x => x.usuarioID == ID).FirstOrDefault();
                    db.Entry(item).State = EntityState.Deleted;
                    db.SaveChanges();
                    MessageBox.Show("Registro eliminado con éxito", "Éxito");
                    Limpiar();
                    Llenar();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error");
                }

            }
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monedas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}