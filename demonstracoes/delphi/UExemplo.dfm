object FrmExemplo: TFrmExemplo
  Left = 525
  Top = 153
  BorderStyle = bsDialog
  ClientHeight = 695
  ClientWidth = 681
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object pgCtrlMessages: TPageControl
    Left = 1
    Top = 303
    Width = 676
    Height = 401
    ActivePage = tbSheetMemo
    Align = alCustom
    TabOrder = 0
    TabStop = False
    object tbSheetMemo: TTabSheet
      Caption = 'XML'
      object lblHidden: TLabel
        Left = 0
        Top = 341
        Width = 668
        Height = 32
        Align = alBottom
        Alignment = taCenter
        Caption = 'Antes de come'#231'ar, configure o arquivo cteConfig.ini'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -27
        Font.Name = 'Arial'
        Font.Style = [fsBold]
        ParentFont = False
        Visible = False
        ExplicitWidth = 687
      end
      object mOutput: TMemo
        Left = 0
        Top = 0
        Width = 668
        Height = 341
        TabStop = False
        Align = alClient
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlue
        Font.Height = -13
        Font.Name = 'Courier New'
        Font.Style = [fsBold]
        ParentFont = False
        ScrollBars = ssVertical
        TabOrder = 0
      end
    end
    object tbsXMLFormatado: TTabSheet
      Caption = 'XML Formatado'
      ImageIndex = 2
      object mFmtOutput: TMemo
        Left = 0
        Top = 0
        Width = 668
        Height = 373
        TabStop = False
        Align = alClient
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlue
        Font.Height = -13
        Font.Name = 'Courier New'
        Font.Style = [fsBold]
        ParentFont = False
        ScrollBars = ssVertical
        TabOrder = 0
      end
    end
  end
  object pnlMenu: TPanel
    Left = 0
    Top = 0
    Width = 676
    Height = 298
    Align = alCustom
    TabOrder = 1
    object pnlConfig: TPanel
      Left = 1
      Top = 1
      Width = 219
      Height = 296
      Align = alLeft
      BevelOuter = bvNone
      BorderWidth = 5
      TabOrder = 0
      object gbConfig: TGroupBox
        Left = 6
        Top = 5
        Width = 213
        Height = 273
        Align = alCustom
        Caption = ' Configura'#231#245'es '
        TabOrder = 0
        object edCNPJ: TLabeledEdit
          Left = 10
          Top = 107
          Width = 190
          Height = 21
          TabStop = False
          Color = cl3DLight
          EditLabel.Width = 142
          EditLabel.Height = 13
          EditLabel.Caption = 'CNPJ (Apenas n'#250'meros)*'
          EditLabel.Font.Charset = DEFAULT_CHARSET
          EditLabel.Font.Color = clWindowText
          EditLabel.Font.Height = -11
          EditLabel.Font.Name = 'MS Sans Serif'
          EditLabel.Font.Style = [fsBold]
          EditLabel.ParentFont = False
          ReadOnly = True
          TabOrder = 2
        end
        object edtProtocolo: TLabeledEdit
          Left = 10
          Top = 218
          Width = 190
          Height = 21
          TabStop = False
          EditLabel.Width = 75
          EditLabel.Height = 13
          EditLabel.BiDiMode = bdLeftToRight
          EditLabel.Caption = 'N'#186' do Protocolo'
          EditLabel.ParentBiDiMode = False
          TabOrder = 5
        end
        object edUF: TLabeledEdit
          Left = 14
          Top = 28
          Width = 57
          Height = 21
          TabStop = False
          Color = cl3DLight
          EditLabel.Width = 17
          EditLabel.Height = 13
          EditLabel.Caption = 'UF'
          EditLabel.Font.Charset = DEFAULT_CHARSET
          EditLabel.Font.Color = clWindowText
          EditLabel.Font.Height = -11
          EditLabel.Font.Name = 'MS Sans Serif'
          EditLabel.Font.Style = [fsBold]
          EditLabel.ParentFont = False
          ReadOnly = True
          TabOrder = 0
        end
        object edtRecibo: TLabeledEdit
          Left = 11
          Top = 181
          Width = 190
          Height = 21
          TabStop = False
          EditLabel.Width = 62
          EditLabel.Height = 13
          EditLabel.BiDiMode = bdLeftToRight
          EditLabel.Caption = 'N'#186' do Recibo'
          EditLabel.ParentBiDiMode = False
          TabOrder = 4
        end
        object edtChave: TLabeledEdit
          Left = 10
          Top = 144
          Width = 190
          Height = 21
          TabStop = False
          EditLabel.Width = 61
          EditLabel.Height = 13
          EditLabel.BiDiMode = bdLeftToRight
          EditLabel.Caption = 'N'#186' da Chave'
          EditLabel.ParentBiDiMode = False
          TabOrder = 3
        end
        object edtSH: TLabeledEdit
          Left = 11
          Top = 67
          Width = 189
          Height = 21
          Color = cl3DLight
          EditLabel.Width = 135
          EditLabel.Height = 13
          EditLabel.Caption = 'CNPJ Software House *'
          EditLabel.Font.Charset = ANSI_CHARSET
          EditLabel.Font.Color = clWindowText
          EditLabel.Font.Height = -11
          EditLabel.Font.Name = 'MS Sans Serif'
          EditLabel.Font.Style = [fsBold]
          EditLabel.ParentFont = False
          TabOrder = 1
        end
      end
    end
    object grpOptions: TGroupBox
      Left = 224
      Top = 7
      Width = 448
      Height = 272
      Align = alCustom
      Caption = ' Opera'#231#245'es '
      TabOrder = 1
      OnClick = grpOptionsClick
      object lblInfo: TLabel
        Left = 15
        Top = 253
        Width = 191
        Height = 13
        Caption = 'Siga as opera'#231#245'es na ordem assinalada.'
        Color = clBtnFace
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlue
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentColor = False
        ParentFont = False
      end
      object Label1: TLabel
        Left = 9
        Top = 18
        Width = 56
        Height = 13
        Caption = 'Certificado:'
      end
      object btnConfigIni: TBitBtn
        Left = 14
        Top = 66
        Width = 200
        Height = 25
        Caption = '1.2. Configurar via arquivo .ini'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 0
        OnClick = btnConfigIniClick
      end
      object btnConsultarReciboCTe: TBitBtn
        Left = 225
        Top = 66
        Width = 214
        Height = 25
        Caption = '7. Consultar Recibo CTe'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 5
        OnClick = btnConsultarReciboCTeClick
      end
      object btnCancelarCTe: TBitBtn
        Left = 225
        Top = 121
        Width = 214
        Height = 25
        Caption = '9. Cancelar CTe'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 7
        OnClick = btnCancelarCTeClick
      end
      object btnEnviarCTe: TBitBtn
        Left = 225
        Top = 39
        Width = 214
        Height = 25
        Caption = '6. Enviar CTe'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 4
        OnClick = btnEnviarCTeClick
      end
      object btnConsultarCTe: TBitBtn
        Left = 225
        Top = 94
        Width = 214
        Height = 25
        Hint = 'Consulta Avulsa'
        Caption = '8. Consultar CTe'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        ParentShowHint = False
        ShowHint = True
        TabOrder = 6
        OnClick = btnConsultarCTeClick
      end
      object btnGerarXMLViaDataSet: TButton
        Left = 14
        Top = 174
        Width = 200
        Height = 25
        Caption = '4.2 Gerar XML via DataSet'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 3
        OnClick = btnGerarXMLViaDataSetClick
      end
      object btnGerarXMLViaTx2: TButton
        Left = 14
        Top = 147
        Width = 200
        Height = 25
        Caption = '4.1. Gerar XML via Tx2'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 2
        OnClick = btnGerarXMLViaTx2Click
      end
      object btnVerificarStatus: TBitBtn
        Left = 14
        Top = 120
        Width = 200
        Height = 25
        Caption = '3. Verificar Status do Servi'#231'o'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 1
        OnClick = btnVerificarStatusClick
      end
      object btnLoadConfig: TButton
        Left = 14
        Top = 93
        Width = 200
        Height = 25
        Caption = '2. LoadConfig'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 8
        OnClick = btnLoadConfigClick
      end
      object btnAssinar: TButton
        Left = 15
        Top = 201
        Width = 199
        Height = 25
        Caption = '5.1 Assinar CTe'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 9
        OnClick = btnAssinarClick
      end
      object btnPreverDacte: TButton
        Left = 14
        Top = 227
        Width = 200
        Height = 25
        Caption = '5.2 Prever DACTE'
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 10
        OnClick = btnPreverDacteClick
      end
      object btnConfiguraSH: TBitBtn
        Left = 14
        Top = 39
        Width = 200
        Height = 25
        Caption = '1.1. Configura Software House'
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 11
        OnClick = btnConfiguraSHClick
      end
      object grpImpressao: TGroupBox
        Left = 225
        Top = 164
        Width = 214
        Height = 88
        Caption = ' Impress'#227'o do DACTE '
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 12
        object btnExportarPDF: TBitBtn
          Left = 5
          Top = 46
          Width = 200
          Height = 29
          Caption = '11. Exportar para PDF'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 1
          OnClick = btnExportarPDFClick
        end
        object btnVisualizar: TBitBtn
          Left = 5
          Top = 16
          Width = 200
          Height = 28
          Caption = '10. Visualizar'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          TabOrder = 0
          OnClick = btnVisualizarClick
        end
      end
      object cbListaCertificados: TComboBox
        Left = 67
        Top = 15
        Width = 372
        Height = 21
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 13
        Text = 'Selecione o Certificado'
      end
    end
  end
  object mStatus: TMemo
    Left = 0
    Top = 662
    Width = 681
    Height = 33
    TabStop = False
    Align = alBottom
    TabOrder = 2
  end
  object OpnDlgXML: TOpenDialog
    Filter = 'Arquivos xml|*.xml'
    Left = 48
    Top = 617
  end
  object OpnDlgTx2: TOpenDialog
    Filter = 'Arquivos Tx2|*.tx2'
    Left = 16
    Top = 617
  end
  object svDlgExportar: TSaveDialog
    Filter = 'Arquivos pdf|*.pdf'
    Left = 80
    Top = 617
  end
end
