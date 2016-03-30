using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Runtime.InteropServices;

[DisallowMultipleComponent]
public class SampleBehaviour : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        // basic
        MarshalSample.Import.SetFloat(5.0f);
        Debug.Log(MarshalSample.Import.GetFloat());

        // byte array
        {
            var bytes = new Byte[] { 1, 2, 3 };
            MarshalSample.Import.SetBytes(bytes, bytes.Length);
            bytes = Enumerable.Range(0, 3).Select(_ => (Byte)0).ToArray();
            var size = MarshalSample.Import.GetBytes(bytes, bytes.Length);
            Debug.LogFormat("{0}({1})", String.Join(", ", bytes.Select(x => x.ToString()).ToArray()), size);
        }

        // byte array by pointer
        {
            var bytes = new Byte[] { 4, 5, 6 };
            // http://stackoverflow.com/questions/537573/how-to-get-intptr-from-byte-in-c-sharp
            var pBytes = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            MarshalSample.Import.SetBytesByVoidPointer(pBytes.AddrOfPinnedObject(), bytes.Length);
            pBytes.Free();

            int size;
            var p = MarshalSample.Import.GetBytesPointer(out size);
            //Debug.Log(p);
            var dst = new Byte[size];
            //var oneDeep = (IntPtr)Marshal.PtrToStructure(p, typeof(IntPtr));
            Marshal.Copy(p, dst, 0, dst.Length);
            Debug.LogFormat("{0}({1})", String.Join(", ", dst.Select(x => x.ToString()).ToArray()), size);
        }

        // byte array by double pointer
        {
            var bytes = new Byte[] { 7, 8 };
            var pBytes = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            MarshalSample.Import.SetBytesByVoidPointer(pBytes.AddrOfPinnedObject(), bytes.Length);
            pBytes.Free();
        }
        { 
            var p = new[] { IntPtr.Zero };
            var pp = GCHandle.Alloc(p, GCHandleType.Pinned);
            var size = MarshalSample.Import.GetBytesByVoidPointer(pp.AddrOfPinnedObject());
            pp.Free();
            //Debug.Log(p[0]);
            var dst = new Byte[size];
            //var oneDeep = (IntPtr)Marshal.PtrToStructure(p, typeof(IntPtr));
            Marshal.Copy(p[0], dst, 0, dst.Length);
            Debug.LogFormat("{0}({1})", String.Join(", ", dst.Select(x => x.ToString()).ToArray()), size);
        }
    }
}
