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
namespace AntiDebugging.WinStructs
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct SystemKernelDebuggerInformation
    {
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
        public bool KernelDebuggerEnabled;
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
        public bool KernelDebuggerNotPresent;
    }
}
