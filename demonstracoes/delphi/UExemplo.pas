{
  Utilitário de exemplo para uso do componente TecnoSpeed CTe para integração
  com o sistema de Conhecimento de Transportes Eletrônico.

  @bold(Site oficial)
  @br
  http://www.tecnospeed.com.br

  @author(TecnoSpeed - Consultoria em TI (http://www.tecnospeed.com.br))
  @created(Abril/2010)
}

unit UExemplo;

interface

uses
  Windows,
  Messages,
  SysUtils,
  Variants,
  Classes,
  Graphics,
  XPMan,
  Controls,
  Forms,
  Dialogs,
  xmldom,
  StdCtrls,
  Buttons,
  ExtCtrls,
  ComCtrls,
  IniFiles,
  UCancelamentoCTe,
  spdCTeXMLUtils,
  spdCTeType,
  spdCTe,
  spdCTeException,
  spdCustomCTe,
  spdCTeUtils,
  spdCteDataSet,
  spdCCeCTeDataSetAdapter,
  {$I GovTLB.inc};

// ******************************************************************************************************
//
// Declarações
//
// ******************************************************************************************************

const
  INI_FILE = 'cteConfig.ini';
  INI_SECTION = 'CTE';

type
  TTipoConfiguracao = (tcViaIni, tcViaPropriedades);

  TFrmExemplo = class(TForm)
    pgCtrlMessages: TPageControl;
    tbSheetMemo: TTabSheet;
    lblHidden: TLabel;
    mOutput: TMemo;
    pnlMenu: TPanel;
    pnlConfig: TPanel;
    gbConfig: TGroupBox;
    edCNPJ: TLabeledEdit;
    edtProtocolo: TLabeledEdit;
    edUF: TLabeledEdit;
    mStatus: TMemo;
    OpnDlgTx2: TOpenDialog;
    edtRecibo: TLabeledEdit;
    edtChave: TLabeledEdit;
    opnDlgXML: TOpenDialog;
    svDlgExportar: TSaveDialog;
    tbsXMLFormatado: TTabSheet;
    mFmtOutput: TMemo;
    grpOptions: TGroupBox;
    lblInfo: TLabel;
    btnConfigIni: TBitBtn;
    btnConsultarReciboCTe: TBitBtn;
    btnCancelarCTe: TBitBtn;
    btnEnviarCTe: TBitBtn;
    btnConsultarCTe: TBitBtn;
    btnGerarXMLViaDataSet: TButton;
    btnGerarXMLViaTx2: TButton;
    btnVerificarStatus: TBitBtn;
    btnLoadConfig: TButton;
    btnAssinar: TButton;
    btnPreverDacte: TButton;
    btnConfiguraSH: TBitBtn;
    grpImpressao: TGroupBox;
    btnExportarPDF: TBitBtn;
    btnVisualizar: TBitBtn;
    cbListaCertificados: TComboBox;
    Label1: TLabel;
    edtSH: TLabeledEdit;
    // Inicialização do formulário
    procedure FormCreate(Sender: TObject);
    // Destruição do formulário
    procedure FormDestroy(Sender: TObject);
    // 1.1. Configurar o CNPJ da Software House
    procedure btnConfiguraSHClick(Sender: TObject);
    // 1.2. Configurar CTe via arquivo .ini
    procedure btnConfigIniClick(Sender: TObject);
    // 2. LoadConfig
    procedure btnLoadConfigClick(Sender: TObject);
    // 3.Verificar Status do Serviço
    procedure btnVerificarStatusClick(Sender: TObject);
    // 4.1.Gerar XML via TX2
    procedure btnGerarXMLViaTx2Click(Sender: TObject);
    // 4.2.Gerar XML via DataSet
    procedure btnGerarXMLViaDataSetClick(Sender: TObject);
    // 5.1 Assinar CTe
    procedure btnAssinarClick(Sender: TObject);
    // 5.2 Prever DACTE
    procedure btnPreverDacteClick(Sender: TObject);
    // 6.Enviar CTe
    procedure btnEnviarCTeClick(Sender: TObject);
    // 7. Consultar Recibo CTe
    procedure btnConsultarReciboCTeClick(Sender: TObject);
    // 8.Consultar CTe
    procedure btnConsultarCTeClick(Sender: TObject);
    // 9.Cancelar CTe
    procedure btnCancelarCTeClick(Sender: TObject);
    // 10.Visualizar
    procedure btnVisualizarClick(Sender: TObject);
    // 11.Exportar para PDF
    procedure btnExportarPDFClick(Sender: TObject);
    // Gera o XML do Tomador
    procedure CTeGenerateXMLTomadorServico(const aFileName, aXML: String);
    procedure grpOptionsClick(Sender: TObject);

  private
    CTe: TspdCTe;
    CTeDataSet: TspdCTeDataSet;
    fUtils: TspdGovUtils;
    // guarda o tipo da configuração, pode ser via arquivo ini ou propriedades configuradas no componente.
    fTipoConfiguracao: TTipoConfiguracao;
    // guarda o nome do arquivo do XML Tomador Serviço para utilizá-lo posteriormente na impressão
    FXMLTomadorServicoFileName: string;
    // método para configurar o componente via o arquivo cteConfig.ini
    procedure ConfiguraViaArquivo;

  public
    // Carrega as configurações do arquivo .ini
    procedure LoadConfig;
    // Atualização do status na tela
    procedure UpdateStatus(aMsg: string; Clear: Boolean = true; ReplaceLast: Boolean = False);
    // Atualização de mensagens de texto no objeto mOutput(Memo)
    procedure UpdateOutput(aMessage: string);
    // Escreve configurações em um arquivo .ini
    procedure WriteToIni(aName, aValue: string);
    // Valida a presença do arquivo .ini
    procedure CheckConfig(ClearOutput: Boolean = true);
    // Valida a versão do Manual Utilizada
    procedure CheckVersao;
    // Retorna o dígito verificador da chave
    function RetornaDV(aChave: string): string;
    //Retorna a chave do CT-e
    function GetValueChave(aXml : string) : string;
    // Retorna o XML Destinatário do CT-e
    function getXMLDestinatario : string;

  end;

var
  FrmExemplo: TFrmExemplo;

implementation

{$R *.dfm}

uses
  ShellApi, StrUtils;

// ******************************************************************************************************
//
// Funções utilitárias
//
// ******************************************************************************************************

// Inicialização do formulário
procedure TFrmExemplo.FormCreate(Sender: TObject);
begin
  CTe := TspdCTe.Create(nil);
  CTeDataSet := TspdCTeDataSet.Create(nil);
  fUtils := TspdGovUtils.Create(nil);

  FrmExemplo.Caption := 'Tecnospeed CTe - Versão: ' + CTe.Versao;
  pgCtrlMessages.ActivePageIndex := 0; // selecionar a página XML.
  FXMLTomadorServicoFileName := '';
  fTipoConfiguracao := tcViaIni;

  CTe.ListarCertificados(cbListaCertificados.Items);

end;

// Destruição do formulário
procedure TFrmExemplo.FormDestroy(Sender: TObject);
begin
  CTe.Free;
  FUtils.Free;
end;

//Retorna a chave do CT-e
function TFrmExemplo.GetValueChave(aXml: string): string;
Var
  aPINI, aPFIN: integer;
begin
  aPINI := PosStr('<infCte Id="CTe'  , aXml)+ 15;
  Result := Copy(aXml, aPINI, 44);
end;

// Retorna o XML Destinatário do CT-e
function TFrmExemplo.getXMLDestinatario: string;
var
aXMLDestinatario : string;
begin
      aXMLDestinatario := CTe.DiretorioXmlTomadorServico + '\' + edtChave.Text + '-cte.xml';
      if FileExists(aXMLDestinatario) then
      begin
        Result := fUtils.LoadFromFile(aXMLDestinatario);
      end
      else  if mOutput.Text <> '' then
      begin
        Result := mOutput.Text;
      end
      else
      begin
         raise Exception.Create('Informe a chave de um CT-e Autorizado ou preencha o memo com o valor do XML Destinatário');
      end;
end;

procedure TFrmExemplo.grpOptionsClick(Sender: TObject);
begin

end;

// Atualização do status na tela
procedure TFrmExemplo.UpdateStatus(aMsg: string; Clear: Boolean = true; ReplaceLast: Boolean = False);
begin
  if Clear then
    mStatus.Clear;
  if ReplaceLast then
    mStatus.Lines[mStatus.Lines.Count - 1] := mStatus.Lines[mStatus.Lines.Count - 1] + aMsg
  else
    mStatus.Lines.Add(aMsg);
  mStatus.Refresh;
end;

// Atualização de mensagens de texto no objeto mOutput(Memo)
procedure TFrmExemplo.UpdateOutput(aMessage: string);
begin
  mOutput.Lines.Text := aMessage;
  mFmtOutput.Lines.Text := ReformatXml(aMessage);
end;

// Carrega as configurações do arquivo .ini
procedure TFrmExemplo.LoadConfig;
var
  aMessage: string;
begin
  UpdateStatus('', true);
  try
    CTe.LoadConfig;
  except
    on e: Exception do
      raise EspdCTeException.Create(e.Message);
  end;

  aMessage := '';
  edUF.Text := CTe.UF;
  edCNPJ.Text := CTe.CNPJ;
  cbListaCertificados.Text := CTe.NomeCertificado.Text;

  UpdateStatus('Configurações carregadas via arquivo ini.');
end;

// Escreve configurações em um arquivo .ini
procedure TFrmExemplo.WriteToIni(aName, aValue: string);
var
  IniFile: TIniFile;
  aCurrentDir: string;
begin
  aCurrentDir := ExtractFilePath(ParamStr(0));
  SetCurrentDir(aCurrentDir);
  IniFile := TIniFile.Create(aCurrentDir + INI_FILE);
  try
    IniFile.WriteString(INI_SECTION, aName, aValue);
  finally
    IniFile.Free;
  end;
end;

// Valida a presença do arquivo .ini
procedure TFrmExemplo.CheckConfig(ClearOutput: Boolean = true);
var
  bConfig : Boolean;
begin
  if ClearOutput then
  begin
    mOutput.Clear;
    mFmtOutput.Clear;
  end;

  Application.ProcessMessages;

  bConfig := True;

  if trim(CTe.UF) = '' then
    bConfig := False;
  if trim(CTe.CNPJ) = '' then
    bConfig := False;
  if trim(CTe.NomeCertificado.Text) = '' then
  begin
    if (Trim(CTe.CaminhoCertificado) = '')  or  (Trim(Cte.SenhaCertificado) = '') then
      bConfig := False;
  end;
  if (fTipoConfiguracao = tcViaIni) and (not bConfig) then
    raise Exception.Create('Favor configurar o componente antes de prosseguir (via ini ou via propriedades).');
end;

// Retorna o dígito verificador da chave
function TFrmExemplo.RetornaDV(aChave: string): string;
begin
  Result := aChave[Length(aChave)];
end;

procedure TFrmExemplo.CTeGenerateXMLTomadorServico(const aFileName, aXML: String);
begin
  FXMLTomadorServicoFileName := aFileName;
end;

procedure TFrmExemplo.ConfiguraViaArquivo;
var
  _ExecuteFile: string;
  _NomeCertificado: string;
begin
  try
    if cbListaCertificados.Text <> '' then
    begin
      _NomeCertificado := Trim(cbListaCertificados.Text);
      WriteToIni('NomeCertificado', _NomeCertificado);
    end;
    _ExecuteFile := ExtractFilePath(ParamStr(0)) + 'cteConfig.ini';
    ShellExecute(Application.Handle, nil, Pchar(_ExecuteFile), nil, nil, SW_SHOWNORMAL);
  except
    raise EspdCTeException.Create('Erro ao tentar abrir o arquivo ' + INI_FILE +
      '. Verifique se o arquivo está na mesma pasta que o executável.');
  end;
end;

procedure TFrmExemplo.CheckVersao;
begin
  if (CTe.VersaoManual <> vm200) and (CTe.VersaoManual <> vm200a) and (CTe.VersaoManual <> vm300) then
    raise Exception.Create('Os eventos Multimodal, CCe e Cancelamento só podem '+
      'ser realizados na versão 2.00 ou maior');
end;

// ******************************************************************************************************
//
// Aqui começam as funções de exemplo do componente spdCTe
//
// ******************************************************************************************************


// 1.1 Configurar o CNPJ da Software House
procedure TFrmExemplo.btnConfiguraSHClick(Sender: TObject);
begin
  CTe.ConfigurarSoftwareHouse(edtSH.Text, '');
end;

// 1.2 Configurar Arquivo .ini
procedure TFrmExemplo.btnConfigIniClick(Sender: TObject);
begin
  (Sender as TWinControl).Enabled := False;
  try
    ConfiguraViaArquivo;
 finally
    (Sender as TWinControl).Enabled := True;
  end;
end;

// 2.Executando LoadConfig
procedure TFrmExemplo.btnLoadConfigClick(Sender: TObject);
begin
  LoadConfig;
end;

// 3.Verificar Status do Serviço
procedure TFrmExemplo.btnVerificarStatusClick(Sender: TObject);
var
  _returnValue: WideString;
begin
  CheckConfig(False);
  try
    (Sender as TWinControl).Enabled := False;
    try
      UpdateStatus('Verificando status...');
      _returnValue := CTe.StatusDoServico;
      UpdateOutput(_returnValue);
      UpdateStatus('Status do Serviço OK.');
    finally
      (Sender as TWinControl).Enabled := true;
    end;
  except
    UpdateStatus(' falha', False, true);
    raise ;
  end;
end;

// 4.1.Gerar XML via TX2
procedure TFrmExemplo.btnGerarXMLViaTx2Click(Sender: TObject);
var
  aChave: string;
  aXML: string;
begin
  CheckConfig(False);
  mOutput.Clear;
  mFmtOutput.Clear;

  (Sender as TWinControl).Enabled := False;
  try
    OpnDlgTx2.InitialDir := ExtractFileDir(Application.ExeName);
    OpnDlgTx2.FileName := 'cte.tx2';
    if OpnDlgTx2.Execute then
    begin
      aXML := CTe.GerarXMLporTX2(OpnDlgTx2.FileName);
      UpdateOutput(aXML);
      UpdateStatus('XML via Tx2 gerado com sucesso.');
      aChave := GetValueChave(mOutput.Text);
      edtChave.Text := aChave;
    end;
  finally
    (Sender as TWinControl).Enabled := True;
  end;
end;

// 4.2.Gerar XML via DataSet
procedure TFrmExemplo.btnGerarXMLViaDataSetClick(Sender: TObject);

    // Configura CTeDataSet
procedure ConfiguraCteDataSet;
var
    AChave: string;
    aData : string;
    aCodigoUF: string;
    aDV: string;
    aModelo: string;
    aSerie: string;
    aNumero: string;
    aCodigo: string;
    aTpEmiss: string;
    aVersaoManual: string;
begin
    // Codigo UF
    aCodigoUF := IntToStr(CTe.ObterCodigoUF(CTe.UF));

    // Datas
    aData := FormatDateTime('yyyy-mm-dd', Now);
    aCodigo := '06021956';

    // Modelo
    aModelo := '57';

    // Serie
    aSerie := '1';

    // Tipo de Emissão
    aTpEmiss := '1';  // Forma de emissão Normal

    // Numero
    aNumero := InputBox('Número do CT-e', 'Informe o nº do CT-e','0');

    // Calcula a Chave
    AChave := CTe.CalculaChave(aCodigoUF, aData, CTe.CNPJ, aModelo, aSerie, aNumero, aCodigo, aTpEmiss);
    edtChave.Text := AChave;

    // DV
    aDV := RetornaDV(AChave);
    aVersaoManual := '3.00';

    // Configura a versão de manual do CT-e
    CTeDataSet.Versao := aVersaoManual;

    //Alimentar as informações do lote
    CTeDataSet.ConfigSection := 'XMLENVIO';

    // Configura o arquivo de mapeamento para a criação dos datasets
    CTeDataSet.MappingFileName := fUtils.ExpandPath(CTe.DiretorioEsquemas + aVersaoManual)+ CTe.MappingFileName;

    // Cria a lista de datasets
    CTeDataSet.CreateDataSets;

    // Configura o lote dde envio de CT-e
    CTeDataSet.IdLote := '1';
end;

procedure DadosdoCTe(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('versao_2').AsString := '3.00';
    CTeDataSet.Campo('cUF_5').AsString := '43';
    CTeDataSet.Campo('cCT_6').AsString := '00000000';
    CTeDataSet.Campo('CFOP_7').AsString := '5357';
    CTeDataSet.Campo('natOp_8').AsString := 'TRANSPORTE RODOVIARIO DE CARGAS';
    CTeDataSet.Campo('mod_10').AsString := '57';
    CTeDataSet.Campo('serie_11').AsString := '876';
    CTeDataSet.Campo('nCT_12').AsString := '10';
    CTeDataSet.Campo('dhEmi_13').AsString := '2018-10-15T15:26:00-03:00';
    CTeDataSet.Campo('tpImp_14').AsString := '1';
    CTeDataSet.Campo('tpEmis_15').AsString := '1';
    CTeDataSet.Campo('tpAmb_17').AsString := '2';
    CTeDataSet.Campo('tpCTe_18').AsString := '0';
    CTeDataSet.Campo('procEmi_19').AsString := '0';
    CTeDataSet.Campo('verProc_20').AsString := '1';
    CTeDataSet.Campo('cMunEnv_672').AsString := '4302105';
    CTeDataSet.Campo('xMunEnv_673').AsString := 'BENTO GONCALVES';
    CTeDataSet.Campo('UFEnv_674').AsString := 'RS';
    CTeDataSet.Campo('modal_25').AsString := '01';
    CTeDataSet.Campo('tpServ_26').AsString := '0';
    CTeDataSet.Campo('cMunIni_27').AsString := '4302105';
    CTeDataSet.Campo('xMunIni_28').AsString := 'BENTO GONCALVES';
    CTeDataSet.Campo('UFIni_29').AsString := 'RS';
    CTeDataSet.Campo('cMunFim_30').AsString := '4302105';
    CTeDataSet.Campo('xMunFim_31').AsString := 'BENTO GONCALVES';
    CTeDataSet.Campo('UFFim_32').AsString := 'RS';
    CTeDataSet.Campo('retira_33').AsString := '0';
    CTeDataSet.Campo('xDetRetira_34').AsString := 'detalhes teste';
    CTeDataSet.Campo('indIEToma_1406').AsString := '1';
  end;

    procedure DadosTomador(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('toma_36').AsString := '3';
  end;


  procedure DadosEmitente(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('CNPJ_95').AsString := '99999999999999';
    CTeDataSet.Campo('IE_96').AsString := '9999999999';
    CTeDataSet.Campo('xNome_97').AsString := 'Nome teste';
    CTeDataSet.Campo('xFant_98').AsString := 'Nome teste';
    CTeDataSet.Campo('xLgr_100').AsString := 'Rua teste';
    CTeDataSet.Campo('nro_101').AsString := '300';
    CTeDataSet.Campo('xCpl_102').AsString := '10 andar';
    CTeDataSet.Campo('xBairro_103').AsString := 'BAIRRO TESTE';
    CTeDataSet.Campo('cMun_104').AsString := '4302105';
    CTeDataSet.Campo('xMun_105').AsString := 'BENTO GONCALVES';
    CTeDataSet.Campo('CEP_106').AsString := '89233198';
    CTeDataSet.Campo('UF_107').AsString := 'RS';
    CTeDataSet.Campo('fone_110').AsString := '1132433400';
  end;


  procedure DadosRemetente(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('CNPJ_112').AsString := '08187168000160';
    CTeDataSet.Campo('IE_114').AsString := '9044016688';
    CTeDataSet.Campo('xNome_115').AsString := 'CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL';
    CTeDataSet.Campo('xFant_116').AsString := 'CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL';
    CTeDataSet.Campo('fone_117').AsString := '4430283749';
    CTeDataSet.Campo('xLgr_119').AsString := 'RUA DUQUE DE CAXIAS  S/N';
    CTeDataSet.Campo('nro_120').AsString := '0';
    CTeDataSet.Campo('xBairro_122').AsString := 'PARANA';
    CTeDataSet.Campo('cMun_123').AsString := '4115200';
    CTeDataSet.Campo('xMun_124').AsString := 'PARANA';
    CTeDataSet.Campo('CEP_125').AsString := '01000000';
    CTeDataSet.Campo('UF_126').AsString := 'PR';
    CTeDataSet.Campo('cPais_127').AsString := '1058';
    CTeDataSet.Campo('xPais_128').AsString := 'BRASIL';
    CTeDataSet.Campo('email_604').AsString := 'x@tecnospeed.com.br';
  end;


  procedure DadosDestinatario(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('CPF_200').AsString := '22233344405';
    CTeDataSet.Campo('IE_201').AsString := '0500048665';
    CTeDataSet.Campo('xNome_202').AsString := 'CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL';
    CTeDataSet.Campo('xLgr_206').AsString := 'Praca Matriz';
    CTeDataSet.Campo('nro_207').AsString := '0';
    CTeDataSet.Campo('xBairro_209').AsString := 'Centro';
    CTeDataSet.Campo('cMun_210').AsString := '4302105';
    CTeDataSet.Campo('xMun_211').AsString := 'BENTO GONCALVES';
    CTeDataSet.Campo('CEP_212').AsString := '01000000';
    CTeDataSet.Campo('UF_213').AsString := 'RS';
    CTeDataSet.Campo('cPais_214').AsString := '1058';
    CTeDataSet.Campo('xPais_215').AsString := 'BRASIL';
    CTeDataSet.Campo('email_608').AsString := 'teste.teste@teste.com.br';
  end;



  procedure PrestacaodeServico(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('vTPrest_228').AsString := '200.00';
    CTeDataSet.Campo('vRec_229').AsString := '200.00';
  end;


  procedure DadosImpostos(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('CST_609').AsString := '00';
    CTeDataSet.Campo('vBC_610').AsString := '0.01';
    CTeDataSet.Campo('pICMS_611').AsString := '7.00';
    CTeDataSet.Campo('vICMS_612').AsString := '0.01';
  end;


  procedure VersaoModal(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('versaoModal_636').AsString := '3.00';
  end;


  procedure DadosCarga(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('vCarga_671').AsString := '1000.00';
    CTeDataSet.Campo('proPred_271').AsString := 'LATA';
  end;


  procedure DadosICMSUFFim(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.Campo('vBCUFFim_676').AsString := '1.10';
    CTeDataSet.Campo('pFCPUFFim_682').AsString := '1.10';
    CTeDataSet.Campo('pICMSUFFim_677').AsString := '40';
    CTeDataSet.Campo('pICMSInter_678').AsString := '12.00';
    CTeDataSet.Campo('pICMSInterPart_679').AsString := '40.00';
    CTeDataSet.Campo('vICMSUFFim_680').AsString := '1.10';
    CTeDataSet.Campo('vICMSUFIni_681').AsString := '1.10';
    CTeDataSet.Campo('vFCPUFFim_683').AsString := '1.10';
  end;

  procedure OutrasInformacoes(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.IncluirParte('infOutros');
    CTeDataSet.Campo('tpDoc_159').AsString := '00';
    CTeDataSet.Campo('nDoc_161').AsString := '123456';
    CTeDataSet.Campo('dEmi_162').AsString := '2011-03-22';
    CTeDataSet.Campo('vDocFisc_163').AsString := '1.00';
    CTeDataSet.IncluirParte('infUnidCarga');
    CTeDataSet.Campo('tpUnidCarga_810').AsString := '1';
    CTeDataSet.Campo('idUnidCarga_811').AsString := '1';
    CTeDataSet.SalvarParte('infUnidCarga');
    CTeDataSet.SalvarParte('infOutros');
  end;

procedure QuantidadesCarga(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.IncluirParte('infQ');
    CTeDataSet.Campo('cUnid_274').AsString := '00';
    CTeDataSet.Campo('tpMed_275').AsString := 'm3';
    CTeDataSet.Campo('qCarga_276').AsString := '1';
    CTeDataSet.SalvarParte('infQ');
  end;

  procedure ModalRodoviario(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.IncluirParte('Rodo');
    CTeDataSet.Campo('RNTRC_305').AsString := '00000012';
    CTeDataSet.SalvarParte('Rodo');
  end;

  procedure OrdensColeta(aDs : TspdCTeDataSet);
  begin
    CTeDataSet.IncluirParte('Occ');
    CTeDataSet.Campo('serie_312').AsString := '1';
    CTeDataSet.Campo('nOcc_313').AsString := '1';
    CTeDataSet.Campo('dEmi_314').AsString := '2018-05-15';
    CTeDataSet.Campo('CNPJ_316').AsString := '08187168000160';
    CTeDataSet.Campo('cInt_317').AsString := '10';
    CTeDataSet.Campo('IE_318').AsString := '0500077436';
    CTeDataSet.Campo('UF_319').AsString := 'PR';
    CTeDataSet.Campo('fone_320').AsString := '99999999';
    CTeDataSet.SalvarParte('Occ');
  end;

var
  _XML: string;
begin
  (Sender as TWinControl).Enabled := False;

  try
    CheckConfig(False);
      mOutput.Clear;
      mFmtOutput.Clear;

    configuraCteDataSet;

    CTeDataSet.Incluir;
      DadosdoCTe(CTeDataSet);
      DadosTomador(CTeDataSet);
      DadosdoCTe(CTeDataSet);
      DadosEmitente(CTeDataSet);
      DadosRemetente(CTeDataSet);
      DadosDestinatario(CTeDataSet);
      PrestacaodeServico(CTeDataSet);
      DadosImpostos(CTeDataSet);
      VersaoModal(CTeDataSet);
      DadosCarga(CTeDataSet);
      DadosICMSUFFim(CTeDataSet);
      OutrasInformacoes(CTeDataSet);
      QuantidadesCarga(CTeDataSet);
      ModalRodoviario(CTeDataSet);
      OrdensColeta(CTeDataSet);
      CTeDataSet.Salvar;
      _XML := CTeDataSet.LoteCTe;

      UpdateOutput(_XML);
      UpdateStatus('XML via DataSets gerado com sucesso.');

  finally
    (Sender as TWinControl).Enabled := True;
  end;
end;

// 5.1. Assinar CTe
procedure TFrmExemplo.btnAssinarClick(Sender: TObject);
var
  _returnValue: string;
begin
  _returnValue := mOutput.Text;
  _returnValue := CTe.AssinarCT(_returnValue);
  UpdateOutput(_returnValue);
  UpdateStatus('CTe Assinado.');
end;

// 5.2. Preve Dacte
procedure TFrmExemplo.btnPreverDacteClick(Sender: TObject);
var
  _xml : WideString;
begin
  if (GetValueTag('enviCTe', mOutput.Lines.Text) <> '') or
    (GetValueTag('infEvento', mOutput.Lines.Text) <> '') then
  begin
    CheckConfig(false);
    CTe.PreverDACTE( mOutput.Lines.Text );
  end
  else
  begin
    if MessageDlg('Deseja informar um XML de Tomador?',
      mtConfirmation, [mbYes,mbCancel], 0) = mrYes then
    begin
      opnDlgXML.InitialDir := CTe.DiretorioXmlTomadorServico;
      if opnDlgXML.Execute then
      begin
        _xml := fUtils.LoadFromFile(opnDlgXML.FileName);
        CTe.PreverDACTE( _xml );
      end;
    end;
  end;
end;

// 6.Enviar CTe
procedure TFrmExemplo.btnEnviarCTeClick(Sender: TObject);
var
  _returnValue: string;
  envio : string;
  retorno : string;
begin
  CheckConfig(False);
  FXMLTomadorServicoFileName := '';
  try
    (Sender as TWinControl).Enabled := False;
    try
        UpdateStatus('Enviando CTe...');
        _returnValue := mOutput.Text;
        _returnValue := CTe.EnviarCT('1', _returnValue);
        UpdateOutput(_returnValue);
        edtRecibo.Text := CTe.ExtrairRecibo(_returnValue);
        UpdateStatus('Envio Ok.');
    finally
      (Sender as TWinControl).Enabled := true;
    end;
  except
    UpdateStatus(' falha', False, true);
    raise ;
  end;
  envio := cte.UltimoLogEnvio;
  retorno := CTe.UltimoLogRetorno;
end;

// 7. Consultar Recibo CTe
procedure TFrmExemplo.btnConsultarReciboCTeClick(Sender: TObject);
var
  _returnValue: string;
begin
  CheckConfig;
  try
    (Sender as TWinControl).Enabled := False;
    try
      if edtRecibo.Text <> '' then
      begin
        UpdateStatus('Consultando recibo...');
        _returnValue := CTe.ConsultarRecibo(edtRecibo.Text);
        UpdateOutput(_returnValue);
        edtProtocolo.Text := CTe.ExtrairProtocolo(_returnValue);
        UpdateStatus('Consulta ok...');
      end
      else
      begin
        ShowMessage('Favor informar um recibo antes de prosseguir');
        edtRecibo.SetFocus;
      end;
    finally
      (Sender as TWinControl).Enabled := true;
    end;
  except
    UpdateStatus(' falha', False, true);
    raise ;
  end;
end;

// 8.Consultar CTe
procedure TFrmExemplo.btnConsultarCTeClick(Sender: TObject);
var
  _returnValue: string;
begin
  CheckConfig;
  try
    (Sender as TWinControl).Enabled := False;
    try
      if edtChave.Text <> '' then
      begin
        UpdateStatus('Consultando...');
        _returnValue := CTe.ConsultarCT(edtChave.Text);
        edtProtocolo.Text := CTe.ExtrairProtocolo(_returnValue);
        UpdateOutput(_returnValue);
        UpdateStatus('Consulta ok...');
      end
      else
      begin
        ShowMessage('Favor informar uma chave antes de prosseguir');
        edtChave.SetFocus;
      end;
    finally
      (Sender as TWinControl).Enabled := true;
    end;
  except
    UpdateStatus(' falha', False, true);
    raise ;
  end;
end;

// 9.Cancelar CTe
procedure TFrmExemplo.btnCancelarCTeClick(Sender: TObject);
var
  _returnValue, _Chave, _Protocolo, _Justificativa, _DataHora: string;
  _frmCancelamentoCTe: TfrmCancelamentoCTe;
begin
    CheckVersao;

  CheckConfig;
  _frmCancelamentoCTe := TfrmCancelamentoCTe.Create(Self);
  _frmCancelamentoCTe.edtChave.Text := edtChave.Text;
  _frmCancelamentoCTe.edtProtocolo.Text := edtProtocolo.Text;
  _frmCancelamentoCTe.ShowModal;
  try
    if _frmCancelamentoCTe.ModalResult = mrOk then
    begin
      (Sender as TWinControl).Enabled := False;
      UpdateStatus('Cancelando CTe...');
      try
        try
          _Chave := _frmCancelamentoCTe.edtChave.Text;
          _Protocolo := _frmCancelamentoCTe.edtProtocolo.Text;
          _Justificativa := _frmCancelamentoCTe.mJustificativa.Text;

          begin
            _DataHora := InputBox('Data e Hora do Evento', 'Digite a Data e Hora do Evento: ', FormatDateTime('YYYY-MM-DD"T"HH:MM:SS',Now) + '-03:00');
            _returnValue := CTe.CancelarCTEvento(_Chave, _Protocolo, _Justificativa, _DataHora);
          end;

          UpdateOutput(_returnValue);

          UpdateStatus('Cancelamento ok.');
        except
          UpdateStatus(' falha', False, true);
          raise ;
        end;
      finally
        (Sender as TWinControl).Enabled := true;
      end;
    end
    else

  finally
    _frmCancelamentoCTe.Free;
  end;
end;

// 10.Visualizar
procedure TFrmExemplo.btnVisualizarClick(Sender: TObject);
var
  _XML, aXMLDestinatario: WideString;
begin
  try
    CheckConfig(false);
    _XML := getXMLDestinatario;
      CTe.VisualizarDACTE(_XML);
  except
    on e: Exception do
      raise EspdCTeException.Create(e.Message);
  end;
end;

// 11.Exportar para PDF
procedure TFrmExemplo.btnExportarPDFClick(Sender: TObject);
var
  _XML: String;
begin
    CheckConfig(false);
      if edtChave.Text <> '' then
        svDlgExportar.FileName := edtChave.Text + '.pdf';
      if svDlgExportar.Execute then
      begin
        _XML := getXMLDestinatario;
        CTe.ExportarDACTEParaPDF(_XML, '', svDlgExportar.FileName);
        UpdateStatus('Geração de PDF realizada com sucesso em!');
      end;
end;

initialization

Application.Icon.LoadFromFile('cte.ico');

finalization

end.
