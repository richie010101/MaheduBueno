namespace MaheduBueno
{
    partial class AgregarProductos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Información = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTNAGREGAR = new System.Windows.Forms.Button();
            this.BTNEDITARSELECCION = new System.Windows.Forms.Button();
            this.BTNELIMINARSELECCION = new System.Windows.Forms.Button();
            this.agregarPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Addpanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.agregarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.Addpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Información,
            this.Precio,
            this.CantidadActual});
            this.dataGridView1.Location = new System.Drawing.Point(12, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(772, 272);
            this.dataGridView1.TabIndex = 21;
            // 
            // Información
            // 
            this.Información.HeaderText = "Información";
            this.Información.MinimumWidth = 20;
            this.Información.Name = "Información";
            this.Información.ReadOnly = true;
            this.Información.Width = 450;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 125;
            // 
            // CantidadActual
            // 
            this.CantidadActual.HeaderText = "Cantidad Actual";
            this.CantidadActual.MinimumWidth = 6;
            this.CantidadActual.Name = "CantidadActual";
            this.CantidadActual.ReadOnly = true;
            this.CantidadActual.Width = 143;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(634, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 33);
            this.button2.TabIndex = 20;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(609, 31);
            this.textBox1.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::MaheduBueno.Properties.Resources.casita;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(12, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 33);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(293, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 34);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ricardo Tinoco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(318, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 34);
            this.label1.TabIndex = 16;
            this.label1.Text = "Bienvenido";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MaheduBueno.Properties.Resources.potencializa;
            this.pictureBox2.Location = new System.Drawing.Point(12, -12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(175, 95);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MaheduBueno.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(634, -12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // BTNAGREGAR
            // 
            this.BTNAGREGAR.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNAGREGAR.Location = new System.Drawing.Point(13, 488);
            this.BTNAGREGAR.Name = "BTNAGREGAR";
            this.BTNAGREGAR.Size = new System.Drawing.Size(153, 31);
            this.BTNAGREGAR.TabIndex = 22;
            this.BTNAGREGAR.Text = "Agregar nuevo";
            this.BTNAGREGAR.UseVisualStyleBackColor = true;
            this.BTNAGREGAR.Click += new System.EventHandler(this.BTNAGREGAR_Click);
            // 
            // BTNEDITARSELECCION
            // 
            this.BTNEDITARSELECCION.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNEDITARSELECCION.Location = new System.Drawing.Point(190, 488);
            this.BTNEDITARSELECCION.Name = "BTNEDITARSELECCION";
            this.BTNEDITARSELECCION.Size = new System.Drawing.Size(147, 31);
            this.BTNEDITARSELECCION.TabIndex = 23;
            this.BTNEDITARSELECCION.Text = "Editar selección";
            this.BTNEDITARSELECCION.UseVisualStyleBackColor = true;
            // 
            // BTNELIMINARSELECCION
            // 
            this.BTNELIMINARSELECCION.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNELIMINARSELECCION.Location = new System.Drawing.Point(359, 488);
            this.BTNELIMINARSELECCION.Name = "BTNELIMINARSELECCION";
            this.BTNELIMINARSELECCION.Size = new System.Drawing.Size(172, 31);
            this.BTNELIMINARSELECCION.TabIndex = 24;
            this.BTNELIMINARSELECCION.Text = "Eliminar selección";
            this.BTNELIMINARSELECCION.UseVisualStyleBackColor = true;
            // 
            // agregarPanel
            // 
            this.agregarPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.agregarPanel.Controls.Add(this.Addpanel);
            this.agregarPanel.Controls.Add(this.button5);
            this.agregarPanel.Controls.Add(this.button4);
            this.agregarPanel.Controls.Add(this.button3);
            this.agregarPanel.Location = new System.Drawing.Point(515, 98);
            this.agregarPanel.Name = "agregarPanel";
            this.agregarPanel.Size = new System.Drawing.Size(300, 462);
            this.agregarPanel.TabIndex = 2;
            this.agregarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.agregarPanel_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(78, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 81);
            this.button3.TabIndex = 0;
            this.button3.Text = "Productos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(78, 234);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 81);
            this.button4.TabIndex = 1;
            this.button4.Text = "Materia\r\nprima\r\n";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(13, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 37);
            this.button5.TabIndex = 2;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(277, 22);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(13, 81);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(277, 22);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 199);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(274, 22);
            this.textBox4.TabIndex = 5;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(16, 140);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(274, 22);
            this.numericUpDown1.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(16, 259);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(274, 22);
            this.textBox5.TabIndex = 7;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(21, 330);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 34);
            this.button7.TabIndex = 9;
            this.button7.Text = "Siguiente";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(169, 332);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(121, 31);
            this.button8.TabIndex = 10;
            this.button8.Text = "Cancelar";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "SKU";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Precio";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Costo";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Addpanel
            // 
            this.Addpanel.BackColor = System.Drawing.Color.Transparent;
            this.Addpanel.Controls.Add(this.label7);
            this.Addpanel.Controls.Add(this.textBox3);
            this.Addpanel.Controls.Add(this.label6);
            this.Addpanel.Controls.Add(this.textBox2);
            this.Addpanel.Controls.Add(this.label5);
            this.Addpanel.Controls.Add(this.textBox4);
            this.Addpanel.Controls.Add(this.label4);
            this.Addpanel.Controls.Add(this.numericUpDown1);
            this.Addpanel.Controls.Add(this.label3);
            this.Addpanel.Controls.Add(this.textBox5);
            this.Addpanel.Controls.Add(this.button8);
            this.Addpanel.Controls.Add(this.button7);
            this.Addpanel.Location = new System.Drawing.Point(0, 55);
            this.Addpanel.Name = "Addpanel";
            this.Addpanel.Size = new System.Drawing.Size(297, 404);
            this.Addpanel.TabIndex = 3;
            this.Addpanel.Visible = false;
            // 
            // AgregarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MaheduBueno.Properties.Resources.fondo2;
            this.ClientSize = new System.Drawing.Size(806, 553);
            this.Controls.Add(this.agregarPanel);
            this.Controls.Add(this.BTNELIMINARSELECCION);
            this.Controls.Add(this.BTNEDITARSELECCION);
            this.Controls.Add(this.BTNAGREGAR);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AgregarProductos";
            this.Text = "AgregarProductos";
            this.Load += new System.EventHandler(this.AgregarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.agregarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.Addpanel.ResumeLayout(false);
            this.Addpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Información;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadActual;
        private System.Windows.Forms.Button BTNAGREGAR;
        private System.Windows.Forms.Button BTNEDITARSELECCION;
        private System.Windows.Forms.Button BTNELIMINARSELECCION;
        private System.Windows.Forms.Panel agregarPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel Addpanel;
    }
}