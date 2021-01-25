using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using InputBoxNs;
using System.Diagnostics;

namespace ExemploCTeNS
{
    public partial class frmExemplo : Form
    {
        //******************************************************************************************************
        //
        //          Importação de funções externas
        //
        //******************************************************************************************************        

        //Carga de Dlls
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        //******************************************************************************************************
        //
        //          Declaração de variáveis
        //
        //******************************************************************************************************     

        //Declaração de variáveis do componente spdCTeX e spdCTeDataSetX
        CTeX.spdCTeX CTe;
        CTeDataSetX.spdCTeDataSetX CteDataSetX;

        //Formulário no qual serão preenchidos os dados pertinentes para a geração de XML, seja via Tx2, seja via DataSet
        FDadosXML frmDados = new FDadosXML();

        //Caminho para o arquivo de configuração
        string ArqIni;
        string CertificadoSelecionado;

        //guarda o nro do lote a ser enviado
        string FIdLote;

        //******************************************************************************************************
        //
        //          Funções utilitárias
        //
        //******************************************************************************************************

        //Inicialização
        public frmExemplo()
        {
            InitializeComponent();

            //Instancia o Objeto responsável pela interação com servidores da Receita
            CTe = new CTeX.spdCTeX();

            //instancia o objeto que criará os datasets para depois gerar o xml de envio    
            try {
                CteDataSetX = new CTeDataSetX.spdCTeDataSetX();
            }
            catch (Exception ex)
            {
                TratarExcecao(ex);
            }




            //Utiliza Método do Componente para Listar Certificados instalado no SO            
            string Certificados;
            string[] vetor;

            Certificados = CTe.ListarCertificados();
            vetor = Certificados.Split('|');

            ListCertificados.Items.Clear();

            foreach (string _cert in vetor)
            {
                ListCertificados.Items.Add(_cert);
            }

            gbOperacoes.Enabled = false;
            btnPreverDacte.Enabled = false;
        }

        //Lê valor do arquivo .ini
        public static string GetIniValue(string section, string key, string filename)
        {
            int chars = 256;
            StringBuilder buffer = new StringBuilder(chars);
            string sDefault = "";
            if (GetPrivateProfileString(section, key, sDefault,
              buffer, chars, filename) != 0)
            {
                return buffer.ToString();
            }
            else
            {
                return null;
            }
        }

        //Grava valor no arquivo .ini
        public static bool WriteIniValue(string section, string key, string value, string filename)
        {
            return WritePrivateProfileString(section, key, value, filename);
        }

        //Função para salvar em arquivo
        private void SaveXMLToFile(string FilePath, string Text)
        {
            //cria uma instância do objeto writer e abre o arquivo para escrita
            TextWriter tw = new StreamWriter(FilePath);

            // escreve uma linha de texto no arquivo
            tw.WriteLine(Text);

            // fecha o arquivo
            tw.Close();
        }

        //Mostra nos TextBox da tela os valores que foram carregados nas propriedades do componente
        private void AtualizaInformacoesNaTela()
        {
            edUF.Text = CTe.UF;
            edCNPJ.Text = CTe.CNPJ;
            edArqServHomologacao.Text = CTe.ArquivoServidoresHom;
            edDiretorioEsquemas.Text = CTe.DiretorioEsquemas;
            edDiretorioTemplates.Text = CTe.DiretorioTemplates;
            edDiretorioLog.Text = CTe.DiretorioLog;

            switch (CTe.VersaoManual)
            {
                case CTeX.VersaoManual.vm103:
                    {
                        cboVersao.SelectedIndex = 0;
                        break;
                    }
                case CTeX.VersaoManual.vm104:
                    cboVersao.SelectedIndex = 1;
                    break;
            }

            //Habilita botões de operações com o servidor
            gbOperacoes.Enabled = true;
        }

        //Atualiza o valor de retorno de um método na tela
        private void AtualizaRetornoNaTela(string Valor)
        {
            mOutput.Text = Valor;
            mFrmtOutput.Text = CTe.ReformatXML(Valor);
        }

        //Atualiza o status na tela
        private void AtualizaStatusNaTela(string Valor)
        {
            lblStatus.Text = Valor;
        }

        //Verifica o path do XML do tomador, caso exista
        private string ObterCaminhoXMLTomador(string Chave)
        {
            string _XmlTomador = CTe.DiretorioXMLTomadorServico + "\\" + Chave.Trim() + "-cte.xml";
            if (File.Exists(_XmlTomador))
            {
                return _XmlTomador;
            }
            else
            {
                return "";
            }

        }

        //Carregar certificado digital
        private void btnSelecionarCertificado_Click(object sender, EventArgs e)
        {
            if (ListCertificados.SelectedIndex != -1)
            {
                CertificadoSelecionado = ListCertificados.Items[ListCertificados.SelectedIndex].ToString();
                CTe.NomeCertificado = CertificadoSelecionado;
                CTe.SaveConfig(Application.StartupPath + "/cteConfig.ini");
            }
            else
            {
                Aviso("Favor selecionar um certificado");
            }
        }

        //Carregar configurações por arquivo .ini
        private void btnCarregarConfigPorIni_Click(object sender, EventArgs e)
        {
            //Arquivo INI a ser manipulado com parametrizações
            ArqIni = Application.StartupPath + "\\cteConfig.ini";

            //Grava o nome do certificado selecionado no arquivo .ini
            if ((CertificadoSelecionado != null) && (CertificadoSelecionado.Trim() != ""))
            {
                WriteIniValue("CTe", "NomeCertificado", CertificadoSelecionado, ArqIni);
            }

            //Esse método faz com que o Componente carregue as configuracoes do INI para as devidas propriedades
            CTe.LoadConfig(ArqIni);

            ListCertificados.Text = GetIniValue("CTe", "NomeCertificado", ArqIni);

            //Mostra as informações de configuração na tela
            AtualizaInformacoesNaTela();

            if (rbEPEC.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moEPECX;
            else if (rbFSDA.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moFSDAX;
            else if (rbSVCRS.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moSVCX;
            else if (rbNormal.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moNormalX;

            //Mantém o ambiente como homologação (apenas para este exemplo)
            CTe.Ambiente = CTeX.Ambiente.akHomologacao;

            //switch (cboVersao.SelectedIndex)
            switch (CTe.VersaoManual)
            {
                case CTeX.VersaoManual.vm103:
                    {
                        cboVersao.SelectedIndex = 0;
                        break;
                    }
                case CTeX.VersaoManual.vm104:
                    {                        
                        cboVersao.SelectedIndex = 1;
                        break;
                    }
                case CTeX.VersaoManual.vm200:
                    {                        
                        cboVersao.SelectedIndex = 2;
                        break;
                    }
                case CTeX.VersaoManual.vm200a:
                    {                        
                        cboVersao.SelectedIndex = 3;
                        break;
                    }
                case CTeX.VersaoManual.vm300:
                    {                        
                        cboVersao.SelectedIndex = 4;
                        break;
                    }
                case CTeX.VersaoManual.vm300a:
                    {                        
                        cboVersao.SelectedIndex = 5;
                        break;
                    }
            }
        }

        //Carregar configurações por código
        private void btnCarregarConfigPorCodigo_Click(object sender, EventArgs e)
        {
            //Ambiente
            CTe.Ambiente = CTeX.Ambiente.akHomologacao; //Configura Ambiente de Homologacao

            //Configurações globais
            CTe.UF = edUF.Text; //CONFIGURAR A UF
            CTe.CNPJ = edCNPJ.Text; //CONFIGURAR O CNPJ
            CTe.TipoCertificado = CTeX.TipoCerticado.ckFileX;
            CTe.NomeCertificado = CertificadoSelecionado;
            CTe.ArquivoServidoresHom = Application.StartupPath + "\\cteServidoresHom.ini";
            CTe.ArquivoServidoresProd = Application.StartupPath + "\\cteServidoresProd.ini";

            switch (cboVersao.SelectedIndex)
            {
                case 0:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm103;
                        break;
                    }
                case 1:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm104;
                        break;
                    }
                case 2:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm200;
                        break;
                    }
                case 3:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm200a;
                        break;
                    }
                case 4:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm300;
                        break;
                    }
                case 5:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm300a;
                        break;
                    }
            }
            CTe.MappingFileName = "MappingCte.txt";
            CTe.DiretorioEsquemas = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Esquemas\\";
            CTe.DiretorioTemplates = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Templates\\";
            CTe.DiretorioLog = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Log\\";
            CTe.MaxSizeLoteEnvio = 500;
            CTe.ValidarEsquemaAntesEnvio = false;
            CTe.IgnoreInvalidCertificates = true;

