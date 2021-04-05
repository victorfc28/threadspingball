namespace pingBall
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
            this.titulo = new System.Windows.Forms.Label();
            this.lbip1 = new System.Windows.Forms.Label();
            this.lbip2 = new System.Windows.Forms.Label();
            this.tbip1 = new System.Windows.Forms.TextBox();
            this.tbip2 = new System.Windows.Forms.TextBox();
            this.btPing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(98, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(78, 24);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "PingBall";
            // 
            // lbip1
            // 
            this.lbip1.AutoSize = true;
            this.lbip1.Location = new System.Drawing.Point(61, 64);
            this.lbip1.Name = "lbip1";
            this.lbip1.Size = new System.Drawing.Size(26, 13);
            this.lbip1.TabIndex = 1;
            this.lbip1.Text = "IP 1";
            // 
            // lbip2
            // 
            this.lbip2.AutoSize = true;
            this.lbip2.Location = new System.Drawing.Point(61, 90);
            this.lbip2.Name = "lbip2";
            this.lbip2.Size = new System.Drawing.Size(26, 13);
            this.lbip2.TabIndex = 2;
            this.lbip2.Text = "IP 2";
            // 
            // tbip1
            // 
            this.tbip1.Location = new System.Drawing.Point(102, 61);
            this.tbip1.Name = "tbip1";
            this.tbip1.Size = new System.Drawing.Size(100, 20);
            this.tbip1.TabIndex = 3;
            // 
            // tbip2
            // 
            this.tbip2.Location = new System.Drawing.Point(102, 87);
            this.tbip2.Name = "tbip2";
            this.tbip2.Size = new System.Drawing.Size(100, 20);
            this.tbip2.TabIndex = 4;
            // 
            // btPing
            // 
            this.btPing.Location = new System.Drawing.Point(101, 141);
            this.btPing.Name = "btPing";
            this.btPing.Size = new System.Drawing.Size(75, 23);
            this.btPing.TabIndex = 5;
            this.btPing.Text = "Hacer Ping";
            this.btPing.UseVisualStyleBackColor = true;
            this.btPing.Click += new System.EventHandler(this.btPing_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 176);
            this.Controls.Add(this.btPing);
            this.Controls.Add(this.tbip2);
            this.Controls.Add(this.tbip1);
            this.Controls.Add(this.lbip2);
            this.Controls.Add(this.lbip1);
            this.Controls.Add(this.titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Label lbip1;
        private System.Windows.Forms.Label lbip2;
        private System.Windows.Forms.TextBox tbip1;
        private System.Windows.Forms.TextBox tbip2;
        private System.Windows.Forms.Button btPing;
    }
}

