namespace ExemploCTeNS
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
            this.edChave = new System.Windows.Forms.TextBox();
            this.mJustificativa = new System.Windows.Forms.RichTextBox();
            this.lblChave = new System.Windows.Forms.Label();
            this.lblNumeroProtocolo = new System.Windows.Forms.Label();
            this.edNumeroProtocolo = new System.Windows.Forms.TextBox();
            this.lblJustificativa = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edChave
            // 
            this.edChave.Location = new System.Drawing.Point(12, 25);
            this.edChave.Name = "edChave";
            this.edChave.Size = new System.Drawing.Size(268, 20);
            this.edChave.TabIndex = 0;
            // 
            // mJustificativa
            // 
            this.mJustificativa.Location = new System.Drawing.Point(12, 103);
            this.mJustificativa.Name = "mJustificativa";
            this.mJustificativa.Size = new System.Drawing.Size(268, 121);
            this.mJustificativa.TabIndex = 2;
            this.mJustificativa.Text = "";
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.Location = new System.Drawing.Point(13, 9);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(52, 13);
            this.lblChave.TabIndex = 3;
            this.lblChave.Text = "Chave *";
            // 
            // lblNumeroProtocolo
            // 
            this.lblNumeroProtocolo.AutoSize = true;
            this.lblNumeroProtocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroProtocolo.Location = new System.Drawing.Point(13, 48);
            this.lblNumeroProtocolo.Name = "lblNumeroProtocolo";
            this.lblNumeroProtocolo.Size = new System.Drawing.Size(70, 13);
            this.lblNumeroProtocolo.TabIndex = 5;
            this.lblNumeroProtocolo.Text = "Protocolo *";
            // 
            // edNumeroProtocolo
            // 
            this.edNumeroProtocolo.Location = new System.Drawing.Point(12, 64);
            this.edNumeroProtocolo.Name = "edNumeroProtocolo";
            this.edNumeroProtocolo.Size = new System.Drawing.Size(268, 20);
            this.edNumeroProtocolo.TabIndex = 4;
            // 
            // lblJustificativa
            // 
            this.lblJustificativa.AutoSize = true;
            this.lblJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJustificativa.Location = new System.Drawing.Point(13, 87);
            this.lblJustificativa.Name = "lblJustificativa";
            this.lblJustificativa.Size = new System.Drawing.Size(84, 13);
            this.lblJustificativa.TabIndex = 6;
            this.lblJustificativa.Text = "Justificativa *";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(124, 230);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(205, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FCancelaCTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 259);
            this.Controls.Add(this.lblChave);
            this.Controls.Add(this.edChave);
            this.Controls.Add(this.lblNumeroProtocolo);
            this.Controls.Add(this.edNumeroProtocolo);
            this.Controls.Add(this.lblJustificativa);
            this.Controls.Add(this.mJustificativa);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FCancelaCTe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar CTe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.Label lblNumeroProtocolo;
        private System.Windows.Forms.Label lblJustificativa;
        public System.Windows.Forms.TextBox edChave;
        public System.Windows.Forms.RichTextBox mJustificativa;
        public System.Windows.Forms.TextBox edNumeroProtocolo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}