/*
THIS PROJECT LEAKED BY 

 /$            /       /              /
| $ $__  $ $          | $ $      | $ $             |__  $ $/
| $ $  \ $ $ /$$   /$$| $ $      | $ $        /$$$$$$ | $ $   
| $$$$$$$ | $ $  | $ $| $ $      | $ $       /$$__  $$| $ $   
| $ $__  $$| $ $  | $ $| $ $      | $ $      | $$$$$$$$| $ $   
| $ $  \ $ $| $ $  | $ $| $ $      | $ $      | $ $_____/| $ $   
| $$$$$$$/|  $$$$$$/| $$$$$$$$| $$$$$$$$|  $$$$$$$| $ $   
|_______/  \______/ |________/|________/ \_______/|__/   
                                                         
                                                         
                                                       
https://discord.gg/bt0
https://wwww.2m96.lol

Be Safe! If you buy this you have been scamed. :(
*/
using System.Runtime.InteropServices;
namespace AntiDebugging.WinStructs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DebugEvent
    {
        [MarshalAs(UnmanagedType.I4)]
        public DebugEventType dwDebugEventCode;
        public int dwProcessId;
        public int dwThreadId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bytes;
    }
}
