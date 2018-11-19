VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form FrmExemplo 
   Caption         =   "ExemploCTe"
   ClientHeight    =   9000
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8355
   LinkTopic       =   "Form1"
   ScaleHeight     =   9000
   ScaleWidth      =   8355
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog 
      Left            =   7800
      Top             =   8520
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.TextBox mmXML 
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF0000&
      Height          =   4335
      HideSelection   =   0   'False
      Left            =   0
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   34
      Top             =   4080
      Width           =   8415
   End
   Begin VB.Frame gbOperacoes 
      Caption         =   "Operações"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4095
      Left            =   2640
      TabIndex        =   1
      Top             =   0
      Width           =   5775
      Begin VB.Frame gbImpressao 
         Caption         =   "Impressão do Dacte"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1335
         Left            =   2880
         TabIndex        =   28
         Top             =   2400
         Width           =   2655
         Begin VB.CommandButton btnExporta 
            Caption         =   "11. Exportar para PDF"
            Height          =   315
            Left            =   120
            TabIndex        =   30
            Top             =   720
            Width           =   2415
         End
         Begin VB.CommandButton btnVisualizar 
            Caption         =   "10. Visualizar"
            Height          =   315
            Left            =   120
            TabIndex        =   29
            Top             =   360
            Width           =   2415
         End
      End
      Begin VB.CommandButton btnCancelar 
         Caption         =   "9. Cancelar CTe"
         Height          =   315
         Left            =   2880
         TabIndex        =   27
         Top             =   1920
         Width           =   2655
      End
      Begin VB.CommandButton btnConsultaCTe 
         Caption         =   "8. Consultar CTe"
         Height          =   315
         Left            =   2880
         TabIndex        =   26
         Top             =   1560
         Width           =   2655
      End
      Begin VB.CommandButton btnConsultaRecibo 
         Caption         =   "7. Consultar Recibo CTe"
         Height          =   315
         Left            =   2880
         TabIndex        =   25
         Top             =   1200
         Width           =   2655
      End
      Begin VB.CommandButton btnEnviarCTe 
         Caption         =   "6. Enviar CTe"
         Height          =   315
         Left            =   2880
         TabIndex        =   24
         Top             =   840
         Width           =   2655
      End
      Begin VB.CommandButton btnPreverDacte 
         Caption         =   "5.2 Prever DACTE"
         Height          =   315
         Left            =   120
         TabIndex        =   23
         Top             =   3360
         Width           =   2655
      End
      Begin VB.CommandButton btnAssinar 
         Caption         =   "5.1 Assinar CTe"
         Height          =   315
         Left            =   120
         TabIndex        =   22
         Top             =   3000
         Width           =   2655
      End
      Begin VB.CommandButton btnDataSet 
         Caption         =   "4.2 Gerar XML via DataSet"
         Height          =   315
         Left            =   120
         TabIndex        =   21
         Top             =   2640
         Width           =   2655
      End
      Begin VB.CommandButton btnTx2 
         Caption         =   "4.1 Gerar XML via Tx2"
         Height          =   315
         Left            =   120
         TabIndex        =   20
         Top             =   2280
         Width           =   2655
      End
      Begin VB.CommandButton btnStatus 
         Caption         =   "3. Verificar Status de Serviço"
         Height          =   315
         Left            =   120
         TabIndex        =   19
         Top             =   1920
         Width           =   2655
      End
      Begin VB.CommandButton btnLoadConfig 
         Caption         =   "2. LoadConfig"
         Height          =   315
         Left            =   120
         TabIndex        =   18
         Top             =   1560
         Width           =   2655
      End
      Begin VB.CommandButton btnConfiguraIni 
         Caption         =   "1.2 Configurar via arquivo .ini"
         Height          =   315
         Left            =   120
         TabIndex        =   17
         Top             =   1200
         Width           =   2655
      End
      Begin VB.CommandButton btnConfiguraSH 
         Caption         =   "1.1 Configura Software House"
         Height          =   315
         Left            =   120
         TabIndex        =   16
         Top             =   840
         Width           =   2655
      End
      Begin VB.ComboBox cbCertificados 
         Height          =   315
         Left            =   1080
         TabIndex        =   15
         Top             =   360
         Width           =   4455
      End
      Begin VB.Label Label9 
         Caption         =   "Siga as operações na ordem assinalada"
         ForeColor       =   &H8000000D&
         Height          =   255
         Left            =   120
         TabIndex        =   31
         Top             =   3720
         Width           =   2895
      End
      Begin VB.Label lblCertificado 
         Caption         =   "Certificado: "
         Height          =   255
         Left            =   240
         TabIndex        =   14
         Top             =   360
         Width           =   855
      End
   End
   Begin VB.Frame gbConfig 
      Caption         =   "Configurações"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4095
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   2535
      Begin VB.TextBox edtUF 
         Height          =   315
         Left            =   120
         TabIndex        =   33
         Top             =   480
         Width           =   375
      End
      Begin VB.TextBox edtProtocolo 
         Height          =   285
         Left            =   120
         TabIndex        =   8
         Top             =   3480
         Width           =   2295
      End
      Begin VB.TextBox edtRecibo 
         Height          =   285
         Left            =   120
         TabIndex        =   7
         Top             =   2880
         Width           =   2295
      End
      Begin VB.TextBox edtChave 
         Height          =   285
         Left            =   120
         TabIndex        =   6
         Top             =   2280
         Width           =   2295
      End
      Begin VB.TextBox edtCNPJEmit 
         Height          =   285
         Left            =   120
         TabIndex        =   5
         Top             =   1680
         Width           =   2295
      End
      Begin VB.TextBox edtCNPJSH 
         Height          =   285
         Left            =   120
         TabIndex        =   4
         Text            =   "08187168000160"
         Top             =   1080
         Width           =   2295
      End
      Begin VB.Label lblProtocolo 
         Caption         =   "Nº Protocolo"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   3240
         Width           =   1095
      End
      Begin VB.Label lblRecibo 
         Caption         =   "Nº Recibo"
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Top             =   2640
         Width           =   1575
      End
      Begin VB.Label lblChave 
         Caption         =   "Nº Chave"
         Height          =   255
         Left            =   120
         TabIndex        =   11
         Top             =   2040
         Width           =   855
      End
      Begin VB.Label lblCNPJEmit 
         Caption         =   "CNPJ (Apenas números) *"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   10
         Top             =   1440
         Width           =   2175
      End
      Begin VB.Label lblCNPJSH 
         Caption         =   "CNPJ Software House *"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   840
         Width           =   2055
      End
      Begin VB.Label lblUF 
         Caption         =   "UF"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   240
         Width           =   495
      End
   End
   Begin VB.Label lblStatus 
      Height          =   375
      Left            =   0
      TabIndex        =   32
      Top             =   8520
      Visible         =   0   'False
      Width           =   8535
   End
   Begin VB.Label Label2 
      Caption         =   "UF"
      Height          =   255
      Left            =   1920
      TabIndex        =   3
      Top             =   1320
      Width           =   495
   End
