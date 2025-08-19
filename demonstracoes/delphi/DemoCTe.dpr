program DemoCTe;

uses
  Forms,
  UnitDemonstracao in 'UnitDemonstracao.pas' {Form1},
  UnitCancelamento in 'UnitCancelamento.pas' {Form2},
  DataSetsForm in '..\..\..\..\..\CT-e D7\Demo-CT-e-D7\DataSetsForm.pas' {DataSetsSelect};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TDataSetsSelect, DataSetsSelect);
  Application.Run;
end.
