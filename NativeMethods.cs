using System.Runtime.InteropServices;
using System; 

namespace AMSI
{
    public enum AMSI_RESULT
    {
        AMSI_RESULT_CLEAN = 0,
        AMSI_RESULT_NOT_DETECTED = 1,
        AMSI_RESULT_DETECTED = 32768
    }

    public static class NativeMethods
    {
        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern int AmsiInitialize([MarshalAs(UnmanagedType.LPWStr)]string appName, out IntPtr amsiContext);

        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern void AmsiUninitialize(IntPtr amsiContext);

        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern int AmsiOpenSession(IntPtr amsiContext, out IntPtr session);

        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern void AmsiCloseSession(IntPtr amsiContext, IntPtr session);

        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern int AmsiScanString(IntPtr amsiContext, string inString, string contentName, IntPtr session, out AMSI_RESULT result);
        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern int AmsiScanBuffer(IntPtr amsiContext, byte[] buffer, ulong length, string contentName, IntPtr session, out AMSI_RESULT result);
        [DllImport("Amsi.dll", CharSet = CharSet.Unicode)]
        public static extern bool AmsiResultIsMalware(AMSI_RESULT result);
    } 
}
