object frmCancelamentoCTe: TfrmCancelamentoCTe
  Left = 508
  Top = 157
  BorderIcons = []
  BorderStyle = bsDialog
  Caption = 'Cancelamento de CTe'
  ClientHeight = 373
  ClientWidth = 299
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  KeyPreview = True
  OldCreateOrder = False
  Position = poScreenCenter
  OnKeyPress = FormKeyPress
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object pgcDados: TPageControl
    Left = 0
    Top = 0
    Width = 299
    Height = 329
    ActivePage = tbsDadosCancelamento
    Align = alTop
    TabOrder = 0
    object tbsDadosCancelamento: TTabSheet
      Caption = 'Dados para Cancelamento de CTe'
      ImageIndex = 2
      object Label2: TLabel
        Left = 0
        Top = 285
        Width = 107
        Height = 13
        Caption = '* Campos obrigat'#243'rios'
      end
      object lblJustificativa: TLabel
        Left = 3
        Top = 91
        Width = 178
        Height = 13
        Caption = 'Justificativa (m'#237'nimo 15 caracteres) *'
      end
      object edtChave: TLabeledEdit
        Left = 3
        Top = 24
        Width = 273
        Height = 21
        EditLabel.Width = 55
        EditLabel.Height = 13
        EditLabel.Caption = 'N'#186' Chave *'
        TabOrder = 0
      end
      object edtProtocolo: TLabeledEdit
        Left = 3
        Top = 64
        Width = 273
        Height = 21
        EditLabel.Width = 69
        EditLabel.Height = 13
        EditLabel.Caption = 'N'#186' Protocolo *'
        TabOrder = 1
      end
      object mJustificativa: TMemo
        Left = 3
        Top = 107
        Width = 273
        Height = 172
        TabOrder = 2
      end
    end
  end
  object btnOk: TButton
    Left = 133
    Top = 340
    Width = 75
    Height = 25
    Caption = 'Ok'
    ModalResult = 1
    TabOrder = 1
    OnClick = btnOkClick
  end
  object btnCancelar: TButton
    Left = 214
    Top = 340
    Width = 75
    Height = 25
    Cancel = True
    Caption = 'Cancelar'
    ModalResult = 2
    TabOrder = 2
  end
end
