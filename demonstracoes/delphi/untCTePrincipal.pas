unit untCTePrincipal;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, IniFiles, spdCTeXMLUtils, spdCTeType, spdCTe,
  spdCTeException, spdCustomCTe, spdCTeUtils, spdCteDataSet, spdCCeCTeDataSetAdapter,
  StdCtrls, ExtCtrls, ComCtrls, DateUtils, Buttons, ShellApi;

type
  TfrmCTePrincipal = class(TForm)
    OpenDialog: TOpenDialog;
    pcSuperior: TPageControl;
    tsAutorizacao: TTabSheet;
    tsImpressao: TTabSheet;
    SpeedButton1: TSpeedButton;
    GroupBox9: TGroupBox;
    GroupBox15: TGroupBox;
    Label4: TLabel;
    Label6: TLabel;
    EdtCNPJ: TEdit;
    edtToken: TEdit;
    cbCertificado: TComboBox;
    lbl1: TLabel;
    edtCNPJEmitente: TEdit;
    Label3: TLabel;
    edtUF: TEdit;
    Label5: TLabel;
    edtInscMunicipal: TEdit;
    Label12: TLabel;
    edtChave: TEdit;
    Label14: TLabel;
    edtRecibo: TEdit;
    Label15: TLabel;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    edtModelo: TEdit;
    edtSerie: TEdit;
    edtNumeroCTe: TEdit;
    edtCodigo: TEdit;
    sbPreencherComp: TSpeedButton;
    sbGerarTX2: TSpeedButton;
    sbEnviarCCe: TSpeedButton;
    sbAssinar: TSpeedButton;
    sbEnviar: TSpeedButton;
    pcProcessos: TPageControl;
    tsXMLformatado: TTabSheet;
    tsXML: TTabSheet;
    GroupBox6: TGroupBox;
    mmXML: TMemo;
    tsXMLRetorno: TTabSheet;
    GroupBox8: TGroupBox;
    mmXMLRetorno: TMemo;
    Label11: TLabel;
    lblProducao: TLabel;
    edtProtocolo: TEdit;
    Label13: TLabel;
    sbConsultaLote: TSpeedButton;
    sbConsultarRecibo: TSpeedButton;
    sbConfigINI: TSpeedButton;
    mmXMLEnvio: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure sbPreencherCompClick(Sender: TObject);
    procedure sbGerarTX2Click(Sender: TObject);
    procedure sbAssinarClick(Sender: TObject);
    procedure sbEnviarClick(Sender: TObject);
    procedure Label6Click(Sender: TObject);
    procedure sbConsultaLoteClick(Sender: TObject);
    procedure sbConsultarReciboClick(Sender: TObject);
    procedure SpeedButton1Click(Sender: TObject);
    procedure SomenteNumero(Sender: TObject; var Key: Char);
    procedure sbEnviarCCeClick(Sender: TObject);
    procedure sbConfigINIClick(Sender: TObject);
    procedure mmXMLEnvioKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure cbCertificadoChange(Sender: TObject);
  private
    procedure CarregarDadosCTe;
    procedure Limpar;
    procedure PreencherTX2CCe;
    function GetChave: string;
    function DigitoMod11(pNumero: string): Integer;
    function GetVersao(const AFileName: String): String;
    { Private declarations }
  public
    { Public declarations }
    vCurrentDir : string;
    vCTe        : TspdCTe;
    vCTeDataSet : TspdCTeDataSet;
    vCTeUtils   : TspdCTeUtils;
    vArquivoIni : TIniFile;
  end;

var
  frmCTePrincipal: TfrmCTePrincipal;

implementation

uses spdXMLUtils, Math;

{$R *.dfm}

{
** ERROS **
===============================================================================
==
=>
===============================================================================
}

function TfrmCTePrincipal.GetVersao(const AFileName: String): String;
var
  FileName: string;
  InfoSize, Wnd: DWORD;
  VerBuf: Pointer;
  FI: PVSFixedFileInfo;
  VerSize: DWORD;
