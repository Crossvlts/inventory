namespace SistemaInventario.ModuloProductos
{
    partial class ctrlProductos
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
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator2 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.checkEstatus = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.Exento = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtNivelPedido = new DevExpress.XtraEditors.TextEdit();
            this.checkVenderBajoCero = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtInventarioInicial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCategoria = new DevExpress.XtraEditors.ComboBoxEdit();
            this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUnidad = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoBarras = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtVenta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtUtilidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtCosto = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivelPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkVenderBajoCero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventarioInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategoria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarras.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUtilidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(711, 312);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(64, 30);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Question;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(16, 46);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(95, 20);
            this.txtID.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 26);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "N°";
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(10, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(303, 340);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "N°";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Producto";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Estatus";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(642, 312);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(64, 30);
            this.btnCerrar.TabIndex = 16;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(781, 310);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(64, 30);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(16, 87);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(147, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // checkEstatus
            // 
            this.checkEstatus.Location = new System.Drawing.Point(16, 213);
            this.checkEstatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEstatus.Name = "checkEstatus";
            this.checkEstatus.Properties.Caption = "Estatus";
            this.checkEstatus.Size = new System.Drawing.Size(81, 18);
            this.checkEstatus.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 69);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Producto";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Location = new System.Drawing.Point(319, 0);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(526, 306);
            this.xtraTabControl1.TabIndex = 22;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.Exento);
            this.xtraTabPage1.Controls.Add(this.labelControl11);
            this.xtraTabPage1.Controls.Add(this.txtNivelPedido);
            this.xtraTabPage1.Controls.Add(this.checkVenderBajoCero);
            this.xtraTabPage1.Controls.Add(this.labelControl10);
            this.xtraTabPage1.Controls.Add(this.txtInventarioInicial);
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.cmbCategoria);
            this.xtraTabPage1.Controls.Add(this.barCodeControl1);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.cmbUnidad);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.txtCodigoBarras);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.txtDescripcion);
            this.xtraTabPage1.Controls.Add(this.txtID);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.checkEstatus);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.txtNombre);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(524, 283);
            this.xtraTabPage1.Text = "Datos principales";
            this.xtraTabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.xtraTabPage1_Paint);
            // 
            // Exento
            // 
            this.Exento.Location = new System.Drawing.Point(16, 233);
            this.Exento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exento.Name = "Exento";
            this.Exento.Properties.Caption = "Exento";
            this.Exento.Size = new System.Drawing.Size(141, 18);
            this.Exento.TabIndex = 36;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(430, 93);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(73, 13);
            this.labelControl11.TabIndex = 35;
            this.labelControl11.Text = "Nivel de pedido";
            // 
            // txtNivelPedido
            // 
            this.txtNivelPedido.Location = new System.Drawing.Point(430, 112);
            this.txtNivelPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNivelPedido.Name = "txtNivelPedido";
            this.txtNivelPedido.Properties.Mask.EditMask = "n2";
            this.txtNivelPedido.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNivelPedido.Size = new System.Drawing.Size(81, 20);
            this.txtNivelPedido.TabIndex = 34;
            // 
            // checkVenderBajoCero
            // 
            this.checkVenderBajoCero.Location = new System.Drawing.Point(16, 254);
            this.checkVenderBajoCero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkVenderBajoCero.Name = "checkVenderBajoCero";
            this.checkVenderBajoCero.Properties.Caption = "vender sin existencia";
            this.checkVenderBajoCero.Size = new System.Drawing.Size(141, 18);
            this.checkVenderBajoCero.TabIndex = 33;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(431, 54);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(80, 13);
            this.labelControl10.TabIndex = 31;
            this.labelControl10.Text = "Inventario Inicial";
            // 
            // txtInventarioInicial
            // 
            this.txtInventarioInicial.Location = new System.Drawing.Point(431, 72);
            this.txtInventarioInicial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInventarioInicial.Name = "txtInventarioInicial";
            this.txtInventarioInicial.Properties.Mask.EditMask = "n2";
            this.txtInventarioInicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInventarioInicial.Size = new System.Drawing.Size(81, 20);
            this.txtInventarioInicial.TabIndex = 30;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(173, 110);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(47, 13);
            this.labelControl9.TabIndex = 29;
            this.labelControl9.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Location = new System.Drawing.Point(173, 128);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCategoria.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCategoria.Size = new System.Drawing.Size(153, 20);
            this.cmbCategoria.TabIndex = 3;
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.barCodeControl1.Appearance.Options.UseBackColor = true;
            this.barCodeControl1.AutoModule = true;
            this.barCodeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barCodeControl1.HorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barCodeControl1.HorizontalTextAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barCodeControl1.Location = new System.Drawing.Point(357, 11);
            this.barCodeControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Padding = new System.Windows.Forms.Padding(9, 2, 9, 0);
            this.barCodeControl1.Size = new System.Drawing.Size(154, 28);
            this.barCodeControl1.Symbology = code128Generator2;
            this.barCodeControl1.TabIndex = 27;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 110);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(33, 13);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "Unidad";
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.Location = new System.Drawing.Point(16, 128);
            this.cmbUnidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Properties.AutoComplete = false;
            this.cmbUnidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnidad.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbUnidad.Size = new System.Drawing.Size(147, 20);
            this.cmbUnidad.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(173, 69);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(82, 13);
            this.labelControl4.TabIndex = 23;
            this.labelControl4.Text = "Código de barras";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(173, 86);
            this.txtCodigoBarras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(153, 20);
            this.txtCodigoBarras.TabIndex = 4;
            this.txtCodigoBarras.EditValueChanged += new System.EventHandler(this.txtCodigoBarras_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 150);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(16, 170);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.AutoHeight = false;
            this.txtDescripcion.Size = new System.Drawing.Size(495, 36);
            this.txtDescripcion.TabIndex = 5;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.button1);
            this.xtraTabPage2.Controls.Add(this.pictureBox2);
            this.xtraTabPage2.Controls.Add(this.labelControl8);
            this.xtraTabPage2.Controls.Add(this.txtVenta);
            this.xtraTabPage2.Controls.Add(this.labelControl7);
            this.xtraTabPage2.Controls.Add(this.txtUtilidad);
            this.xtraTabPage2.Controls.Add(this.labelControl6);
            this.xtraTabPage2.Controls.Add(this.txtCosto);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(524, 283);
            this.xtraTabPage2.Text = "Precios";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 22);
            this.button1.TabIndex = 34;
            this.button1.Text = "Calcular venta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.pictureBox2.Location = new System.Drawing.Point(461, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(16, 117);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 13);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "Precio venta";
            // 
            // txtVenta
            // 
            this.txtVenta.Location = new System.Drawing.Point(16, 136);
            this.txtVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Properties.Mask.EditMask = "d";
            this.txtVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVenta.Size = new System.Drawing.Size(194, 20);
            this.txtVenta.TabIndex = 17;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 73);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(57, 13);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "Utilidad (%)";
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Location = new System.Drawing.Point(16, 93);
            this.txtUtilidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Properties.Mask.EditMask = "d";
            this.txtUtilidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtUtilidad.Size = new System.Drawing.Size(91, 20);
            this.txtUtilidad.TabIndex = 15;
            this.txtUtilidad.EditValueChanged += new System.EventHandler(this.txtUtilidad_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 31);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 13);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Precio costo";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(16, 49);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Properties.Mask.EditMask = "d";
            this.txtCosto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCosto.Size = new System.Drawing.Size(194, 20);
            this.txtCosto.TabIndex = 13;
            this.txtCosto.EditValueChanged += new System.EventHandler(this.textEdit3_EditValueChanged);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.listView2);
            this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(524, 283);
            this.xtraTabPage3.Text = "Inventario / Movimientos";
            // 
            // listView2
            // 
            this.listView2.AutoArrange = false;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(524, 283);
            this.listView2.TabIndex = 19;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "N°";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Producto";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Cantidad";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Fecha";
            this.columnHeader7.Width = 100;
            // 
            // ctrlProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 351);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAceptar);
            this.IconOptions.Image = global::SistemaInventario.Properties.Resources.Casa_Fortu_2;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1002, 472);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(859, 391);
            this.Name = "ctrlProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.ctrlProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivelPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkVenderBajoCero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventarioInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategoria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarras.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUtilidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.CheckEdit checkEstatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUnidad;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCodigoBarras;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtCosto;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtVenta;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtUtilidad;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCategoria;
        private DevExpress.XtraEditors.BarCodeControl barCodeControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtInventarioInicial;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.CheckEdit checkVenderBajoCero;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtNivelPedido;
        private DevExpress.XtraEditors.CheckEdit Exento;
    }
}