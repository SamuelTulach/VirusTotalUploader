# VirusTotal Uploader
![screenshot](https://i.imgur.com/AoYrHye.png)

VirusTotal Uploader is open-source application written in C# and WinForms for uploading files to VirusTotal service. It has a great and simple design with drag and drop interface. It is easy to use and you can avoid many viruses with it!

[![Join the chat at https://gitter.im/VirusTotalUploader/Lobby](https://badges.gitter.im/VirusTotalUploader/Lobby.svg)](https://gitter.im/VirusTotalUploader/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) [![Build status](https://ci.appveyor.com/api/projects/status/ulpfhv1v32bhwaju?svg=true)](https://ci.appveyor.com/project/SamuelTulach/virustotaluploader)



## Warning
This is not officially supported application. It was created, because official VirusTotal desktop app is unmaintained. If you are afraid you can build it from source by yourself. Also please don´t download it from any 3d party sites.

## Download
Please go to [releases page](https://github.com/SamuelTulach/VirusTotalUploader/releases) to download compiled app and installer. **Don´t forget to star the project!**

## How to get API key
It is really simple! All you need to do is to go to [VirusTotal official page](https://www.virustotal.com/), create profile and copy your key.

![getapikey](https://i.imgur.com/28gAgkE.gif)

## How to use
It is really easy! Just drag and drop file into the app and voila!

![usage](https://i.imgur.com/blyQ1jK.gif)

Alternatively you can add VirusTotal Uploader to file content menu and click on file and select "Scan with VirusTotal".

![usage](https://i.imgur.com/2iGyilJ.gif)

## Building
To build this project without installing Visual Studio, follow these steps:

**Setup**
1. Download and install "Build Tools for Visual Studio" from https://visualstudio.microsoft.com/downloads/ (scroll down, it's under "All downloads")
2. Run Visual Studio Installer. Under the "Individual components" tab check ".NET Framework 4.6.1 targeting pack"
    * On the right, under "Installation details" it should show "MSBuild Tools" and "Individual components" with "C# and Visual Basic Roslyn compilers" and ".NET Framework 4.6.1 targeting pack" listed.
3. Click the install button
    * You should see "MSBuild.exe" in a path similar to `C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin`
4. Download NuGet from https://www.nuget.org/downloads
    * You want the recommended download from the left side under "Windows x86 Commandline"
  
**Build**
1. Clone this repo and navigate to `VirusTotalUploader/VirusTotal Uploader/VirusTotal Uploader/`. You should see `VirusTotal Uploader.sln` in this directory.
2. Run `nuget restore` to gather the required dependencies
3. Run `msbuild "VirusTotal Uploader.sln"`
4. The compiled .exe is in `VirusTotalUploader/VirusTotal Uploader/VirusTotal Uploader/bin/Debug` along with its dependencies.
    * The first time building the project after a change it may give a few warnings. Rebuilding without making more changes usually results in 0 warnings.

You may now move and run `VirusTotal Uploader.exe` from anywhere you'd like, just as long as the accompaning files are in the same directory as the exe. You may also delete the `app.publish` directory along with its contents.

## Contributing
If you have any idea how to make this app better, please create pull request. If you find any bug, please create issue.

## Help
If you want to help this project, please **star this repo**.
If you want to support me, [you can use my PayPal](https://www.paypal.me/SamuelTulach).

## TODO

 - Make file splitter to upload files larger than 150M
 - Compress files before upload
 - ~~Make window frame dark in darkmode~~ ✓
 - Make code more readable for other people
 - Comment code
 - ~~Save settings to something more than just txt file~~ ✓

## License
This project is licensed under GPLv3. Please see [LICENSE file](https://github.com/SamuelTulach/VirusTotalUploader/blob/master/LICENSE).

