namespace FormularioCliente
{
    partial class FormCliente2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDireccionIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtEnviar = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.rtxtRecibido = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDireccionIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.txtEnviar);
            this.groupBox1.Controls.Add(this.btnEnviar);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 184);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(525, 172);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensajes";
            // 
            // lblDireccionIP
            // 
            this.lblDireccionIP.AutoSize = true;
            this.lblDireccionIP.Location = new System.Drawing.Point(162, 137);
            this.lblDireccionIP.Name = "lblDireccionIP";
            this.lblDireccionIP.Size = new System.Drawing.Size(91, 20);
            this.lblDireccionIP.TabIndex = 9;
            this.lblDireccionIP.Text = "Direccion IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Conectado desde:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(375, 66);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(142, 30);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // txtEnviar
            // 
            this.txtEnviar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnviar.Location = new System.Drawing.Point(8, 28);
            this.txtEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnviar.Multiline = true;
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(359, 102);
            this.txtEnviar.TabIndex = 3;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(375, 28);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(142, 30);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rtxtRecibido
            // 
            this.rtxtRecibido.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtRecibido.Location = new System.Drawing.Point(13, 13);
            this.rtxtRecibido.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtRecibido.Name = "rtxtRecibido";
            this.rtxtRecibido.Size = new System.Drawing.Size(525, 163);
            this.rtxtRecibido.TabIndex = 22;
            this.rtxtRecibido.Text = "";
            // 
            // FormCliente2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtxtRecibido);
            this.Name = "FormCliente2";
            this.Text = "Mensajes";
            this.Load += new System.EventHandler(this.FormCliente2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtEnviar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox rtxtRecibido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDireccionIP;
    }
}