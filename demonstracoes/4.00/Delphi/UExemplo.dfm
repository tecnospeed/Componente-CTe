object FrmExemplo: TFrmExemplo
  Left = 525
  Top = 153
  BorderStyle = bsDialog
  ClientHeight = 695
  ClientWidth = 691
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Position = poScreenCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  OnShow = FormShow
  TextHeight = 13
  object mStatus: TMemo
    Left = 0
    Top = 662
    Width = 691
    Height = 33
    TabStop = False
    Align = alBottom
    TabOrder = 0
    ExplicitTop = 644
    ExplicitWidth = 681
  end
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 691
    Height = 662
    ActivePage = TabSheet2
    Align = alClient
    TabOrder = 1
    ExplicitWidth = 681
    ExplicitHeight = 644
    object Principal: TTabSheet
      Caption = 'Principal'
      OnContextPopup = PrincipalContextPopup
      object pnlMenu: TPanel
        Left = 0
        Top = 2
        Width = 676
        Height = 336
        Align = alCustom
        TabOrder = 0
        object pnlConfig: TPanel
          Left = 1
          Top = 1
          Width = 219
          Height = 334
          Align = alLeft
          BevelOuter = bvNone
          BorderWidth = 5
          TabOrder = 0
          object gbConfig: TGroupBox
            Left = 6
            Top = 6
            Width = 213
            Height = 297
            Align = alCustom
            Caption = ' Configura'#231#245'es '
            TabOrder = 0
            object Label5: TLabel
              Left = 11
              Top = 257
              Width = 45
              Height = 13
              Caption = 'Token SH'
            end
            object edCNPJ: TLabeledEdit
              Left = 11
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
              Text = ''
            end
            object edtProtocolo: TLabeledEdit
              Left = 11
              Top = 230
              Width = 190
              Height = 21
              TabStop = False
              EditLabel.Width = 75
              EditLabel.Height = 13
              EditLabel.BiDiMode = bdLeftToRight
              EditLabel.Caption = 'N'#186' do Protocolo'
              EditLabel.ParentBiDiMode = False
              TabOrder = 5
              Text = ''
            end
            object edUF: TLabeledEdit
              Left = 11
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
              Text = ''
            end
            object edtRecibo: TLabeledEdit
              Left = 11
              Top = 190
              Width = 190
              Height = 21
              TabStop = False
              EditLabel.Width = 62
              EditLabel.Height = 13
              EditLabel.BiDiMode = bdLeftToRight
              EditLabel.Caption = 'N'#186' do Recibo'
              EditLabel.ParentBiDiMode = False
              TabOrder = 4
              Text = ''
            end
            object edtChave: TLabeledEdit
              Left = 11
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
              Text = ''
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
              Text = ''
            end
            object edtToken: TEdit
              Left = 11
              Top = 273
              Width = 189
              Height = 21
              TabOrder = 6
            end
          end
        end
        object grpOptions: TGroupBox
          Left = 226
          Top = 8
          Width = 448
          Height = 328
          Align = alCustom
          Caption = ' Opera'#231#245'es '
          TabOrder = 1
          object lblInfo: TLabel
            Left = 247
            Top = 256
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
            Top = 69
            Width = 200
            Height = 25
            Caption = '1.2. Configurar via arquivo .ini'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 2
            OnClick = btnConfigIniClick
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
            TabOrder = 9
            OnClick = btnCancelarCTeClick
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
            TabOrder = 8
            OnClick = btnConsultarCTeClick
          end
          object btnGerarXMLViaDataSet: TButton
            Left = 14
            Top = 189
            Width = 200
            Height = 25
            Caption = '4.2 Gerar XML via DataSet'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 6
            OnClick = btnGerarXMLViaDataSetClick
          end
          object btnGerarXMLViaTx2: TButton
            Left = 14
            Top = 159
            Width = 200
            Height = 25
            Caption = '4.1. Gerar XML via Tx2'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 5
            OnClick = btnGerarXMLViaTx2Click
          end
          object btnVerificarStatus: TBitBtn
            Left = 14
            Top = 129
            Width = 200
            Height = 25
            Caption = '3. Verificar Status do Servi'#231'o'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 4
            OnClick = btnVerificarStatusClick
          end
          object btnLoadConfig: TButton
            Left = 14
            Top = 99
            Width = 200
            Height = 25
            Caption = '2. LoadConfig'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 3
            OnClick = btnLoadConfigClick
          end
          object btnAssinar: TButton
            Left = 14
            Top = 220
            Width = 200
            Height = 25
            Caption = '5.1 Assinar CTe'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 14
            OnClick = btnAssinarClick
          end
          object btnPreverDacte: TButton
            Left = 14
            Top = 251
            Width = 99
            Height = 25
            Caption = '5.2 Prever DACTE'
            Font.Charset = ANSI_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 7
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
            TabOrder = 1
            OnClick = btnConfiguraSHClick
          end
          object grpImpressao: TGroupBox
            Left = 225
            Top = 147
            Width = 214
            Height = 80
            Caption = ' Impress'#227'o do DACTE '
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 10
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
            TabOrder = 0
            Text = 'Selecione o Certificado'
          end
          object btnEditarDacte: TButton
            Left = 119
            Top = 251
            Width = 91
            Height = 25
            Caption = '5.3 Editar DACTE'
            Font.Charset = ANSI_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 11
            OnClick = btnEditarDacteClick
          end
          object chkPaisagem: TCheckBox
            Left = 239
            Top = 233
            Width = 73
            Height = 17
            Caption = 'Paisagem'
            TabOrder = 12
          end
          object btnEnviarEmail: TBitBtn
            Left = 225
            Top = 66
            Width = 215
            Height = 25
            Caption = '7 - Email CTe'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'MS Sans Serif'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 13
            OnClick = btnEnviarEmailClick
          end
          object btnConvert: TButton
            Left = 14
            Top = 282
            Width = 196
            Height = 25
            Caption = 'Converter xml para Dataset'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 15
          end
          object btnSincrono: TButton
            Left = 225
            Top = 39
            Width = 214
            Height = 25
            Caption = '6 - Enviar Sincrono'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 16
            OnClick = btnSincronoClick
          end
          object btnGerarXml: TButton
            Left = 225
            Top = 282
            Width = 208
            Height = 25
            Caption = 'GerarXmlTomadorServico'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = clWindowText
            Font.Height = -11
            Font.Name = 'Tahoma'
            Font.Style = [fsBold]
            ParentFont = False
            TabOrder = 17
            OnClick = btnGerarXmlClick
          end
        end
      end
      object pgCtrlMessages: TPageControl
        Left = 3
        Top = 344
        Width = 676
        Height = 272
        ActivePage = tbSheetMemo
        Align = alCustom
        TabOrder = 1
        TabStop = False
        object tbSheetMemo: TTabSheet
          Caption = 'XML'
          object lblHidden: TLabel
            Left = 0
            Top = 212
            Width = 687
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
          end
          object mOutput: TMemo
            Left = 0
            Top = 0
            Width = 668
            Height = 212
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
            Height = 244
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
    end
    object TabSheet2: TTabSheet
      Caption = 'Outros Recursos'
      ImageIndex = 1
      object Label2: TLabel
        Left = 504
        Top = 27
        Width = 119
        Height = 13
        Caption = 'CONSULTA DESTINADAS'
      end
      object Label3: TLabel
        Left = 154
        Top = 234
        Width = 31
        Height = 13
        Caption = 'Chave'
      end
      object Label4: TLabel
        Left = 446
        Top = 234
        Width = 57
        Height = 13
        Caption = 'Justificativa'
      end
      object btnValidarLoteEnvio: TBitBtn
        Left = 13
        Top = 19
        Width = 116
        Height = 29
        Caption = 'Validar Lote Envio'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 0
        OnClick = btnValidarLoteEnvioClick
      end
      object btnCteOcx: TBitBtn
        Left = 13
        Top = 54
        Width = 170
        Height = 29
        Caption = 'Update Ini (usando OCX)'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 1
        OnClick = btnCteOcxClick
      end
      object btnExportarDacteOcx: TBitBtn
        Left = 13
        Top = 89
        Width = 170
        Height = 29
        Caption = 'Exportar Dacte (usando OCX)'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 2
        OnClick = btnExportarDacteOcxClick
      end
      object btnEnviarDesacordo: TBitBtn
        Left = 13
        Top = 249
        Width = 128
        Height = 25
        Caption = 'Enviar Desacordo'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 3
        OnClick = btnEnviarDesacordoClick
      end
      object mmoRetornoOutros: TMemo
        Left = 13
        Top = 280
        Width = 668
        Height = 281
        TabStop = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlue
        Font.Height = -13
        Font.Name = 'Courier New'
        Font.Style = [fsBold]
        ParentFont = False
        ScrollBars = ssVertical
        TabOrder = 4
      end
      object btnEnviarComprovanteEntrega: TBitBtn
        Left = 13
        Top = 124
        Width = 198
        Height = 25
        Caption = 'Enviar Comprovante Entrega'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 5
        OnClick = btnEnviarComprovanteEntregaClick
      end
      object btnComprovanteEntregaOCX: TBitBtn
        Left = 13
        Top = 155
        Width = 198
        Height = 25
        Caption = 'Enviar Comprovante Entrega OCX'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 6
        OnClick = btnComprovanteEntregaOCXClick
      end
      object btnCancelarComprovanteEntrega: TBitBtn
        Left = 217
        Top = 124
        Width = 210
        Height = 25
        Caption = 'Cancelar Comprovante Entrega'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 7
        OnClick = btnCancelarComprovanteEntregaClick
      end
      object btnCancelarComprovanteEntregaOCX: TBitBtn
        Left = 217
        Top = 155
        Width = 210
        Height = 25
        Caption = 'Cancelar Comprovante Entrega OCX'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 8
        OnClick = btnCancelarComprovanteEntregaOCXClick
      end
      object EnviarEPEC: TButton
        Left = 279
        Top = 84
        Width = 75
        Height = 25
        Caption = 'EnviarEPEC'
        TabOrder = 9
        OnClick = EnviarEPECClick
      end
      object btnAssinarEPEC: TButton
        Left = 279
        Top = 53
        Width = 75
        Height = 25
        Caption = 'AssinarEPEC'
        TabOrder = 10
        OnClick = btnAssinarEPECClick
      end
      object btnMontarEPEC: TButton
        Left = 279
        Top = 22
        Width = 75
        Height = 25
        Caption = 'MontarEPEC'
        TabOrder = 11
        OnClick = btnMontarEPECClick
      end
      object Button1: TButton
        Left = 519
        Top = 52
        Width = 114
        Height = 26
        Caption = 'ConsultaDistribuicao'
        TabOrder = 12
        OnClick = Button1Click
      end
      object Button2: TButton
        Left = 559
        Top = 84
        Width = 74
        Height = 25
        Caption = 'TratarXMLret'
        TabOrder = 13
        OnClick = Button2Click
      end
      object Edit1: TEdit
        Left = 154
        Top = 253
        Width = 273
        Height = 21
        TabOrder = 14
      end
      object Edit2: TEdit
        Left = 446
        Top = 253
        Width = 131
        Height = 21
        TabOrder = 15
      end
    end
    object Insucesso: TTabSheet
      Caption = 'Insucesso'
      ImageIndex = 2
      object Label6: TLabel
        Left = 56
        Top = 29
        Width = 53
        Height = 13
        Caption = 'Chave CTE'
      end
      object Label7: TLabel
        Left = 24
        Top = 62
        Width = 85
        Height = 13
        Caption = 'Data hora Evento'
      end
      object TLabel
        Left = 40
        Top = 89
        Width = 69
        Height = 13
        Caption = 'Num Protocolo'
      end
      object Label8: TLabel
        Left = 12
        Top = 119
        Width = 97
        Height = 13
        Caption = 'Data hora Tentativa'
      end
      object Label9: TLabel
        Left = 20
        Top = 149
        Width = 95
        Height = 13
        Caption = 'Numero tentativas*'
      end
      object Label10: TLabel
        Left = 28
        Top = 179
        Width = 81
        Height = 13
        Caption = 'Motivo insucesso'
      end
      object Label11: TLabel
        Left = 52
        Top = 209
        Width = 63
        Height = 13
        Caption = 'Justificativa*'
      end
      object Label12: TLabel
        Left = 70
        Top = 242
        Width = 45
        Height = 13
        Caption = 'Latitude*'
      end
      object Label13: TLabel
        Left = 62
        Top = 269
        Width = 53
        Height = 13
        Caption = 'Longitude*'
      end
      object Label14: TLabel
        Left = 46
        Top = 299
        Width = 63
        Height = 13
        Caption = 'Path iimagem'
      end
      object Label15: TLabel
        Left = 50
        Top = 329
        Width = 59
        Height = 13
        Caption = 'Lista chaves'
      end
      object Label16: TLabel
        Left = 24
        Top = 359
        Width = 86
        Height = 13
        Caption = 'Sequencia evento'
      end
      object Label17: TLabel
        Left = 21
        Top = 512
        Width = 88
        Height = 13
        Caption = 'Prot aut insucesso'
      end
      object Label18: TLabel
        Left = 136
        Top = 389
        Width = 108
        Height = 13
        Caption = '*Campos opcionais'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label19: TLabel
        Left = 512
        Top = 504
        Width = 3
        Height = 13
        Caption = ' '
      end
      object Label20: TLabel
        Left = 136
        Top = 583
        Width = 182
        Height = 13
        Caption = 'Para cancelamamento informar:'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Label21: TLabel
        Left = 136
        Top = 598
        Width = 466
        Height = 13
        Caption = 
          'Chave CTE, Data hora Evento, Num Protocolo, Prot aut insucesso, ' +
          'sequencia evento'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Tahoma'
        Font.Style = [fsBold]
        ParentFont = False
      end
      object Button3: TButton
        Left = 136
        Top = 408
        Width = 113
        Height = 25
        Caption = 'Enviar Insucesso'
        TabOrder = 0
        OnClick = Button3Click
      end
      object edtChaveInsucesso: TEdit
        Left = 136
        Top = 29
        Width = 321
        Height = 21
        TabOrder = 1
      end
      object edtDhEventoInsucesso: TEdit
        Left = 136
        Top = 59
        Width = 233
        Height = 21
        TabOrder = 2
      end
      object edtProtInsucesso: TEdit
        Left = 136
        Top = 89
        Width = 233
        Height = 21
        TabOrder = 3
      end
      object edtDhTentativa: TEdit
        Left = 136
        Top = 119
        Width = 233
        Height = 21
        TabOrder = 4
      end
      object edtNumTentInsucesso: TEdit
        Left = 136
        Top = 149
        Width = 121
        Height = 21
        TabOrder = 5
      end
      object edtTpMotivoInsucesso: TEdit
        Left = 136
        Top = 179
        Width = 273
        Height = 21
        TabOrder = 6
      end
      object edtJustMotInsucesso: TEdit
        Left = 136
        Top = 209
        Width = 273
        Height = 21
        TabOrder = 7
      end
      object edtLatInsucesso: TEdit
        Left = 136
        Top = 239
        Width = 121
        Height = 21
        TabOrder = 8
      end
      object edtlongInsucesso: TEdit
        Left = 136
        Top = 269
        Width = 121
        Height = 21
        TabOrder = 9
      end
      object edtPathInsucesso: TEdit
        Left = 136
        Top = 299
        Width = 121
        Height = 21
        TabOrder = 10
      end
      object edtListaChavesInsucesso: TEdit
        Left = 136
        Top = 329
        Width = 121
        Height = 21
        TabOrder = 11
      end
      object edtSeqInsucesso: TEdit
        Left = 136
        Top = 359
        Width = 121
        Height = 21
        TabOrder = 12
        Text = '01'
      end
      object btnGeraDataHora: TButton
        Left = 375
        Top = 67
        Width = 58
        Height = 16
        Caption = 'Gerar'
        TabOrder = 13
        OnClick = btnGeraDataHoraClick
      end
      object btnCancelarInsucesso: TButton
        Left = 136
        Top = 552
        Width = 113
        Height = 25
        Caption = 'Cancelar Insucesso'
        TabOrder = 14
        OnClick = btnCancelarInsucessoClick
      end
      object edtProtAutInsucesso: TEdit
        Left = 136
        Top = 512
        Width = 273
        Height = 21
        TabOrder = 15
        OnChange = edtProtAutInsucessoChange
      end
      object mmInsuc: TMemo
        Left = 263
        Top = 236
        Width = 402
        Height = 245
        TabOrder = 16
      end
    end
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
  object spdCTeDataSet1: TspdCTeDataSet
    ConfigSection = 'XMLENVIO'
    Versao = '3.00a'
    Left = 408
    Top = 616
  end
end
