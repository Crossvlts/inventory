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
    public partial class nuevoCliente : DevExpress.XtraEditors.XtraForm
    {
        public nuevoCliente()
        {
            InitializeComponent();
        }

        ventasEntities db = new ventasEntities();
        private void nuevoCliente_Load(object sender, EventArgs e)
        {
            txtIDFiscal.Text = Comun.ItemSeleccionado;
            txtPrimerNombre.Select();
            txtPrimerNombre.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            crear();
        }

        private void crear()
        {
            if (txtIDFiscal.Text == "")
            {
                MessageBox.Show("Debe indicar el ID Fiscal", "Advertencia");
                txtIDFiscal.Select();
                return;
            }
            else if (txtPrimerNombre.Text == "")
            {
                MessageBox.Show("Debe el primer nombre", "Advertencia");
                txtPrimerNombre.Select();
                return;
            }
            else if (txtPrimerApellido.Text == "")
            {
                MessageBox.Show("Debe indicar el primer apellido", "Advertencia");
                txtPrimerApellido.Select();
                return;
            }
            try
            {
                Clientes item = new Clientes();
                item.estatus = true;
                item.primerNombre = txtPrimerNombre.Text;
                item.segundoNombre = txtSegundoNombre.Text;
                item.primerApellido = txtPrimerApellido.Text;
                item.segundoApellido = txtSegundoApellido.Text;
                item.telefono = txtTelefono.Text;
                item.IDFiscal = txtIDFiscal.Text;
                db.Clientes.Add(item);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void nuevoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                crear();
            }
        }
    }
}