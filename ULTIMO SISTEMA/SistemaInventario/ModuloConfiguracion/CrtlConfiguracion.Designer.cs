namespace SistemaInventario.ModuloConfiguracion
{
    partial class CrtlConfiguracion
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
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpresa = new DevExpress.XtraEditors.TextEdit();
            this.txtIDFiscal = new DevExpress.XtraEditors.TextEdit();
            this.txtTelefonoC = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
            this.txtImpuesto = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.igft = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDFiscal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonoC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.igft.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.pictureBox1.Location = new System.Drawing.Point(392, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sistema de ventas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "2023";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Empresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID Fiscal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Teléfono";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.EditValue = "Mercería Casa Fortu 18 C.A.";
            this.txtEmpresa.Location = new System.Drawing.Point(19, 43);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Properties.ReadOnly = true;
            this.txtEmpresa.Size = new System.Drawing.Size(356, 22);
            this.txtEmpresa.TabIndex = 6;
            // 
            // txtIDFiscal
            // 
            this.txtIDFiscal.EditValue = "J-297489732-2";
            this.txtIDFiscal.Location = new System.Drawing.Point(19, 89);
            this.txtIDFiscal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDFiscal.Name = "txtIDFiscal";
            this.txtIDFiscal.Properties.ReadOnly = true;
            this.txtIDFiscal.Size = new System.Drawing.Size(356, 22);
            this.txtIDFiscal.TabIndex = 7;
            // 
            // txtTelefonoC
            // 
            this.txtTelefonoC.EditValue = "0281-2655526";
            this.txtTelefonoC.Location = new System.Drawing.Point(19, 133);
            this.txtTelefonoC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefonoC.Name = "txtTelefonoC";
            this.txtTelefonoC.Properties.ReadOnly = true;
            this.txtTelefonoC.Size = new System.Drawing.Size(192, 22);
            this.txtTelefonoC.TabIndex = 8;
            this.txtTelefonoC.EditValueChanged += new System.EventHandler(this.txtTelefono_EditValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(22, 236);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(156, 37);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Actualizar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.barCodeControl1.Appearance.Options.UseBackColor = true;
            this.barCodeControl1.AutoModule = true;
            this.barCodeControl1.Location = new System.Drawing.Point(392, 214);
            this.barCodeControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl1.Size = new System.Drawing.Size(150, 30);
            this.barCodeControl1.Symbology = code128Generator1;
            this.barCodeControl1.TabIndex = 10;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(20, 185);
            this.txtImpuesto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Properties.Mask.EditMask = "n";
            this.txtImpuesto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImpuesto.Size = new System.Drawing.Size(92, 22);
            this.txtImpuesto.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Impuesto (%)";
            // 
            // igft
            // 
            this.igft.Location = new System.Drawing.Point(120, 185);
            this.igft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.igft.Name = "igft";
            this.igft.Properties.Mask.EditMask = "n";
            this.igft.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.igft.Size = new System.Drawing.Size(92, 22);
            this.igft.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "IGTF  (%)";
            // 
            // CrtlConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 306);
            this.Controls.Add(this.igft);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.barCodeControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtTelefonoC);
            this.Controls.Add(this.txtIDFiscal);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.IconOptions.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(558, 346);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(479, 281);
            this.Name = "CrtlConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración del sistema";
            this.Load += new System.EventHandler(this.CrtlConfiguracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDFiscal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefonoC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.igft.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtEmpresa;
        private DevExpress.XtraEditors.TextEdit txtIDFiscal;
        private DevExpress.XtraEditors.TextEdit txtTelefonoC;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.BarCodeControl barCodeControl1;
        private DevExpress.XtraEditors.TextEdit txtImpuesto;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit igft;
        private System.Windows.Forms.Label label7;
    }
}