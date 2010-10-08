[Setup]
AppID={{82135C39-AE73-476D-B8F7-2F98679A81D8}
AppName=Manga Downloader
AppVerName=Manga Downloader
AppPublisher=r15ch13
AppPublisherURL=http://www.r15ch13.de/
AppSupportURL=http://www.r15ch13.de/
AppUpdatesURL=http://www.r15ch13.de/
DefaultDirName={pf}\Manga Downloader
DefaultGroupName=Manga Downloader
DisableProgramGroupPage=true
OutputDir=J:\My Dropbox\VB.net\MangaDownloader\MangaDownloader\bin\Release\publish
Compression=lzma
SolidCompression=true
VersionInfoCopyright=Copyright © 2009 Richard Kuhnt <r15ch13>
VersionInfoProductName=Manga Downloader
AppCopyright=Copyright © 2009 Richard Kuhnt <r15ch13>
WizardImageFile=compiler:wizmodernimage-is.bmp
WizardSmallImageFile=compiler:wizmodernsmallimage-is.bmp

; Versionszeug
VersionInfoVersion=1.0.4.0
VersionInfoProductVersion=1.0.4.0
OutputBaseFilename=MangaDownloaderSetup_v1.0.4.0
AppVersion=1.0.4.0

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}

[Files]
Source: MangaDownloader.exe; DestDir: {app}; Flags: ignoreversion
Source: wget\wget.exe; DestDir: {app}\wget
Source: wget\License.txt; DestDir: {app}\wget
Source: wget\libeay32.dll; DestDir: {app}\wget
Source: wget\libiconv2.dll; DestDir: {app}\wget
Source: wget\libintl3.dll; DestDir: {app}\wget
Source: wget\libssl32.dll; DestDir: {app}\wget
[Icons]
Name: {group}\Manga Downloader; Filename: {app}\MangaDownloader.exe; IconIndex: 0; WorkingDir: {app}; IconFilename: {app}\MangaDownloader.exe
Name: {group}\Deinstallieren; Filename: {uninstallexe}; WorkingDir: {app}
Name: {commondesktop}\Manga Downloader; Filename: {app}\MangaDownloader.exe; Tasks: desktopicon; WorkingDir: {app}; IconIndex: 0; IconFilename: {app}\MangaDownloader.exe
Name: {commondesktop}\Mangas; Filename: {app}\Mangas; Tasks: desktopicon; WorkingDir: {app}

[Languages]
Name: german; MessagesFile: compiler:Languages\German.isl

[UninstallDelete]
Name: {app}\MangaDownloader.exe; Type: files
Name: {app}\wget; Type: filesandordirs
Name: {app}\wget.log; Type: files
[_ISTool]
OutputExeFilename=J:\My Dropbox\VB.net\MangaDownloader\MangaDownloader\bin\Release\publish\MangaDownloaderSetup_v1.0.4.0.exe
[Dirs]
Name: {app}\Mangas
