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
using System.Data.Entity;
using SistemaInventario.Modelos;

namespace SistemaInventario.Categorias
{
    public partial class CtrlCategoria : DevExpress.XtraEditors.XtraForm
    {
        public CtrlCategoria()
        {
            InitializeComponent();
        }

        private void CtrlCategoria_Load(object sender, EventArgs e)
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

        private int ValidarCategoria(string name)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Categorias.Where(x => x.nombre == name).Count();
                    return existe;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ActualizarCrear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Llenar();
        }
        // ------------------------------------------ Metodos y funciones ----------------------- //
        // ---------------- Llenar formulario ------------------------//
        private void Llenar()
        {
            using (ventasEntities db = new ventasEntities())
            {
                var Categorias = (from categoria in db.Categorias
                                  select new
                                  {
                                      ID = categoria.categoriaID,
                                      nombre = categoria.nombre,
                                      estatus = categoria.estatus
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

        private void ActualizarCrear()
        {
            if (btnAceptar.Text == "Aceptar")
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese una Categoría", "Advertencia");

                }
                else
                {


                    using (ventasEntities db = new ventasEntities())
                    {
                        try
                        {
                            if (ValidarCategoria(txtNombre.Text) > 0)
                            {
                                MessageBox.Show("Categoría Existente", "Advertencia");
                                return;
                            }
                            Modelos.Categorias categori = new Modelos.Categorias();
                            categori.estatus = checkEstatus.Checked;
                            categori.nombre = txtNombre.Text;
                            db.Categorias.Add(categori);
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

                        if (ValidarCategoria(txtNombre.Text) > 1)
                        {
                            MessageBox.Show("Categoría Existente", "Advertencia");
                            return;
                        }
                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.Categorias.Where(x => x.categoriaID == ID).FirstOrDefault();

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
                    var item = db.Categorias.Where(x => x.categoriaID == ID).FirstOrDefault();
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