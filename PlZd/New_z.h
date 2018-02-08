#pragma once
#include "header.h"


class CAdditionalModalDialog
{
private:
	bool add;
	char * PUT;
	int rez;
public:
	CAdditionalModalDialog(bool add, int rez = 0);
	CAdditionalModalDialog(void);
public:
	~CAdditionalModalDialog(void);
	static BOOL CALLBACK DlgProc(HWND hWnd, UINT mes, WPARAM wp, LPARAM lp);
	static CAdditionalModalDialog* ptr;
	BOOL Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam);
	void Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify);
	void Cls_OnClose(HWND hwnd);
	void MessageAboutError(DWORD dwError);

	void Cls_OnVScroll(HWND hwnd, HWND hwndCtl, UINT code, int pos);

	void Cls_Open(HWND hwnd);
	void Chec(int index);
	
	void  IzmPr(HWND hwnd);

	void SetPUT(char * PUT);
	void SetAdd(bool add);
	bool GetAdd();
	char * GetPUT();

	proces* temp;
	
	HWND hExit, hOK, hDialog, hPut, hOpen, hReg, hEdit1, hEdit2, hEdit3, hSpin1, hSpin2, hSpin3, hDate, hChec[7];
};