End
Attribute VB_Name = "FrmExemplo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Declarado Objeto pertencente a Classe que faz interação com servidores da Receita'
Dim CTe As CTeX.spdCTeX
Dim CTeDataSet As CTeDataSetX.spdCTeDataSetX
Dim ArqIni As String
Dim CertificadoSelecionado As String

'******************************************************************************************************
'
'          Declaração de funções externas
'
'******************************************************************************************************
'Função para ler arquivos INI usando API window
Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal Secao As String, ByVal parametro As Any, ByVal padrao As String, ByVal variavel As String, ByVal tam As Long, ByVal arquivo As String) As Long

'Função para gravar arquivos INI usando API windows
Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal Secao As String, ByVal parametro As Any, ByVal valor As Any, ByVal arquivo As String) As Long

'Função para configurar o diretório atual
Private Declare Function SetCurrentDirectory Lib "kernel32" _
() 'Alias "SetCurrentDirectoryA" (ByVal lpPathName As String) As Long

Option Explicit

'Função auxiliar para pegar o fuso
Private Const TIME_ZONE_ID_DAYLIGHT As Long = 2

'Função auxiliar para pegar o fuso
Private Type SYSTEMTIME
   wYear         As Integer
   wMonth        As Integer
   wDayOfWeek    As Integer
   wDay          As Integer
   wHour         As Integer
   wMinute       As Integer
   wSecond       As Integer
   wMilliseconds As Integer
