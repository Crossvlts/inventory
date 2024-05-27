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

namespace SistemaInventario.ModuloRespaldos
{
    public partial class CtrlRespaldo : DevExpress.XtraEditors.XtraForm
    {
        public CtrlRespaldo()
        {
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CtrlRespaldo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Respaldo();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Restaurar();

        }

        private void Respaldo()
        {
            using (var db = new ventasEntities())
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "SQL Server database backup files|*.bak";
                saveFileDialog1.Title = "Database Backup";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string backupPath = saveFileDialog1.FileName;
                    string dbname = db.Database.Connection.Database;
                    string sqlCommand = "BACKUP DATABASE [{0}] TO DISK = N'{1}' WITH NOFORMAT, NOINIT, NAME = N'MyAir-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                    db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname, backupPath));
                    MessageBox.Show("Respaldo guardado con Éxito", "Éxito");

                }
            }



        }

        public void Restaurar()
        {
            using (var db = new ventasEntities())
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "SQL Server database backup files|*.bak";
                openFileDialog1.Title = "Database Restore";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string restorePath = openFileDialog1.FileName;
                    string dbname = db.Database.Connection.Database;
                    string sqlCommandText = "USE [master]; ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [{0}] FROM DISK = N'{1}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5; ALTER DATABASE [{0}] SET MULTI_USER;";
                    string sqlCommand = string.Format(sqlCommandText, dbname, restorePath);

                    using (var command = new System.Data.SqlClient.SqlCommand(sqlCommand, (System.Data.SqlClient.SqlConnection)db.Database.Connection))
                    {
                        db.Database.Connection.Open();
                        command.ExecuteNonQuery();
                        db.Database.Connection.Close();
                    }

                    MessageBox.Show("Respaldo Restaurado con Éxito", "Éxito");
                }
            }
        }
    }
}