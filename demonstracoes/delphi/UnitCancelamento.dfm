object Form2: TForm2
  Left = 785
  Top = 178
  Width = 470
  Height = 502
  Caption = 'Form2'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object lbJustificativa: TLabel
    Left = 13
    Top = 163
    Width = 126
    Height = 13
    Caption = 'Justificativa Cancelamento'
  end
  object lblDataHora: TLabel
    Left = 14
    Top = 111
    Width = 58
    Height = 13
    Caption = 'Data e Hora'
  end
  object lblChaveCanc: TLabel
    Left = 10
    Top = 12
    Width = 57
    Height = 13
    Caption = 'Chave CT-e'
  end
  object lblProtocolo: TLabel
    Left = 9
    Top = 63
    Width = 45
    Height = 13
    Caption = 'Protocolo'
  end
  object lblSequencia: TLabel
    Left = 291
    Top = 63
    Width = 88
    Height = 13
    Caption = 'Sequencia Evento'
  end
  object btnCancela: TButton
    Left = 102
    Top = 215
    Width = 245
    Height = 23
    Caption = 'Cancela CT-e'
    TabOrder = 0
    OnClick = btnCancelaClick
  end
  object mmXmlCanc: TMemo
    Left = 13
    Top = 245
    Width = 437
    Height = 209
    Lines.Strings = (
      'mmXmlCanc')
    TabOrder = 1
  end
  object edtJustificativa: TEdit
    Left = 15
    Top = 184
    Width = 433
    Height = 21
    TabOrder = 2
  end
  object edtChave: TEdit
    Left = 10
    Top = 34
    Width = 437
    Height = 21
    TabOrder = 3
  end
  object edtProtocolo: TEdit
    Left = 10
    Top = 81
    Width = 199
    Height = 21
    TabOrder = 4
  end
  object edtDataHora: TEdit
    Left = 11
    Top = 133
    Width = 127
    Height = 21
    TabOrder = 5
  end
  object btnHora: TButton
    Left = 151
    Top = 133
    Width = 68
    Height = 20
    Caption = 'Data\Hora'
    TabOrder = 6
    OnClick = btnHoraClick
  end
  object cbbSequencia: TComboBox
    Left = 291
    Top = 81
    Width = 155
    Height = 21
    ItemHeight = 13
    TabOrder = 7
    Items.Strings = (
      '1'
      '2'
      '3'
      '4'
      '5')
  end
end