begin
  Result := EmptyStr;
  FileName := AFileName;
  UniqueString(FileName);
  InfoSize := GetFileVersionInfoSize(PChar(FileName), Wnd);
  if InfoSize <> 0 then
  begin
    GetMem(VerBuf, InfoSize);
    try
      if GetFileVersionInfo(PChar(FileName), Wnd, InfoSize, VerBuf) then
        if VerQueryValue(VerBuf, '\', Pointer(FI), VerSize) then
          Result:= Concat(IntToStr(FI.dwFileVersionMS shr 16), '.',
                          IntToStr(FI.dwFileVersionMS and $FFFF), '.',
                          IntToStr(FI.dwFileVersionLS shr 16), '.',
                          IntToStr(FI.dwFileVersionLS and $FFFF));
    finally
      FreeMem(VerBuf);
    end;
  end;
end;

Function TfrmCTePrincipal.DigitoMod11(pNumero: string): Integer;
var
  vCadeia   : String;
  vX        : Integer;
  vY        : Integer;
  vValor    : Integer;
  vDigito   : Integer;
  vPosicao  : String;
  vPosicaoI : Integer;
Begin
   vValor := 0;
   vCadeia := pNumero;

   For vY := 2 DownTo 1 do
   Begin
      For vX := 9 DownTo 1 do
      Begin
         vPosicao    := Copy( vCadeia, ( 17 - ( vX + ( 9 * ( vY - 1 ) ) ) ), 1 );
         vPosicaoI    := StrToInt( vPosicao );
         vValor      := vValor + ( vPosicaoI * ( vX + 1 ) )
      End;
   End;
 
   vDigito := ( ( vValor * 10 ) mod 11 );

   If vDigito >= 10 Then
      vDigito := 0;
 
   Result := vDigito;
 
End;

procedure TfrmCTePrincipal.CarregarDadosCTe;
begin
  edtCNPJ.Text             := vArquivoIni.ReadString('CTE','CNPJ','');
  edtTOKEN.Text            := vArquivoIni.ReadString('CTE','TOKENSH','');
  edtCNPJEmitente.Text     := vArquivoIni.ReadString('CTE','CNPJ','');

  vCTe.LoadConfig();
  vCTe.ListarCertificados(cbCertificado.Items);                                                                      -0
{
  Quando o ListarCertificados não trouxer nada, verificar se o certificado foi instalado por maquina ou por usuário
}
  cbCertificado.ItemIndex  := 0;
  EdtUF.Text := vCTe.UF;

end;

procedure TfrmCTePrincipal.Limpar;
begin
  edtChave.Text  := '';
  edtRecibo.Text := '';

  pcProcessos.ActivePage := tsXMLformatado;
end;

procedure TfrmCTePrincipal.FormCreate(Sender: TObject);
begin
  vCurrentDir := ExtractFilePath(ParamStr(0));
  Limpar;
  vCTe        := TspdCTe.Create(nil);
  vCTeDataSet := TspdCTeDataSet.Create(nil);
  vCTeUtils   := TspdCTeUtils.Create;
  
  vArquivoIni := TIniFile.Create(vCurrentDir + 'cteConfig.ini');

  frmCTePrincipal.Caption := 'Demonstração CT-e v.' + vCTe.Versao + ' - TecnoSpeed';
end;

procedure TfrmCTePrincipal.FormShow(Sender: TObject);
begin
  CarregarDadosCTe;
end;

procedure TfrmCTePrincipal.sbPreencherCompClick(Sender: TObject);
begin
  try
    vCTe.ConfigurarSoftwareHouse(edtCNPJ.Text, edtTOKEN.Text);
    vCTe.LoadConfig();

    if edtCNPJEmitente.Text <> '00000000000000' then
       vCTe.CNPJ                       := edtCNPJEmitente.Text;    //CNPJ completo do Emitente;

    vCTe.NomeCertificado.Text       := cbCertificado.Text;
    vCTe.MappingFileName    := 'MappingCTe.txt';
    vCTe.VersaoManual       := vm300a;

    lblProducao.Visible := vCTe.Ambiente = akProducao;
    edtChave.Text := getChave;
{ Necessário apenas para certificado A1
        vCTe.SenhaCertificado := '';
}
{ Senha do certificado A3, caso queira autenticação automática
        vCTe.Pincode := '';
}
{ Configurações necessárias apenas para proxy
        vCTe.Proxy := '';
        vCTe.Usuario := '';
        vCTe.Senha := '';
}
    EdtUF.Text := vCTe.UF;
    ShowMessage('Configurado com sucesso.');

  except
    on e : exception do
     showmessage('Ocorreu o seguinte erro: '+ e.message);
  end;
end;

function TfrmCTePrincipal.GetChave: string;
var
  vChave: string;
  vData : string;
  vCodigoUF: string;
  vTpEmiss: string;
begin
    vCodigoUF := IntToStr(vCTe.ObterCodigoUF(vCTe.UF));
    vData     := FormatDateTime('yyyy-mm-dd', Now);
    vTpEmiss  := '1';  // Tipo de emissão: "1-Normal”, “5-Contingência FS-DA”, “7-Autorização pela SVC-RS”, “8-Autorização pela SVC-SP”;

    {
    O CT-e, modelo 57, poderá ser utilizado pelos contribuintes do ICMS em substituição aos seguintes documentos:
      I - Conhecimento de Transporte Rodoviário de Cargas, modelo 8;
      II - Conhecimento de Transporte Aquaviário de Cargas, modelo 9;
      III - Conhecimento Aéreo, modelo 10;
      IV - Conhecimento de Transporte Ferroviário de Cargas, modelo 11;
      V - Nota Fiscal de Serviço de Transporte Ferroviário de Cargas, modelo 27;
      VI - Nota Fiscal de Serviço de Transporte, modelo 7, quando utilizada em transporte de cargas.
    }
    if (edtModelo.text = '')
    or (edtSerie.text = '')
    or (edtNumeroCTe.text = '')
    or (edtCodigo.text = '') then
    begin
      ShowMessage('Favor preencher todos os campos para geração da chave');
      Exit;
    end;

    vChave    := vCTe.CalculaChave(vCodigoUF, vData, vCTe.CNPJ, edtModelo.text, edtSerie.text, edtNumeroCTe.text, edtCodigo.text, vTpEmiss);

    sleep(2000);
    Result := vChave;
end;

procedure TfrmCTePrincipal.sbGerarTX2Click(Sender: TObject);
var
  vTX2: string;
begin
  try
    mmXMLEnvio.Clear;
    OpenDialog.InitialDir := ExtractFilePath(ParamStr(0));
    OpenDialog.Execute;

    if OpenDialog.FileName <> '' then
    begin
      vTX2 := OpenDialog.FileName;
      mmXMLEnvio.Text := vCTe.GerarXMLporTx2(vTX2);
    end;


    pcProcessos.ActivePage := tsXMLformatado;
  finally
//    vTX2OK := True;
  end;
end;

procedure TfrmCTePrincipal.sbAssinarClick(Sender: TObject);
var
  XMLString : string;
begin
  try
    XMLString := mmXMLEnvio.Text;
    vCTe.NomeCertificado.Text := cbCertificado.Text;
    mmXMLEnvio.Text := vCTe.AssinarCT(XMLString);

    pcProcessos.ActivePage := tsXMLformatado;
  except
    on e : exception do
     showmessage('Ocorreu o seguinte erro: '+ e.message);
  end;
end;

procedure TfrmCTePrincipal.sbEnviarClick(Sender: TObject);
begin
  try
    mmXML.Lines.Clear;
    mmXML.Text := vCTe.EnviarCT('1', mmXMLEnvio.Text);

    edtRecibo.Text := vCTe.ExtrairRecibo(mmXML.Text);

    pcProcessos.ActivePage := tsXMLRetorno;

    ShowMessage('Envio feito com sucesso, favor executar a consulta!');

    pcProcessos.ActivePage := tsXML;
  except
    on e : exception do
     showmessage('Ocorreu o seguinte erro: '+ e.message);
  end;
end;

procedure TfrmCTePrincipal.Label6Click(Sender: TObject);
begin
  ShellExecute(Application.Handle, 'open', PChar('http://sped.rfb.gov.br/estatico/FE/A52DB11609848FF5D567967207254F89AAFF06/Leiautes%20da%20EFD-Reinf%20v2.0%20-%20Anexo%20I%20-%20Tabelas.pdf'), nil, nil, 0);
end;

procedure TfrmCTePrincipal.sbConsultaLoteClick(Sender: TObject);
begin
  if edtChave.Text <> '' then
  begin
    mmXMLRetorno.text := vCTe.ConsultarCT(edtChave.Text);
    edtProtocolo.Text := vCTe.ExtrairProtocolo(mmXMLRetorno.text);
  end
  else
  begin
    ShowMessage('Favor informar uma chave antes de prosseguir');
    edtChave.SetFocus;
  end;
end;

procedure TfrmCTePrincipal.sbConsultarReciboClick(Sender: TObject);
begin
  if edtRecibo.Text <> '' then
  begin
    mmXMLRetorno.text := vCTe.ConsultarRecibo(edtRecibo.Text);
    edtProtocolo.Text := vCTe.ExtrairProtocolo(mmXMLRetorno.text);
  end
  else
  begin
    ShowMessage('Favor informar um recibo antes de prosseguir');
    edtRecibo.SetFocus;
  end;
end;

procedure TfrmCTePrincipal.SpeedButton1Click(Sender: TObject);
var
  vXML: string;
begin
  vXML := '';
  OpenDialog.InitialDir := ExtractFilePath(ParamStr(0));
  OpenDialog.Execute;

  if OpenDialog.FileName <> '' then
  begin
    vXML := OpenDialog.FileName;
    vCTe.ImprimirDACTE(vXML, '', '');
  end;
end;

procedure TfrmCTePrincipal.SomenteNumero(Sender: TObject; var Key: Char);
begin
   if  not ( Key in ['0'..'9', Chr(8)] ) then
      Key := #0
end;

procedure TfrmCTePrincipal.PreencherTX2CCe;
  var
  vTX2: string;
begin
  mmXMLEnvio.Clear;
  OpenDialog.InitialDir := ExtractFilePath(ParamStr(0));
  OpenDialog.Execute;

  if OpenDialog.FileName <> '' then
  begin
    vTX2 := OpenDialog.FileName;
    mmXMLEnvio.Lines.LoadFromFile(vTX2);
  end;
end;

procedure TfrmCTePrincipal.sbEnviarCCeClick(Sender: TObject);
var
  StringXML: string;
begin
  try
    PreencherTX2CCe;

    mmXMLEnvio.Text := vCTe.GerarXMLCCeporTX2(mmXMLEnvio.Text);

    mmXMLRetorno.Lines.Clear;
    mmXMLRetorno.Text := vCTe.EnviarCCe(edtChave.text, FormatDateTime('yyyy-mm-dd"T"hh:nn:ss',date)+'-03:00', mmXMLEnvio.Text, '1');

    edtRecibo.Text := vCTe.ExtrairRecibo(mmXMLRetorno.Text);
    pcProcessos.ActivePage := tsXMLRetorno;

    ShowMessage('Envio feito com sucesso, favor executar a consulta!');

    pcProcessos.ActivePage := tsXMLformatado;
  except
    on e : exception do
     showmessage('Ocorreu o seguinte erro: '+ e.message);
  end;
end;

procedure TfrmCTePrincipal.sbConfigINIClick(Sender: TObject);
var
  vExecuteFile: string;
  vNomeCertificado: string;
  vIniFile: TIniFile;
begin
  try
    if cbCertificado.Text <> '' then
    begin
      vNomeCertificado := Trim(cbCertificado.Text);

      SetCurrentDir(vCurrentDir);
      vIniFile := TIniFile.Create(vCurrentDir + 'cteConfig.ini');
      try
        vIniFile.WriteString('CTE', 'NomeCertificado', vNomeCertificado);
      finally
        vIniFile.Free;
      end;
    end;
    vExecuteFile := ExtractFilePath(vCurrentDir + 'cteConfig.ini');
    ShellExecute(Application.Handle, nil, Pchar(vExecuteFile), nil, nil, SW_SHOWNORMAL);
  finally
  end;
end;

procedure TfrmCTePrincipal.mmXMLEnvioKeyDown(Sender: TObject;
  var Key: Word; Shift: TShiftState);
var
  C: string;
begin
  if ssCtrl in Shift then
  begin
    C := LowerCase(Char(Key));
    if C = 'a' then
    begin
      mmXMLEnvio.SelectAll;
    end;
  end;
end;

procedure TfrmCTePrincipal.cbCertificadoChange(Sender: TObject);
begin
   vCTe.NomeCertificado.Text       := cbCertificado.Text;
end;

end.
