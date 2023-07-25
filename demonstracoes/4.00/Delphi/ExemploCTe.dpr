program ExemploCTe;

uses
  Forms,
  UCancelamentoCTe in 'UCancelamentoCTe.pas' {frmCancelamentoCTe},
  UExemplo in 'UExemplo.pas'; {FrmExemplo}

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFrmExemplo, FrmExemplo);
  Application.Run;
end.
