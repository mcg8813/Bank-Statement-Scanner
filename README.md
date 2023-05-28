# Bank-Statement-Scanner
Simple app that formats bank transactions from a pdf in csv.

# Installation 
BSS requires [.NET Desktop Runtime 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), which you should be prompted to install after running the setup file.
1. Download `BankStatementScanner.exe` from the [latest release](https://github.com/mcg8813/Bank-Statement-Scanner/releases/latest). 

![BSS Installation ](https://github.com/mcg8813/Bank-Statement-Scanner/assets/60420807/f268f5b5-c195-4383-9b76-619254825ae2)

2. Run `BankStatementScanner.exe`. *If prompted with Windows Defender select "**More Info**" and then "**Run Anyway**".*
4. Install .NET Desktop Runtime, if not installed already.

![BSS Dot Net runtime](https://github.com/mcg8813/Bank-Statement-Scanner/assets/60420807/c9a80f75-2148-4e24-b801-b913ed9909ca)

5. Launch "BSS-GUI". A shortcut should've been created on your desktop and start menu.

BSS should update automatically given you're connected to the internet. If an update is available the application will download it and automatically restart the application to install it.

# How to Use

1. Select Upload file (Only PDF files are supported).
2. (Optional) Change output folder. 
   - `Set to Input` will change the output directory to the same one as the current uploaded PDF.
   - `Select Folder` will bring up the folder browser dialog. 

*The output path will be shown in the buttom right of the window, to the left of the save button. Default path is `C:\Users\<User>\AppData\Local\BankStatementScanner\app-<Version>\Outputs` but isn't functional.* 

3. Select `Extract Formatted`. This will start the process of formatting the PDF to csv. If successful it will populate the table on the right.
4. (Optional) You can modify the table but it will not save automatically. Make sure to press the `Save` button after you modify the table.
