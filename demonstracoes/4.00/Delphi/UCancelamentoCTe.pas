unit UCancelamentoCTe;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, StdCtrls, ExtCtrls, Mask, UUtils;

type
  TfrmCancelamentoCTe = class(TForm)
    pgcDados: TPageControl;
    btnOk: TButton;
    btnCancelar: TButton;
    tbsDadosCancelamento: TTabSheet;
    edtChave: TLabeledEdit;
    edtProtocolo: TLabeledEdit;
    Label2: TLabel;
    mJustificativa: TMemo;
    lblJustificativa: TLabel;
    procedure btnOkClick(Sender: TObject);
    procedure FormKeyPress(Sender: TObject; var Key: Char);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

implementation

{$R *.dfm}

{ TfrmDados }

procedure TfrmCancelamentoCTe.btnOkClick(Sender: TObject);
begin
  ModalResult := mrNone;
  if tbsDadosCancelamento.TabVisible then
  begin
    if (Trim(mJustificativa.Lines.Text) = '') or (Length(mJustificativa.Lines.Text) < 15)  then 
    begin
      mJustificativa.SetFocus;
      raise Exception.Create('Campo justificativa está vazio ou com quantidade de caracteres inferior à 15.');
    end;
    
    if Trim(edtChave.Text) = '' then
    begin
      edtChave.SetFocus;
      raise Exception.Create('Campo Chave não foi preenchido');
    end;

    if Trim(edtProtocolo.Text) = '' then
    begin
      edtProtocolo.SetFocus;
      raise Exception.Create('Campo Protocolo não foi preenchido');
    end;

    if Trim(mJustificativa.Lines.Text) = '' then
    begin
      mJustificativa.SetFocus;
      raise Exception.Create('Campo Justificativa não foi preenchido');
    end;
  end;

  ModalResult := mrOk;
end;

procedure TfrmCancelamentoCTe.FormKeyPress(Sender: TObject; var Key: Char);
begin
  EnterAsTab_KeyPress(Self, Key, btnOk);
end;

procedure TfrmCancelamentoCTe.FormShow(Sender: TObject);
begin
  edtChave.SetFocus;
end;

end.
