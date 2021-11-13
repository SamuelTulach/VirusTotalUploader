
#define VtuAppName "VirusTotal Uploader"
#define VtuAppVersion "0.1.8"
#define VtuAppPublisher "Samuel Tulach"
#define VtuAppURL "https://github.com/SamuelTulach/VirusTotalUploader"
#define VtuAppExeName "uploader.exe"

[Setup]
AppId={{51FB250B-1C78-4B32-86E8-7710231434B0}
AppName={#VtuAppName}
AppVersion={#VtuAppVersion}
;AppVerName={#VtuAppName} {#VtuAppVersion}
AppPublisher={#VtuAppPublisher}
AppPublisherURL={#VtuAppURL}
AppSupportURL={#VtuAppURL}
AppUpdatesURL={#VtuAppURL}
DefaultDirName={autopf}\{#VtuAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=output
OutputBaseFilename=uploader
SetupIconFile=uploader\uploader\icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Dirs]
Name: "{app}"; Permissions: users-full

[Files]
Source: "uploader\uploader\build\rel\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "localization\*"; DestDir: "{app}\local"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#VtuAppName}"; Filename: "{app}\{#VtuAppExeName}"

[Registry]
Root: "HKCR"; Subkey: "*\shell\Upload to VirusTotal"; ValueType: none; ValueName: ""; ValueData: ""; Flags: uninsdeletekey
Root: "HKCR"; Subkey: "*\shell\Upload to VirusTotal\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#VtuAppExeName}"" ""%1"""; Flags: uninsdeletekey

[Run]
Filename: "{app}\{#VtuAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(VtuAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

