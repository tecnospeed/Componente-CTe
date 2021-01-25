object frmCTePrincipal: TfrmCTePrincipal
  Left = 594
  Top = 168
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'Demonstra'#231#227'o CTe'
  ClientHeight = 670
  ClientWidth = 612
  Color = clMenu
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poMainFormCenter
  OnCreate = FormCreate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object pcSuperior: TPageControl
    Left = 0
    Top = 0
    Width = 612
    Height = 339
    ActivePage = tsAutorizacao
    Align = alTop
    TabOrder = 0
    object tsAutorizacao: TTabSheet
      Caption = 'Autoriza'#231#245'es e Consultas'
      object GroupBox9: TGroupBox
        Left = 0
        Top = 0
        Width = 205
        Height = 311
        Align = alLeft
        Caption = 'Configura'#231#245'es'
        TabOrder = 0
        object Label3: TLabel
          Left = 12
          Top = 56
          Width = 71
          Height = 13
          Caption = 'CNPJ Emitente'
        end
        object Label5: TLabel
          Left = 12
          Top = 16
          Width = 14
          Height = 13
          Caption = 'UF'
        end
        object Label12: TLabel
          Left = 12
          Top = 95
          Width = 91
          Height = 13
          Caption = 'Inscri'#231#227'o Municipal'
        end
        object Label14: TLabel
          Left = 12
          Top = 134
          Width = 31
          Height = 13
          Caption = 'Chave'
        end
        object Label15: TLabel
          Left = 12
          Top = 174
          Width = 34
          Height = 13
          Caption = 'Recibo'
        end
        object edtCNPJEmitente: TEdit
          Left = 10
          Top = 72
          Width = 185
          Height = 21
          TabOrder = 0
        end
        object edtUF: TEdit
          Left = 10
          Top = 32
          Width = 185
          Height = 21
          TabOrder = 1
        end
        object edtInscMunicipal: TEdit
          Left = 10
          Top = 111
          Width = 185
          Height = 21
          TabOrder = 2
        end
        object edtChave: TEdit
          Left = 10
          Top = 150
          Width = 185
          Height = 21
          TabOrder = 3
        end
        object edtRecibo: TEdit
          Left = 10
          Top = 190
          Width = 185
          Height = 21
          ReadOnly = True
          TabOrder = 4
        end
        object GroupBox1: TGroupBox
          Left = 2
          Top = 212
          Width = 201
          Height = 97
          Align = alBottom
          Caption = 'Dados para Chave da CTe'
          TabOrder = 5
          object Label1: TLabel
            Left = 10
            Top = 15
            Width = 35
            Height = 13
            Caption = 'Modelo'
          end
          object Label7: TLabel
            Left = 59
            Top = 15
            Width = 24
            Height = 13
            Caption = 'S'#233'rie'
          end
          object Label8: TLabel
            Left = 110
            Top = 56
            Width = 53
            Height = 13
            Caption = 'N'#186' do CT-e'
          end
          object Label9: TLabel
            Left = 10
            Top = 55
            Width = 81
            Height = 13
            Caption = 'C'#243'digo (8 digitos)'
          end
          object Label11: TLabel
            Left = 298
            Top = 51
            Width = 61
            Height = 13
            Caption = 'Identifica'#231#227'o'
          end
          object edtModelo: TEdit
            Left = 10
            Top = 31
            Width = 41
            Height = 21
            ReadOnly = True
            TabOrder = 0
            Text = '57'
            OnKeyPress = SomenteNumero
          end
          object edtSerie: TEdit
            Left = 59
            Top = 31
            Width = 41
            Height = 21
            ReadOnly = True
            TabOrder = 1
            Text = '0'
            OnKeyPress = SomenteNumero
          end
          object edtNumeroCTe: TEdit
            Left = 110
            Top = 72
            Width = 75
            Height = 21
            ReadOnly = True
            TabOrder = 2
            Text = '1001'
            OnKeyPress = SomenteNumero
          end
          object edtCodigo: TEdit
            Left = 9
            Top = 71
            Width = 95
            Height = 21
            MaxLength = 8
            ReadOnly = True
            TabOrder = 3
            Text = '12457832'
            OnKeyPress = SomenteNumero
          end
        end
      end
      object GroupBox15: TGroupBox
        Left = 207
        Top = 0
        Width = 397
        Height = 311
        Align = alRight
        Caption = 'Opera'#231#245'es'
        TabOrder = 1
        object Label4: TLabel
          Left = 10
          Top = 15
          Width = 27
          Height = 13
          Caption = 'CNPJ'
        end
        object Label6: TLabel
          Left = 198
          Top = 14
          Width = 31
          Height = 13
          Caption = 'Token'
        end
        object lbl1: TLabel
          Left = 11
          Top = 56
          Width = 50
          Height = 13
          Caption = 'Certificado'
        end
        object sbPreencherComp: TSpeedButton
          Left = 6
          Top = 168
          Width = 197
          Height = 32
          Caption = '2 - Preencher Componente'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbPreencherCompClick
        end
        object sbGerarTX2: TSpeedButton
          Left = 6
          Top = 200
          Width = 197
          Height = 32
          Caption = '3 - Gerar XML por TX2'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbGerarTX2Click
        end
        object sbEnviarCCe: TSpeedButton
          Left = 207
          Top = 232
          Width = 183
          Height = 31
          Caption = 'Enviar CCe'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbEnviarCCeClick
        end
        object sbAssinar: TSpeedButton
          Left = 6
          Top = 233
          Width = 197
          Height = 30
          Caption = '4 - Assinar XML'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbAssinarClick
        end
        object sbEnviar: TSpeedButton
          Left = 207
          Top = 138
          Width = 182
          Height = 30
          Caption = '5 - Enviar'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbEnviarClick
        end
        object lblProducao: TLabel
          Left = 212
          Top = 293
          Width = 177
          Height = 16
          Caption = 'Ambiente de PRODU'#199#195'O'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clRed
          Font.Height = -13
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          Visible = False
        end
        object Label13: TLabel
          Left = 12
          Top = 94
          Width = 45
          Height = 13
          Caption = 'Protocolo'
        end
        object sbConsultaLote: TSpeedButton
          Left = 207
          Top = 168
          Width = 182
          Height = 32
          Caption = 'Consultar Por Chave'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbConsultaLoteClick
        end
        object sbConsultarRecibo: TSpeedButton
          Left = 207
          Top = 200
          Width = 182
          Height = 32
          Caption = 'Consultar N'#186' do Recibo'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbConsultarReciboClick
        end
        object sbConfigINI: TSpeedButton
          Left = 6
          Top = 136
          Width = 197
          Height = 32
          Caption = '1 - Configurar Arquivo INI'
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clWindowText
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = [fsBold]
          ParentFont = False
          OnClick = sbConfigINIClick
        end
        object EdtCNPJ: TEdit
          Left = 10
          Top = 31
          Width = 185
          Height = 21
          TabOrder = 0
        end
        object edtToken: TEdit
          Left = 198
          Top = 30
          Width = 191
          Height = 21
          ReadOnly = True
          TabOrder = 1
        end
        object cbCertificado: TComboBox
          Left = 11
          Top = 71
          Width = 379
          Height = 21
          ItemHeight = 13
          TabOrder = 2
          Text = '\'
          OnChange = cbCertificadoChange
        end
        object edtProtocolo: TEdit
          Left = 11
          Top = 109
          Width = 378
          Height = 21
          ReadOnly = True
          TabOrder = 3
        end
      end
    end
    object tsImpressao: TTabSheet
      Caption = 'Impress'#227'o'
      ImageIndex = 1
      object SpeedButton1: TSpeedButton
        Left = 24
        Top = 15
        Width = 149
        Height = 21
        Caption = 'Imprimir DACTE'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        OnClick = SpeedButton1Click
      end
    end
  end
  object pcProcessos: TPageControl
    Left = 0
    Top = 338
    Width = 612
    Height = 332
    ActivePage = tsXMLformatado
    Align = alBottom
    TabOrder = 1
    object tsXMLformatado: TTabSheet
      Caption = 'XML Envio'
      ImageIndex = 1
      object mmXMLEnvio: TMemo
        Left = 0
        Top = 0
        Width = 604
        Height = 304
        Align = alClient
        ReadOnly = True
        TabOrder = 0
        OnKeyDown = mmXMLEnvioKeyDown
      end
    end
    object tsXML: TTabSheet
      Caption = 'XML'
      object GroupBox6: TGroupBox
        Left = 0
        Top = 0
        Width = 604
        Height = 304
        Align = alClient
        Caption = 'XML gerado'
        TabOrder = 0
        object mmXML: TMemo
          Left = 2
          Top = 15
          Width = 600
          Height = 287
          Align = alClient
          TabOrder = 0
        end
      end
    end
    object tsXMLRetorno: TTabSheet
      Caption = 'XML Retorno'
      ImageIndex = 5
      object GroupBox8: TGroupBox
        Left = 0
        Top = 0
        Width = 604
        Height = 304
        Align = alClient
        Caption = 'XML de Retorno da Consulta'
        TabOrder = 0
        object mmXMLRetorno: TMemo
          Left = 2
          Top = 15
          Width = 600
          Height = 287
          Align = alClient
          TabOrder = 0
        end
      end
    end
  end
  object OpenDialog: TOpenDialog
    Title = 'Selecionar TX2'
    Left = 424
  end
end
