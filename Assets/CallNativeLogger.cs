using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallNativeLogger : MonoBehaviour
{
    void Start()
    {
        NativeLogger.TestLogger();
    }
}
