#include "New_z.h"


CAdditionalModalDialog* CAdditionalModalDialog::ptr = NULL;

CAdditionalModalDialog::CAdditionalModalDialog(void)
{
	ptr = this;
	temp = new proces;
	rez = 0;
}

CAdditionalModalDialog::CAdditionalModalDialog(bool add, int rez)
{
	ptr = this;
	this->add = add;
	if (add)
	temp = new proces;
	this->rez = 0;
}

CAdditionalModalDialog::~CAdditionalModalDialog(void)
{
	
}

void CAdditionalModalDialog::Cls_OnClose(HWND hwnd)
{
	
	EndDialog(hwnd, IDCANCEL);
}

void CAdditionalModalDialog::SetPUT(char * PUT)
{
	int size = strlen(PUT)+1;
	this->PUT = new TCHAR[size];
	for (int i = 0; i < size; i++)
		this->PUT[i] = PUT[i];
	this->PUT[size] = NULL;
}

void CAdditionalModalDialog::SetAdd(bool add){
	this->add = add;
}

bool CAdditionalModalDialog::GetAdd()
{
	return add;
}

char *  CAdditionalModalDialog::GetPUT()
{
	return PUT;
}

void CAdditionalModalDialog::MessageAboutError(DWORD dwError)
{
	LPVOID lpMsgBuf = NULL;
	TCHAR szBuf[260];
	BOOL fOK = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM//флаг сообщает функции, что нужна строка, соответствующая коду ошибки, определённому в системе
		| FORMAT_MESSAGE_ALLOCATE_BUFFER, NULL,//нужно выделить соответствующий блок памяти для хранения текста
		dwError,//код ошибки
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),//язык, на котором выводится описание ошибки (язык пользователя по умолчанию)
		(LPTSTR)&lpMsgBuf,//адрес выделенного блока памяти записывается в эту переменную
		0,//минимальный размер буфера для выделения памяти
		NULL);
	if (lpMsgBuf != NULL)
	{
		wsprintf(szBuf, TEXT("Ошибка %d: %s"), dwError, lpMsgBuf);
		MessageBox(hDialog, szBuf, TEXT("Сообщение об ошибке"), MB_OK | MB_ICONSTOP);
		LocalFree(lpMsgBuf);
	}
}

void CAdditionalModalDialog::Cls_Open(HWND hwnd)
{

	TCHAR * FullPath = new TCHAR[MAX_PATH];
	FullPath[0] = '\0';
	OPENFILENAME open = { sizeof(OPENFILENAME) };
	open.hwndOwner = hwnd;
	open.lpstrFilter = TEXT("Text Files(*.txt)\0*.txt\0All Files(*.*)\0*.*\0");
	open.lpstrFile = FullPath;
	open.nMaxFile = MAX_PATH;

	open.lpstrInitialDir = TEXT("C:\\");
	open.Flags = OFN_CREATEPROMPT | OFN_PATHMUSTEXIST;
	if (GetOpenFileName(&open))
	{
		/////////////////////////////////////////////////////N
		//regedirs(FullPath, hSubMenu, FileTitle);
		/////////////////////////////////////////////////////F
			_finddata_t fd;
			_findfirst(open.lpstrFile, &fd);
			char *P = new char[strlen(fd.name)];
			strcpy(P, fd.name);
			SetWindowText(hwnd, P);

			SetPUT(open.lpstrFile);

			SendMessageA(hPut, WM_SETTEXT, TRUE, (LPARAM)PUT);
	}
	else
	{
		MessageBox(0, TEXT("Ошибка окрытия файла"), TEXT("Библиотека"), MB_OK | MB_ICONINFORMATION);
	}
}

