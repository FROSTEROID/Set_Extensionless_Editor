# Set_Extentionless_Editor
A scriptlike(yeah, shitcode!) C# tool for associating an .exe file with files without extension. Extentionless files. Yeah, files, that have no .ext. There are some, You know.
If You have no idea how visual studio works, just go into SetExtentionlessEditor\bin\Release and load the .exe file down. Or waste some years on learning how to program in C#, that's awesome, too.

<summary>
Make windows open extensionless files with a program you specify.
(RELOGIN MAY BE NECESSARY!)
You also can specify a mime type for those files. So, two ways to use.

1) Specify a single parameter-path pointing to the .exe to call. 
It will be called and passed the opened file as a single arg.
("%PATH% %1" in the windows register)
EXAMPLE: SetExtentionlessEditor "%windir%\\notepad.exe"

2) (+visual sugar) Specify two parameters: full path to .exe and a mime type to apply to 
extensionless files. This will make the explorer show an icon that's
associated with that mime type along with extless files in it's GUI.
EXAMPLE: SetExtentionlessEditor "%windir%\\notepad.exe" txtfile

And You need to be the Admin(evaluated) to do this shiet.
</summary>

ЗЫ: See the Capture.PNG in the root for a poor visualisation of the process.
ЗЫ2: http://vim.wikia.com/wiki/Associate_files_with_no_extension_to_Vim_under_Windows