End Type
'Função auxiliar para pegar o fuso
Private Type TIME_ZONE_INFORMATION
   Bias As Long
   StandardName(0 To 63) As Byte  'unicode (0-based)
   StandardDate As SYSTEMTIME
   StandardBias As Long
   DaylightName(0 To 63) As Byte  'unicode (0-based)
   DaylightDate As SYSTEMTIME
   DaylightBias As Long
End Type
'Função auxiliar para pegar o fuso
Private Declare Function GetTimeZoneInformation Lib "kernel32.dll" (lpTimeZoneInformation As TIME_ZONE_INFORMATION) As Long
'Função para pegar o fuso
Private Function GetCurrentTimeBias() As String

   Dim tzi As TIME_ZONE_INFORMATION
   Dim dwBias As Long
   Dim tmp As String

   Select Case GetTimeZoneInformation(tzi)
   Case TIME_ZONE_ID_DAYLIGHT
      dwBias = tzi.Bias + tzi.DaylightBias
   Case Else
      dwBias = tzi.Bias + tzi.StandardBias
   End Select

   tmp = "-0" & CStr(dwBias \ 60) & ":00"

   GetCurrentTimeBias = tmp
   
End Function

'Inicialização
Private Sub Form_Initialize()

  'Instancia o Objeto responsável pela interação com servidores da Receita
  Set CTe = New CTeX.spdCTeX
  'Instancia o Objeto responsável pela geração do DataSet
  Set CTeDataSet = New CTeDataSetX.spdCTeDataSetX
  
  'Utiliza Método do Componente para Listar Certificados instalado no SO
  Dim i As Integer
  Dim vetor As Variant

  vetor = Split(CTe.ListarCertificados, "|")
  cbCertificados.Clear
  For i = LBound(vetor) To UBound(vetor)
          cbCertificados.AddItem vetor(i)
  Next

  'Arquivo INI a ser manipulado com parametrizações
  ArqIni = App.Path + "\cteConfig.ini"
    
End Sub
'1.1. Configurar o CNPJ da Software House
Private Sub btnConfiguraSH_Click()
On Error GoTo TrataErroSH
    CTe.ConfigurarSoftwareHouse edtCNPJSH.Text, ""
TrataErroSH:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'1.2. Configurar CTe via arquivo .ini
Private Sub btnConfiguraIni_Click()
On Error GoTo TrataErroConfigIni
    
  Dim Rs As String
  
  Rs = cbCertificados.Text
  If Rs <> "" Then
  write_ini "CTe", "NomeCertificado", Rs
  Shell "C:\Windows\System32\notepad.exe " + App.Path + "\cteConfig.ini", vbNormalFocus
  Else
  AtualizaStatusNaTela ("Favor selecionar um certificado")
  End If
TrataErroConfigIni:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'2. LoadConfig
Private Sub btnLoadConfig_Click()
On Error GoTo TrataErroLoadConfig
    CTe.LoadConfig ArqIni
    edtUF.Text = CTe.UF
    edtCNPJEmit.Text = CTe.CNPJ
    cbCertificados.Text = CTe.NomeCertificado
    AtualizaStatusNaTela "Configurações carregadas via ini."
Exit Sub
TrataErroLoadConfig:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'3.Verificar Status do Servi?o
Private Sub btnStatus_Click()
 On Error GoTo TratarErroStatus
    CheckConfig (False)
    Dim Retorno As String
    Retorno = CTe.StatusdoServico()
    AtualizaRetornoNaTela (Retorno)
    AtualizaStatusNaTela ("Status do Serviço: OK")
