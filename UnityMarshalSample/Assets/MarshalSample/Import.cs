using System;
using System.Runtime.InteropServices;

namespace MarshalSample
{
    public static class Import
    {
        const string DllName = "MarshalSample";

        #region premitive
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFloat(float n);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetFloat();
        #endregion

        #region Byte[]
        [DllImport(DllName)]
        public static extern void SetBytes(Byte[] p, int size);

        [DllImport(DllName)]
        public static extern int GetBytes(Byte[] p /* out */, int size);

        [DllImport(DllName)]
        public static extern void SetBytesByVoidPointer(IntPtr p, int size);

        [DllImport(DllName)]
        public static extern IntPtr GetBytesPointer(out int size);

        [DllImport(DllName)]
        public static extern int GetBytesByVoidPointer(IntPtr p);
        #endregion
    }
}
