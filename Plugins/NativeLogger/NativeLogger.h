#ifndef H_LOGGER_
#define H_LOGGER_

#include <cstdio>

typedef void(*LoggerFuncPtr)(int level, const char *);

class NativeLogger
{
public:
	enum Level
	{
		Info = 0,
		Warning = 1,
		Error = 2
	};

	static void SetLogger(LoggerFuncPtr logger);

	static void Log(Level level, const char* msg);
	static void LogInfo(const char* msg);
	static void LogWarn(const char* msg);
	static void LogError(const char* msg);

protected:
	static LoggerFuncPtr Logger;
};

#endif