BOOL CAdditionalModalDialog::Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
	hDialog = hwnd;
	for (int i = 0; i < 7; i++)
		hChec[i] = GetDlgItem(hwnd, IDC_CHECK1 + i);

	hExit = GetDlgItem(hwnd, IDCANCEL);
	hOK = GetDlgItem(hwnd, IDOK);
	hPut = GetDlgItem(hwnd, IDC_PUT);
	hOpen = GetDlgItem(hwnd, IDC_OPEN);
	hReg = GetDlgItem(hwnd, IDC_REG);
	SendMessage(hReg, CB_ADDSTRING, 0, LPARAM(TEXT("Ежедневно")));
	SendMessage(hReg, CB_ADDSTRING, 0, LPARAM(TEXT("Еженедельно")));
	SendMessage(hReg, CB_ADDSTRING, 0, LPARAM(TEXT("Ежемесячно")));
	SendMessage(hReg, CB_ADDSTRING, 0, LPARAM(TEXT("Однократно")));

	hEdit1 = GetDlgItem(hwnd, IDC_HORS1);
	hEdit2 = GetDlgItem(hwnd, IDC_MIN1);
	hEdit3 = GetDlgItem(hwnd, IDC_SEKO1);

	hSpin1 = GetDlgItem(hwnd, IDC_SPIN1);
	hSpin2 = GetDlgItem(hwnd, IDC_SPIN2);
	hSpin3 = GetDlgItem(hwnd, IDC_SPIN3);

	SendMessage(hSpin1, UDM_SETRANGE32, 0, 23);
	SendMessage(hSpin1, UDM_SETBUDDY, WPARAM(hEdit1), 0);
	SetWindowText(hEdit1, TEXT("0"));

	SendMessage(hSpin2, UDM_SETRANGE32, 0, 59);
	SendMessage(hSpin2, UDM_SETBUDDY, WPARAM(hEdit2), 0);
	SetWindowText(hEdit2, TEXT("0"));

	SendMessage(hSpin3, UDM_SETRANGE32, 0, 59);
	SendMessage(hSpin3, UDM_SETBUDDY, WPARAM(hEdit3), 0);
	SetWindowText(hEdit3, TEXT("0"));

	hDate = GetDlgItem(hwnd, IDC_DATETIMEPICKER1);

	if (!add)
	{
		IzmPr(hwnd);
	}
	return TRUE;
}
////////////////////////////////////////////////////////////////
void CAdditionalModalDialog::Cls_OnVScroll(HWND hwnd, HWND hwndCtl, UINT code, int pos)
{
	// обработчик сообщения нажатия на одну из стрелок счётчика
	TCHAR buf[30];
	wsprintf(buf, TEXT("Счётчик: %d"), pos);
	// отобразим состояние счётчика в строке состояния
}

void  CAdditionalModalDialog::IzmPr(HWND hwnd)
{
	

	SetWindowTextA(hwnd, temp->name);
	
	for (int i = 0; i < 7; i++)
		temp->inDay[i] == BST_CHECKED? SendMessage(hChec[i], BM_SETCHECK, BST_CHECKED, 0):0;

	char name[260];
	
	_itoa(temp->H, name,10);
	SetWindowTextA(hEdit1, name);

	_itoa(temp->M, name, 10);
	SetWindowTextA(hEdit2, name);

	_itoa(temp->S, name, 10);
	SetWindowTextA(hEdit3, name);
	////
	SetWindowTextA(hPut, temp->put);
	////

	SetWindowTextA(hDate, temp->date );

	SendMessage(hReg, CB_SETCURSEL, temp->reg, 0);
	Chec(temp->reg);
}

