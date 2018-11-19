using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace ExemploCTe
{
    public partial class FrmExemplo : Form
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

        //Declaração de variáveis do componente spdCTeX
        CTeX.spdCTeX CTe;
        CTeDataSetX.spdCTeDataSetX CTeDataSet;

        //Caminho para o arquivo de configuração
        //Arquivo INI a ser manipulado com parametrizações
        string ArqIni = Application.StartupPath + "\\cteConfig.ini";
        string CertificadoSelecionado;

        //guarda o nro do lote a ser enviado
        string FIdLote;

        //******************************************************************************************************
        //
        //          Funções utilitárias
        //
        //******************************************************************************************************
        
        //Inicialização
        public FrmExemplo()
        {
            InitializeComponent();
            //Instancia o Objeto responsável pelaT interação com servidores da Receita
            CTe = new CTeX.spdCTeX();
            CTeDataSet = new CTeDataSetX.spdCTeDataSetX();

            //Utiliza Método do Componente para Listar Certificados instalado no SO            
            string Certificados;
            string[] vetor;

            Certificados = CTe.ListarCertificados();
            vetor = Certificados.Split('|');

            cbCertificados.Items.Clear();

            foreach (string _cert in vetor)
            {
                cbCertificados.Items.Add(_cert);
            }

        }

        // 1.1 Configurar o CNPJ da Software House
        private void BtnConfiguraSH_Click(object sender, EventArgs e)
        {
            CTe.ConfigurarSoftwareHouse(edtCNPJSH.Text, "");
        }

        // 1.2 Configurar Arquivo .ini
        private void BtnConfiguraIni_Click(object sender, EventArgs e)
        {
                if (cbCertificados.SelectedIndex != -1)
                {
                    CertificadoSelecionado = cbCertificados.Items[cbCertificados.SelectedIndex].ToString();
                    CTe.NomeCertificado = CertificadoSelecionado;
                    
                    //Grava o nome do certificado selecionado no arquivo .ini
                    WriteIniValue("CTe", "NomeCertificado", CertificadoSelecionado, ArqIni);
                    System.Diagnostics.Process.Start(ArqIni);
                }
                else
                {
                    Aviso("Favor selecionar um certificado");
                }
        }

        // 2.Executando LoadConfig
        private void BtnLoadConfig_Click(object sender, EventArgs e)
        {
            try
            {
                CTe.LoadConfig(ArqIni);
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("LoadConfig CTe: Erro");
                TratarExcecao(ex);
            }
            edtUF.Text = CTe.UF;
            edtCNPJEmit.Text = CTe.CNPJ;
            cbCertificados.Text = CTe.NomeCertificado;
            AtualizaStatusNaTela("Configurações carregadas via arquivo ini.");
        }

        // 3.Verificar Status do Serviço
        private void BtnStatus_Click(object sender, EventArgs e)
        {
            CheckConfig(false);
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

        // 4.1.Gerar XML via TX2
        private void BtnTx2_Click(object sender, EventArgs e)
        {
            CheckConfig();
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Tx2 files (*.tx2)|*.tx2";
                openFileDialog1.InitialDirectory = Application.StartupPath;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ConfiguraCteDataSet();
                    CTeDataSet.LoadFromTX2(openFileDialog1.FileName);
                    string _ValorDeRetorno = CTeDataSet.LoteCTe();
                    AtualizaRetornoNaTela(_ValorDeRetorno);
                    edtChave.Text = CTeDataSet.GetCampo("Id_3").Substring(3, 44);
                    AtualizaStatusNaTela("Gerar XML por TX2: OK");
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Gerar XML por TX2: Erro");
                TratarExcecao(ex);
            }
        }

        // 4.2.Gerar XML via DataSet
        private void BtnDataSet_Click(object sender, EventArgs e)
        {
            CheckConfig();
            ConfiguraCteDataSet();
            CTeDataSet.Incluir();
            DadosdoCTe();
            DadosTomador();
            DadosdoCTe();
            DadosEmitente();
            DadosRemetente();
            DadosDestinatario();
            PrestacaodeServico();
            DadosImpostos();
            VersaoModal();
            DadosCarga();
            DadosICMSUFFim();
            OutrasInformacoes();
            QuantidadesCarga();
            ModalRodoviario();
            OrdensColeta();
            CTeDataSet.Salvar();

            string CodigoUF = CTe.ObterCodigoUF(CTe.UF).ToString();

            string Data = DateTime.Now.ToString("yyyy-MM-dd");

            string Hora = DateTime.Now.ToString("hh:mm:ss");

            string DataFull = Data + "T" + Hora + "-03:00";

            string Modelo = "67";

            string Codigo = "06021956";

            string Serie = "1";

            string Numero = "1";

            string tpEmis = "1";

            string Chave = CTe.CalculaChave(CodigoUF, Data, CTe.CNPJ, Modelo, Serie, Numero, Codigo, tpEmis);
            
            edtChave.Text = Chave;

            string _XML = CTeDataSet.LoteCTe();
            AtualizaRetornoNaTela(_XML);
            AtualizaStatusNaTela("XML via DataSets gerado com sucesso.");
        }

        // 5.1. Assinar CTe
        private void BtnAssinar_Click(object sender, EventArgs e)
        {
            string _XML = CTe.AssinarCT(CTe.CompressXML(mmXML.Text));
            AtualizaRetornoNaTela(_XML);
            AtualizaStatusNaTela("Assinar CTe: OK");
        }

        // 5.2. Preve Dacte
        private void BtnPreverDacte_Click(object sender, EventArgs e)
        {
            CheckConfig(false);
            try
            {
                string _XML = mmXML.Text;
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

        // 6.Enviar CTe
        private void BtnEnviarCTe_Click(object sender, EventArgs e)
        {
            CheckConfig(false);
            try
            {

                    string _XMLDeEnvio;
                    string _ValorDeRetorno;

                    _XMLDeEnvio = CTe.CompressXML(mmXML.Text);
                    _XMLDeEnvio = CTe.AssinarCT(ref _XMLDeEnvio);
                    _ValorDeRetorno = CTe.EnviarCT(FIdLote, _XMLDeEnvio);

                    edtRecibo.Text = CTe.ExtrairRecibo(_ValorDeRetorno);

                    AtualizaRetornoNaTela(_ValorDeRetorno);

                    AtualizaStatusNaTela("Enviar CTe: OK");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Enviar CTe: Erro");
                TratarExcecao(ex);
            }
        }

        // 7. Consultar Recibo CTe
        private void BtnConsultaRecibo_Click(object sender, EventArgs e)
        {
            CheckConfig();
            try
            {
                if (edtRecibo.Text != "")
                {
                    string _ValorDeRetorno = CTe.ConsultarRecibo(edtRecibo.Text);

                    edtProtocolo.Text = CTe.ExtrairProtocolo(_ValorDeRetorno);

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

        // 8.Consultar CTe
        private void BtnConsultaCTe_Click(object sender, EventArgs e)
        {
            CheckConfig();
            try
            {
                if (edtChave.Text != "")
                {
                    string _ValorDeRetorno = CTe.ConsultarCT(edtChave.Text);

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

        // 9.Cancelar CTe
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CheckConfig();
            try
            {
                WindowsFormsApp3.FCancelaCTe frmCancela = new WindowsFormsApp3.FCancelaCTe();
                DialogResult Result;

                frmCancela.edtChave.Text = edtChave.Text;
                frmCancela.edtNumeroProtocolo.Text = edtProtocolo.Text;
                string _Data = String.Format("{0:yyyy-MM-dd'T'HH:mm:sszzz}", DateTime.Now);

                Result = frmCancela.ShowDialog();

                if (Result == DialogResult.OK)
                {

                    string _ValorDeRetorno = CTe.CancelarCTEvento(frmCancela.edtChave.Text,
                                         frmCancela.edtNumeroProtocolo.Text,
                                         frmCancela.mmJustificativa.Text,
                                         _Data,
                                         "1");

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

        // 10.Visualizar
        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            CheckConfig(false);
            try
            {
                CTe.EditarModeloDACTE(mmXML.Text, "");
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Visualizar: Erro");
                TratarExcecao(ex);
            }
        }

        // 11.Exportar para PDF
        private void BtnExporta_Click(object sender, EventArgs e)
        {
            CheckConfig(false);
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CTe.ExportarDACTEParaPDF(mmXML.Text, "", saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                AtualizaStatusNaTela("Exportar para PDF: Erro");
                TratarExcecao(ex);
            }
        }

        // Configura CTeDataSet
        private void ConfiguraCteDataSet()
        {
            string _VersaoManual = "3.00";
            CTeDataSet.Versao = _VersaoManual;
            CTeDataSet.ConfigSection = "XMLENVIO";
            CTeDataSet.MappingFileName = CTe.DiretorioEsquemas + _VersaoManual + "\\" + CTe.MappingFileName;
            CTeDataSet.CreateDataSets();
            CTeDataSet.IdLote = "1";
        }
        // Preenche os Dados do CTe do DataSet
        private void DadosdoCTe()
        {
            CTeDataSet.SetCampo("versao_2", "3.00");
            CTeDataSet.SetCampo("cUF_5", "43");
            CTeDataSet.SetCampo("cCT_6", "00000000");
            CTeDataSet.SetCampo("CFOP_7", "5357");
            CTeDataSet.SetCampo("natOp_8", "TRANSPORTE RODOVIARIO DE CARGAS");
            CTeDataSet.SetCampo("mod_10", "57");
            CTeDataSet.SetCampo("serie_11", "876");
            CTeDataSet.SetCampo("nCT_12", "10");
            CTeDataSet.SetCampo("dhEmi_13", "2018-10-15T15:26:00-03:00");
            CTeDataSet.SetCampo("tpImp_14", "1");
            CTeDataSet.SetCampo("tpEmis_15", "1");
            CTeDataSet.SetCampo("tpAmb_17", "2");
            CTeDataSet.SetCampo("tpCTe_18", "0");
            CTeDataSet.SetCampo("procEmi_19", "0");
            CTeDataSet.SetCampo("verProc_20", "1");
            CTeDataSet.SetCampo("cMunEnv_672", "4302105");
            CTeDataSet.SetCampo("xMunEnv_673", "BENTO GONCALVES");
            CTeDataSet.SetCampo("UFEnv_674", "RS");
            CTeDataSet.SetCampo("modal_25", "01");
            CTeDataSet.SetCampo("tpServ_26", "0");
            CTeDataSet.SetCampo("cMunIni_27", "4302105");
            CTeDataSet.SetCampo("xMunIni_28", "BENTO GONCALVES");
            CTeDataSet.SetCampo("UFIni_29", "RS");
            CTeDataSet.SetCampo("cMunFim_30", "4302105");
            CTeDataSet.SetCampo("xMunFim_31", "BENTO GONCALVES");
            CTeDataSet.SetCampo("UFFim_32", "RS");
            CTeDataSet.SetCampo("retira_33", "0");
            CTeDataSet.SetCampo("xDetRetira_34", "detalhes teste");
            CTeDataSet.SetCampo("indIEToma_1406", "1");
        }

        // Preenche os Dados do Tomador do DataSet
        private void DadosTomador()
        {
            CTeDataSet.SetCampo("toma_36", "3");
        }

        // Preenche os Dados do Emitente do DataSet
        private void DadosEmitente()
        {
            CTeDataSet.SetCampo("CNPJ_95", "99999999999999");
            CTeDataSet.SetCampo("IE_96", "9999999999");
            CTeDataSet.SetCampo("xNome_97", "Nome teste");
            CTeDataSet.SetCampo("xFant_98", "Nome teste");
            CTeDataSet.SetCampo("xLgr_100", "Rua teste");
            CTeDataSet.SetCampo("nro_101", "300");
            CTeDataSet.SetCampo("xCpl_102", "10 andar");
            CTeDataSet.SetCampo("xBairro_103", "BAIRRO TESTE");
            CTeDataSet.SetCampo("cMun_104", "4302105");
            CTeDataSet.SetCampo("xMun_105", "BENTO GONCALVES");
            CTeDataSet.SetCampo("CEP_106", "89233198");
            CTeDataSet.SetCampo("UF_107", "RS");
            CTeDataSet.SetCampo("fone_110", "1132433400");
        }

        // Preenche os Dados do Remetente do DataSet
        private void DadosRemetente()
        {
            CTeDataSet.SetCampo("CNPJ_112", "08187168000160");
            CTeDataSet.SetCampo("IE_114", "9044016688");
            CTeDataSet.SetCampo("xNome_115", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            CTeDataSet.SetCampo("xFant_116", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            CTeDataSet.SetCampo("fone_117", "4430283749");
            CTeDataSet.SetCampo("xLgr_119", "RUA DUQUE DE CAXIAS  S/N");
            CTeDataSet.SetCampo("nro_120", "0");
            CTeDataSet.SetCampo("xBairro_122", "PARANA");
            CTeDataSet.SetCampo("cMun_123", "4115200");
            CTeDataSet.SetCampo("xMun_124", "PARANA");
            CTeDataSet.SetCampo("CEP_125", "01000000");
            CTeDataSet.SetCampo("UF_126", "PR");
            CTeDataSet.SetCampo("cPais_127", "1058");
            CTeDataSet.SetCampo("xPais_128", "BRASIL");
            CTeDataSet.SetCampo("email_604", "x@tecnospeed.com.br");
        }

        // Preenche os Dados do Destinatario do DataSet
        private void DadosDestinatario()
        {
            CTeDataSet.SetCampo("CPF_200", "22233344405");
            CTeDataSet.SetCampo("IE_201", "0500048665");
            CTeDataSet.SetCampo("xNome_202", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL");
            CTeDataSet.SetCampo("xLgr_206", "Praca Matriz");
            CTeDataSet.SetCampo("nro_207", "0");
            CTeDataSet.SetCampo("xBairro_209", "Centro");
            CTeDataSet.SetCampo("cMun_210", "4302105");
            CTeDataSet.SetCampo("xMun_211", "BENTO GONCALVES");
            CTeDataSet.SetCampo("CEP_212", "01000000");
            CTeDataSet.SetCampo("UF_213", "RS");
            CTeDataSet.SetCampo("cPais_214", "1058");
            CTeDataSet.SetCampo("xPais_215", "BRASIL");
            CTeDataSet.SetCampo("email_608", "teste.teste@teste.com.br");
        }

        // Preenche os Dados da Pretacao de Servico do DataSet
        private void PrestacaodeServico()
        {
            CTeDataSet.SetCampo("vTPrest_228", "200.00");
            CTeDataSet.SetCampo("vRec_229", "200.00");
        }

        // Preenche os Dados dos impostos do DataSet
        private void DadosImpostos()
        {
            CTeDataSet.SetCampo("CST_609", "00");
            CTeDataSet.SetCampo("vBC_610", "0.01");
            CTeDataSet.SetCampo("pICMS_611", "7.00");
            CTeDataSet.SetCampo("vICMS_612", "0.01");
        }

        // Preenche os Dados da Versao Modal do DataSet
        private void VersaoModal()
        {
            CTeDataSet.SetCampo("versaoModal_636", "3.00");
        }

        // Preenche os Dados da carga do DataSet
        private void DadosCarga()
        {
            CTeDataSet.SetCampo("vCarga_671", "1000.00");
            CTeDataSet.SetCampo("proPred_271", "LATA");
        }

        // Preenche os Dados do ICMSUFFim do DataSet
        private void DadosICMSUFFim()
        {
            CTeDataSet.SetCampo("vBCUFFim_676", "1.10");
            CTeDataSet.SetCampo("pFCPUFFim_682", "1.10");
            CTeDataSet.SetCampo("pICMSUFFim_677", "40");
            CTeDataSet.SetCampo("pICMSInter_678", "12.00");
            CTeDataSet.SetCampo("pICMSInterPart_679", "40.00");
            CTeDataSet.SetCampo("vICMSUFFim_680", "1.10");
            CTeDataSet.SetCampo("vICMSUFIni_681", "1.10");
            CTeDataSet.SetCampo("vFCPUFFim_683", "1.10");
        }

        // Preenche os Dados de Outras Informacoes do DataSet
        private void OutrasInformacoes()
        {
            CTeDataSet.IncluirParte("infOutros");
            CTeDataSet.SetCampo("tpDoc_159", "00");
            CTeDataSet.SetCampo("nDoc_161", "123456");
            CTeDataSet.SetCampo("dEmi_162", "2011-03-22");
            CTeDataSet.SetCampo("vDocFisc_163", "1.00");
            CTeDataSet.IncluirParte("infUnidCarga");
            CTeDataSet.SetCampo("tpUnidCarga_810", "1");
            CTeDataSet.SetCampo("idUnidCarga_811", "1");
            CTeDataSet.SalvarParte("infUnidCarga");
            CTeDataSet.SalvarParte("infOutros");
        }

        // Preenche os Dados do Quantidade de Carga do DataSet
        private void QuantidadesCarga()
        {
            CTeDataSet.IncluirParte("infQ");
            CTeDataSet.SetCampo("cUnid_274", "00");
            CTeDataSet.SetCampo("tpMed_275", "m3");
            CTeDataSet.SetCampo("qCarga_276", "1");
            CTeDataSet.SalvarParte("infQ");
        }

        // Preenche os Dados do Modal Rodoviario do DataSet
        private void ModalRodoviario()
        {
            CTeDataSet.IncluirParte("Rodo");
            CTeDataSet.SetCampo("RNTRC_305", "00000012");
            CTeDataSet.SalvarParte("Rodo");
        }

        // Preenche os Dados de Ordens de Coleta do DataSet
        private void OrdensColeta()
        {
            CTeDataSet.IncluirParte("Occ");
            CTeDataSet.SetCampo("serie_312", "1");
            CTeDataSet.SetCampo("nOcc_313", "1");
            CTeDataSet.SetCampo("dEmi_314", "2018-05-15");
            CTeDataSet.SetCampo("CNPJ_316", "08187168000160");
            CTeDataSet.SetCampo("cInt_317", "10");
            CTeDataSet.SetCampo("IE_318", "0500077436");
            CTeDataSet.SetCampo("UF_319", "PR");
            CTeDataSet.SetCampo("fone_320", "99999999");
            CTeDataSet.SalvarParte("Occ");
        }


        // Templaate de Aviso
        private void Aviso(string aMensagem)
        {
            MessageBox.Show(aMensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Atualiza o valor de retorno de um método na tela
        private void AtualizaRetornoNaTela(string Valor)
        {
            mmXML.Text = Valor;
            mmXMLFormatado.Text = CTe.ReformatXML(Valor);
        }

        //Atualiza o status na tela
        private void AtualizaStatusNaTela(string Valor)
        {
            lblStatus.Text = Valor;
        }
        
        // Tratamento de Exceptions
        private void TratarExcecao(Exception ex)
        {
            MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Grava valor no arquivo .ini
        public static bool WriteIniValue(string section, string key, string value, string filename)
        {
            return WritePrivateProfileString(section, key, value, filename);
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

        // Verifica se o componente está configurado
        private void CheckConfig(bool ClearOutput = true )
        {
            bool bConfig;
            if (ClearOutput) {
                mmXML.Clear();
                mmXMLFormatado.Clear();
            }

            bConfig = true;

            if (CTe.UF == null)
            {
                bConfig = false;
            }
            if (CTe.CNPJ== null)
            {
                bConfig = false;
            }
            if (CTe.NomeCertificado == null)
            {
                if(CTe.CaminhoCertificado == null || CTe.SenhaCertificado == null)
                {
                    bConfig = false;
                }
            }
            if (!bConfig)
            {
                throw new Exception("Favor configurar o componente antes de prosseguir (via ini ou via propriedades).");
            }
        }
    }
}
