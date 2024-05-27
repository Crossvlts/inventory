using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Modelos;
using System.Data.Entity;

namespace SistemaInventario.ModuloInstrumentoPago
{
    public partial class CtrlInstrumentoPago : DevExpress.XtraEditors.XtraForm
    {
        public CtrlInstrumentoPago()
        {
            InitializeComponent();
        }

        private void CtrlInstrumentoPago_Load(object sender, EventArgs e)
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
                    checkIGFT.Checked = item.SubItems[3].Text == "Si" ? true : false;
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
            using (ventasEntities db = new ventasEntities())
            {
                var Instrumento = (from instrum in db.MetodosPago
                                   select new
                                   {
                                       ID = instrum.metodoPagoID,
                                       nombre = instrum.nombre,
                                       estatus = instrum.estatus,
                                       aplicaIGTF = instrum.aplicaIGTF
                                   }).ToList();


                int i = 0;
                foreach (var b in Instrumento)
                {
                    try
                    {
                        string[] row = { b.ID.ToString(), b.nombre.ToString(), b.estatus.Value ? "Si" : "No", b.aplicaIGTF.Value ? "Si" : "No" };
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
            checkIGFT.Checked = false;
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
                        Modelos.MetodosPago item = new Modelos.MetodosPago();
                        item.estatus = checkEstatus.Checked;
                        item.aplicaIGTF = checkIGFT.Checked;
                        item.nombre = txtNombre.Text;
                        db.MetodosPago.Add(item);
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
                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.MetodosPago.Where(x => x.metodoPagoID == ID).FirstOrDefault();
                        item.estatus = checkEstatus.Checked;
                        item.aplicaIGTF = checkIGFT.Checked;
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
                    var item = db.MetodosPago.Where(x => x.metodoPagoID == ID).FirstOrDefault();
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
    }
}