            if (rbEPEC.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moEPECX;
            else if (rbFSDA.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moFSDAX;
            else if (rbSVCRS.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moSVCX;
            else if (rbNormal.Checked)
                CTe.ModoOperacao = CTeX.ModoOperacao.moNormalX;


            //Configurações de impressão
            //if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
            //{
            //    CTe.ImpressaoModeloRetrato = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Templates\\1.03\\Dacte\\Retrato.rtm";
            //    CTe.ImpressaoLogoTipoEmitente = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Templates\\1.03\\Dacte\\tecnospeed.jpg";
            //}
            //else
            //{
            //    CTe.ImpressaoModeloRetrato = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Templates\\1.04\\Dacte\\Retrato.rtm";
            //    CTe.ImpressaoLogoTipoEmitente = @"C:\Program Files\TecnoSpeed\CTe\Arquivos" + "\\Templates\\1.04\\Dacte\\tecnospeed.jpg";
            //}

            CTe.ImpressaoModeloPaisagem = "";
            CTe.ImpressaoFraseHomologacao = "SEM VALOR FISCAL";

            //Mostra as informações de configuração na tela
            AtualizaInformacoesNaTela();
        }

        private void TratarExcecao(Exception ex)
        {
            MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Aviso(string aMensagem)
        {
            MessageBox.Show(aMensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string LoadFromFile(string aFilename)
        {
            System.IO.StreamReader sr = new
            System.IO.StreamReader(aFilename);

            string _XML = sr.ReadToEnd();

            sr.Close();

            return _XML;
        }

        //******************************************************************************************************
        //
        //          Aqui começam as funções de exemplo do componente spdCTe
        //
        //******************************************************************************************************

        //1.Status do Serviço
        private void btnStatusServico_Click_1(object sender, EventArgs e)
        {
            try
            {
                string _ValorDeRetorno = CTe.StatusdoServico();

                AtualizaRetornoNaTela(_ValorDeRetorno);

                AtualizaStatusNaTela("Status do Serviço: OK");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Status do Serviço: Erro");
                TratarExcecao(ex);
            }
        }

        //2.Gerar XML por TX2
        private void btnGerarXMLporTx2_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.FileName = "cte.tx2";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {                    
                    //frmDados já instanciado no início
                    frmDados.edEmitCNPJ.Text = CTe.CNPJ;
                    DialogResult Result;
                    Result = frmDados.ShowDialog();

                    if (Result == DialogResult.OK)
                    {
                        // Configura o dataset
                        // Configura a seção do mapeamento da qual o DatasetX será configurado         
                        CteDataSetX.ConfigSection = "XMLENVIO";

                        switch (CTe.VersaoManual)
                        {
                            case CTeX.VersaoManual.vm103:
                                CteDataSetX.MappingFileName = CTe.DiretorioEsquemas + "1.03\\" + CTe.MappingFileName;
                                CteDataSetX.Versao = "1.03";
                            break;
                            case CTeX.VersaoManual.vm104:
                                CteDataSetX.MappingFileName = CTe.DiretorioEsquemas + "1.04\\" + CTe.MappingFileName;
                                CteDataSetX.Versao = "1.04";
                            break;
                            case CTeX.VersaoManual.vm200:
                                CteDataSetX.MappingFileName = CTe.DiretorioEsquemas + "2.00\\" + CTe.MappingFileName;
                                CteDataSetX.Versao = "2.00";
                            break;
                            case CTeX.VersaoManual.vm200a:
                                CteDataSetX.MappingFileName = CTe.DiretorioEsquemas + "2.00a\\" + CTe.MappingFileName;
                                CteDataSetX.Versao = "2.00a";
                            break;
                            case CTeX.VersaoManual.vm300:
                                CteDataSetX.MappingFileName = CTe.DiretorioEsquemas + "3.00\\" + CTe.MappingFileName;
                                CteDataSetX.Versao = "3.00";
                            break;
                            case CTeX.VersaoManual.vm300a:
                                CteDataSetX.MappingFileName = CTe.DiretorioEsquemas + "3.00a\\" + CTe.MappingFileName;
                                CteDataSetX.Versao = "3.00a";
                            break;
                        }

                        CteDataSetX.CreateDataSets();

                        //alimentar as informações do lote (Header do Lote)                        
                        FIdLote = frmDados.edNroLote.Text;
                        CteDataSetX.IdLote = FIdLote;

                        CteDataSetX.LoadFromTX2(openFileDialog1.FileName);  // Carrega o arquivo .tx2

                        // para cada registro de CTe lido a partir do Tx2, pedir o número do CTe correspondente para o Cálculo da Chave do CTe
                        // move o ponteiro para o primeiro registro do dataset
                        CteDataSetX.First();
                        // enquanto não atingir o fim do dataset
                        while (CteDataSetX.Eof() == false)
                        {
                            int _CodigoUF = CTe.ObterCodigoUF(CTe.UF.ToString());
                            string _Data = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                            string _DataFull = String.Format("{0:yyyy-MM-ddThh:mm:ss}", DateTime.Now);
                            string _Codigo = CteDataSetX.GetCampo("cCT_6");
                            string _Modelo = CteDataSetX.GetCampo("mod_10");
                            string _Serie = CteDataSetX.GetCampo("serie_11");
                            string _TpEmiss = CteDataSetX.GetCampo("tpEmis_15");
                            string _Numero = frmDados.edNroCT.Text;
                            string _Chave = "";
                            switch (CTe.VersaoManual)
                            {
                                case CTeX.VersaoManual.vm103:
                                    _Chave = CTe.CalculaChave(_CodigoUF.ToString(), _Data, CTe.CNPJ, _Modelo, _Serie, _Numero, _Codigo, "");
                                    break;
                                case CTeX.VersaoManual.vm104:
                                    _Chave = CTe.CalculaChave(_CodigoUF.ToString(), _Data, CTe.CNPJ, _Modelo, _Serie, _Numero, _Codigo, _TpEmiss);
                                    break;
                            }
                            string _DV = _Chave.Substring(_Chave.Length - 1);

                            edChave.Text = _Chave;

                            //Editar o DataSet
                            CteDataSetX.Editar();

                            CteDataSetX.SetCampo("versao_2", CteDataSetX.Versao);
                            CteDataSetX.SetCampo("Id_3", "CTe" + _Chave);
                            CteDataSetX.SetCampo("nCT_12", _Numero);
                            CteDataSetX.SetCampo("dhEmi_13", _DataFull);
                            CteDataSetX.SetCampo("cDV_16", _DV);
                            //Dados relativos ao Emitente:
                            CteDataSetX.SetCampo("CNPJ_95", frmDados.edEmitCNPJ.Text);//Cnpj do Emitente
                            CteDataSetX.SetCampo("IE_96", frmDados.edEmitIE.Text);//IE do Emitente
                            CteDataSetX.SetCampo("xNome_97", frmDados.edEmitRazaoSocial.Text);//Razão Social do Emitente
                            CteDataSetX.SetCampo("xFant_98", frmDados.edEmitFantasia.Text);//Nome Fantasia do Emitente
                            CteDataSetX.SetCampo("xLgr_100", frmDados.edEmitLogradouro.Text);// Logradouro do Emitente

                            //Dados relativos ao Remetente:
                            CteDataSetX.SetCampo("CNPJ_112", frmDados.edRemCNPJ.Text);//Cnpj do Remetente
                            CteDataSetX.SetCampo("IE_114", frmDados.edRemIE.Text);//IE do Remetente
                            CteDataSetX.SetCampo("xNome_115", frmDados.edRemRazaoSocial.Text);//Razão Social do Remetente
                            CteDataSetX.SetCampo("xFant_116", frmDados.edRemFantasia.Text);//Nome Fantasia do Remetente
                            CteDataSetX.SetCampo("xLgr_119", frmDados.edRemLogradouro.Text);//Logradouro do Remetente

                            //salva as alterações 
                            CteDataSetX.Salvar();

                            //move o ponteiro para o próximo registro
                            CteDataSetX.Next();
                        }

                        string _ValorDeRetorno = CteDataSetX.LoteCTe();
                        AtualizaRetornoNaTela(_ValorDeRetorno);

                        AtualizaStatusNaTela("Gerar XML por TX2: OK");
                        btnPreverDacte.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Gerar XML por TX2: Erro");
                TratarExcecao(ex);
            }
        }

        //3.Gerar XML por DataSet
        private void btnGerarXMLporDataSet_Click_1(object sender, EventArgs e)
        {
            try
            {
                //frmDados já instanciado no início
                frmDados.edEmitCNPJ.Text = CTe.CNPJ;
                DialogResult Result;
                Result = frmDados.ShowDialog();
                if (Result == DialogResult.OK)
                {
                    //instancia o objeto que criará os datasets para depois gerar o xml de envio
                    CTeDataSetX.spdCTeDataSetX DataSetX;
                    DataSetX = new CTeDataSetX.spdCTeDataSetX();

                    //Configura o dataset
                    //configura a seção do mapeamento da qual o DatasetX será configurado                   
                    DataSetX.ConfigSection = "XMLENVIO";
                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.MappingFileName = CTe.DiretorioEsquemas + "1.03\\" + CTe.MappingFileName;
                        DataSetX.Versao = "1.03";
                    }
                    else
                    {
                        DataSetX.MappingFileName = CTe.DiretorioEsquemas + "1.04\\" + CTe.MappingFileName;
                        DataSetX.Versao = "1.04";
                    }
                    DataSetX.CreateDataSets();

                    //alimentar as informações do lote (Header do Lote)
                    FIdLote = frmDados.edNroLote.Text;
                    DataSetX.IdLote = FIdLote;


                    //Dados do dataset CTe
                    int _CodigoUF = CTe.ObterCodigoUF(CTe.UF.ToString());
                    string _Data = String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    string _DataFull = String.Format("{0:yyyy-MM-ddThh:mm:ss}", DateTime.Now);
                    string _Codigo = "";
                    switch (CTe.VersaoManual)
                    {
                        case CTeX.VersaoManual.vm103:
                            _Codigo = "060219568";
                            break;
                        case CTeX.VersaoManual.vm104:
                            _Codigo = "06021956";
                            break;
                    }
                    string _Modelo = "57";
                    string _Serie = "0";
                    string _TpEmiss = null;

                    if (rbNormal.Checked)
                        _TpEmiss = "1";
                    else if (rbSVCRS.Checked)
                        _TpEmiss = "7"; //SVC-RS=7 
                    else if (rbSVCSP.Checked)
                        _TpEmiss = "8"; //SVC-SP=8 
                    else if (rbFSDA.Checked)
                        _TpEmiss = "5";
                    else if (rbEPEC.Checked)
                        _TpEmiss = "4";

                    
                    string _Numero = frmDados.edNroCT.Text;
                    string _Chave = "";
                    switch (CTe.VersaoManual)
                    {
                        case CTeX.VersaoManual.vm103:
                            _Chave = CTe.CalculaChave(_CodigoUF.ToString(), _Data, CTe.CNPJ, _Modelo, _Serie, _Numero, _Codigo, "");
                            break;
                        case CTeX.VersaoManual.vm104:
                            _Chave = CTe.CalculaChave(_CodigoUF.ToString(), _Data, CTe.CNPJ, _Modelo, _Serie, _Numero, _Codigo, _TpEmiss);
                            break;
                    }
                    string _DV = _Chave.Substring(_Chave.Length - 1);

                    edChave.Text = _Chave;

                    DataSetX.Incluir();
                    DataSetX.SetCampo("versao_2", DataSetX.Versao);
                    DataSetX.SetCampo("Id_3", "CTe" + _Chave);
                    DataSetX.SetCampo("cUF_5", "43");
                    DataSetX.SetCampo("cCT_6", _Codigo);
                    DataSetX.SetCampo("CFOP_7", "5357");
                    DataSetX.SetCampo("natOp_8", "TRANSP)ORTE RODOVIARIO DE CARGAS");
                    DataSetX.SetCampo("forPag_9", "0");
                    DataSetX.SetCampo("mod_10", _Modelo);
                    DataSetX.SetCampo("serie_11", _Serie);
                    DataSetX.SetCampo("nCT_12", _Numero);
                    DataSetX.SetCampo("dhEmi_13", _DataFull);
                    DataSetX.SetCampo("tpImp_14", "1");
                    DataSetX.SetCampo("tpEmis_15", _TpEmiss);
                    DataSetX.SetCampo("cDV_16", _DV);
                    DataSetX.SetCampo("tpAmb_17", "2");
                    DataSetX.SetCampo("tpCTe_18", "0");
                    DataSetX.SetCampo("procEmi_19", "0");
                    DataSetX.SetCampo("verProc_20", "1");
                    DataSetX.SetCampo("refCTE_21", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("cMunEnv_672", "4302105");
                        DataSetX.SetCampo("xMunEnv_673", "BENTO GONCALVES");
                        DataSetX.SetCampo("uFEnv_674", "RS");
                    }
                    else
                    {
                        DataSetX.SetCampo("cMunEmi_22", "4302105");
                        DataSetX.SetCampo("xMunEmi_23", "BENTO GONCALVES");
                        DataSetX.SetCampo("UFEmi_24", "RS");
                    }

                    DataSetX.SetCampo("modal_25", "01");
                    DataSetX.SetCampo("tpServ_26", "0");
                    DataSetX.SetCampo("cMunIni_27", "4302105");
                    DataSetX.SetCampo("xMunIni_28", "BENTO GONCALVES");
                    DataSetX.SetCampo("UFIni_29", "RS");
                    DataSetX.SetCampo("cMunFim_30", "4302105");
                    DataSetX.SetCampo("xMunFim_31", "BENTO GONCALVES");
                    DataSetX.SetCampo("UFFim_32", "RS");
                    DataSetX.SetCampo("retira_33", "0");
                    DataSetX.SetCampo("xDetRetira_34", "");
                    DataSetX.SetCampo("toma_36", "0");
                    DataSetX.SetCampo("toma_38", "");
                    DataSetX.SetCampo("CNPJ_39", "");
                    DataSetX.SetCampo("CPF_40", "");
                    DataSetX.SetCampo("IE_41", "");
                    DataSetX.SetCampo("xNome_42", "");
                    DataSetX.SetCampo("xFant_43", "");
                    DataSetX.SetCampo("fone_44", "");
                    DataSetX.SetCampo("xLgr_46", "");
                    DataSetX.SetCampo("nro_47", "");
                    DataSetX.SetCampo("xCpl_48", "");
                    DataSetX.SetCampo("xBairro_49", "");
                    DataSetX.SetCampo("cMun_50", "");
                    DataSetX.SetCampo("xMun_51", "");
                    DataSetX.SetCampo("CEP_52", "");
                    DataSetX.SetCampo("UF_53", "");
                    DataSetX.SetCampo("cPais_54", "");
                    DataSetX.SetCampo("xPais_55", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("email_601", "");
                        if (rbNormal.Checked)
                        {
                            DataSetX.SetCampo("dhCont_602", "");
                            DataSetX.SetCampo("xJust_603", "");
                        }
                        else
                        {
                            DataSetX.SetCampo("dhCont_602", _DataFull);
                            DataSetX.SetCampo("xJust_603", "Servidor está fora do ar.");
                        }

                    }

                    DataSetX.SetCampo("xCaracAd_57", "");
                    DataSetX.SetCampo("xCaracSer_58", "");
                    DataSetX.SetCampo("xEmi_59", "");
                    DataSetX.SetCampo("xOrig_61", "");

                    DataSetX.IncluirParte("pass");
                    DataSetX.SetCampo("xPass_63", "");
                    DataSetX.SalvarParte("pass");
                    DataSetX.IncluirParte("ObsCont");

                    DataSetX.SetCampo("xDest_64", "");
                    DataSetX.SetCampo("xRota_65", "");
                    DataSetX.SetCampo("tpPer_68", "");
                    DataSetX.SetCampo("tpPer_70", "");
                    DataSetX.SetCampo("dProg_71", "");
                    DataSetX.SetCampo("tpPer_73", "");
                    DataSetX.SetCampo("dIni_74", "");
                    DataSetX.SetCampo("dFim_75", "");
                    DataSetX.SetCampo("hIni_83", "");
                    DataSetX.SetCampo("hFim_84", "");
                    DataSetX.SetCampo("origCalc_85", "");
                    DataSetX.SetCampo("destCalc_86", "");
                    DataSetX.SetCampo("xObs_87", "");

                    DataSetX.SetCampo("xCampo_89", "");
                    DataSetX.SetCampo("xTexto_90", "");
                    DataSetX.SalvarParte("ObsCont");

                    DataSetX.IncluirParte("ObsFisco");
                    DataSetX.SetCampo("xCampo_92", "");
                    DataSetX.SetCampo("xTexto_93", "");
                    DataSetX.SalvarParte("ObsFisco");

                    DataSetX.SetCampo("CNPJ_95", CTe.CNPJ);
                    //Informe a Inscrição Estadual do emitente (transportadora));
                    DataSetX.SetCampo("IE_96", frmDados.edEmitIE.Text);
                    DataSetX.SetCampo("xNome_97", frmDados.edEmitRazaoSocial.Text);
                    //Informe a razão social do emitente (transportadora));
                    DataSetX.SetCampo("xFant_98", frmDados.edEmitFantasia.Text);
                    //Informe o nome Fantasia do emitente (transportadora));
                    DataSetX.SetCampo("xLgr_100", frmDados.edEmitLogradouro.Text);
                    //Informe o logradouro do emitente (transportadora));
                    DataSetX.SetCampo("nro_101", "300");
                    DataSetX.SetCampo("xCpl_102", "10 andar");
                    DataSetX.SetCampo("xBairro_103", "BAIRRO TESTE");
                    DataSetX.SetCampo("cMun_104", "4302105");
                    DataSetX.SetCampo("xMun_105", "BENTO GONCALVES");
                    DataSetX.SetCampo("CEP_106", "89233198");
                    DataSetX.SetCampo("UF_107", "RS");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.SetCampo("cPais_108", "1058");
                        DataSetX.SetCampo("xPais_109", "BRASIL");
                    }

                    DataSetX.SetCampo("fone_110", "1132433400");
                    DataSetX.SetCampo("CNPJ_112", frmDados.edRemCNPJ.Text);//Informe o cnpj do Remetente)
                    DataSetX.SetCampo("CPF_113", "");
                    DataSetX.SetCampo("IE_114", frmDados.edRemIE.Text); //Informe a IE do Remetente);
                    DataSetX.SetCampo("xNome_115", frmDados.edRemRazaoSocial.Text);
                    DataSetX.SetCampo("xFant_116", frmDados.edRemFantasia.Text);
                    DataSetX.SetCampo("fone_117", "4430283749");
                    DataSetX.SetCampo("xLgr_119", frmDados.edRemLogradouro.Text);
                    DataSetX.SetCampo("nro_120", "SN");
                    DataSetX.SetCampo("xCpl_121", "");
                    DataSetX.SetCampo("xBairro_122", "PARANA");
                    DataSetX.SetCampo("cMun_123", "4115200");
                    DataSetX.SetCampo("xMun_124", "PARANA");
                    DataSetX.SetCampo("CEP_125", "01000000");
                    DataSetX.SetCampo("UF_126", "PR");
                    DataSetX.SetCampo("cPais_127", "790");
                    DataSetX.SetCampo("xPais_128", "BRASIL");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("email_604", "");
                    }

                    DataSetX.IncluirParte("infNF");
                    DataSetX.SetCampo("nRoma_130", "");
                    DataSetX.SetCampo("nPed_131", "");
                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("mod_605", "");
                    }
                    DataSetX.SetCampo("serie_132", "");
                    DataSetX.SetCampo("nDoc_133", "");
                    DataSetX.SetCampo("dEmi_134", "");
                    DataSetX.SetCampo("vBC_135", "");
                    DataSetX.SetCampo("vICMS_136", "");
                    DataSetX.SetCampo("vBCST_137", "");
                    DataSetX.SetCampo("vST_138", "");
                    DataSetX.SetCampo("vProd_139", "");
                    DataSetX.SetCampo("vNF_140", "");
                    DataSetX.SetCampo("nCFOP_141", "");
                    DataSetX.SetCampo("nPeso_142", "");
                    DataSetX.SetCampo("PIN_143", "");
                    DataSetX.SetCampo("CNPJ_145", "");
                    DataSetX.SetCampo("CPF_146", "");
                    DataSetX.SetCampo("xNome_147", "");
                    DataSetX.SetCampo("xLgr_148", "");
                    DataSetX.SetCampo("nro_149", "");
                    DataSetX.SetCampo("xCpl_150", "");
                    DataSetX.SetCampo("xBairro_151", "");
                    DataSetX.SetCampo("cMun_152", "");
                    DataSetX.SetCampo("xMun_153", "");
                    DataSetX.SetCampo("UF_154", "");
                    DataSetX.SalvarParte("infNF");

                    DataSetX.IncluirParte("infNFe");
                    DataSetX.SetCampo("chave_156", "");
                    DataSetX.SetCampo("PIN_157", "");
                    DataSetX.SalvarParte("infNF");

                    DataSetX.IncluirParte("infOutros");
                    DataSetX.SetCampo("tpDoc_159", "00");
                    DataSetX.SetCampo("descOutros_160", "");
                    DataSetX.SetCampo("nDoc_161", "123456");
                    DataSetX.SetCampo("dEmi_162", "2011-03-22");
                    DataSetX.SetCampo("vDocFisc_163", "1.00");
                    DataSetX.SalvarParte("infOutros");

                    DataSetX.SetCampo("CNPJ_165", "");
                    DataSetX.SetCampo("CPF_166", "");
                    DataSetX.SetCampo("IE_167", "");
                    DataSetX.SetCampo("xNome_168", "");
                    DataSetX.SetCampo("fone_169", "");
                    DataSetX.SetCampo("xLgr_171", "");
                    DataSetX.SetCampo("nro_172", "");
                    DataSetX.SetCampo("xCpl_173", "");
                    DataSetX.SetCampo("xBairro_174", "");
                    DataSetX.SetCampo("cMun_175", "");
                    DataSetX.SetCampo("xMun_176", "");
                    DataSetX.SetCampo("CEP_177", "");
                    DataSetX.SetCampo("UF_178", "");
                    DataSetX.SetCampo("cPais_179", "");
                    DataSetX.SetCampo("xPais_180", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("email_606", "");
                    }

                    DataSetX.SetCampo("CNPJ_182", "");
                    DataSetX.SetCampo("CPF_183", "");
                    DataSetX.SetCampo("IE_184", "");
                    DataSetX.SetCampo("xNome_185", "");
                    DataSetX.SetCampo("fone_186", "");
                    DataSetX.SetCampo("xLgr_188", "");
                    DataSetX.SetCampo("nro_189", "");
                    DataSetX.SetCampo("xCpl_190", "");
                    DataSetX.SetCampo("xBairro_191", "");
                    DataSetX.SetCampo("cMun_192", "");
                    DataSetX.SetCampo("xMun_193", "");
                    DataSetX.SetCampo("CEP_194", "");
                    DataSetX.SetCampo("UF_195", "");
                    DataSetX.SetCampo("cPais_196", "");
                    DataSetX.SetCampo("xPais_197", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("email_607", "");
                    }

                    DataSetX.SetCampo("CNPJ_199", "");
                    DataSetX.SetCampo("CPF_200", "22233344405");
                    DataSetX.SetCampo("IE_201", "");
                    DataSetX.SetCampo("xNome_202", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
                    DataSetX.SetCampo("fone_203", "");
                    DataSetX.SetCampo("ISUF_204", "");
                    DataSetX.SetCampo("xLgr_206", "Praca Matriz");
                    DataSetX.SetCampo("nro_207", "SN");
                    DataSetX.SetCampo("xCpl_208", "");
                    DataSetX.SetCampo("xBairro_209", "Centro");
                    DataSetX.SetCampo("cMun_210", "4302105");
                    DataSetX.SetCampo("xMun_211", "BENTO GONCALVES");
                    DataSetX.SetCampo("CEP_212", "01000000");
                    DataSetX.SetCampo("UF_213", "RS");
                    DataSetX.SetCampo("cPais_214", "790");
                    DataSetX.SetCampo("xPais_215", "BRASIL");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("email_608", "");
                    }

                    DataSetX.SetCampo("CNPJ_217", "");
                    DataSetX.SetCampo("CPF_218", "");
                    DataSetX.SetCampo("xNome_219", "");
                    DataSetX.SetCampo("xLgr_220", "");
                    DataSetX.SetCampo("nro_221", "");
                    DataSetX.SetCampo("xCpl_222", "");
                    DataSetX.SetCampo("xBairro_223", "");
                    DataSetX.SetCampo("cMun_224", "");
                    DataSetX.SetCampo("xMun_225", "");
                    DataSetX.SetCampo("UF_226", "");
                    DataSetX.SetCampo("vTPrest_228", "200.00");
                    DataSetX.SetCampo("vRec_229", "200.00");

                    DataSetX.IncluirParte("Comp");
                    DataSetX.SetCampo("xNome_231", "");
                    DataSetX.SetCampo("vComp_232", "");
                    DataSetX.SalvarParte("Comp");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.SetCampo("CST_236", "00");
                        DataSetX.SetCampo("vBC_237", "200.00");
                        DataSetX.SetCampo("pICMS_238", "12.00");
                        DataSetX.SetCampo("vICMS_239", "24.00");
                        DataSetX.SetCampo("CST_241", "");
                        DataSetX.SetCampo("pRedBC_242", "");
                        DataSetX.SetCampo("vBC_243", "");
                        DataSetX.SetCampo("pICMS_244", "");
                        DataSetX.SetCampo("vICMS_245", "");
                        DataSetX.SetCampo("CST_247", "");
                        DataSetX.SetCampo("CST_249", "");
                        DataSetX.SetCampo("vBC_250", "");
                        DataSetX.SetCampo("pICMS_251", "");
                        DataSetX.SetCampo("vICMS_252", "");
                        DataSetX.SetCampo("vCred_253", "");
                        DataSetX.SetCampo("CST_255", "");
                        DataSetX.SetCampo("pRedBC_256", "");
                        DataSetX.SetCampo("vBC_257", "");
                        DataSetX.SetCampo("pICMS_258", "");
                        DataSetX.SetCampo("vICMS_259", "");
                        DataSetX.SetCampo("CST_261", "");
                        DataSetX.SetCampo("pRedBC_262", "");
                        DataSetX.SetCampo("vBC_263", "");
                        DataSetX.SetCampo("pICMS_264", "");
                        DataSetX.SetCampo("vICMS_265", "");
                        DataSetX.SetCampo("vCred_266", "");
                    }

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("CST_609", "00");
                        DataSetX.SetCampo("vBC_610", "0.60");
                        DataSetX.SetCampo("pICMS_611", "0.50");
                        DataSetX.SetCampo("vICMS_612", "2.00");
                        DataSetX.SetCampo("CST_613", "");
                        DataSetX.SetCampo("pRedBC_614", "");
                        DataSetX.SetCampo("vBC_615", "");
                        DataSetX.SetCampo("pICMS_616", "");
                        DataSetX.SetCampo("vICMS_617", "");
                        DataSetX.SetCampo("CST_618", "");
                        DataSetX.SetCampo("CST_619", "");
                        DataSetX.SetCampo("vBCSTRet_620", "");
                        DataSetX.SetCampo("vICMSSTRet_621", "");
                        DataSetX.SetCampo("pICMSSTRet_622", "");
                        DataSetX.SetCampo("vCred_623", "");
                        DataSetX.SetCampo("CST_624", "");
                        DataSetX.SetCampo("pRedBC_625", "");
                        DataSetX.SetCampo("vBC_626", "");
                        DataSetX.SetCampo("pICMS_627", "");
                        DataSetX.SetCampo("vICMS_628", "");
                        DataSetX.SetCampo("vCred_629", "");
                        DataSetX.SetCampo("CST_630", "");
                        DataSetX.SetCampo("pRedBCOutraUF_631", "");
                        DataSetX.SetCampo("vBCOutraUF_632", "");
                        DataSetX.SetCampo("pICMSOutraUF_633", "");
                        DataSetX.SetCampo("vICMSOutraUF_634", "");
                        DataSetX.SetCampo("indSN_635", "");
                    }

                    switch (CTe.VersaoManual)
                    {
                        case CTeX.VersaoManual.vm104: DataSetX.SetCampo("vCarga_671", "1000.00");
                            break;
                        case CTeX.VersaoManual.vm103: DataSetX.SetCampo("vMerc_270", "1000.00");
                            break;
                    }

                    DataSetX.SetCampo("InfAdFisco_267", "");
                    DataSetX.SetCampo("proPred_271", "LATA");
                    DataSetX.SetCampo("xOutCat_272", "");

                    DataSetX.IncluirParte("infQ");
                    DataSetX.SetCampo("cUnid_274", "00");
                    DataSetX.SetCampo("tpMed_275", "m3");
                    DataSetX.SetCampo("qCarga_276", "1");
                    DataSetX.SalvarParte("infQ");

                    DataSetX.IncluirParte("contQt");
                    DataSetX.SetCampo("nCont_278", "");

                    DataSetX.IncluirParte("lacContQt");
                    DataSetX.SetCampo("nLacre_280", "");
                    DataSetX.SalvarParte("lacContQt");

                    DataSetX.SetCampo("dPrev_281", "");
                    DataSetX.SalvarParte("contQt");

                    DataSetX.IncluirParte("emiDocAnt");
                    DataSetX.SetCampo("CNPJ_284", "");
                    DataSetX.SetCampo("CPF_285", "");
                    DataSetX.SetCampo("IE_286", "");
                    DataSetX.SetCampo("UF_287", "");
                    DataSetX.SetCampo("xNome_288", "");
                    DataSetX.SalvarParte("emiDocAnt");

                    DataSetX.IncluirParte("idDocAntPap");
                    DataSetX.SetCampo("tpDoc_291", "");
                    DataSetX.SetCampo("serie_292", "");
                    DataSetX.SetCampo("subser_293", "");
                    DataSetX.SetCampo("nDoc_294", "");
                    DataSetX.SetCampo("dEmi_295", "");
                    DataSetX.SalvarParte("idDocAntPap");

                    DataSetX.IncluirParte("idDocAntEle");
                    DataSetX.SetCampo("chave_297", "");
                    DataSetX.SalvarParte("idDocAntEle");

                    DataSetX.IncluirParte("seg");
                    DataSetX.SetCampo("respSeg_299", "");
                    DataSetX.SetCampo("xSeg_300", "");
                    DataSetX.SetCampo("nApol_301", "");
                    DataSetX.SetCampo("nAver_302", "");

                    switch (CTe.VersaoManual)
                    {
                        //Nomenclatura alterada para versão 1.04
                        case CTeX.VersaoManual.vm104: DataSetX.SetCampo("vCarga_675", "");
                            break;
                        case CTeX.VersaoManual.vm103: DataSetX.SetCampo("vMerc_303", "");
                            break;
                    }

                    DataSetX.SalvarParte("seg");

                    //Início dos dados dos modais

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("versaoModal_636", "1.04");
                    }

                    //Modal Rodoviário
                    switch (CTe.VersaoManual)
                    {
                        //Para Versão 1.03 este campo deve conter 14 dígitos.
                        case CTeX.VersaoManual.vm103: DataSetX.SetCampo("RNTRC_305", "00000012000000");
                            break;
                        // Para Versão 1.04a este campo deve conter 8 dígitos.
                        case CTeX.VersaoManual.vm104: DataSetX.SetCampo("RNTRC_305", "00000012");
                            break;
                    }

                    DataSetX.SetCampo("dPrev_306", "2009-04-29");
                    DataSetX.SetCampo("lota_307", "0");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.SetCampo("serie_309", "");
                        DataSetX.SetCampo("nCTRB_310", "");
                    }

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("CIOT_1001", "");
                    }

                    DataSetX.IncluirParte("occ");
                    DataSetX.SetCampo("serie_312", "");
                    DataSetX.SetCampo("nOcc_313", "");
                    DataSetX.SetCampo("dEmi_314", "");
                    DataSetX.SetCampo("CNPJ_316", "");
                    DataSetX.SetCampo("cInt_317", "");
                    DataSetX.SetCampo("IE_318", "");
                    DataSetX.SetCampo("UF_319", "");
                    DataSetX.SetCampo("fone_320", "");
                    DataSetX.SalvarParte("occ");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.SetCampo("nroRE_322", "");
                        DataSetX.SetCampo("vTValePed_323", "");
                        DataSetX.SetCampo("respPg_324", "");

                        DataSetX.IncluirParte("disp");
                        DataSetX.SetCampo("tpDisp_326", "");
                        DataSetX.SetCampo("xEmp_327", "");
                        DataSetX.SetCampo("dVig_328", "");
                        DataSetX.SetCampo("nDisp_329", "");
                        DataSetX.SetCampo("nCompC_330", "");
                        DataSetX.SalvarParte("disp");
                    }
                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.IncluirParte("valePed");
                        DataSetX.SetCampo("CNPJForn_1002", "");
                        DataSetX.SetCampo("nCompra_1003", "");
                        DataSetX.SetCampo("CNPJPg_1004", "");
                        DataSetX.SalvarParte("valePed");
                    }

                    DataSetX.IncluirParte("veic");
                    DataSetX.SetCampo("cInt_332", "");
                    DataSetX.SetCampo("RENAVAM_333", "");
                    DataSetX.SetCampo("placa_334", "");
                    DataSetX.SetCampo("tara_335", "");
                    DataSetX.SetCampo("capKG_336", "");
                    DataSetX.SetCampo("capM3_337", "");
                    DataSetX.SetCampo("tpProp_338", "");
                    DataSetX.SetCampo("tpVeic_339", "");
                    DataSetX.SetCampo("tpRod_340", "");
                    DataSetX.SetCampo("tpCar_341", "");
                    DataSetX.SetCampo("UF_342", "");
                    DataSetX.SetCampo("CPF_344", "");
                    DataSetX.SetCampo("CNPJ_345", "");
                    DataSetX.SetCampo("RNTRC_346", "");
                    DataSetX.SetCampo("xNome_347", "");
                    DataSetX.SetCampo("IE_348", "");
                    DataSetX.SetCampo("UF_349", "");
                    DataSetX.SetCampo("tpProp_350", "");
                    DataSetX.SalvarParte("veic");

                    DataSetX.IncluirParte("lacRodo");
                    DataSetX.SetCampo("nLacre_352", "");
                    DataSetX.SalvarParte("lacRodo");

                    DataSetX.IncluirParte("moto");
                    DataSetX.SetCampo("xNome_354", "");
                    DataSetX.SetCampo("CPF_355", "");
                    DataSetX.SalvarParte("moto");

                    //Modal Aéreo
                    DataSetX.SetCampo("nMinu_357", "");
                    DataSetX.SetCampo("nOCA_358", "");
                    DataSetX.SetCampo("dPrev_359", "");
                    DataSetX.SetCampo("xLAgEmi_360", "");
                    DataSetX.SetCampo("cIATA_361", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.SetCampo("trecho_363", "");
                    }

                    DataSetX.SetCampo("CL_364", "");
                    DataSetX.SetCampo("cTar_365", "");
                    DataSetX.SetCampo("vTar_366", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("xDime_1101", "");
                        DataSetX.IncluirParte("cInfManu");
                        DataSetX.SetCampo("cInfManu_1102", "");
                        DataSetX.SalvarParte("cInfManu");

                        DataSetX.IncluirParte("cIMP");
                        DataSetX.SetCampo("cIMP_1103", "");
                        DataSetX.SalvarParte("cIMP");
                    }

                    //Modal Aquaviário
                    DataSetX.SetCampo("vPrest_368", "");
                    DataSetX.SetCampo("vAFRMM_369", "");
                    DataSetX.SetCampo("nBooking_370", "");
                    DataSetX.SetCampo("nCtrl_371", "");
                    DataSetX.SetCampo("xNavio_372", "");
                    DataSetX.SetCampo("nViag_373", "");
                    DataSetX.SetCampo("direc_374", "");
                    DataSetX.SetCampo("prtEmb_375", "");
                    DataSetX.SetCampo("prtTrans_376", "");
                    DataSetX.SetCampo("prtDest_377", "");
                    DataSetX.SetCampo("tpNav_378", "");
                    DataSetX.SetCampo("irin_379", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.IncluirParte("balsa");
                        DataSetX.SetCampo("xBalsa_1201", "");
                        DataSetX.SalvarParte("balsa");
                    }

                    DataSetX.IncluirParte("lacre");
                    DataSetX.SetCampo("nLacre_381", "");
                    DataSetX.SalvarParte("lacre");

                    //Modal Ferroviário
                    DataSetX.SetCampo("tpTraf_383", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("respFat_1301", "");
                        DataSetX.SetCampo("ferrEmi_1302", "");
                    }

                    DataSetX.SetCampo("fluxo_384", "");
                    DataSetX.SetCampo("idTrem_385", "");
                    DataSetX.SetCampo("vFrete_386", "");
                    DataSetX.SetCampo("CNPJ_388", "");
                    DataSetX.SetCampo("cInt_389", "");
                    DataSetX.SetCampo("IE_390", "");
                    DataSetX.SetCampo("xNome_391", "");
                    DataSetX.SetCampo("xLgr_393", "");
                    DataSetX.SetCampo("nro_394", "");
                    DataSetX.SetCampo("xCpl_395", "");
                    DataSetX.SetCampo("xBairro_396", "");
                    DataSetX.SetCampo("cMun_397", "");
                    DataSetX.SetCampo("xMun_398", "");
                    DataSetX.SetCampo("CEP_399", "");
                    DataSetX.SetCampo("UF_400", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.IncluirParte("DCL");
                        DataSetX.SetCampo("serie_402", "");
                        DataSetX.SetCampo("nDCL_403", "");
                        DataSetX.SetCampo("dEmi_404", "");
                        DataSetX.SetCampo("qVag_405", "");
                        DataSetX.SetCampo("pCalc_406", "");
                        DataSetX.SetCampo("vTar_407", "");
                        DataSetX.SetCampo("vFrete_408", "");
                        DataSetX.SetCampo("vSAcess_409", "");
                        DataSetX.SetCampo("vTServ_410", "");
                        DataSetX.SetCampo("idTrem_411", "");
                        DataSetX.SalvarParte("DCL");

                        DataSetX.IncluirParte("detVagDCL");
                        DataSetX.SetCampo("nVag_413", "");
                        DataSetX.SetCampo("cap_414", "");
                        DataSetX.SetCampo("tpVag_415", "");
                        DataSetX.SetCampo("pesoR_416", "");
                        DataSetX.SetCampo("pesoBC_417", "");
                        DataSetX.SalvarParte("detVagDCL");

                        DataSetX.IncluirParte("lacDetVagDCL");
                        DataSetX.SetCampo("nLacre_419", "");
                        DataSetX.SalvarParte("lacDetVagDCL");

                        DataSetX.IncluirParte("contDCL");
                        DataSetX.SetCampo("nCont_421", "");
                        DataSetX.SetCampo("dPrev_422", "");
                        DataSetX.SalvarParte("contDCL");
                    }

                    DataSetX.IncluirParte("detVag");
                    DataSetX.SetCampo("nVag_424", "");
                    DataSetX.SetCampo("cap_425", "");
                    DataSetX.SetCampo("tpVag_426", "");
                    DataSetX.SetCampo("pesoR_427", "");
                    DataSetX.SetCampo("pesoBC_428", "");
                    DataSetX.SalvarParte("detVag");

                    DataSetX.IncluirParte("lacDetVag");
                    DataSetX.SetCampo("nLacre_430", "");
                    DataSetX.SalvarParte("lacDetVag");

                    DataSetX.IncluirParte("contVag");
                    DataSetX.SetCampo("nCont_432", "");
                    DataSetX.SetCampo("dPrev_433", "");
                    DataSetX.SalvarParte("contVag");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.IncluirParte("ratNF");
                        DataSetX.SetCampo("serie_1303", "");
                        DataSetX.SetCampo("nDoc_1304", "");
                        DataSetX.SetCampo("pesoRat_1305", "");
                        DataSetX.SalvarParte("ratNF");

                        DataSetX.IncluirParte("ratNFe");
                        DataSetX.SetCampo("chave_1306", "");
                        DataSetX.SetCampo("pesoRat_1307", "");
                        DataSetX.SalvarParte("ratNFe");
                    }

                    //Modal Dutoviário
                    DataSetX.SetCampo("vTar_435", "");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("dIni_1401", "");
                        DataSetX.SetCampo("dFim_1402", "");
                    }

                    //Fim dos dados dos modais

                    DataSetX.IncluirParte("peri");
                    DataSetX.SetCampo("nONU_437", "");
                    DataSetX.SetCampo("xNomeAE_438", "");
                    DataSetX.SetCampo("xClaRisco_439", "");
                    DataSetX.SetCampo("grEmb_440", "");
                    DataSetX.SetCampo("qTotProd_441", "");
                    DataSetX.SetCampo("qVolTipo_442", "");
                    DataSetX.SetCampo("pontoFulgor_443", "");
                    DataSetX.SalvarParte("peri");

                    DataSetX.IncluirParte("veicNovos");
                    DataSetX.SetCampo("chassi_445", "");
                    DataSetX.SetCampo("cCor_446", "");
                    DataSetX.SetCampo("xCor_447", "");
                    DataSetX.SetCampo("cMod_448", "");
                    DataSetX.SetCampo("vUnit_449", "");
                    DataSetX.SetCampo("vFrete_450", "");
                    DataSetX.SalvarParte("veicNovos");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("nFat_637", "");
                        DataSetX.SetCampo("vOrig_638", "");
                        DataSetX.SetCampo("vDesc_639", "");
                        DataSetX.SetCampo("vLiq_640", "");

                        DataSetX.IncluirParte("dup");
                        DataSetX.SetCampo("nDup_641", "");
                        DataSetX.SetCampo("dVenc_642", "");
                        DataSetX.SetCampo("vDup_643", "");
                        DataSetX.SalvarParte("dup");
                    }

                    DataSetX.SetCampo("chCte_452", "");
                    DataSetX.SetCampo("refNFe_454", "");
                    DataSetX.SetCampo("CNPJ_456", "");
                    DataSetX.SetCampo("mod_457", "");
                    DataSetX.SetCampo("serie_458", "");
                    DataSetX.SetCampo("subserie_459", "");
                    DataSetX.SetCampo("nro_460", "");
                    DataSetX.SetCampo("valor_461", "");
                    DataSetX.SetCampo("dEmi_462", "");
                    DataSetX.SetCampo("refCte_463", "");
                    DataSetX.SetCampo("refCteAnu_465", "");

                    DataSetX.IncluirParte("infCteComp");
                    DataSetX.SetCampo("chave_467", "");
                    DataSetX.SetCampo("vTPrest_469", "");

                    DataSetX.IncluirParte("compComp");
                    DataSetX.SetCampo("xNome_471", "");
                    DataSetX.SetCampo("vComp_472", "");
                    DataSetX.SalvarParte("compComp");

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm103)
                    {
                        DataSetX.SetCampo("CST_476", "");
                        DataSetX.SetCampo("vBC_477", "");
                        DataSetX.SetCampo("pICMS_478", "");
                        DataSetX.SetCampo("vICMS_479", "");
                        DataSetX.SetCampo("CST_481", "");
                        DataSetX.SetCampo("pRedBC_482", "");
                        DataSetX.SetCampo("vBC_483", "");
                        DataSetX.SetCampo("pICMS_484", "");
                        DataSetX.SetCampo("vICMS_485", "");
                        DataSetX.SetCampo("CST_487", "");
                        DataSetX.SetCampo("CST_489", "");
                        DataSetX.SetCampo("vBC_490", "");
                        DataSetX.SetCampo("pICMS_491", "");
                        DataSetX.SetCampo("vICMS_492", "");
                        DataSetX.SetCampo("vCred_493", "");
                        DataSetX.SetCampo("CST_495", "");
                        DataSetX.SetCampo("pRedBC_496", "");
                        DataSetX.SetCampo("vBC_497", "");
                        DataSetX.SetCampo("pICMS_498", "");
                        DataSetX.SetCampo("vICMS_499", "");
                        DataSetX.SetCampo("CST_501", "");
                        DataSetX.SetCampo("pRedBC_502", "");
                        DataSetX.SetCampo("vBC_503", "");
                        DataSetX.SetCampo("pICMS_504", "");
                        DataSetX.SetCampo("vICMS_505", "");
                        DataSetX.SetCampo("vCred_506", "");
                    }

                    if (CTe.VersaoManual == CTeX.VersaoManual.vm104)
                    {
                        DataSetX.SetCampo("CST_644", "");
                        DataSetX.SetCampo("vBC_645", "");
                        DataSetX.SetCampo("pICMS_646", "");
                        DataSetX.SetCampo("vICMS_647", "");
                        DataSetX.SetCampo("CST_648", "");
                        DataSetX.SetCampo("pRedBC_649", "");
                        DataSetX.SetCampo("vBC_650", "");
                        DataSetX.SetCampo("pICMS_651", "");
                        DataSetX.SetCampo("vICMS_652", "");
                        DataSetX.SetCampo("CST_653", "");
                        DataSetX.SetCampo("CST_654", "");
                        DataSetX.SetCampo("vBCSTRet_655", "");
                        DataSetX.SetCampo("vICMSSTRet_656", "");
                        DataSetX.SetCampo("pICMSSTRet_657", "");
                        DataSetX.SetCampo("vCred_658", "");
                        DataSetX.SetCampo("CST_659", "");
                        DataSetX.SetCampo("pRedBC_660", "");
                        DataSetX.SetCampo("vBC_661", "");
                        DataSetX.SetCampo("pICMS_662", "");
                        DataSetX.SetCampo("vICMS_663", "");
                        DataSetX.SetCampo("vCred_664", "");
                        DataSetX.SetCampo("CST_665", "");
                        DataSetX.SetCampo("pRedBCOutraUF_666", "");
                        DataSetX.SetCampo("vBCOutraUF_667", "");
                        DataSetX.SetCampo("pICMSOutraUF_668", "");
                        DataSetX.SetCampo("vICMSOutraUF_669", "");
                        DataSetX.SetCampo("indSN_670", "");
                    }

                    DataSetX.SetCampo("infAdFisco_507", "");
                    DataSetX.SalvarParte("infCteComp");

                    DataSetX.SetCampo("chCte_509", "");
                    DataSetX.SetCampo("dEmi_510", "");

                    DataSetX.Salvar();

                    string _ValorDeRetorno = DataSetX.LoteCTe();
                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Gerar XML por DataSet: OK");
                    btnPreverDacte.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Gerar XML por DataSet: Erro");
                TratarExcecao(ex);
            }
        }

        //4.Enviar CTe
        private void btnEnviarCTe_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (FIdLote != "")
                {
                    string _XMLDeEnvio;
                    string _ValorDeRetorno;

                    _XMLDeEnvio = CTe.CompressXML(mOutput.Text);
                    _XMLDeEnvio = CTe.AssinarCT(ref _XMLDeEnvio);
                    _ValorDeRetorno = CTe.EnviarCT(FIdLote, _XMLDeEnvio);

                    edRecibo.Text = CTe.ExtrairRecibo(_ValorDeRetorno);

                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Enviar CTe: OK");
                    btnPreverDacte.Enabled = false;
                }
                else
                    Aviso("Verifique se o o lote foi informado");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Enviar CTe: Erro");
                TratarExcecao(ex);
            }

        }

        //5.Consultar Recibo CTe
        private void btnConsultarReciboCTe_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (edRecibo.Text != "")
                {
                    string _ValorDeRetorno = CTe.ConsultarRecibo(edRecibo.Text);

                    edProtocolo.Text = CTe.ExtrairProtocolo(_ValorDeRetorno);

                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Consultar Recibo CTe: OK");
                }
                else
                {
                    Aviso("Favor informar um recibo antes de prosseguir");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Consultar Recibo CTe: Erro");
                TratarExcecao(ex);
            }
        }

        //6.Consultar CTe
        private void btnConsultarCTe_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (edChave.Text != "")
                {
                    string _ValorDeRetorno = CTe.ConsultarCT(edChave.Text);

                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Consultar CTe: OK");
                }
                else
                {
                    Aviso("Favor informar uma chave antes de prosseguir");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Consultar CTe: Erro");
                TratarExcecao(ex);
            }
        }

        //7.Cancelar CTe
        private void btnCancelarCTe_Click_1(object sender, EventArgs e)
        {
            try
            {
                FCancelaCTe frmCancela = new FCancelaCTe();
                DialogResult Result;

                frmCancela.edChave.Text = edChave.Text;
                frmCancela.edNumeroProtocolo.Text = edProtocolo.Text;

                Result = frmCancela.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    string _ValorDeRetorno = CTe.CancelarCT(frmCancela.edChave.Text,
                                                            frmCancela.edNumeroProtocolo.Text,
                                                            frmCancela.mJustificativa.Text);

                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Cancelar CTe: OK");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Cancelar CTe: Erro");
                TratarExcecao(ex);
            }
        }

        //8.Inutilizar CTe
        private void btnInutilizarCte_Click_1(object sender, EventArgs e)
        {
            try
            {
                FInutilizaCTe frmInutiliza = new FInutilizaCTe();
                DialogResult Result;

                frmInutiliza.edAno.Text = String.Format("{0:yy}", DateTime.Now);
                frmInutiliza.edCNPJ.Text = CTe.CNPJ;
                frmInutiliza.edModelo.Text = "57";
                frmInutiliza.edSerie.Text = "0";

                Result = frmInutiliza.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    string _ValorDeRetorno = CTe.InutilizarCT(frmInutiliza.edAno.Text,
                                                              frmInutiliza.edCNPJ.Text,
                                                              frmInutiliza.edModelo.Text,
                                                              frmInutiliza.edSerie.Text,
                                                              frmInutiliza.edCTInicial.Text,
                                                              frmInutiliza.edCTFinal.Text,
                                                              frmInutiliza.mJustificativa.Text);

                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Inutilizar CTe: OK");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Inutilizar CTe: Erro");
                TratarExcecao(ex);
            }
        }

        //******************************************************************************************************
        //
        //          Aqui começam as funções para impressão
        //
        //******************************************************************************************************

        //9.Editar Modelo
        private void btnEditarModelo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!chbModoContingencia.Checked)
                {
                    string _XMLTomador = ObterCaminhoXMLTomador(edChave.Text);
                    if (_XMLTomador.Trim() != "")
                    {
                        string _XML = LoadFromFile(_XMLTomador);
                        CTe.EditarModeloDACTE(_XML, "");
                    }
                }
                else
                {
                    CTe.EditarModeloDACTE(mOutput.Text, "");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Editar Modelo: Erro");
                TratarExcecao(ex);
            }
        }

        //10.Imprimir
        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!chbModoContingencia.Checked)
                {
                    string _XMLTomador = ObterCaminhoXMLTomador(edChave.Text);
                    if (_XMLTomador.Trim() != "")
                    {
                        string _XML = LoadFromFile(_XMLTomador);
                        CTe.ImprimirDACTE(_XML, "", "");
                    }
                }
                else
                {
                    CTe.ImprimirDACTE(mOutput.Text, "", "");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Imprimir: Erro");
                TratarExcecao(ex);
            }
        }

        //11.Exportar para PDF
        private void btnExportarPdf_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!chbModoContingencia.Checked)
                {
                    string _XMLTomador = ObterCaminhoXMLTomador(edChave.Text);
                    if (_XMLTomador.Trim() != "")
                    {
                        string _XML = LoadFromFile(_XMLTomador);
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            CTe.ExportarDACTEParaPDF(_XML, "", saveFileDialog1.FileName);
                        }
                    }
                }
                else
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        CTe.ExportarDACTEParaPDF(mOutput.Text, "", saveFileDialog1.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Exportar para PDF: Erro");
                TratarExcecao(ex);
            }
        }

        //12.Visualizar
        private void btnVisualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!chbModoContingencia.Checked)
                {
                    string _XMLTomador = ObterCaminhoXMLTomador(edChave.Text);
                    if (_XMLTomador.Trim() != "")
                    {
                        string _XML = LoadFromFile(_XMLTomador);
                        CTe.VisualizarDACTE(_XML, "");
                    }
                }
                else
                {
                    CTe.VisualizarDACTE(mOutput.Text, "");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Visualizar: Erro");
                TratarExcecao(ex);
            }
        }

        //13.Enviar por Email
        private void btnEnviarEmail_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (edChave.Text != "")
                {
                    InputBoxResult result = InputBox.Show("Email do Tomador de Serviço", "Favor informar o email do tomador de serviço", "exemplo@yahoo.com", null);
                    if ((result.OK) && (result.Text != ""))
                    {
                        //Configure as propriedades relacionadas ao envio de email:
                        CTe.EmailServidorSMTP = "smtp.gmail.com"; // CONFIGURAR SERVIDOR SMTP, por exemplo: smtp.gmail.com
                        CTe.EmailUsuario = "testedacte@gmail.com"; // CONFIGURAR USUARIO
                        CTe.EmailSenha = "tecnospeed"; // CONFIGURAR SENHA
                        CTe.EmailRemetente = "testedacte@gmail.com";// CONFIGURAR EMAIL DO REMETENTE, exemplo: jose@gmail.com
                        CTe.EmailTomadorServico = result.Text;// CONFIGURAR EMAIL(S) DO(s) TOMADOR DE SERVIÇO(S), exemplo: fulano@yahoo.com.br
                        CTe.EmailAutenticacao = true; //Verificar se o servidor de smtp necessita ser autenticado.
                        CTe.EmailAssunto = "Teste envio de email";
                        CTe.EmailMensagem = "Esta mensagem é um teste";

                        if (CTe.EnviarConhecimentoTomador(edChave.Text, "", ""))
                            Aviso("Email enviado com sucesso para " + CTe.EmailTomadorServico);
                    }
                }
                else
                    Aviso("Favor informar uma chave válida.");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Enviar por Email: Erro");
                TratarExcecao(ex);
            }
        }

        private void cboVersao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboVersao.SelectedIndex)
            {
                case 0:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm103;
                        break;
                    }
                case 1:
                    {
                        CTe.VersaoManual = CTeX.VersaoManual.vm104;
                        break;
                    }
            }
            //Grava no arquivo .ini a Versão do Manual selecionada.
            WriteIniValue("CTe", "VersaoManual", cboVersao.Text, ArqIni);
        }

        private void btnPreverDacte_Click_1(object sender, EventArgs e)
        {
            try
            {
                string _XML = mOutput.Text;
                if (_XML.Trim() != "")
                {
                    CTe.PreverDACTE(_XML, "");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Prever Dacte: Erro");
                TratarExcecao(ex);
            }
        }

        private void btnMontarEPEC_Click(object sender, EventArgs e)
        {
            
            try
            {
                //string _XmlEPEC, _DataHora;

                if (mOutput.Text != "")
                {
                    //InputBoxResult result = InputBox.Show("Data e Hora do Evento", "Digite a Data e Hora do Evento:", "01/01/2013 10:10:10", null);
                    //_DataHora = result.Text;
                    //_XmlEPEC = mOutput.Text;
                    //_XmlEPEC = CTe.MontarEPEC(_XmlEPEC, _DataHora);
                    //AtualizaRetornoNaTela(_XmlEPEC);
                    AtualizaStatusNaTela("Montar EPEC é Deprecated!");
                }
                else
                    Aviso("Favor primeiramente gerar um Lote CTe");  
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Erro ao montar EPEC: Erro");
                TratarExcecao(ex);
            }
        }

        private void btnAssinarEPEC_Click(object sender, EventArgs e)
        {
            try
            {
                string _XmlEPEC;
                _XmlEPEC = mOutput.Text;
                _XmlEPEC = CTe.AssinarEPEC(_XmlEPEC);
                AtualizaRetornoNaTela(_XmlEPEC);
                AtualizaStatusNaTela("XML EPEC Assinado");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Erro ao Assinar EPEC: Erro");
                TratarExcecao(ex);
            }
        }

        private void btnConsultarEPEC_Click(object sender, EventArgs e)
        {
            try
            {
                if (edChave.Text != "")
                {
                    //string _ValorDeRetorno = CTe.ConsultarEPEC(edChave.Text);                    

                    //AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Consultar EPEC: Método Deprecated");
                }
                else
                {
                    Aviso("Favor informar uma chave antes de prosseguir");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Consultar EPEC: Erro");
                TratarExcecao(ex);
            }
        }

        private void btnEnviarEPEC_Click(object sender, EventArgs e)
        {
            try
            {
                string _XmlEPEC;
                _XmlEPEC = mOutput.Text;
                _XmlEPEC = CTe.EnviarEPEC(_XmlEPEC);
                AtualizaRetornoNaTela(_XmlEPEC);
                AtualizaStatusNaTela("XML EPEC Enviado");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Erro ao Enviar EPEC: Erro");
                TratarExcecao(ex);
            }
        }

        private void btnOpenIni_Click(object sender, EventArgs e)
        {
            Process.Start(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("\\", "//").Remove(0, 7) + "//cteConfig.ini");
        }

        private void btnDhDesacordo_Click(object sender, EventArgs e)
        {
            tbDataHoraDesacordo.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00";
        }

        private void btnEnviarDesacordo_Click(object sender, EventArgs e)
        {
            mOutput.Text = CTe.EnviarDesacordo(tbChaveDesacordo.Text, tbDataHoraDesacordo.Text, rtbObservacaoDesacordo.Text, tbSequenciaDesacordo.Text);
        }
    }
}