////////////////////////////////////////////////////////////////
void CAdditionalModalDialog::Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify)
{
	
	switch (id)
	{
	case IDC_OPEN:
		Cls_Open(hwnd);
		break;
	case ID_OK:
	{			 			  
			  bool regit[5] = {0,0,0,0,0};
				
			  char name[260];
			  GetWindowTextA(hwnd, name, 260);
			  int size = strlen(name);

			  temp->name = new char[size+1];

			  for (int i = 0; i < size; i++)
				  temp->name[i] = name[i];
			  temp->name[size] = '\0';

			  ////
			  for (int i = 0; i < 7; i++)
				  temp->inDay[i] = SendMessage(hChec[i], BM_GETCHECK, 0, 0);
			  //////////////////////////////////////////////////////////////////////////////inDay
			  for (int i = 0; i < 7; i++)
				  temp->inDay[i] == BST_CHECKED ? regit[2] = true:0;			  
			  //////////////////////////////////////////////////////////////////////////////
			  GetWindowTextA(hEdit1, name, 260);
			  temp->H = atoi(name);

			  GetWindowTextA(hEdit2, name, 260);
			  temp->M = atoi(name);

			  GetWindowTextA(hEdit3, name, 260);
			  temp->S = atoi(name);
			  ////
			  size=GetWindowTextA(hPut, name, 260);
			 




			  //////////////////////////////////////////////////////////////////////////////put
			  if (size == 0)
				  MessageBox(0, TEXT("Укажите путь к файлу!"), TEXT("Планеровщик заданий"), MB_OK | MB_ICONINFORMATION);
			  else
				  regit[0] = true;
			  //////////////////////////////////////////////////////////////////////////////
			  size = strlen(name);

			  temp->put = new char[size + 1];

			  for (int i = 0; i < size; i++)
				  temp->put[i] = name[i];
			  temp->put[size] = '\0';
			  ////
			  GetWindowTextA(hDate, name, 260);

			  size = strlen(name);
			  temp->date = new char[size + 1];

			  for (int i = 0; i < size; i++)
				  temp->date[i] = name[i];
			  temp->date[size] = '\0';


			  //////////////////////////////////////////////////////////////////////////////

			  int D, M, Y;
			  for (int i1 = 0, i = 0; i1<2; i++, i1++)
				  name[i] = temp->date[i1];
			  name[2] = '\0';
			  D = atoi(name);

			  for (int i1 = 3, i = 0; i1<5; i++, i1++)
				  name[i] = temp->date[i1];
			  name[2] = '\0';
			  M = atoi(name);

			  for (int i1 = 6, i = 0; i1<10; i++, i1++)
				  name[i] = temp->date[i1];
			  name[4] = '\0';
			  Y = atoi(name);
			  //////////////////////////////////////////////////////////////////////////////date
			  SYSTEMTIME st;
			  GetLocalTime(&st);
			  if (st.wYear > Y && st.wMonth > M ||
				  st.wYear == Y && st.wMonth == M && st.wDay > D)
			  {
				  MessageBox(0, TEXT("Укажите правельную двту начала!"), TEXT("Планеровщик заданий"), MB_OK | MB_ICONINFORMATION);
			  }
			  else
			  {
				  regit[3] = true;
			  }

			  //////////////////////////////////////////////////////////////////////////////reg
			  if (temp->reg >= 0 && temp->reg <= 3)
				  regit[1] = true;
			  else
				  MessageBox(0, TEXT("Укажите задание!"), TEXT("Планеровщик заданий"), MB_OK | MB_ICONINFORMATION);
			  //////////////////////////////////////////////////////////////////////////////time

			  if (temp->reg == 3)
			  {
				  if (st.wHour >  temp->H || st.wHour == temp->H && st.wMinute >  temp->M ||
					  st.wHour == temp->H && st.wMinute == temp->M && st.wSecond >  temp->S)
				  {
					  MessageBox(0, TEXT("Укажите правильное время!"), TEXT("Планеровщик заданий"), MB_OK | MB_ICONINFORMATION);
				  }
				  else
				  {
					  regit[4] = true;
				  }
			  }
			  else
			  {
				  regit[4] = true;
			  }
			  //////////////////////////////////////////////////////////////////////////////inday
			  if (temp->reg==2)
			  {
				  if (!regit[2])
					  MessageBox(0, TEXT("Укажите расписание по неделям!"), TEXT("Планеровщик заданий"), MB_OK | MB_ICONINFORMATION);
			  }
			  else
			  {
				  regit[2] = true;
			  }
			  ////////////////////////////////////////////////////////////////
			  if (regit[0] == true && regit[1] == true && regit[2] == true && regit[3] == true && regit[4] == true)
			  EndDialog(hwnd, IDOK);
	}
		break;
	case IDCLOSE:

		Cls_OnClose(hwnd);
		break;

	case IDC_REG:
		if(codeNotify == CBN_SELCHANGE)
		{
		
			// Получим индекс выбранного элемента ComboBox
			
			int index; 
			if (add)
			{
				index = SendMessage(hReg, CB_GETCURSEL, 0, 0);
				temp->reg = index;
			}
			else
			{
				index = temp->reg;
			}
			Chec(index);
		}
	}
}
void CAdditionalModalDialog::Chec(int index)
{
	switch (index)
	{
	case 0:

		for (int i = 0; i < 7; i++)
			SendMessage(hChec[i], BM_SETCHECK, BST_UNCHECKED, 0);
		for (int i = 0; i < 7; i++)
			EnableWindow(hChec[i], false);


		break;
	case 1:
		for (int i = 0; i < 7; i++)
			SendMessage(hChec[i], BM_SETCHECK, BST_UNCHECKED, 0);
		for (int i = 0; i < 7; i++)
			EnableWindow(hChec[i], false);


		break;
	case 2:
		for (int i = 0; i < 7; i++)
			SendMessage(hChec[i], BM_SETCHECK, BST_UNCHECKED, 0);
		for (int i = 0; i < 7; i++)
			EnableWindow(hChec[i], true);


		break;
	case 3:
		for (int i = 0; i < 7; i++)
			SendMessage(hChec[i], BM_SETCHECK, BST_UNCHECKED, 0);
		for (int i = 0; i < 7; i++)
			EnableWindow(hChec[i], false);


		break;
	}
}
BOOL CALLBACK CAdditionalModalDialog::DlgProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
		HANDLE_MSG(hwnd, WM_CLOSE, ptr->Cls_OnClose);
		HANDLE_MSG(hwnd, WM_INITDIALOG, ptr->Cls_OnInitDialog);
		HANDLE_MSG(hwnd, WM_VSCROLL, ptr->Cls_OnVScroll);
		HANDLE_MSG(hwnd, WM_COMMAND, ptr->Cls_OnCommand);
	}
	return FALSE;
}
