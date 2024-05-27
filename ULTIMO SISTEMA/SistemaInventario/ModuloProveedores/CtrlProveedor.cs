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

namespace SistemaInventario.ModuloProveedores
{
    public partial class CtrlProveedor : DevExpress.XtraEditors.XtraForm
    {
        public CtrlProveedor()
        {
            InitializeComponent();
        }

        private void CtrlProveedor_Load(object sender, EventArgs e)
        {
            Limpiar();
            Llenar();
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

        // ------------------------------------------ Metodos y funciones ----------------------- //
        // ---------------- Llenar formulario ------------------------//
        private void Llenar()
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var ProveedorS = (from Proveedor in db.Proveedores
                                     select new
                                     {
                                         ID = Proveedor.proveedorID,
                                         IDFiscal = Proveedor.IDFiscal,
                                         nombre = Proveedor.empresa,
                                         estatus = Proveedor.estatus
                                     }).ToList();


                    int i = 0;
                    foreach (var b in ProveedorS)
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
            txtDireccion.Text = "";
            txtEmpresa.Text = "";
            txtVendedor.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
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
                        if (ValidarEmpresa(txtEmpresa.Text) > 0)
                        {
                            MessageBox.Show("Está empresa ya se encuentra registrada", "Advertencia");
                            return;
                        }
                        Modelos.Proveedores item = new Modelos.Proveedores();
                        item.estatus = checkEstatus.Checked;
                        item.empresa = txtEmpresa.Text;
                        item.vendedor = txtVendedor.Text;
                        item.direccion = txtDireccion.Text;
                        item.telefono = txtTelefono.Text;
                        item.IDFiscal = txtIDFiscal.Text;
                        db.Proveedores.Add(item);
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
                        if (ValidarEmpresa(txtEmpresa.Text) > 1)
                        {
                            MessageBox.Show("Está empresa ya se encuentra registrada", "Advertencia");
                            return;
                        }
                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.Proveedores.Where(x => x.proveedorID == ID).FirstOrDefault();
                        item.estatus = checkEstatus.Checked;
                        item.empresa = txtEmpresa.Text;
                        item.vendedor = txtVendedor.Text;
                        item.direccion = txtDireccion.Text;
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
                    var item = db.Proveedores.Where(x => x.proveedorID == ID).FirstOrDefault();
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
        private int ValidarIDFiscal(string idFiscal)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Proveedores.Where(x => x.IDFiscal == idFiscal).Count();
                    return existe;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int ValidarEmpresa(string empr)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Proveedores.Where(x => x.empresa == empr).Count();
                    return existe;
                }
            }
            catch (Exception)
            {
                return 0;
            }
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
                        var objeto = db.Proveedores.Where(x => x.proveedorID == ID).FirstOrDefault();
                        txtIDFiscal.Text = objeto.IDFiscal;
                        txtEmpresa.Text = objeto.empresa;
                        txtVendedor.Text = objeto.vendedor;
                        txtDireccion.Text = objeto.direccion;
                        txtTelefono.Text = objeto.telefono;
                        txtTelefono.Text = objeto.telefono;
                        checkEstatus.Checked = objeto.estatus.Value;
                        btnAceptar.Text = "Modificar";
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}