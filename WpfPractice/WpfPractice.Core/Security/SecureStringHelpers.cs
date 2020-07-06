using System;
using System.Runtime.InteropServices;
using System.Security;

namespace WpfPractice.Core.Security
{
    public static class SecureStringHelpers
    {
        public static string UnSecure(this SecureString str)
        {
            if (str == null)
                return string.Empty;

            // pointed to unsecure string in memory
            var unmannagedString = IntPtr.Zero;

            try
            {
                unmannagedString = Marshal.SecureStringToGlobalAllocUnicode(str);

                return Marshal.PtrToStringUni(unmannagedString);
            }
            finally
            {
                // clean up any memory allocations
                Marshal.ZeroFreeGlobalAllocUnicode(unmannagedString);
            }
        }
    }
}
