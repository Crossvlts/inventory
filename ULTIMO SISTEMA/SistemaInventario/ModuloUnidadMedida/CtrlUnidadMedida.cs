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

namespace SistemaInventario.ModuloUnidadMedida
{
    public partial class CtrlUnidadMedida : DevExpress.XtraEditors.XtraForm
    {
        public CtrlUnidadMedida()
        {
            InitializeComponent();
        }

        private void CtrlUnidadMedida_Load(object sender, EventArgs e)
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
                    ListViewItem item = listView1.SelectedItems[0];
                    txtNombre.Text = item.SubItems[1].Text;
                    txtID.Text = item.SubItems[0].Text;
                    checkEstatus.Checked = item.SubItems[2].Text == "Si" ? true : false;
                    btnAceptar.Text = "Modificar";
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

        // ------------------------------------------ Metodos y funciones ----------------------- //
        // ---------------- Llenar formulario ------------------------//
        private void Llenar()
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var unidadMedidaS = (from unidadMedida in db.UnidadesMedidas
                                         select new
                                         {
                                             ID = unidadMedida.unidadMedidaID,
                                             nombre = unidadMedida.nombre,
                                             estatus = unidadMedida.estatus
                                         }).ToList();


                    int i = 0;
                    foreach (var b in unidadMedidaS)
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
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Items.Clear();
            //--------------------- Txtbox --------------------
            txtNombre.Text = "";
            txtID.Text = "";
            checkEstatus.Checked = false;
            btnAceptar.Text = "Aceptar";
        }
        // ---------------- Salir del módulo ----------------------------//
        private void Salir()
        {
            this.Close();
        }

        private int ValidarUnidad(string name)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.UnidadesMedidas.Where(x => x.nombre == name).Count();
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
            if (btnAceptar.Text == "Aceptar")
            {
                using (ventasEntities db = new ventasEntities())
                {
                    try
                    {
                        if (ValidarUnidad(txtNombre.Text) > 0)
                        {
                            MessageBox.Show("Categoría Existente", "Advertencia");
                            return;
                        }
                        Modelos.UnidadesMedidas item = new Modelos.UnidadesMedidas();
                        item.estatus = checkEstatus.Checked;
                        item.nombre = txtNombre.Text;
                        db.UnidadesMedidas.Add(item);
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
                        if (ValidarUnidad(txtNombre.Text) > 1)
                        {
                            MessageBox.Show("Categoría Existente", "Advertencia");
                            return;
                        }

                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.UnidadesMedidas.Where(x => x.unidadMedidaID == ID).FirstOrDefault();

                        item.estatus = checkEstatus.Checked;
                        item.nombre = txtNombre.Text;
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
                    var item = db.UnidadesMedidas.Where(x => x.unidadMedidaID == ID).FirstOrDefault();
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

        private void txtNombre_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}