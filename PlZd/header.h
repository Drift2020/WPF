#pragma once
#define _CRT_SECURE_NO_WARNINGS
#define _AFXDLL
#include <fstream>
#include <tchar.h>
#include <windows.h>
#include <tlhelp32.h>
#include <windowsX.h>
#include <list>
#include <iomanip>
#include <ctime>
#include <io.h>
#include <commctrl.h>
#include "resource.h"

#pragma comment(lib,"comctl32")
struct proces{
	HANDLE proc;
	char * put;
	char * name;
	int reg;
	int H;
	int M;
	int S;
	char * date;
	int inDay[7];
};