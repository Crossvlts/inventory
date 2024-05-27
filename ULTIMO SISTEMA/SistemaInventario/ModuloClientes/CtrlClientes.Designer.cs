namespace SistemaInventario.ModuloClientes
{
    partial class CtrlClientes
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
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPrimerNombre = new DevExpress.XtraEditors.TextEdit();
            this.checkEstatus = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSegundoNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSegundoApellido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrimerApellido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtTelefono = new DevExpress.XtraEditors.TextEdit();
            this.txtIDFiscal = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoApellido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerApellido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDFiscal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(614, 361);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 37);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Question;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(441, 39);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(94, 22);
            this.txtID.TabIndex = 30;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(441, 18);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(14, 16);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "N°";
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(376, 386);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "N°";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID Fiscal";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Activo";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(532, 361);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 37);
            this.btnCerrar.TabIndex = 26;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(695, 361);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 37);
            this.btnAceptar.TabIndex = 25;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtPrimerNombre
            // 
            this.txtPrimerNombre.Location = new System.Drawing.Point(441, 140);
            this.txtPrimerNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Properties.Mask.EditMask = "\\p{L}+";
            this.txtPrimerNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPrimerNombre.Size = new System.Drawing.Size(147, 22);
            this.txtPrimerNombre.TabIndex = 24;
            // 
            // checkEstatus
            // 
            this.checkEstatus.Location = new System.Drawing.Point(441, 268);
            this.checkEstatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEstatus.Name = "checkEstatus";
            this.checkEstatus.Properties.Caption = "Estatus";
            this.checkEstatus.Size = new System.Drawing.Size(94, 21);
            this.checkEstatus.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(441, 118);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 16);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Primer Nombre";
            // 
            // txtSegundoNombre
            // 
            this.txtSegundoNombre.Location = new System.Drawing.Point(594, 139);
            this.txtSegundoNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Properties.Mask.EditMask = "\\p{L}+";
            this.txtSegundoNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSegundoNombre.Size = new System.Drawing.Size(147, 22);
            this.txtSegundoNombre.TabIndex = 33;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(594, 117);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(99, 16);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "Segundo Nombre";
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(594, 190);
            this.txtSegundoApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Properties.Mask.EditMask = "\\p{L}+";
            this.txtSegundoApellido.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSegundoApellido.Size = new System.Drawing.Size(147, 22);
            this.txtSegundoApellido.TabIndex = 37;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(594, 167);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(99, 16);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Segundo Apellido";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(441, 190);
            this.txtPrimerApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Properties.Mask.EditMask = "\\p{L}+";
            this.txtPrimerApellido.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPrimerApellido.Size = new System.Drawing.Size(147, 22);
            this.txtPrimerApellido.TabIndex = 35;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(441, 167);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(87, 16);
            this.labelControl5.TabIndex = 34;
            this.labelControl5.Text = "Primer Apellido";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(441, 68);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 16);
            this.labelControl6.TabIndex = 39;
            this.labelControl6.Text = "ID Fiscal";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(441, 218);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 16);
            this.labelControl7.TabIndex = 41;
            this.labelControl7.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(441, 239);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtTelefono.Properties.Mask.BeepOnError = true;
            this.txtTelefono.Properties.Mask.EditMask = "d";
            this.txtTelefono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTelefono.Properties.MaxLength = 10;
            this.txtTelefono.Properties.NullText = "0";
            this.txtTelefono.Size = new System.Drawing.Size(300, 22);
            this.txtTelefono.TabIndex = 67;
            // 
            // txtIDFiscal
            // 
            this.txtIDFiscal.Location = new System.Drawing.Point(441, 89);
            this.txtIDFiscal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDFiscal.Name = "txtIDFiscal";
            this.txtIDFiscal.Properties.MaxLength = 50;
            this.txtIDFiscal.Size = new System.Drawing.Size(300, 22);
            this.txtIDFiscal.TabIndex = 68;
            // 
            // CtrlClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 418);
            this.Controls.Add(this.txtIDFiscal);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtSegundoApellido);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtSegundoNombre);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPrimerNombre);
            this.Controls.Add(this.checkEstatus);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(783, 449);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(673, 372);
            this.Name = "CtrlClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.CtrlClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CtrlClientes_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CtrlClientes_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoApellido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerApellido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDFiscal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtPrimerNombre;
        private DevExpress.XtraEditors.CheckEdit checkEstatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSegundoNombre;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSegundoApellido;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPrimerApellido;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtTelefono;
        private DevExpress.XtraEditors.TextEdit txtIDFiscal;
    }
}