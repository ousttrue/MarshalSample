using System.Runtime.InteropServices;

namespace MarshalSample
{
    public static class Import
    {
        const string DllName = "MarshalSample";

        [DllImport(DllName, CallingConvention=CallingConvention.Cdecl)]
        public static extern float GetFloat();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFloat(float n);
    }
}
