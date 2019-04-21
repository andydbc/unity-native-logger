#include "NativeLogger.h"

#define UNITY_INTERFACE_API __stdcall
#define UNITY_INTERFACE_EXPORT __declspec(dllexport)

extern "C"
{
	UNITY_INTERFACE_EXPORT void SetLogger(LoggerFuncPtr fp)
	{
		NativeLogger::SetLogger(fp);
	}

	UNITY_INTERFACE_EXPORT void TestLogger()
	{
		NativeLogger::LogInfo("Test Info");
		NativeLogger::LogWarn("Test Warning");
		NativeLogger::LogError("Test Error");
	}
}
