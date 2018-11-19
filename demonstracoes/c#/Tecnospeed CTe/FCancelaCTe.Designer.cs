namespace WindowsFormsApp3
{
    partial class FCancelaCTe
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
            this.lblChave = new System.Windows.Forms.Label();
            this.edtChave = new System.Windows.Forms.TextBox();
            this.lblNumeroProtocolo = new System.Windows.Forms.Label();
            this.edtNumeroProtocolo = new System.Windows.Forms.TextBox();
            this.lblJustificativa = new System.Windows.Forms.Label();
            this.mmJustificativa = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.Location = new System.Drawing.Point(9, 8);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(52, 13);
            this.lblChave.TabIndex = 11;
            this.lblChave.Text = "Chave *";
            // 
            // edtChave
            // 
            this.edtChave.Location = new System.Drawing.Point(8, 24);
            this.edtChave.Name = "edtChave";
            this.edtChave.Size = new System.Drawing.Size(268, 20);
            this.edtChave.TabIndex = 9;
            // 
            // lblNumeroProtocolo
            // 
            this.lblNumeroProtocolo.AutoSize = true;
            this.lblNumeroProtocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroProtocolo.Location = new System.Drawing.Point(9, 47);
            this.lblNumeroProtocolo.Name = "lblNumeroProtocolo";
            this.lblNumeroProtocolo.Size = new System.Drawing.Size(70, 13);
            this.lblNumeroProtocolo.TabIndex = 13;
            this.lblNumeroProtocolo.Text = "Protocolo *";
            // 
            // edtNumeroProtocolo
            // 
            this.edtNumeroProtocolo.Location = new System.Drawing.Point(8, 63);
            this.edtNumeroProtocolo.Name = "edtNumeroProtocolo";
            this.edtNumeroProtocolo.Size = new System.Drawing.Size(268, 20);
            this.edtNumeroProtocolo.TabIndex = 12;
            // 
            // lblJustificativa
            // 
            this.lblJustificativa.AutoSize = true;
            this.lblJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJustificativa.Location = new System.Drawing.Point(9, 86);
            this.lblJustificativa.Name = "lblJustificativa";
            this.lblJustificativa.Size = new System.Drawing.Size(84, 13);
            this.lblJustificativa.TabIndex = 14;
            this.lblJustificativa.Text = "Justificativa *";
            // 
            // mmJustificativa
            // 
            this.mmJustificativa.Location = new System.Drawing.Point(8, 102);
            this.mmJustificativa.Name = "mmJustificativa";
            this.mmJustificativa.Size = new System.Drawing.Size(268, 121);
            this.mmJustificativa.TabIndex = 10;
            this.mmJustificativa.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(120, 229);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(201, 229);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FCancelaCTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblChave);
            this.Controls.Add(this.edtChave);
            this.Controls.Add(this.lblNumeroProtocolo);
            this.Controls.Add(this.edtNumeroProtocolo);
            this.Controls.Add(this.lblJustificativa);
            this.Controls.Add(this.mmJustificativa);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.Name = "FCancelaCTe";
            this.Text = "FCancelaCTe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChave;
        public System.Windows.Forms.TextBox edtChave;
        private System.Windows.Forms.Label lblNumeroProtocolo;
        public System.Windows.Forms.TextBox edtNumeroProtocolo;
        private System.Windows.Forms.Label lblJustificativa;
        public System.Windows.Forms.RichTextBox mmJustificativa;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}