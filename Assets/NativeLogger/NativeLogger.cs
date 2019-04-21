using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class NativeLogger
{
    const string NATIVE_LOGGER_DLL = "NativeLogger_x86_64";

    public enum Level
    {
        LogInfo = 0,
        LogWarning = 1,
        LogError = 2
    }

    [InitializeOnLoadMethod]
    static void Initialize()
    {
        LogDelegate callback_delegate = new LogDelegate(LogCallback);
        IntPtr delegatePtr = Marshal.GetFunctionPointerForDelegate(callback_delegate);
        SetLogger(delegatePtr);
    }

    [DllImport(NATIVE_LOGGER_DLL)]
    private static extern void SetLogger(IntPtr fp);

    [DllImport(NATIVE_LOGGER_DLL)]
    public static extern void TestLogger();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void LogDelegate(int level, string str);

    static void LogCallback(int level, string msg)
    {
        if (level == (int)Level.LogInfo)
            Debug.Log(msg);
        else if (level == (int)Level.LogWarning)
            Debug.LogWarning(msg);
        else if (level == (int)Level.LogError)
            Debug.LogError(msg);
    }
}
