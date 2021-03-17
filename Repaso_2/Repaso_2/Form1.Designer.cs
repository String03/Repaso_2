namespace Repaso_2
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
            this.grillaGenero = new System.Windows.Forms.DataGridView();
            this.btn_alta_genero = new System.Windows.Forms.Button();
            this.btn_baja_genero = new System.Windows.Forms.Button();
            this.btn_modificacion_genero = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre_genero = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaGenero)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaGenero
            // 
            this.grillaGenero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaGenero.Location = new System.Drawing.Point(52, 42);
            this.grillaGenero.MultiSelect = false;
            this.grillaGenero.Name = "grillaGenero";
            this.grillaGenero.ReadOnly = true;
            this.grillaGenero.RowTemplate.Height = 24;
            this.grillaGenero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaGenero.Size = new System.Drawing.Size(690, 150);
            this.grillaGenero.TabIndex = 0;
            // 
            // btn_alta_genero
            // 
            this.btn_alta_genero.Location = new System.Drawing.Point(52, 255);
            this.btn_alta_genero.Name = "btn_alta_genero";
            this.btn_alta_genero.Size = new System.Drawing.Size(75, 23);
            this.btn_alta_genero.TabIndex = 1;
            this.btn_alta_genero.Text = "Alta";
            this.btn_alta_genero.UseVisualStyleBackColor = true;
            this.btn_alta_genero.Click += new System.EventHandler(this.btn_alta_genero_Click);
            // 
            // btn_baja_genero
            // 
            this.btn_baja_genero.Location = new System.Drawing.Point(343, 255);
            this.btn_baja_genero.Name = "btn_baja_genero";
            this.btn_baja_genero.Size = new System.Drawing.Size(75, 23);
            this.btn_baja_genero.TabIndex = 2;
            this.btn_baja_genero.Text = "Baja";
            this.btn_baja_genero.UseVisualStyleBackColor = true;
            this.btn_baja_genero.Click += new System.EventHandler(this.btn_baja_genero_Click);
            // 
            // btn_modificacion_genero
            // 
            this.btn_modificacion_genero.Location = new System.Drawing.Point(609, 255);
            this.btn_modificacion_genero.Name = "btn_modificacion_genero";
            this.btn_modificacion_genero.Size = new System.Drawing.Size(133, 23);
            this.btn_modificacion_genero.TabIndex = 3;
            this.btn_modificacion_genero.Text = "Modificación";
            this.btn_modificacion_genero.UseVisualStyleBackColor = true;
            this.btn_modificacion_genero.Click += new System.EventHandler(this.btn_modificacion_genero_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // txt_nombre_genero
            // 
            this.txt_nombre_genero.Location = new System.Drawing.Point(117, 355);
            this.txt_nombre_genero.Name = "txt_nombre_genero";
            this.txt_nombre_genero.Size = new System.Drawing.Size(282, 22);
            this.txt_nombre_genero.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_nombre_genero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_modificacion_genero);
            this.Controls.Add(this.btn_baja_genero);
            this.Controls.Add(this.btn_alta_genero);
            this.Controls.Add(this.grillaGenero);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaGenero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaGenero;
        private System.Windows.Forms.Button btn_alta_genero;
        private System.Windows.Forms.Button btn_baja_genero;
        private System.Windows.Forms.Button btn_modificacion_genero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre_genero;
    }
}

