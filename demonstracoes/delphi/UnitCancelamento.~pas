unit UnitCancelamento;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Mask, DBCtrls, ExtCtrls, spdCustomCTe,UnitDemonstracao,
  IdBaseComponent, IdComponent, IdUDPBase, IdUDPClient, IdSNTP;

type
  TForm2 = class(TForm)
    btnCancela: TButton;
    mmXmlCanc: TMemo;
    edtJustificativa: TEdit;
    edtChave: TEdit;
    edtProtocolo: TEdit;
    edtDataHora: TEdit;
    btnHora: TButton;
    lbJustificativa: TLabel;
    lblDataHora: TLabel;
    lblChaveCanc: TLabel;
    lblProtocolo: TLabel;
    cbbSequencia: TComboBox;
    lblSequencia: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btnCancelaClick(Sender: TObject);
    procedure btnHoraClick(Sender: TObject);
  private

  public
    { Public declarations }
  end;

var
  Form2: TForm2;
  //Form1 := TForm1.Create(Self);


implementation

{$R *.dfm}

procedure TForm2.FormCreate(Sender: TObject);
begin
   // Form1.FormCreate();
end;

procedure TForm2.btnCancelaClick(Sender: TObject);
begin
   mmXmlCanc.Text :=  Form1.CTe.StatusDoServico();
  Form1.CTe.CancelarCTEvento(edtChave.Text,edtProtocolo.Text,edtJustificativa.Text,edtDataHora.Text,cbbSequencia.Text)
end;


procedure TForm2.btnHoraClick(Sender: TObject);
begin
    edtDataHora.Text := FormatDateTime('YYYY-MM-DD"T"HH:NN:SS"-03:00"', Now);
end;

end.
