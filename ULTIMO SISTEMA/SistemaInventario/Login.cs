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

namespace SistemaInventario
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            logear();
        }
        private void logear()
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var usuarioExiste = db.Usuarios.Where(x => x.usuario == txtUsuario.Text && x.contrasena == txtContrasena.Text).ToList();

                    if (usuarioExiste.Count > 0)
                    {
                        //1) Validar si esta activo
                        if (usuarioExiste.FirstOrDefault().estatus != true)
                        {
                            MessageBox.Show("Usuario inactivo", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        int usuarioID = usuarioExiste.FirstOrDefault().usuarioID;
                        var tienePermisos = db.UsuariosPermisos.Where(x => x.usuarioID == usuarioID).Count();
                        if (tienePermisos == 0)
                        {
                            MessageBox.Show("Usuario sin permisos", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        var Permisos = db.UsuariosPermisos.Where(x => x.usuarioID == usuarioID).FirstOrDefault();
                        //Permisos del sistema
                        Comun.categorias = Permisos.categorias.Value;
                        Comun.clientes = Permisos.clientes.Value;
                        Comun.configuracionGeneral = Permisos.configuracionGeneral.Value;
                        Comun.instrumentoPago = Permisos.instrumentoPago.Value;
                        Comun.listadoCompras = Permisos.listadoCompras.Value;
                        Comun.listadoVenta = Permisos.listadoVenta.Value;
                        Comun.nuevaCompra = Permisos.nuevaCompra.Value;
                        Comun.nuevaVenta = Permisos.nuevaVenta.Value;
                        Comun.pestanaCompras = Permisos.pestanaCompras.Value;
                        Comun.pestanaMantenimiento = Permisos.pestanaMantenimiento.Value;
                        Comun.pestanaReporte = Permisos.pestanaReporte.Value;
                        Comun.pestanaVentas = Permisos.pestanaVentas.Value;
                        Comun.proveedores = Permisos.proveedores.Value;
                        Comun.reportes = Permisos.reportes.Value;
                        Comun.stock = Permisos.stock.Value;
                        Comun.unidadMedida = Permisos.unidadMedida.Value;
                        Comun.productos = Permisos.productos.Value;
                        Comun.usuarios = Permisos.usuarios.Value;
                        Comun.monedas = Permisos.monedas.Value;



                        // Login existoso 
                        Comun.usuario = usuarioExiste.FirstOrDefault().usuario;
                        Comun.esAdmin = usuarioExiste.FirstOrDefault().esAdmin.Value;
                        Comun.usuarioID = usuarioExiste.FirstOrDefault().usuarioID;
                        // Ir al formulario principal
                        Principal frmPrincipal = new Principal();
                        frmPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario/Contraseña incorrecto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtUsuario_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtContrasena.Select();
                txtContrasena.Focus();
            }
        }

        private void txtContrasena_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.Focus();
                btnLogin.Select();
            }
        }
    }
}