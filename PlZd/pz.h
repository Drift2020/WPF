#pragma once
#include "header.h"

class Target
{
public:
	Target(void);

public:

	static BOOL CALLBACK DlgProc(HWND hWnd, UINT mes, WPARAM wp, LPARAM lp);
	static Target* ptr;
	void MessageAboutError(DWORD dwError);
	BOOL Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam);
	void Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify);
	void Cls_OnClose(HWND hwnd);
	
	void OnTrayIcon(WPARAM wp, LPARAM lp);
	void Cls_OnSize(HWND hwnd, UINT state, int cx, int cy);

	void LoadData();
	void SaveData();

	HMENU hMenu;
	HWND hLict1, hLict2, hDialog;
	HANDLE hProzes1, hProzes2;
	HICON hIcon;
	PNOTIFYICONDATA pNID;

	std::list<proces*> inf;
};