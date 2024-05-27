namespace SistemaInventario.ModuloVentas
{
    partial class nuevoCliente
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
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtIDFiscal = new DevExpress.XtraEditors.TextEdit();
            this.txtSegundoApellido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrimerApellido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSegundoNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrimerNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtTelefono = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDFiscal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoApellido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerApellido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 131);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 13);
            this.labelControl7.TabIndex = 53;
            this.labelControl7.Text = "Teléfono";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 9);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 51;
            this.labelControl6.Text = "ID Fiscal";
            // 
            // txtIDFiscal
            // 
            this.txtIDFiscal.Location = new System.Drawing.Point(10, 27);
            this.txtIDFiscal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDFiscal.Name = "txtIDFiscal";
            this.txtIDFiscal.Properties.Mask.EditMask = "n0";
            this.txtIDFiscal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtIDFiscal.Size = new System.Drawing.Size(257, 20);
            this.txtIDFiscal.TabIndex = 50;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(141, 108);
            this.txtSegundoApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Properties.Mask.EditMask = "\\p{L}+";
            this.txtSegundoApellido.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSegundoApellido.Size = new System.Drawing.Size(126, 20);
            this.txtSegundoApellido.TabIndex = 49;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(141, 89);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(82, 13);
            this.labelControl4.TabIndex = 48;
            this.labelControl4.Text = "Segundo Apellido";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(10, 108);
            this.txtPrimerApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Properties.Mask.EditMask = "\\p{L}+";
            this.txtPrimerApellido.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPrimerApellido.Size = new System.Drawing.Size(126, 20);
            this.txtPrimerApellido.TabIndex = 47;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 89);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "Primer Apellido";
            // 
            // txtSegundoNombre
            // 
            this.txtSegundoNombre.Location = new System.Drawing.Point(141, 67);
            this.txtSegundoNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Properties.Mask.EditMask = "\\p{L}+";
            this.txtSegundoNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSegundoNombre.Size = new System.Drawing.Size(126, 20);
            this.txtSegundoNombre.TabIndex = 45;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(141, 49);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 13);
            this.labelControl3.TabIndex = 44;
            this.labelControl3.Text = "Segundo Nombre";
            // 
            // txtPrimerNombre
            // 
            this.txtPrimerNombre.Location = new System.Drawing.Point(10, 67);
            this.txtPrimerNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrimerNombre.Name = "txtPrimerNombre";
            this.txtPrimerNombre.Properties.Mask.EditMask = "\\p{L}+";
            this.txtPrimerNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPrimerNombre.Size = new System.Drawing.Size(126, 20);
            this.txtPrimerNombre.TabIndex = 43;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 50);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 42;
            this.labelControl1.Text = "Primer Nombre";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(306, 149);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(105, 28);
            this.simpleButton1.TabIndex = 54;
            this.simpleButton1.Text = "Crear (F5)";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(10, 153);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtTelefono.Properties.Mask.BeepOnError = true;
            this.txtTelefono.Properties.Mask.EditMask = "d";
            this.txtTelefono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTelefono.Properties.MaxLength = 10;
            this.txtTelefono.Properties.NullText = "0";
            this.txtTelefono.Size = new System.Drawing.Size(126, 20);
            this.txtTelefono.TabIndex = 68;
            // 
            // nuevoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 187);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtIDFiscal);
            this.Controls.Add(this.txtSegundoApellido);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtSegundoNombre);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtPrimerNombre);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(491, 269);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(491, 261);
            this.Name = "nuevoCliente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo cliente";
            this.Load += new System.EventHandler(this.nuevoCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nuevoCliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtIDFiscal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoApellido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerApellido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundoNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrimerNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtIDFiscal;
        private DevExpress.XtraEditors.TextEdit txtSegundoApellido;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPrimerApellido;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtSegundoNombre;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPrimerNombre;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtTelefono;
    }
}