Exit Sub
TratarErroStatus:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'4.1.Gerar XML via TX2
Private Sub btnTx2_Click()
    On Error GoTo TratarErroTx2
    CheckConfig (True)
    Dim arquivo As String
    Dim Retorno As String
   arquivo = FileOpen("TX2 (*.tx2) | *.tx2") 'Carrega o arquivo .tx2
   Dim fso As New FileSystemObject
   If arquivo <> "" Then
    ConfiguraCteDataSet
    CTeDataSet.LoadFromTX2 (arquivo)
    Retorno = CTeDataSet.LoteCTe()
    AtualizaRetornoNaTela (Retorno)
    edtChave.Text = Mid((CTeDataSet.GetCampo("Id_3")), 4, 44)
    AtualizaStatusNaTela ("Gerar XML por TX2: OK")
   End If
   Exit Sub
TratarErroTx2:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'4.2.Gerar XML via DataSet
Private Sub btnDataSet_Click()
    On Error GoTo TratarErroDataSet
    Dim XML As String
            CheckConfig (True)
            ConfiguraCteDataSet
            CTeDataSet.Incluir
            DadosdoCTe
            DadosTomador
            DadosdoCTe
            DadosEmitente
            DadosRemetente
            DadosDestinatario
            PrestacaodeServico
            DadosImpostos
            VersaoModal
            DadosCarga
            DadosICMSUFFim
            OutrasInformacoes
            QuantidadesCarga
            ModalRodoviario
            OrdensColeta
            CTeDataSet.Salvar
            XML = CTeDataSet.LoteCTe()
            edtChave.Text = Mid((CTeDataSet.GetCampo("Id_3")), 4, 44)
            AtualizaRetornoNaTela (XML)
            AtualizaStatusNaTela ("Gerar XML por DataSet: OK")
TratarErroDataSet:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'5.1 Assinar CTe
Private Sub btnAssinar_Click()
    On Error GoTo TratarErroAssina
Dim XML As String
XML = CTe.AssinarCT(CTe.CompressXML(mmXML.Text))
AtualizaRetornoNaTela (XML)
AtualizaStatusNaTela ("Assinar CTe: OK")
TratarErroAssina:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'5.2 Prever DACTE
Private Sub btnPreverDacte_Click()
On Error GoTo TratarErroPrever
CheckConfig (False)
Dim XML As String
XML = mmXML.Text
If Trim(XML) <> "" Then
CTe.PreverDACTE XML, ""
Else
lblStatus = "Por gentileza informe o XML Assinado no memo."
End If
TratarErroPrever:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'6.Enviar CTe
Private Sub btnEnviarCTe_Click()
On Error GoTo TratarErroEnvia
    CheckConfig (False)
    Dim Retorno As String
    Retorno = CTe.EnviarCT("1", CTe.CompressXML(mmXML.Text))
    edtRecibo.Text = CTe.ExtrairRecibo(Retorno)
    AtualizaRetornoNaTela (Retorno)
    AtualizaStatusNaTela ("Enviar CTe: OK")
TratarErroEnvia:
  If Err.Description <> "" Then
    lblStatus = Err.Description
  End If
End Sub
'7. Consultar Recibo CTe
Private Sub btnConsultaRecibo_Click()
On Error GoTo TratarErroConsultaRecibo
CheckConfig (True)
    Dim Retorno As String
    Retorno = CTe.ConsultarRecibo(edtRecibo.Text)
    edtProtocolo.Text = CTe.ExtrairProtocolo(Retorno)
    AtualizaRetornoNaTela (Retorno)
    AtualizaStatusNaTela ("Consultar Recibo CTe: OK")
TratarErroConsultaRecibo:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'8.Consultar CTe
Private Sub btnConsultaCTe_Click()
On Error GoTo TratarErroConsultaCTe
CheckConfig (True)
    Dim Retorno As String
    Retorno = CTe.ConsultarCT(edtChave.Text)
    edtProtocolo.Text = CTe.ExtrairProtocolo(Retorno)
    AtualizaRetornoNaTela (Retorno)
    AtualizaStatusNaTela ("Consultar Recibo CTe: OK")
