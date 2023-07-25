unit UUtils;

interface

uses Controls, Messages, Forms, StdCtrls, IniFiles, Classes;

procedure EnterAsTab_KeyPress(SelfForm: TForm; var Key: Char; btnOK: TButton);
procedure CarregarValoresCamposForm(SelfForm: TForm);
procedure SalvarValoresCamposForm(SelfForm: TForm);

implementation

uses SysUtils;

type
  TOperacaoCamposForm = (ocfCarregar, ocfSalvar);

procedure EnterAsTab_KeyPress(SelfForm: TForm; var Key: Char; btnOK: TButton);
begin
  if not (SelfForm.ActiveControl is TMemo) then  // Memos aceitam Enter
  begin
    //verifica se a tecla pressionada é o ENTER (#$D ou #13)
    if key = #$D then
    begin
      //se for, passa o foco para o próximo campo, zerando o valor da variável Key
      Key:= #0;
      SelfForm.Perform(WM_NEXTDLGCTL, 0, 0);
    end;
    // Se for Ctrl+Enter já dá OK
    if key = #$A then
      btnOk.Click;
  end;
end;

procedure CarregarSalvarValoresCamposForm(SelfForm: TForm; Operacao: TOperacaoCamposForm);
var
  i: Integer;
  _ini: TIniFile;
  _edit: TCustomEdit;
begin
  _ini := TIniFile.Create(GetCurrentDir + '\Exemplo.ini');
  try
    for i := 0 to SelfForm.ComponentCount - 1 do
    begin
      if SelfForm.Components[i] is TCustomEdit then
      begin
        _edit := (SelfForm.Components[i] as TCustomEdit);
        case Operacao of
          ocfCarregar:
          begin
            if SelfForm.Components[i].Name = 'edtNumCte' then
              _edit.Text := IntToStr(StrToInt(_ini.ReadString(SelfForm.Name, SelfForm.Components[i].Name, '0'))+1);

            if _edit.Text = '' then
                _edit.Text := _ini.ReadString(SelfForm.Name, SelfForm.Components[i].Name, '');
          end;
          ocfSalvar:
          begin
            if _edit.Text <> '' then
              _ini.WriteString(SelfForm.Name, SelfForm.Components[i].Name, _edit.Text);
          end;
        end;
      end;
    end;
  finally
    _ini.Free;
  end;
end;

procedure CarregarValoresCamposForm(SelfForm: TForm);
begin
  CarregarSalvarValoresCamposForm(SelfForm, ocfCarregar);
end;

procedure SalvarValoresCamposForm(SelfForm: TForm);
begin
  CarregarSalvarValoresCamposForm(SelfForm, ocfSalvar);
end;

end.
