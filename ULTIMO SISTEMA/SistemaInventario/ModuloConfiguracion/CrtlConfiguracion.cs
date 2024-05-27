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

namespace SistemaInventario.ModuloConfiguracion
{
    public partial class CrtlConfiguracion : DevExpress.XtraEditors.XtraForm
    {
        public CrtlConfiguracion()
        {
            InitializeComponent();
        }

        private void CrtlConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existeConfig = db.Configuracion.Count();
                    if (existeConfig > 0)
                    {
                        var registro = db.Configuracion.FirstOrDefault();
                        txtImpuesto.Text = registro.Impuesto.Value.ToString();
                       // txtEmpresa.Text = registro.nombreEmpresa;
                        //txtTelefonoC.Text = registro.telefonoEmpresa;
                       // txtIDFiscal.Text = registro.IDFiscalempresa;
                        igft.Text = registro.IGTF.Value.ToString();
                        barCodeControl1.Text = txtIDFiscal.Text;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ventasEntities db = new ventasEntities())
                {
                    var existeConfig = db.Configuracion.Count();
                    if (existeConfig > 0)
                    {
                        var registro = db.Configuracion.FirstOrDefault();
                        registro.nombreEmpresa = txtEmpresa.Text;
                        registro.telefonoEmpresa = txtTelefonoC.Text;
                        registro.IDFiscalempresa = txtIDFiscal.Text;
                        registro.IGTF = igft.Text != "" ? Convert.ToDecimal(igft.Text) : 0;
                        registro.Impuesto = txtImpuesto.Text != "" ? Convert.ToDecimal(txtImpuesto.Text) : 0;
                        db.Entry(registro).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Registro actualizado con éxito", "Éxito");
                        this.Close();
                    }
                    else
                    {
                        Configuracion registro = new Configuracion();
                        registro.nombreEmpresa = txtEmpresa.Text;
                        registro.telefonoEmpresa = txtTelefonoC.Text;
                        registro.IDFiscalempresa = txtIDFiscal.Text;
                        registro.IGTF = igft.Text != "" ? Convert.ToDecimal(igft.Text) : 0;
                        registro.Impuesto = txtImpuesto.Text != "" ? Convert.ToDecimal(txtImpuesto.Text) : 0;
                        db.Configuracion.Add(registro);
                        db.SaveChanges();
                        MessageBox.Show("Registro actualizado con éxito", "Éxito");
                        this.Close();
                    }


                }
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message, "Error");
            }
        }

        private void txtTelefono_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}