TratarErroConsultaCTe:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'9.Cancelar CTe
Private Sub btnCancelar_Click()
 On Error GoTo TratarErroCancela
  Load FCancela
  
  FCancela.edtChave.Text = edtChave.Text
  FCancela.edtProtocolo.Text = edtProtocolo.Text
  
  FCancela.Show vbModal
    Dim Chave As String
    Dim Protocolo As String
    Dim Justificativa As String
    Dim Retorno As String
    Dim Sequencia As String
    
    Chave = FCancela.edtChave.Text
    Protocolo = FCancela.edtProtocolo.Text
    Justificativa = FCancela.mJustificativa.Text
    Sequencia = FCancela.edtSeq.Text
    
    If Chave <> "" And Protocolo <> "" And Justificativa <> "" Then
    
    Retorno = CTe.CancelarCTEvento(Chave, Protocolo, Justificativa, Format(Now, "yyyy-mm-ddThh:mm:ss") & GetCurrentTimeBias, Sequencia)
    
    AtualizaRetornoNaTela (Retorno)
    
    AtualizaStatusNaTela ("Cancelar CTe: OK")
    Else
    End If
    
    Unload FCancela
    
TratarErroCancela:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'10.Visualizar
Private Sub btnVisualizar_Click()
On Error GoTo TratarErroVisualizar
CheckConfig (False)
  If edtChave.Text <> "" Then
  arquivo = ObterCaminhoXmlTomador(edtChave.Text)
  If arquivo <> "" Then
  Dim fso As New FileSystemObject
    Set arqtxt = fso.OpenTextFile(arquivo)
    XML = arqtxt.ReadAll
    
    CTe.VisualizarDACTE XML, ""
  End If
  Else
        XML = mmXML.Text
        If Trim(XML) <> "" Then
            CTe.VisualizarDACTE XML, ""
        Else
            lblStatus = "Por gentileza informe o XML no memo."
        End If
  End If
TratarErroVisualizar:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'11.Exportar para PDF
Private Sub btnExporta_Click()
On Error GoTo TratarErroExportar
CheckConfig (False)
If edtChave.Text <> "" Then
  Dim fso As New FileSystemObject
  Dim arqtxt As TextStream
  arquivo = ObterCaminhoXmlTomador(edtChave.Text)
  If arquivo <> "" Then
    Set arqtxt = fso.OpenTextFile(arquivo)
    XML = arqtxt.ReadAll
    CaminhoPDF (XML)
  Else
    lblStatus = "Por gentileza informe uma chave válida."
  End If
Else
  XML = mmXML.Text
  If Trim(XML) <> "" Then
    CaminhoPDF (XML)
  Else
    lblStatus = "Por gentileza informe o XML no memo."
  End If
End If
TratarErroExportar:
    If Err.Description <> "" Then
        lblStatus = Err.Description
    End If
End Sub
'Função que verifica se o componente foi configurado
Private Sub CheckConfig(ClearOutput As Boolean)
Dim bConfig As Boolean
If ClearOutput Then
    mmXML.Text = ""
End If

bConfig = True

If CTe.UF = "" Then
    bConfig = False
End If

If CTe.CNPJ = "" Then
    bConfig = False
End If

If CTe.NomeCertificado = "" Then
    bConfig = False
End If
If bConfig = False Then
    Err.Raise vbObjectError + 1, "Form1", "Favor configurar o componente antes de prosseguir (via ini ou via propriedades)."
    'lblStatus = "Favor configurar o componente antes de prosseguir (via ini ou via propriedades)."
End If

End Sub
'Função que define o caminho do PDF
Private Sub CaminhoPDF(XML As String)
    CaminhoArquivoPDF = InputBox("Caminho do arquivo PDF", "Informe o caminho do arquivo PDF", "C:\Dacte.PDF")
    If CaminhoArquivoPDF <> "" Then
        CTe.ExportarDACTEParaPDF CTe.CompressXML(XML), "", CaminhoArquivoPDF
        AtualizaRetornoNaTela "PDF gerado com sucesso: " + CaminhoArquivoPDF
    Else
      lblStatus = "Por gentileza informe um caminho válido."
    End If
