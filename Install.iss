#include <idp.iss>

[Setup]
AppName=Placeholder Generator
AppVersion=1.0.0.0
AppPublisher=Iteratif SARL
AppPublisherURL=www.iteratif.fr
AppContact=olivier.bugalotto@iteratif.fr
VersionInfoVersion=1.0.0.0
VersionInfoCompany=Iteratif SARL
VersionInfoProductName=Placeholder Generator
VersionInfoProductVersion=1.0.0.0
VersionInfoProductTextVersion=1.0.0.0
AppId={{86ECD3BC-52DA-4C51-BB4B-7A2A18F02980}
DefaultDirName={pf}\Iteratif\PlaceholderGenerator
UninstallDisplayName=Placeholder Generator
UninstallDisplayIcon={app}\PlaceholderGenerator.exe
ArchitecturesInstallIn64BitMode=x64
OutputBaseFilename=install

[Files]
Source: "bin\Release\PlaceholderGenerator.exe"; DestDir: "{app}"; DestName: "PlaceholderGenerator.exe"; Flags: 64bit
             
[Run]
Filename: "{app}\PlaceholderGenerator.exe"; Flags: postinstall nowait

[Code]
function Framework45IsNotInstalled(): Boolean;
var
  bSuccess: Boolean;
  regVersion: Cardinal;
begin
  Result := True;

  bSuccess := RegQueryDWordValue(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', regVersion);
  if (True = bSuccess) and (regVersion >= 378389) then begin
    Result := False;
  end;
end;

procedure InitializeWizard;
begin
  if Framework45IsNotInstalled() then
  begin
    idpAddFile('http://go.microsoft.com/fwlink/?LinkId=397707', ExpandConstant('{tmp}\NetFrameworkInstaller.exe'));
    idpDownloadAfter(wpReady);
  end;
end;

procedure InstallFramework;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing .NET Framework 4.5.2. This might take a few minutes…';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
    if not Exec(ExpandConstant('{tmp}\NetFrameworkInstaller.exe'), '/passive /norestart', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
    begin
      MsgBox('.NET installation failed with code: ' + IntToStr(ResultCode) + '.', mbError, MB_OK);
    end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;

    DeleteFile(ExpandConstant('{tmp}\NetFrameworkInstaller.exe'));
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  case CurStep of
    ssPostInstall:
      begin
        if Framework45IsNotInstalled() then
        begin
          InstallFramework();
        end;
      end;
  end;
end;
