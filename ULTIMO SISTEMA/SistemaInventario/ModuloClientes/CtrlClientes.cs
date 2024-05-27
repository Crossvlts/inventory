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

namespace SistemaInventario.ModuloClientes
{
    public partial class CtrlClientes : DevExpress.XtraEditors.XtraForm
    {
        public CtrlClientes()
        {
            InitializeComponent();
        }

        private void CtrlClientes_Load(object sender, EventArgs e)
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
                        var objeto = db.Clientes.Where(x => x.clienteID == ID).FirstOrDefault();
                        txtIDFiscal.Text = objeto.IDFiscal;
                        txtPrimerNombre.Text = objeto.primerNombre;
                        txtSegundoNombre.Text = objeto.segundoNombre;
                        txtPrimerApellido.Text = objeto.primerApellido;
                        txtSegundoApellido.Text = objeto.segundoApellido;
                        checkEstatus.Checked = objeto.estatus.Value;
                        txtTelefono.Text = objeto.telefono;
                        btnAceptar.Text = "Modificar";
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
        private int ValidarIDFiscal(string idFiscal)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Clientes.Where(x => x.IDFiscal == idFiscal).Count();
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
                    var ClientesS = (from Clientes in db.Clientes
                                     select new
                                     {
                                         ID = Clientes.clienteID,
                                         IDFiscal = Clientes.IDFiscal,
                                         nombre = Clientes.primerNombre + " " + Clientes.primerApellido,
                                         estatus = Clientes.estatus
                                     }).ToList();


                    int i = 0;
                    foreach (var b in ClientesS)
                    {
                        try
                        {
                            string[] row = { b.ID.ToString(), b.IDFiscal.ToString(), b.nombre.ToString(), b.estatus.Value ? "Si" : "No" };
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
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtTelefono.Text = "";
            txtPrimerApellido.Text = "";
            txtID.Text = "";
            txtIDFiscal.Text = "";
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
                using (ventasEntities db = new ventasEntities())
                {
                    try
                    {
                        if (ValidarIDFiscal(txtIDFiscal.Text) > 0)
                        {
                            MessageBox.Show("ID Fiscal existe", "Advertencia");
                            return;
                        }
                        Modelos.Clientes item = new Modelos.Clientes();
                        item.estatus = checkEstatus.Checked;
                        item.primerNombre = txtPrimerNombre.Text;
                        item.segundoNombre = txtSegundoNombre.Text;
                        item.primerApellido = txtPrimerApellido.Text;
                        item.segundoApellido = txtSegundoApellido.Text;
                        item.telefono = txtTelefono.Text;
                        item.IDFiscal = txtIDFiscal.Text;
                        db.Clientes.Add(item);
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
                        if (ValidarIDFiscal(txtIDFiscal.Text) > 1)
                        {
                            MessageBox.Show("ID Fiscal existe", "Advertencia");
                            return;
                        }
                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.Clientes.Where(x => x.clienteID == ID).FirstOrDefault();
                        item.estatus = checkEstatus.Checked;
                        item.primerNombre = txtPrimerNombre.Text;
                        item.segundoNombre = txtSegundoNombre.Text;
                        item.primerApellido = txtPrimerApellido.Text;
                        item.segundoApellido = txtSegundoApellido.Text;
                        item.telefono = txtTelefono.Text;
                        item.IDFiscal = txtIDFiscal.Text;
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
                    var item = db.Clientes.Where(x => x.clienteID == ID).FirstOrDefault();
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

        private void CtrlClientes_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CtrlClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                //procesarCompra();
            }
        }
    }
}