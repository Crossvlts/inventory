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

namespace SistemaInventario.ModuloMonedas
{
    public partial class CtrlMonedas : DevExpress.XtraEditors.XtraForm
    {
        public CtrlMonedas()
        {
            InitializeComponent();
        }

        private void CtrlMonedas_Load(object sender, EventArgs e)
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
                    txtMoneda.Text = item.SubItems[1].Text;
                    txtID.Text = item.SubItems[0].Text;
                    checkEstatus.Checked = item.SubItems[2].Text == "Si" ? true : false;
                    checkEsBase.Checked = item.SubItems[3].Text == "Si" ? true : false;
                    txtValor.Text = item.SubItems[4].Text;
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
                var Instrumento = (from instrum in db.Monedas
                                   select new
                                   {
                                       ID = instrum.monedaID,
                                       moneda = instrum.moneda,
                                       estatus = instrum.estatus,
                                       esBase = instrum.esBase,
                                       Valor = instrum.valor,
                                   }).ToList();


                int i = 0;
                foreach (var b in Instrumento)
                {
                    try
                    {
                        string[] row = { b.ID.ToString(), b.moneda.ToString(), b.estatus.Value ? "Si" : "No", b.esBase.Value ? "Si" : "No", b.Valor.Value.ToString() };
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
            txtMoneda.Text = "";
            txtID.Text = "";
            checkEstatus.Checked = false;
            checkEsBase.Checked = false;
            btnAceptar.Text = "Aceptar";
        }
        // ---------------- Salir del módulo ----------------------------//
        private void Salir()
        {
            this.Close();
        }

        private int ValidarMoneda(string coin)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existe = db.Monedas.Where(x => x.moneda == coin).Count();
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
                if (txtMoneda.Text == "")
                {
                    MessageBox.Show("Ingrese Datos", "Advertencia");

                }
                else
                {

                    using (ventasEntities db = new ventasEntities())
                    {
                        if (checkEsBase.Checked)
                        {
                            var existeBase = db.Monedas.Where(x => x.esBase == true).Count();
                            if (existeBase > 0)
                            {
                                MessageBox.Show("Ya existe una moneda base", "Advertencia");
                                return;
                            }
                        }
                        if (ValidarMoneda(txtMoneda.Text) > 0)
                        {
                            MessageBox.Show("Esta moneda ya está registrada", "Advertencia");
                            return;
                        }
                        try
                        {


                            Monedas item = new Monedas();
                            item.estatus = checkEstatus.Checked;
                            item.esBase = checkEsBase.Checked;
                            item.moneda = txtMoneda.Text;
                            item.valor = txtValor.Text != null ? Convert.ToDecimal(txtValor.Text) : 0;
                            db.Monedas.Add(item);
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
                    if (checkEsBase.Checked)
                    {
                        var existeBase = db.Monedas.Where(x => x.esBase == true).Count();
                        if (existeBase > 1)
                        {
                            MessageBox.Show("Ya existe una moneda base", "Advertencia");
                            return;
                        }
                    }
                    if (ValidarMoneda (txtMoneda.Text) > 1)
                    {
                        MessageBox.Show("Esta moneda ya está registrada", "Advertencia");
                        return;
                    }
                    try
                    {
                        int ID = Convert.ToInt32(txtID.Text);
                        var item = db.Monedas.Where(x => x.monedaID == ID).FirstOrDefault();
                        item.estatus = checkEstatus.Checked;
                        item.esBase = checkEsBase.Checked;
                        item.moneda = txtMoneda.Text;
                        item.valor = txtValor.Text != null ? Convert.ToDecimal(txtValor.Text) : 0;
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
                    var item = db.Monedas.Where(x => x.monedaID == ID).FirstOrDefault();
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