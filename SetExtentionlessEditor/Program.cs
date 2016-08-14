using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SetExtentionlessEditor
{
	class Program
	{
		const string RTFM = "Make windows open extentionless files with a program you specify.\nYou also can specify a mime type for those files. So, two ways to use.\n\n1) Specify a single parameter-path pointing to the.exe to call. \nIt will be called and passed the opened file as a single arg.\n(\" % PATH % % 1\" in the windows register)\nEXAMPLE: SetExtentionlessEditor \"%windir%\\notepad.exe\"\n\n2) (+visual sugar) Specify two parameters: full path to.exe and a mime type to apply to \nextentionless files. This will make the explorer show an icon that's\nassociated withthatmime type along with extless files in it's GUI.\nEXAMPLE: SetExtentionlessEditor \"%windir%\\notepad.exe\" txtfile\n\nAnd You need to be the Admin(evaluated) to do this shiet.";

		/// <summary>
		/// Make windows open extentionless files with a program you specify.
		/// You also can specify a mime type for those files. So, two ways to use.
		/// 
		/// 1) Specify a single parameter-path pointing to the .exe to call. 
		/// It will be called and passed the opened file as a single arg.
		/// ("%PATH% %1" in the windows register)
		/// EXAMPLE: SetExtentionlessEditor "%windir%\\notepad.exe"
		/// 
		/// 2) (+visual sugar) Specify two parameters: full path to .exe and a mime type to apply to 
		/// extentionless files. This will make the explorer show an icon that's
		/// associated with that mime type along with extless files in it's GUI.
		/// EXAMPLE: SetExtentionlessEditor "%windir%\\notepad.exe" txtfile
		/// 
		/// And You need to be the Admin(evaluated) to do this shiet.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			string pathToExe;
			string mimeType;
			switch (args.Length)
			{
				case 1: 
					pathToExe = args[0];
						// Erase . mimetype in case it was there to ensure any shit doesn't happen
					Registry.SetValue("HKEY_CLASSES_ROOT\\.\\", "", "");
						// And just take the given path to HKEY_CLASSES_ROOT\.\shell\open\command\@
					Registry.SetValue("HKEY_CLASSES_ROOT\\.\\shell\\open\\command", "", pathToExe+" %1");
					break;

				case 2:						
					pathToExe = args[0];
					mimeType = args[1];
						// Make the HKEY_CLASSES_ROOT\.\@ be the specified type
					Registry.SetValue("HKEY_CLASSES_ROOT\\.\\", "", mimeType);
						// Then make that type be opened with the specified .exe  (write the path to HKEY_CLASSES_ROOT\%mimetypename%\shell\open\command\@)
					Registry.SetValue("HKEY_CLASSES_ROOT\\"+mimeType+"\\shell\\open\\command", "", pathToExe+" %1");
					break;

				default:// The program is used in a nut way. Make the user suffer. A little.
					Console.WriteLine("DICKHEAD!!!!11(((99\nRTFM!\n");
					Console.WriteLine(RTFM);
					break;
			}
#if DEBUG
			Console.WriteLine("\nExecution finished. Give me some junk to die on please.");
			Console.ReadLine();
			Console.WriteLine("Thanks. Bye.");
#else
			Console.WriteLine("Execution finished. Good luck.");
#endif
		}
		// ЗЫ: ("@" is used in .reg files. It's represented as "(default)" in regedit GUI. And it's an empty line here. Yeah, as always, microsoft. As always.)
		// ЗЫ2: http://vim.wikia.com/wiki/Associate_files_with_no_extension_to_Vim_under_Windows
	}
}
