namespace BMPFontGenerator
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbFontFamily = new System.Windows.Forms.ComboBox();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.txtCharacterSet = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarcomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFontStyleBold = new System.Windows.Forms.CheckBox();
            this.chkFontStyleItalic = new System.Windows.Forms.CheckBox();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBitmapWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBitmapHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPaddingRight = new System.Windows.Forms.NumericUpDown();
            this.nudPaddingLeft = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitmapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitmapHeight)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaddingRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaddingLeft)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(479, 397);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // cmbFontFamily
            // 
            this.cmbFontFamily.FormattingEnabled = true;
            this.cmbFontFamily.Location = new System.Drawing.Point(19, 19);
            this.cmbFontFamily.Name = "cmbFontFamily";
            this.cmbFontFamily.Size = new System.Drawing.Size(177, 21);
            this.cmbFontFamily.TabIndex = 1;
            this.cmbFontFamily.Text = "Arial";
            this.cmbFontFamily.SelectedIndexChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(202, 19);
            this.nudFontSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(54, 20);
            this.nudFontSize.TabIndex = 2;
            this.nudFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFontSize.ValueChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // txtCharacterSet
            // 
            this.txtCharacterSet.Location = new System.Drawing.Point(14, 19);
            this.txtCharacterSet.Multiline = true;
            this.txtCharacterSet.Name = "txtCharacterSet";
            this.txtCharacterSet.Size = new System.Drawing.Size(242, 114);
            this.txtCharacterSet.TabIndex = 3;
            this.txtCharacterSet.Text = "0123456789AÁBCDEÉFGHIÍJKLMNÑOÓPQRSTUÚVWXYZaábcdeéfghiíjklmnñoópqrstuúvwxyz .,_()-" +
    "¿?¡!/\\=#$%&:;@";
            this.txtCharacterSet.TextChanged += new System.EventHandler(this.txtCharacters_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem1,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem1
            // 
            this.archivoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripMenuItem,
            this.guardarcomoToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem1.Name = "archivoToolStripMenuItem1";
            this.archivoToolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.archivoToolStripMenuItem1.Text = "&File";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.guardarToolStripMenuItem.Text = "&Save BMP";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripButton_Click);
            // 
            // guardarcomoToolStripMenuItem
            // 
            this.guardarcomoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarcomoToolStripMenuItem.Image")));
            this.guardarcomoToolStripMenuItem.Name = "guardarcomoToolStripMenuItem";
            this.guardarcomoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.guardarcomoToolStripMenuItem.Text = "Export to header file (.h)";
            this.guardarcomoToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercadeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.ayudaToolStripMenuItem.Text = "&Help";
            // 
            // acercadeToolStripMenuItem
            // 
            this.acercadeToolStripMenuItem.Name = "acercadeToolStripMenuItem";
            this.acercadeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acercadeToolStripMenuItem.Text = "&About...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarToolStripButton,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // guardarToolStripButton
            // 
            this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton.Image")));
            this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripButton.Name = "guardarToolStripButton";
            this.guardarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.guardarToolStripButton.Text = "Save BMP";
            this.guardarToolStripButton.Click += new System.EventHandler(this.guardarToolStripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Export to header file (.h)";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(288, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 416);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFontStyleBold);
            this.groupBox2.Controls.Add(this.chkFontStyleItalic);
            this.groupBox2.Controls.Add(this.cmbFontFamily);
            this.groupBox2.Controls.Add(this.nudFontSize);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 80);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font";
            // 
            // chkFontStyleBold
            // 
            this.chkFontStyleBold.AutoSize = true;
            this.chkFontStyleBold.Location = new System.Drawing.Point(89, 50);
            this.chkFontStyleBold.Name = "chkFontStyleBold";
            this.chkFontStyleBold.Size = new System.Drawing.Size(47, 17);
            this.chkFontStyleBold.TabIndex = 4;
            this.chkFontStyleBold.Text = "Bold";
            this.chkFontStyleBold.UseVisualStyleBackColor = true;
            this.chkFontStyleBold.CheckedChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // chkFontStyleItalic
            // 
            this.chkFontStyleItalic.AutoSize = true;
            this.chkFontStyleItalic.Location = new System.Drawing.Point(19, 50);
            this.chkFontStyleItalic.Name = "chkFontStyleItalic";
            this.chkFontStyleItalic.Size = new System.Drawing.Size(48, 17);
            this.chkFontStyleItalic.TabIndex = 3;
            this.chkFontStyleItalic.Text = "Italic";
            this.chkFontStyleItalic.UseVisualStyleBackColor = true;
            this.chkFontStyleItalic.CheckedChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // btnForeColor
            // 
            this.btnForeColor.Location = new System.Drawing.Point(54, 19);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(60, 23);
            this.btnForeColor.TabIndex = 1;
            this.btnForeColor.Text = "...";
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.TextChanged += new System.EventHandler(this.RefreshFontMap);
            this.btnForeColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudBitmapWidth);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.nudBitmapHeight);
            this.groupBox3.Location = new System.Drawing.Point(12, 425);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 53);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bitmap size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "H:";
            // 
            // nudBitmapWidth
            // 
            this.nudBitmapWidth.Location = new System.Drawing.Point(50, 19);
            this.nudBitmapWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBitmapWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBitmapWidth.Name = "nudBitmapWidth";
            this.nudBitmapWidth.Size = new System.Drawing.Size(75, 20);
            this.nudBitmapWidth.TabIndex = 4;
            this.nudBitmapWidth.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudBitmapWidth.ValueChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "W:";
            // 
            // nudBitmapHeight
            // 
            this.nudBitmapHeight.Location = new System.Drawing.Point(161, 19);
            this.nudBitmapHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBitmapHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBitmapHeight.Name = "nudBitmapHeight";
            this.nudBitmapHeight.Size = new System.Drawing.Size(74, 20);
            this.nudBitmapHeight.TabIndex = 5;
            this.nudBitmapHeight.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudBitmapHeight.ValueChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.nudPaddingRight);
            this.groupBox4.Controls.Add(this.nudPaddingLeft);
            this.groupBox4.Location = new System.Drawing.Point(12, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(270, 54);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Padding";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Right:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Left:";
            // 
            // nudPaddingRight
            // 
            this.nudPaddingRight.Location = new System.Drawing.Point(177, 19);
            this.nudPaddingRight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudPaddingRight.Name = "nudPaddingRight";
            this.nudPaddingRight.Size = new System.Drawing.Size(58, 20);
            this.nudPaddingRight.TabIndex = 1;
            this.nudPaddingRight.Value = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            this.nudPaddingRight.ValueChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // nudPaddingLeft
            // 
            this.nudPaddingLeft.Location = new System.Drawing.Point(55, 19);
            this.nudPaddingLeft.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudPaddingLeft.Name = "nudPaddingLeft";
            this.nudPaddingLeft.Size = new System.Drawing.Size(53, 20);
            this.nudPaddingLeft.TabIndex = 0;
            this.nudPaddingLeft.ValueChanged += new System.EventHandler(this.RefreshFontMap);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCharacterSet);
            this.groupBox5.Location = new System.Drawing.Point(12, 271);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(270, 148);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Charset";
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(176, 19);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(58, 23);
            this.btnBackColor.TabIndex = 6;
            this.btnBackColor.Text = "...";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.TextChanged += new System.EventHandler(this.RefreshFontMap);
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(785, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.btnForeColor);
            this.groupBox6.Controls.Add(this.btnBackColor);
            this.groupBox6.Location = new System.Drawing.Point(13, 149);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(269, 56);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Colors";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Back:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fore:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 511);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "BMP Font Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitmapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBitmapHeight)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaddingRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaddingLeft)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbFontFamily;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.TextBox txtCharacterSet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton guardarToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudPaddingRight;
        private System.Windows.Forms.NumericUpDown nudPaddingLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFontStyleItalic;
        private System.Windows.Forms.CheckBox chkFontStyleBold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBitmapWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBitmapHeight;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarcomoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercadeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

