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

namespace SistemaInventario.ModeloStock
{
    public partial class CrtlStock : DevExpress.XtraEditors.XtraForm
    {
        public CrtlStock()
        {
            InitializeComponent();


           }

        private void CrtlStock_Load(object sender, EventArgs e)
        {
            buscar("");

        }

       


        private void buscar(string codigoBarras)
        {
            try
            {
                listView2.Items.Clear();
                using (ventasEntities db = new ventasEntities())
                {

                    decimal Entradas = 0;
                    decimal Salidas = 0;
                    decimal Movimientos = 0;
                    decimal StockInicial = 0;
                    decimal total = 0;
                    if (codigoBarras == "")
                    {
                        var items =
                            db.Stock.GroupBy(l => l.productoID)
                        .Select(cl => new
                        {
                            stockID = cl.FirstOrDefault().stockID,
                            nivelPedido = cl.FirstOrDefault().Productos.nivelAlerta != null ? cl.FirstOrDefault().Productos.nivelAlerta : 0,
                            Nombre = cl.FirstOrDefault().Productos.nombre,
                            Descripcion = cl.FirstOrDefault().Productos.descripcion,
                            CodigoBarras = cl.FirstOrDefault().Productos.codBarras,
                            Fecha = cl.FirstOrDefault().fecha,
                            Cantidad = cl.Sum(c
                            => c.cantidad),
                        }).ToList();

                        int i = 0;
                        foreach (var b in items)
                        {

                            try
                            {
                                string[] row = { b.stockID.ToString(), b.CodigoBarras.ToString(), b.Nombre.ToString(), b.Fecha.Value.ToString(), b.Cantidad.ToString() };
                                var listViewRow = new ListViewItem(row);
                               

                                listView2.Items.Add(listViewRow);
                                if (b.Cantidad <= b.nivelPedido)
                                {
                                    listView2.Items[i].BackColor = Color.Silver;
                                }
                                if (b.Cantidad <= 0)
                                {
                                    listView2.Items[i].BackColor = Color.Orange;
                                }

                                i++;

                                if (b.Cantidad > 0)
                                {
                                    Entradas = Entradas + b.Cantidad.Value;
                                    total = total + b.Cantidad.Value;
                                }
                                else
                                {
                                    Salidas = Salidas + b.Cantidad.Value;
                                    total = total + b.Cantidad.Value;
                                }
                                Movimientos++;
                            }
                            catch (Exception ee)
                            {
                                MessageBox.Show(ee.Message, "Error");
                            }
                        }
                        lblTotal.Text = total.ToString();
                    }
                    else
                    {
                        // Buscar item especifico
                        var items =
                            db.Stock.GroupBy(l => l.productoID)
                        .Select(cl => new
                        {
                            stockID = cl.FirstOrDefault().stockID,
                            Nombre = cl.FirstOrDefault().Productos.nombre,
                            Descripcion = cl.FirstOrDefault().Productos.descripcion,
                            CodigoBarras = cl.FirstOrDefault().Productos.codBarras,
                            Fecha = cl.FirstOrDefault().fecha,
                            Estatus = cl.FirstOrDefault().Productos.estatus == true,
                            Cantidad = cl.Sum(c
                            => c.cantidad),
                        }).Where(x => x.Estatus == true && x.CodigoBarras.Contains(codigoBarras) || x.Nombre.ToString().Contains(codigoBarras)).ToList();


                        int i = 0;
                        foreach (var b in items)
                        {
                            if (i == 0)
                            {
                                StockInicial = b.Cantidad.Value;
                            }
                            try
                            {
                                string[] row = { b.stockID.ToString(), b.CodigoBarras.ToString(), b.Nombre.ToString(), b.Fecha.Value.ToString(), b.Cantidad.ToString() };
                                var listViewRow = new ListViewItem(row);
                                listView2.Items.Add(listViewRow);
                                i++;

                                if (b.Cantidad > 0)
                                {
                                    Entradas = Entradas + b.Cantidad.Value;
                                    total = total + b.Cantidad.Value;
                                }
                                else
                                {
                                    Salidas = Salidas + b.Cantidad.Value;
                                    total = total + b.Cantidad.Value;
                                }
                                Movimientos++;
                            }
                            catch (Exception ee)
                            {
                                MessageBox.Show(ee.Message, "Error");
                            }
                        }
                    }
                    lblTotal.Text = total.ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buscar(searchControl1.Text);
            }
        }

        private void lblStockInicial_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}