End Sub
'Função que configura o componente DataSet
Private Sub ConfiguraCteDataSet()
    CTeDataSet.Versao = "3.00"
    CTeDataSet.ConfigSection = "XMLENVIO"
    CTeDataSet.MappingFileName = CTe.DiretorioEsquemas + "3.00" + "\" + CTe.MappingFileName
    CTeDataSet.CreateDataSets
    CTeDataSet.IdLote = "1"
End Sub

'Função para escrever no arquivo .ini
Function write_ini(ByVal section$, ByVal chv$, ByVal variavel$) As String
    Dim arquivo As String
    Dim Retorno As String
    arquivo = ArqIni
    Retorno = WritePrivateProfileString(ByVal section$, ByVal chv$, ByVal variavel$, ByVal arquivo)
End Function
'Função que atualiza o Status
Private Sub AtualizaStatusNaTela(valor As String)
    lblStatus.Caption = valor
    lblStatus.Visible = True
End Sub
'Função que atualiza o Memo
Private Sub AtualizaRetornoNaTela(valor As String)

    mmXML.Text = CTe.ReformatXML(valor)
    
End Sub

'Verifica se o arquivo existe no caminho passado
Private Function FileExists(Fname As String) As Boolean
    
    If Fname = "" Or Right(Fname, 1) = "\" Then
      FileExists = False: Exit Function
    End If
    
    FileExists = (Dir(Fname) <> "")
    
End Function

'Retorna caminho do XML do tomador
Private Function ObterCaminhoXmlTomador(Chave As String)

    Dim XmlTomador As String
    
    XmlTomador = CTe.DiretorioXMLTomadorServico + "\" + Trim(Chave) + "-cte.xml"
    If FileExists(XmlTomador) Then
        ObterCaminhoXmlTomador = XmlTomador
    Else
        ObterCaminhoXmlTomador = ""
    End If

End Function
'Função auxiliar para abrir arquivo
Function FileOpen(filtro) As String
    CommonDialog.Filter = filtro
    CommonDialog.InitDir = App.Path
    CommonDialog.ShowOpen
    If CommonDialog.FileName = "" Then
         'Teste
    Else
        FileOpen = CommonDialog.FileName ' The FileName property contains the selected file name.
    End If
