
namespace MaheduBueno
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Respuesta = new System.Windows.Forms.Label();
            this.PanelAgregado = new System.Windows.Forms.Panel();
            this.button34 = new System.Windows.Forms.Button();
            this.textErrores = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PanelAgregado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MaheduBueno.Properties.Resources.boquillas;
            this.pictureBox1.Location = new System.Drawing.Point(658, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(748, 736);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MaheduBueno.Properties.Resources.potencializa;
            this.pictureBox2.Location = new System.Drawing.Point(34, 29);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(281, 225);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::MaheduBueno.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(249, 258);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(276, 199);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(288, 485);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Usuario";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.Location = new System.Drawing.Point(288, 528);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(216, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Contraseña";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.CursorChanged += new System.EventHandler(this.textBox2_CursorChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 575);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Iniciar sesión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Respuesta
            // 
            this.Respuesta.AutoSize = true;
            this.Respuesta.BackColor = System.Drawing.Color.Transparent;
            this.Respuesta.Location = new System.Drawing.Point(416, 408);
            this.Respuesta.Name = "Respuesta";
            this.Respuesta.Size = new System.Drawing.Size(0, 13);
            this.Respuesta.TabIndex = 6;
            // 
            // PanelAgregado
            // 
            this.PanelAgregado.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelAgregado.BackgroundImage = global::MaheduBueno.Properties.Resources.fondo2;
            this.PanelAgregado.Controls.Add(this.button34);
            this.PanelAgregado.Controls.Add(this.textErrores);
            this.PanelAgregado.Controls.Add(this.button17);
            this.PanelAgregado.Location = new System.Drawing.Point(202, 324);
            this.PanelAgregado.Margin = new System.Windows.Forms.Padding(2);
            this.PanelAgregado.Name = "PanelAgregado";
            this.PanelAgregado.Size = new System.Drawing.Size(407, 133);
            this.PanelAgregado.TabIndex = 34;
            this.PanelAgregado.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAgregado_Paint);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(50, 95);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(308, 23);
            this.button34.TabIndex = 5;
            this.button34.Text = "Aceptar";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // textErrores
            // 
            this.textErrores.AutoSize = true;
            this.textErrores.BackColor = System.Drawing.Color.Transparent;
            this.textErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textErrores.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textErrores.Location = new System.Drawing.Point(56, 55);
            this.textErrores.Name = "textErrores";
            this.textErrores.Size = new System.Drawing.Size(313, 25);
            this.textErrores.TabIndex = 3;
            this.textErrores.Text = "GUARDADO CORRECTAMENTE\r\n";
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Red;
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(10, 10);
            this.button17.Margin = new System.Windows.Forms.Padding(2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(28, 30);
            this.button17.TabIndex = 2;
            this.button17.Text = "X";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::MaheduBueno.Properties.Resources.f;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.PanelAgregado);
            this.Controls.Add(this.Respuesta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PanelAgregado.ResumeLayout(false);
            this.PanelAgregado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Respuesta;
        private System.Windows.Forms.Panel PanelAgregado;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Label textErrores;
        private System.Windows.Forms.Button button17;
    }
}

