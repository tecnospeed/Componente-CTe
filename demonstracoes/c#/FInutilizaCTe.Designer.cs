namespace ExemploCTeNS
{
    partial class FInutilizaCTe
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblJustificativa = new System.Windows.Forms.Label();
            this.lblCNPJ = new System.Windows.Forms.Label();
            this.edCNPJ = new System.Windows.Forms.TextBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.mJustificativa = new System.Windows.Forms.RichTextBox();
            this.edAno = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.edModelo = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.edSerie = new System.Windows.Forms.TextBox();
            this.lblCTInicial = new System.Windows.Forms.Label();
            this.edCTInicial = new System.Windows.Forms.TextBox();
            this.lblCTFinal = new System.Windows.Forms.Label();
            this.edCTFinal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(294, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(213, 235);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblJustificativa
            // 
            this.lblJustificativa.AutoSize = true;
            this.lblJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJustificativa.Location = new System.Drawing.Point(13, 92);
            this.lblJustificativa.Name = "lblJustificativa";
            this.lblJustificativa.Size = new System.Drawing.Size(84, 13);
            this.lblJustificativa.TabIndex = 14;
            this.lblJustificativa.Text = "Justificativa *";
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNPJ.Location = new System.Drawing.Point(103, 14);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(47, 13);
            this.lblCNPJ.TabIndex = 13;
            this.lblCNPJ.Text = "CNPJ *";
            // 
            // edCNPJ
            // 
            this.edCNPJ.Location = new System.Drawing.Point(103, 30);
            this.edCNPJ.Name = "edCNPJ";
            this.edCNPJ.Size = new System.Drawing.Size(266, 20);
            this.edCNPJ.TabIndex = 12;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(13, 14);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(38, 13);
            this.lblAno.TabIndex = 11;
            this.lblAno.Text = "Ano *";
            // 
            // mJustificativa
            // 
            this.mJustificativa.Location = new System.Drawing.Point(12, 108);
            this.mJustificativa.Name = "mJustificativa";
            this.mJustificativa.Size = new System.Drawing.Size(357, 121);
            this.mJustificativa.TabIndex = 10;
            this.mJustificativa.Text = "";
            // 
            // edAno
            // 
            this.edAno.Location = new System.Drawing.Point(12, 30);
            this.edAno.Name = "edAno";
            this.edAno.Size = new System.Drawing.Size(85, 20);
            this.edAno.TabIndex = 9;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(13, 53);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(57, 13);
            this.lblModelo.TabIndex = 18;
            this.lblModelo.Text = "Modelo *";
            // 
            // edModelo
            // 
            this.edModelo.Location = new System.Drawing.Point(12, 69);
            this.edModelo.Name = "edModelo";
            this.edModelo.Size = new System.Drawing.Size(85, 20);
            this.edModelo.TabIndex = 17;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(103, 53);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(45, 13);
            this.lblSerie.TabIndex = 20;
            this.lblSerie.Text = "Série *";
            // 
            // edSerie
            // 
            this.edSerie.Location = new System.Drawing.Point(103, 69);
            this.edSerie.Name = "edSerie";
            this.edSerie.Size = new System.Drawing.Size(85, 20);
            this.edSerie.TabIndex = 19;
            // 
            // lblCTInicial
            // 
            this.lblCTInicial.AutoSize = true;
            this.lblCTInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCTInicial.Location = new System.Drawing.Point(194, 53);
            this.lblCTInicial.Name = "lblCTInicial";
            this.lblCTInicial.Size = new System.Drawing.Size(70, 13);
            this.lblCTInicial.TabIndex = 22;
            this.lblCTInicial.Text = "CT Inicial *";
            // 
            // edCTInicial
            // 
            this.edCTInicial.Location = new System.Drawing.Point(193, 69);
            this.edCTInicial.Name = "edCTInicial";
            this.edCTInicial.Size = new System.Drawing.Size(85, 20);
            this.edCTInicial.TabIndex = 21;
            // 
            // lblCTFinal
            // 
            this.lblCTFinal.AutoSize = true;
            this.lblCTFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCTFinal.Location = new System.Drawing.Point(285, 53);
            this.lblCTFinal.Name = "lblCTFinal";
            this.lblCTFinal.Size = new System.Drawing.Size(63, 13);
            this.lblCTFinal.TabIndex = 24;
            this.lblCTFinal.Text = "CT Final *";
            // 
            // edCTFinal
            // 
            this.edCTFinal.Location = new System.Drawing.Point(284, 69);
            this.edCTFinal.Name = "edCTFinal";
            this.edCTFinal.Size = new System.Drawing.Size(85, 20);
            this.edCTFinal.TabIndex = 23;
            // 
            // FInutilizaCTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 263);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.edAno);
            this.Controls.Add(this.lblCNPJ);
            this.Controls.Add(this.edCNPJ);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.edModelo);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.edSerie);
            this.Controls.Add(this.lblCTInicial);
            this.Controls.Add(this.edCTInicial);
            this.Controls.Add(this.lblCTFinal);
            this.Controls.Add(this.edCTFinal);
            this.Controls.Add(this.lblJustificativa);
            this.Controls.Add(this.mJustificativa);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FInutilizaCTe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inutilizar Faixa de CTe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblJustificativa;
        private System.Windows.Forms.Label lblCNPJ;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblCTInicial;
        private System.Windows.Forms.Label lblCTFinal;
        public System.Windows.Forms.TextBox edCNPJ;
        public System.Windows.Forms.RichTextBox mJustificativa;
        public System.Windows.Forms.TextBox edAno;
        public System.Windows.Forms.TextBox edModelo;
        public System.Windows.Forms.TextBox edSerie;
        public System.Windows.Forms.TextBox edCTInicial;
        public System.Windows.Forms.TextBox edCTFinal;
    }
}