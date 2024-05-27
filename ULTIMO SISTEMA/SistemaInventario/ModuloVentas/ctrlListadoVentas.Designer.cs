namespace SistemaInventario.ModuloVentas
{
    partial class ctrlListadoVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.listVentas = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.moneda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneda.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Location = new System.Drawing.Point(-41, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 26);
            this.panel1.TabIndex = 41;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(129, 2);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 21);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Ventas";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(833, 7);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(38, 16);
            this.labelControl7.TabIndex = 43;
            this.labelControl7.Text = "Buscar";
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(833, 27);
            this.searchControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(166, 22);
            this.searchControl1.TabIndex = 42;
            // 
            // listVentas
            // 
            this.listVentas.AutoArrange = false;
            this.listVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listVentas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader2});
            this.listVentas.FullRowSelect = true;
            this.listVentas.GridLines = true;
            this.listVentas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listVentas.Location = new System.Drawing.Point(12, 69);
            this.listVentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listVentas.MultiSelect = false;
            this.listVentas.Name = "listVentas";
            this.listVentas.Size = new System.Drawing.Size(976, 326);
            this.listVentas.TabIndex = 44;
            this.listVentas.UseCompatibleStateImageBehavior = false;
            this.listVentas.View = System.Windows.Forms.View.Details;
            this.listVentas.SelectedIndexChanged += new System.EventHandler(this.listVentas_SelectedIndexChanged);
            this.listVentas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listVentas_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "N°";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fecha";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cliente";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Monto venta";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Moneda";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Estatus";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Items ";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(12, 400);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("hoy", "Ventas de hoy"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Ventas del mes"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Todas las ventas")});
            this.radioGroup1.Size = new System.Drawing.Size(367, 32);
            this.radioGroup1.TabIndex = 47;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // moneda
            // 
            this.moneda.Location = new System.Drawing.Point(719, 27);
            this.moneda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moneda.Name = "moneda";
            this.moneda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneda.Properties.Appearance.Options.UseFont = true;
            this.moneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.moneda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.moneda.Size = new System.Drawing.Size(108, 22);
            this.moneda.TabIndex = 70;
            this.moneda.SelectedIndexChanged += new System.EventHandler(this.moneda_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(719, 10);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 16);
            this.labelControl1.TabIndex = 71;
            this.labelControl1.Text = "Moneda";
            // 
            // ctrlListadoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 433);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.moneda);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.listVentas);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.panel1);
            this.IconOptions.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1004, 473);
            this.MinimumSize = new System.Drawing.Size(1004, 473);
            this.Name = "ctrlListadoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Ventas";
            this.Load += new System.EventHandler(this.ctrlListadoVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneda.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private System.Windows.Forms.ListView listVentas;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevExpress.XtraEditors.ComboBoxEdit moneda;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}