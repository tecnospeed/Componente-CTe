namespace ExemploCTe
{
    partial class FrmExemplo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.edtProtocolo = new System.Windows.Forms.TextBox();
            this.lblProtocolo = new System.Windows.Forms.Label();
            this.lblUF = new System.Windows.Forms.Label();
            this.lblRecibo = new System.Windows.Forms.Label();
            this.edtRecibo = new System.Windows.Forms.TextBox();
            this.lblChave = new System.Windows.Forms.Label();
            this.edtChave = new System.Windows.Forms.TextBox();
            this.lblCNPJEmit = new System.Windows.Forms.Label();
            this.edtCNPJEmit = new System.Windows.Forms.TextBox();
            this.lblCNPJSH = new System.Windows.Forms.Label();
            this.edtCNPJSH = new System.Windows.Forms.TextBox();
            this.edtUF = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbOperacoes = new System.Windows.Forms.GroupBox();
            this.gbImpressao = new System.Windows.Forms.GroupBox();
            this.btnExporta = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConsultaCTe = new System.Windows.Forms.Button();
            this.btnConsultaRecibo = new System.Windows.Forms.Button();
            this.btnEnviarCTe = new System.Windows.Forms.Button();
            this.btnPreverDacte = new System.Windows.Forms.Button();
            this.btnAssinar = new System.Windows.Forms.Button();
            this.btnDataSet = new System.Windows.Forms.Button();
            this.btnTx2 = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnConfiguraIni = new System.Windows.Forms.Button();
            this.btnConfiguraSH = new System.Windows.Forms.Button();
            this.cbCertificados = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCertificado = new System.Windows.Forms.Label();
            this.ctrlMensagens = new System.Windows.Forms.TabControl();
            this.tabXML = new System.Windows.Forms.TabPage();
            this.mmXML = new System.Windows.Forms.RichTextBox();
            this.tabXMLFormatado = new System.Windows.Forms.TabPage();
            this.mmXMLFormatado = new System.Windows.Forms.RichTextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.gbConfig.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbOperacoes.SuspendLayout();
            this.gbImpressao.SuspendLayout();
            this.ctrlMensagens.SuspendLayout();
            this.tabXML.SuspendLayout();
            this.tabXMLFormatado.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfig
            // 
            this.gbConfig.Controls.Add(this.edtProtocolo);
            this.gbConfig.Controls.Add(this.lblProtocolo);
            this.gbConfig.Controls.Add(this.lblUF);
            this.gbConfig.Controls.Add(this.lblRecibo);
            this.gbConfig.Controls.Add(this.edtRecibo);
            this.gbConfig.Controls.Add(this.lblChave);
            this.gbConfig.Controls.Add(this.edtChave);
            this.gbConfig.Controls.Add(this.lblCNPJEmit);
            this.gbConfig.Controls.Add(this.edtCNPJEmit);
            this.gbConfig.Controls.Add(this.lblCNPJSH);
            this.gbConfig.Controls.Add(this.edtCNPJSH);
            this.gbConfig.Controls.Add(this.edtUF);
            this.gbConfig.Location = new System.Drawing.Point(3, 3);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(213, 273);
            this.gbConfig.TabIndex = 0;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "Configurações";
            // 
            // edtProtocolo
            // 
            this.edtProtocolo.Location = new System.Drawing.Point(11, 222);
            this.edtProtocolo.Name = "edtProtocolo";
            this.edtProtocolo.Size = new System.Drawing.Size(189, 20);
            this.edtProtocolo.TabIndex = 6;
            // 
            // lblProtocolo
            // 
            this.lblProtocolo.AutoSize = true;
            this.lblProtocolo.Location = new System.Drawing.Point(8, 206);
            this.lblProtocolo.Name = "lblProtocolo";
            this.lblProtocolo.Size = new System.Drawing.Size(82, 13);
            this.lblProtocolo.TabIndex = 5;
            this.lblProtocolo.Text = "Nº do Protocolo";
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUF.Location = new System.Drawing.Point(8, 11);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(23, 13);
            this.lblUF.TabIndex = 1;
            this.lblUF.Text = "UF";
            // 
            // lblRecibo
            // 
            this.lblRecibo.AutoSize = true;
            this.lblRecibo.Location = new System.Drawing.Point(8, 167);
            this.lblRecibo.Name = "lblRecibo";
            this.lblRecibo.Size = new System.Drawing.Size(71, 13);
            this.lblRecibo.TabIndex = 4;
            this.lblRecibo.Text = "Nº do Recibo";
            // 
            // edtRecibo
            // 
            this.edtRecibo.Location = new System.Drawing.Point(11, 183);
            this.edtRecibo.Name = "edtRecibo";
            this.edtRecibo.Size = new System.Drawing.Size(189, 20);
            this.edtRecibo.TabIndex = 4;
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Location = new System.Drawing.Point(8, 128);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(68, 13);
            this.lblChave.TabIndex = 3;
            this.lblChave.Text = "Nº da Chave";
            // 
            // edtChave
            // 
            this.edtChave.Location = new System.Drawing.Point(11, 144);
            this.edtChave.Name = "edtChave";
            this.edtChave.Size = new System.Drawing.Size(189, 20);
            this.edtChave.TabIndex = 3;
            // 
            // lblCNPJEmit
            // 
            this.lblCNPJEmit.AutoSize = true;
            this.lblCNPJEmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNPJEmit.Location = new System.Drawing.Point(8, 89);
            this.lblCNPJEmit.Name = "lblCNPJEmit";
            this.lblCNPJEmit.Size = new System.Drawing.Size(152, 13);
            this.lblCNPJEmit.TabIndex = 2;
            this.lblCNPJEmit.Text = "CNPJ (Apenas números) *";
            // 
            // edtCNPJEmit
            // 
            this.edtCNPJEmit.Location = new System.Drawing.Point(11, 105);
            this.edtCNPJEmit.Name = "edtCNPJEmit";
            this.edtCNPJEmit.Size = new System.Drawing.Size(189, 20);
            this.edtCNPJEmit.TabIndex = 2;
            // 
            // lblCNPJSH
            // 
            this.lblCNPJSH.AutoSize = true;
            this.lblCNPJSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNPJSH.Location = new System.Drawing.Point(8, 50);
            this.lblCNPJSH.Name = "lblCNPJSH";
            this.lblCNPJSH.Size = new System.Drawing.Size(141, 13);
            this.lblCNPJSH.TabIndex = 1;
            this.lblCNPJSH.Text = "CNPJ Software House *";
            // 
            // edtCNPJSH
            // 
            this.edtCNPJSH.Location = new System.Drawing.Point(11, 66);
            this.edtCNPJSH.Name = "edtCNPJSH";
            this.edtCNPJSH.Size = new System.Drawing.Size(189, 20);
            this.edtCNPJSH.TabIndex = 1;
            // 
            // edtUF
            // 
            this.edtUF.Location = new System.Drawing.Point(11, 27);
            this.edtUF.Name = "edtUF";
            this.edtUF.Size = new System.Drawing.Size(57, 20);
            this.edtUF.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbConfig);
            this.panel1.Controls.Add(this.gbOperacoes);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 298);
            this.panel1.TabIndex = 2;
            // 
            // gbOperacoes
            // 
            this.gbOperacoes.Controls.Add(this.gbImpressao);
            this.gbOperacoes.Controls.Add(this.btnCancelar);
            this.gbOperacoes.Controls.Add(this.btnConsultaCTe);
            this.gbOperacoes.Controls.Add(this.btnConsultaRecibo);
            this.gbOperacoes.Controls.Add(this.btnEnviarCTe);
            this.gbOperacoes.Controls.Add(this.btnPreverDacte);
            this.gbOperacoes.Controls.Add(this.btnAssinar);
            this.gbOperacoes.Controls.Add(this.btnDataSet);
            this.gbOperacoes.Controls.Add(this.btnTx2);
            this.gbOperacoes.Controls.Add(this.btnStatus);
            this.gbOperacoes.Controls.Add(this.btnLoadConfig);
            this.gbOperacoes.Controls.Add(this.btnConfiguraIni);
            this.gbOperacoes.Controls.Add(this.btnConfiguraSH);
            this.gbOperacoes.Controls.Add(this.cbCertificados);
            this.gbOperacoes.Controls.Add(this.label2);
            this.gbOperacoes.Controls.Add(this.lblCertificado);
            this.gbOperacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOperacoes.Location = new System.Drawing.Point(222, 4);
            this.gbOperacoes.Name = "gbOperacoes";
            this.gbOperacoes.Size = new System.Drawing.Size(448, 272);
            this.gbOperacoes.TabIndex = 1;
            this.gbOperacoes.TabStop = false;
            this.gbOperacoes.Text = "Operações";
            // 
            // gbImpressao
            // 
            this.gbImpressao.Controls.Add(this.btnExporta);
            this.gbImpressao.Controls.Add(this.btnVisualizar);
            this.gbImpressao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbImpressao.Location = new System.Drawing.Point(225, 150);
            this.gbImpressao.Name = "gbImpressao";
            this.gbImpressao.Size = new System.Drawing.Size(200, 106);
            this.gbImpressao.TabIndex = 14;
            this.gbImpressao.TabStop = false;
            this.gbImpressao.Text = "Impressão do Dacte";
            // 
            // btnExporta
            // 
            this.btnExporta.Location = new System.Drawing.Point(4, 54);
            this.btnExporta.Name = "btnExporta";
            this.btnExporta.Size = new System.Drawing.Size(190, 25);
            this.btnExporta.TabIndex = 16;
            this.btnExporta.Text = "11. Exportar para PDF";
            this.btnExporta.UseVisualStyleBackColor = true;
            this.btnExporta.Click += new System.EventHandler(this.BtnExporta_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(4, 27);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(190, 25);
            this.btnVisualizar.TabIndex = 15;
            this.btnVisualizar.Text = "10. Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.BtnVisualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(227, 123);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(200, 25);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "9. Cancelar CTe";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnConsultaCTe
            // 
            this.btnConsultaCTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaCTe.Location = new System.Drawing.Point(227, 96);
            this.btnConsultaCTe.Name = "btnConsultaCTe";
            this.btnConsultaCTe.Size = new System.Drawing.Size(200, 25);
            this.btnConsultaCTe.TabIndex = 12;
            this.btnConsultaCTe.Text = "8. Consultar CTe";
            this.btnConsultaCTe.UseVisualStyleBackColor = true;
            this.btnConsultaCTe.Click += new System.EventHandler(this.BtnConsultaCTe_Click);
            // 
            // btnConsultaRecibo
            // 
            this.btnConsultaRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaRecibo.Location = new System.Drawing.Point(227, 69);
            this.btnConsultaRecibo.Name = "btnConsultaRecibo";
            this.btnConsultaRecibo.Size = new System.Drawing.Size(200, 25);
            this.btnConsultaRecibo.TabIndex = 11;
            this.btnConsultaRecibo.Text = "7. Consultar Recibo CTe";
            this.btnConsultaRecibo.UseVisualStyleBackColor = true;
            this.btnConsultaRecibo.Click += new System.EventHandler(this.BtnConsultaRecibo_Click);
            // 
            // btnEnviarCTe
            // 
            this.btnEnviarCTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarCTe.Location = new System.Drawing.Point(227, 42);
            this.btnEnviarCTe.Name = "btnEnviarCTe";
            this.btnEnviarCTe.Size = new System.Drawing.Size(200, 25);
            this.btnEnviarCTe.TabIndex = 10;
            this.btnEnviarCTe.Text = "6. Enviar CTe";
            this.btnEnviarCTe.UseVisualStyleBackColor = true;
            this.btnEnviarCTe.Click += new System.EventHandler(this.BtnEnviarCTe_Click);
            // 
            // btnPreverDacte
            // 
            this.btnPreverDacte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreverDacte.Location = new System.Drawing.Point(21, 231);
            this.btnPreverDacte.Name = "btnPreverDacte";
            this.btnPreverDacte.Size = new System.Drawing.Size(200, 25);
            this.btnPreverDacte.TabIndex = 9;
            this.btnPreverDacte.Text = "5.2.  Prever DACTE";
            this.btnPreverDacte.UseVisualStyleBackColor = true;
            this.btnPreverDacte.Click += new System.EventHandler(this.BtnPreverDacte_Click);
            // 
            // btnAssinar
            // 
            this.btnAssinar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssinar.Location = new System.Drawing.Point(21, 204);
            this.btnAssinar.Name = "btnAssinar";
            this.btnAssinar.Size = new System.Drawing.Size(200, 25);
            this.btnAssinar.TabIndex = 8;
            this.btnAssinar.Text = "5.1. Assinar CTe";
            this.btnAssinar.UseVisualStyleBackColor = true;
            this.btnAssinar.Click += new System.EventHandler(this.BtnAssinar_Click);
            // 
            // btnDataSet
            // 
            this.btnDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataSet.Location = new System.Drawing.Point(21, 177);
            this.btnDataSet.Name = "btnDataSet";
            this.btnDataSet.Size = new System.Drawing.Size(200, 25);
            this.btnDataSet.TabIndex = 7;
            this.btnDataSet.Text = "4.2. Gerar XML via DataSet";
            this.btnDataSet.UseVisualStyleBackColor = true;
            this.btnDataSet.Click += new System.EventHandler(this.BtnDataSet_Click);
            // 
            // btnTx2
            // 
            this.btnTx2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTx2.Location = new System.Drawing.Point(21, 150);
            this.btnTx2.Name = "btnTx2";
            this.btnTx2.Size = new System.Drawing.Size(200, 25);
            this.btnTx2.TabIndex = 6;
            this.btnTx2.Text = "4.1. Gerar XML via Tx2";
            this.btnTx2.UseVisualStyleBackColor = true;
            this.btnTx2.Click += new System.EventHandler(this.BtnTx2_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(21, 123);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(200, 25);
            this.btnStatus.TabIndex = 5;
            this.btnStatus.Text = "3. Verificar Status de Serviço";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.BtnStatus_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadConfig.Location = new System.Drawing.Point(21, 96);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(200, 25);
            this.btnLoadConfig.TabIndex = 4;
            this.btnLoadConfig.Text = "2. LoadConfig";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.BtnLoadConfig_Click);
            // 
            // btnConfiguraIni
            // 
            this.btnConfiguraIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguraIni.Location = new System.Drawing.Point(21, 69);
            this.btnConfiguraIni.Name = "btnConfiguraIni";
            this.btnConfiguraIni.Size = new System.Drawing.Size(200, 25);
            this.btnConfiguraIni.TabIndex = 3;
            this.btnConfiguraIni.Text = "1.2. Configurar via arquivo .ini";
            this.btnConfiguraIni.UseVisualStyleBackColor = true;
            this.btnConfiguraIni.Click += new System.EventHandler(this.BtnConfiguraIni_Click);
            // 
            // btnConfiguraSH
            // 
            this.btnConfiguraSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguraSH.Location = new System.Drawing.Point(21, 42);
            this.btnConfiguraSH.Name = "btnConfiguraSH";
            this.btnConfiguraSH.Size = new System.Drawing.Size(200, 25);
            this.btnConfiguraSH.TabIndex = 2;
            this.btnConfiguraSH.Text = "1.1. Configura Software House";
            this.btnConfiguraSH.UseVisualStyleBackColor = true;
            this.btnConfiguraSH.Click += new System.EventHandler(this.BtnConfiguraSH_Click);
            // 
            // cbCertificados
            // 
            this.cbCertificados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCertificados.FormattingEnabled = true;
            this.cbCertificados.Location = new System.Drawing.Point(70, 19);
            this.cbCertificados.Name = "cbCertificados";
            this.cbCertificados.Size = new System.Drawing.Size(372, 21);
            this.cbCertificados.TabIndex = 1;
            this.cbCertificados.Text = "Selecione o Certificado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(21, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Siga as operações na ordem assinalada.";
            // 
            // lblCertificado
            // 
            this.lblCertificado.AutoSize = true;
            this.lblCertificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCertificado.Location = new System.Drawing.Point(6, 23);
            this.lblCertificado.Name = "lblCertificado";
            this.lblCertificado.Size = new System.Drawing.Size(60, 13);
            this.lblCertificado.TabIndex = 0;
            this.lblCertificado.Text = "Certificado:";
            // 
            // ctrlMensagens
            // 
            this.ctrlMensagens.Controls.Add(this.tabXML);
            this.ctrlMensagens.Controls.Add(this.tabXMLFormatado);
            this.ctrlMensagens.Location = new System.Drawing.Point(4, 287);
            this.ctrlMensagens.Name = "ctrlMensagens";
            this.ctrlMensagens.SelectedIndex = 0;
            this.ctrlMensagens.Size = new System.Drawing.Size(676, 370);
            this.ctrlMensagens.TabIndex = 3;
            // 
            // tabXML
            // 
            this.tabXML.Controls.Add(this.mmXML);
            this.tabXML.Location = new System.Drawing.Point(4, 22);
            this.tabXML.Name = "tabXML";
            this.tabXML.Padding = new System.Windows.Forms.Padding(3);
            this.tabXML.Size = new System.Drawing.Size(668, 344);
            this.tabXML.TabIndex = 0;
            this.tabXML.Text = "XML";
            this.tabXML.UseVisualStyleBackColor = true;
            // 
            // mmXML
            // 
            this.mmXML.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmXML.ForeColor = System.Drawing.SystemColors.Highlight;
            this.mmXML.Location = new System.Drawing.Point(-2, 0);
            this.mmXML.Name = "mmXML";
            this.mmXML.Size = new System.Drawing.Size(668, 344);
            this.mmXML.TabIndex = 1;
            this.mmXML.Text = "";
            // 
            // tabXMLFormatado
            // 
            this.tabXMLFormatado.Controls.Add(this.mmXMLFormatado);
            this.tabXMLFormatado.Location = new System.Drawing.Point(4, 22);
            this.tabXMLFormatado.Name = "tabXMLFormatado";
            this.tabXMLFormatado.Padding = new System.Windows.Forms.Padding(3);
            this.tabXMLFormatado.Size = new System.Drawing.Size(668, 344);
            this.tabXMLFormatado.TabIndex = 1;
            this.tabXMLFormatado.Text = "XML Formatado";
            this.tabXMLFormatado.UseVisualStyleBackColor = true;
            // 
            // mmXMLFormatado
            // 
            this.mmXMLFormatado.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmXMLFormatado.ForeColor = System.Drawing.SystemColors.Highlight;
            this.mmXMLFormatado.Location = new System.Drawing.Point(-4, 0);
            this.mmXMLFormatado.Name = "mmXMLFormatado";
            this.mmXMLFormatado.Size = new System.Drawing.Size(668, 344);
            this.mmXMLFormatado.TabIndex = 1;
            this.mmXMLFormatado.Text = "";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblStatus);
            this.pnlBottom.Location = new System.Drawing.Point(1, 659);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(679, 33);
            this.pnlBottom.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // FrmExemplo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 693);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.ctrlMensagens);
            this.Controls.Add(this.panel1);
            this.Name = "FrmExemplo";
            this.Text = "Tecnospeed CTe";
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbOperacoes.ResumeLayout(false);
            this.gbOperacoes.PerformLayout();
            this.gbImpressao.ResumeLayout(false);
            this.ctrlMensagens.ResumeLayout(false);
            this.tabXML.ResumeLayout(false);
            this.tabXMLFormatado.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.TextBox edtProtocolo;
        private System.Windows.Forms.Label lblProtocolo;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.Label lblRecibo;
        private System.Windows.Forms.TextBox edtRecibo;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.TextBox edtChave;
        private System.Windows.Forms.Label lblCNPJEmit;
        private System.Windows.Forms.TextBox edtCNPJEmit;
        private System.Windows.Forms.Label lblCNPJSH;
        private System.Windows.Forms.TextBox edtCNPJSH;
        private System.Windows.Forms.TextBox edtUF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl ctrlMensagens;
        private System.Windows.Forms.TabPage tabXML;
        private System.Windows.Forms.TabPage tabXMLFormatado;
        private System.Windows.Forms.GroupBox gbOperacoes;
        private System.Windows.Forms.Button btnConfiguraSH;
        private System.Windows.Forms.ComboBox cbCertificados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCertificado;
        private System.Windows.Forms.GroupBox gbImpressao;
        private System.Windows.Forms.Button btnExporta;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConsultaCTe;
        private System.Windows.Forms.Button btnConsultaRecibo;
        private System.Windows.Forms.Button btnEnviarCTe;
        private System.Windows.Forms.Button btnPreverDacte;
        private System.Windows.Forms.Button btnAssinar;
        private System.Windows.Forms.Button btnDataSet;
        private System.Windows.Forms.Button btnTx2;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Button btnConfiguraIni;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox mmXML;
        private System.Windows.Forms.RichTextBox mmXMLFormatado;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
    }
}