End Function
        'Preenche os Dados do CTe do DataSet
        Private Sub DadosdoCTe()
            CTeDataSet.SetCampo "versao_2", "3.00"
            CTeDataSet.SetCampo "cUF_5", "43"
            CTeDataSet.SetCampo "cCT_6", "00000000"
            CTeDataSet.SetCampo "CFOP_7", "5357"
            CTeDataSet.SetCampo "natOp_8", "TRANSPORTE RODOVIARIO DE CARGAS"
            CTeDataSet.SetCampo "mod_10", "57"
            CTeDataSet.SetCampo "serie_11", "876"
            CTeDataSet.SetCampo "nCT_12", "10"
            CTeDataSet.SetCampo "dhEmi_13", "2018-10-15T15:26:00-03:00"
            CTeDataSet.SetCampo "tpImp_14", "1"
            CTeDataSet.SetCampo "tpEmis_15", "1"
            CTeDataSet.SetCampo "tpAmb_17", "2"
            CTeDataSet.SetCampo "tpCTe_18", "0"
            CTeDataSet.SetCampo "procEmi_19", "0"
            CTeDataSet.SetCampo "verProc_20", "1"
            CTeDataSet.SetCampo "cMunEnv_672", "4302105"
            CTeDataSet.SetCampo "xMunEnv_673", "BENTO GONCALVES"
            CTeDataSet.SetCampo "UFEnv_674", "RS"
            CTeDataSet.SetCampo "modal_25", "01"
            CTeDataSet.SetCampo "tpServ_26", "0"
            CTeDataSet.SetCampo "cMunIni_27", "4302105"
            CTeDataSet.SetCampo "xMunIni_28", "BENTO GONCALVES"
            CTeDataSet.SetCampo "UFIni_29", "RS"
            CTeDataSet.SetCampo "cMunFim_30", "4302105"
            CTeDataSet.SetCampo "xMunFim_31", "BENTO GONCALVES"
            CTeDataSet.SetCampo "UFFim_32", "RS"
            CTeDataSet.SetCampo "retira_33", "0"
            CTeDataSet.SetCampo "xDetRetira_34", "detalhes teste"
            CTeDataSet.SetCampo "indIEToma_1406", "1"
        End Sub

        'Preenche os Dados do Tomador do DataSet
        Private Sub DadosTomador()
            CTeDataSet.SetCampo "toma_36", "3"
        End Sub

        'Preenche os Dados do Emitente do DataSet
        Private Sub DadosEmitente()
            CTeDataSet.SetCampo "CNPJ_95", "99999999999999"
            CTeDataSet.SetCampo "IE_96", "9999999999"
            CTeDataSet.SetCampo "xNome_97", "Nome teste"
            CTeDataSet.SetCampo "xFant_98", "Nome teste"
            CTeDataSet.SetCampo "xLgr_100", "Rua teste"
            CTeDataSet.SetCampo "nro_101", "300"
            CTeDataSet.SetCampo "xCpl_102", "10 andar"
            CTeDataSet.SetCampo "xBairro_103", "BAIRRO TESTE"
            CTeDataSet.SetCampo "cMun_104", "4302105"
            CTeDataSet.SetCampo "xMun_105", "BENTO GONCALVES"
            CTeDataSet.SetCampo "CEP_106", "89233198"
            CTeDataSet.SetCampo "UF_107", "RS"
            CTeDataSet.SetCampo "fone_110", "1132433400"
        End Sub

        'Preenche os Dados do Remetente do DataSet
        Private Sub DadosRemetente()
            CTeDataSet.SetCampo "CNPJ_112", "08187168000160"
            CTeDataSet.SetCampo "IE_114", "9044016688"
            CTeDataSet.SetCampo "xNome_115", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
            CTeDataSet.SetCampo "xFant_116", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
            CTeDataSet.SetCampo "fone_117", "4430283749"
            CTeDataSet.SetCampo "xLgr_119", "RUA DUQUE DE CAXIAS  S/N"
            CTeDataSet.SetCampo "nro_120", "0"
            CTeDataSet.SetCampo "xBairro_122", "PARANA"
            CTeDataSet.SetCampo "cMun_123", "4115200"
            CTeDataSet.SetCampo "xMun_124", "PARANA"
            CTeDataSet.SetCampo "CEP_125", "01000000"
            CTeDataSet.SetCampo "UF_126", "PR"
            CTeDataSet.SetCampo "cPais_127", "1058"
            CTeDataSet.SetCampo "xPais_128", "BRASIL"
            CTeDataSet.SetCampo "email_604", "x@tecnospeed.com.br"
        End Sub

        'Preenche os Dados do Destinatario do DataSet
        Private Sub DadosDestinatario()
            CTeDataSet.SetCampo "CPF_200", "22233344405"
            CTeDataSet.SetCampo "IE_201", "0500048665"
            CTeDataSet.SetCampo "xNome_202", "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
            CTeDataSet.SetCampo "xLgr_206", "Praca Matriz"
            CTeDataSet.SetCampo "nro_207", "0"
            CTeDataSet.SetCampo "xBairro_209", "Centro"
            CTeDataSet.SetCampo "cMun_210", "4302105"
            CTeDataSet.SetCampo "xMun_211", "BENTO GONCALVES"
            CTeDataSet.SetCampo "CEP_212", "01000000"
            CTeDataSet.SetCampo "UF_213", "RS"
            CTeDataSet.SetCampo "cPais_214", "1058"
            CTeDataSet.SetCampo "xPais_215", "BRASIL"
            CTeDataSet.SetCampo "email_608", "teste.teste@teste.com.br"
        End Sub

        'Preenche os Dados da Pretacao de Servico do DataSet
        Private Sub PrestacaodeServico()
            CTeDataSet.SetCampo "vTPrest_228", "200.00"
            CTeDataSet.SetCampo "vRec_229", "200.00"
        End Sub

        'Preenche os Dados dos impostos do DataSet
        Private Sub DadosImpostos()
            CTeDataSet.SetCampo "CST_609", "00"
            CTeDataSet.SetCampo "vBC_610", "0.01"
            CTeDataSet.SetCampo "pICMS_611", "7.00"
            CTeDataSet.SetCampo "vICMS_612", "0.01"
        End Sub

        'Preenche os Dados da Versao Modal do DataSet
        Private Sub VersaoModal()
            CTeDataSet.SetCampo "versaoModal_636", "3.00"
        End Sub

        'Preenche os Dados da carga do DataSet
        Private Sub DadosCarga()
            CTeDataSet.SetCampo "vCarga_671", "1000.00"
            CTeDataSet.SetCampo "proPred_271", "LATA"
        End Sub

        'Preenche os Dados do ICMSUFFim do DataSet
        Private Sub DadosICMSUFFim()
            CTeDataSet.SetCampo "vBCUFFim_676", "1.10"
            CTeDataSet.SetCampo "pFCPUFFim_682", "1.10"
            CTeDataSet.SetCampo "pICMSUFFim_677", "40"
            CTeDataSet.SetCampo "pICMSInter_678", "12.00"
            CTeDataSet.SetCampo "pICMSInterPart_679", "40.00"
            CTeDataSet.SetCampo "vICMSUFFim_680", "1.10"
            CTeDataSet.SetCampo "vICMSUFIni_681", "1.10"
            CTeDataSet.SetCampo "vFCPUFFim_683", "1.10"
        End Sub

        'Preenche os Dados de Outras Informacoes do DataSet
        Private Sub OutrasInformacoes()
            CTeDataSet.IncluirParte ("infOutros")
            CTeDataSet.SetCampo "tpDoc_159", "00"
            CTeDataSet.SetCampo "nDoc_161", "123456"
            CTeDataSet.SetCampo "dEmi_162", "2011-03-22"
            CTeDataSet.SetCampo "vDocFisc_163", "1.00"
            CTeDataSet.IncluirParte ("infUnidCarga")
            CTeDataSet.SetCampo "tpUnidCarga_810", "1"
            CTeDataSet.SetCampo "idUnidCarga_811", "1"
            CTeDataSet.SalvarParte ("infUnidCarga")
            CTeDataSet.SalvarParte ("infOutros")
        End Sub

        'Preenche os Dados do Quantidade de Carga do DataSet
        Private Sub QuantidadesCarga()
            CTeDataSet.IncluirParte ("infQ")
            CTeDataSet.SetCampo "cUnid_274", "00"
            CTeDataSet.SetCampo "tpMed_275", "m3"
            CTeDataSet.SetCampo "qCarga_276", "1"
            CTeDataSet.SalvarParte ("infQ")
        End Sub

        'Preenche os Dados do Modal Rodoviario do DataSet
        Private Sub ModalRodoviario()
            CTeDataSet.IncluirParte ("Rodo")
            CTeDataSet.SetCampo "RNTRC_305", "00000012"
            CTeDataSet.SalvarParte ("Rodo")
        End Sub

        'Preenche os Dados de Ordens de Coleta do DataSet
        Private Sub OrdensColeta()
            CTeDataSet.IncluirParte ("Occ")
            CTeDataSet.SetCampo "serie_312", "1"
            CTeDataSet.SetCampo "nOcc_313", "1"
            CTeDataSet.SetCampo "dEmi_314", "2018-05-15"
            CTeDataSet.SetCampo "CNPJ_316", "08187168000160"
            CTeDataSet.SetCampo "cInt_317", "10"
            CTeDataSet.SetCampo "IE_318", "0500077436"
            CTeDataSet.SetCampo "UF_319", "PR"
            CTeDataSet.SetCampo "fone_320", "99999999"
            CTeDataSet.SalvarParte ("Occ")
        End Sub

