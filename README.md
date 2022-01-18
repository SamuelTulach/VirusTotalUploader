<div><p align="center"><img src="https://raw.githubusercontent.com/firepacket/VirusTotalUploader/master/uploader/uploader/icon.ico" width="75" height="75" /></p><h3 align="center">VirusTotal Uploader UPGRADED</h3></div>
<p align="center">Open-source desktop uploader for VirusTotal. New Upgrades: <br/>
<i><b><u>Single EXE, Portable Executable, No extra files, Localized, No API Key Required!, No Setup, Right-Click Context Menu Support!</u></b></i>
</p>
<p align="center">

#### Download (<a href="https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net46-web-installer"><img alt="GitHub release" src="https://img.shields.io/badge/Requires-.NET%20Framework%204.6%20(or later)-blue"></a>)
Please go to [releases page](https://github.com/firepacket/VirusTotalUploader/releases) to download <b>the single .exe file</b>!

#### How to get API key
<b>If you don't have an API key, the application will still work using a different method!</b>
But if you get one, your experience will be better! All you need to do is to go to [VirusTotal official page](https://www.virustotal.com/), create profile and copy your key into Settings.<br/>


<img src="assets/1.gif" />

#### How to use
Open the app and drag and drop file into the app and voila! Click the "Settings" button to configure your API key, Language, Auto-Upload, and Context Menu Support. Then you can right-click any file and select "Virus Total Uploader" to get an instant reading along with Auto Upload!</br></br>
Click "Reset" to uninstall if you want to move the .exe, or you can move it, click "Reset" and "Save" again for the Context Menu.
</br></br>
<img src="assets/2.gif" />

#### Various graphical tweaks
Added corrected language, improved localization, made sure that GUI fits everything properly. Localization files are now built into the application.

#### Settings
Using .NET built-in settings for maximum portability. 

#### License
This project is licensed under GPLv3 and it's libraries under their license. Please check both [LICENSE.txt](LICENSE.txt) and [LICENSE_3rd.txt](LICENSE_3rd.txt).

<br/><br/><br/>
#### New Undocumented Feature
If you create a String value in the registry *HKEY_LOCAL_MACHINE\SOFTWARE\Classes\*\shell\Virus Total Uploader\* name it "Browser" and set the value to a different browser .exe path (no quotes) it will use that browser instead<br/>
<b>NOTE: You can only do this if you have enabled Context Menu Support!</b> It was to just keep things tidy for a feature most people won't use, just for me.