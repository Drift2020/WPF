#define WM_ICON WM_APP
#define ID_TRAYICON WM_USER
#include "pz.h"
#include "New_z.h"
Target* Target::ptr = NULL;
Target::Target(void)
{
	ptr = this;
	pNID = new NOTIFYICONDATA;
}

void Target::Cls_OnClose(HWND hwnd)
{
	Shell_NotifyIcon(NIM_DELETE, pNID);
	SaveData();
	EndDialog(hwnd, 0);
}

void Target::MessageAboutError(DWORD dwError)
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

BOOL Target::Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
	// Получим дескрипторы элементов управлени

	hLict1 = GetDlgItem(hwnd, IDC_LIST1);
	hLict2 = GetDlgItem(hwnd, IDC_LIST2);
	hMenu = GetMenu(hwnd);
	hDialog = hwnd;

	HINSTANCE hInst = GetModuleHandle(NULL);

	HICON hIcon1 = LoadIcon(GetWindowInstance(hwnd), (LPCTSTR)IDI_ICON1);
	SendMessage(hwnd, WM_SETICON, ICON_BIG, (LPARAM)hIcon1);

	hIcon = LoadIcon(hInst, MAKEINTRESOURCE(IDI_ICON1)); // загружаем иконку
	memset(pNID, 0, sizeof(NOTIFYICONDATA)); //Обнуление структуры
	pNID->cbSize = sizeof(NOTIFYICONDATA); //размер структуры
	pNID->hIcon = hIcon; //загружаем пользовательскую иконку
	pNID->hWnd = hDialog; //дескриптор окна, которое будет получать уведомляющие сообщения,
	// ассоциированные с иконкой в трэе.	
	lstrcpy(pNID->szTip, "Планировщик заданий"); // Подсказка

	pNID->uCallbackMessage = WM_ICON; // Пользовательское сообщение
	// Система использует этот идентификатор для посылки уведомляющих
	// сообщений окну, дескриптор которого хранится в поле hWnd. Эти сообщения
	// посылаются, когда происходит "мышиное" сообщение в прямоугольнике, где
	// расположена иконка, или иконка выбирается или активизируется с помощью
	// клавиатуры. Параметр сообщения wParam содержит при этом идентификатор
	// иконки в трэе, где произошло событие, а параметр сообщения lParam - 
	// "мышиное" или клавиатурное сообщение, ассоциированное с событием.
	// Пример события: щелчок мышки по иконке в трэе.

	pNID->uFlags = NIF_TIP | NIF_ICON | NIF_MESSAGE | NIF_INFO;
	// NIF_ICON - поле hIcon содержит корректное значение (позволяет создать иконку в трэе).
	// NIF_MESSAGE - поле uCallbackMessage содержит корректное значение
	// (позволяет получать сообщения от иконки в трэе).
	// NIF_TIP - поле szTip содержит корректное значение (позволяет создать всплывающую подсказку для иконки в трэе).
	// NIF_INFO - поле szInfo содержит корректное значение (позволяет создать Balloon подсказку для иконки в трэе).
	
	lstrcpy(pNID->szInfo, "Планировщик заданий АКТИВЕН.");
	lstrcpy(pNID->szInfoTitle, lstrcpy(pNID->szInfoTitle, "Планировщик заданий"));
	pNID->uID = ID_TRAYICON; // предопределённый идентификатор иконки

	Shell_NotifyIcon(NIM_ADD, pNID);
	LoadData();
	return TRUE;
}



void Target::OnTrayIcon(WPARAM wp, LPARAM lp)
{
	// WPARAM - идентификатор иконки
	// LPARAM - сообщение от мыши или клавиатурное сообщение
	if (lp == WM_LBUTTONDBLCLK)
	{
		Shell_NotifyIcon(NIM_DELETE, pNID); // Удаляем иконку из трэя
		ShowWindow(hDialog, SW_NORMAL); // Восстанавливаем окно
		SetForegroundWindow(hDialog); // устанавливаем окно на передний план
	}
}

void Target::Cls_OnSize(HWND hwnd, UINT state, int cx, int cy)
{
	if (state == SIZE_MINIMIZED)
	{
		ShowWindow(hwnd, SW_HIDE); // Прячем окно
		Shell_NotifyIcon(NIM_ADD, pNID); // Добавляем иконку в трэй
	}
}

void DATES(int & D,int & M,int & Y,int reg)
{
	bool v = false;
	if (Y % 4 == 0 && Y % 100 != 0 ||Y % 400 == 0)
		v = true;
	if (M == 2 && D > 28 && !v)
	{
		M++;

		if (reg == 0)
		{
			D = 1;
		}
		else if (reg == 2)
		{
			D -= 28;
		}
	}
	else if (M == 2 && D > 29 && v)
	{
		M++;

		if (reg == 0)
		{
			D = 1;
		}
		else if(reg == 2)
		{
			D -= 29;
		}
	}
	if (M > 12)
	{
		if (reg == 0)
		{
			D = 1;
		}
		M = 1;
		Y++;
	}
	if (M == 1 || M == 3 || M == 5 || M == 7 || M == 8 || M == 10 || M == 12)
	{
		
			if (D > 31)
			{
				if (reg == 0)
				{
					D = 1;
				}
				else if(reg == 2)
				{
					D -= 31;
				}
				M++;
			}
		
	}
	else if(M == 4 || M == 6 || M == 9 || M == 11)
	{
		
			if (D > 30)
			{
				if (reg == 0)
				{
					D = 1;
				}
				else if(reg == 2)
				{
					D -= 30;
				}
				M++;
			}
	}
}

DWORD WINAPI Thread(LPVOID lp)
{
	Target* p = (Target*)lp;
	std::list<proces*>::iterator inf = p->inf.end();
	inf--;
	HANDLE hTimer = CreateWaitableTimer(NULL, TRUE, NULL);// создаем таймер синхронизации
	char buf[11];
	int hours, minutes, seconds,D,M,Y;
	hours = (*inf)->H;
	minutes = (*inf)->M;
	seconds = (*inf)->S;

	for (int i1 = 0,i = 0; i1<2;i++, i1++)
		buf[i] = (*inf)->date[i1];
	buf[2] = '\0';
	D = atoi(buf);

	for (int i1 = 3, i = 0; i1<5; i++, i1++)
		buf[i] = (*inf)->date[i1];
	buf[2] = '\0';
	M = atoi(buf);

	for (int i1 = 6, i = 0; i1<10; i++, i1++)
		buf[i] = (*inf)->date[i1];
	buf[4] = '\0';
	Y = atoi(buf);

	SYSTEMTIME st;
	GetLocalTime(&st); // получим текущее локальное время
	if (st.wHour > hours || st.wHour == hours && st.wMinute > minutes ||
		st.wHour == hours && st.wMinute == minutes && st.wSecond > seconds)
	{

		int poz = 0;
		for (std::list<proces*>::iterator inf1 = p->inf.begin(); inf1 != p->inf.end(); inf1++, poz++)
		if ((*inf)->proc == (*inf1)->proc)
			SendMessage(p->hLict1, LB_DELETESTRING, poz, 0);
		//

		//dell Handle and td...
		CloseHandle((*inf)->proc);
		p->inf.erase(inf);
		CancelWaitableTimer(hTimer); // отменяем таймер
		CloseHandle(hTimer);

		
		return 0;
	}

	bool WORK = true;
	int iDay = 0,TiDay=0;

	while (WORK)
	{

		st.wHour = hours;
		st.wMinute = minutes;
		st.wSecond = seconds;
		st.wDay = D;
		st.wMonth = M;
		st.wYear = Y;

		FILETIME ft;

		SystemTimeToFileTime(&st, &ft); // преобразуем структуру SYSTEMTIME в FILETIME
		LocalFileTimeToFileTime(&ft, &ft); // преобразуем местное время в UTC-время 
		SetWaitableTimer(hTimer, (LARGE_INTEGER *)&ft, 0, NULL, NULL, FALSE); // устанавливаем таймер
		// ожидаем переход таймера в сигнальное состояние
		if (WaitForSingleObject(hTimer, INFINITE) == WAIT_OBJECT_0)
		{

			////////////////////////////////////////if
			char T[200];
			switch ((int)ShellExecute(NULL, "open", (*inf)->put, NULL, NULL, SW_SHOWNORMAL))
			{
			case 0:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Операционной системе недостаточно памяти или ресурсов<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case ERROR_BAD_FORMAT:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Некорректный формат exe-файла<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_ACCESSDENIED:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Отсутствуют права доступа к указанному файлу<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_DLLNOTFOUND:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Указанная Dll-библиотека не найдена<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_ASSOCINCOMPLETE:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Расширение файла некорректно или неполно<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_FNF:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Указанный файл не найден<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_NOASSOC:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Отсутствует приложение, ассоциированное с расширением указанного файла<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);

				break; WORK = false;
			case SE_ERR_OOM:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Недостаточно памяти для завершения операции<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_PNF:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Указанный путь не найден<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			case SE_ERR_SHARE:

				sprintf(T, "Сообщение об ошибке: Файил \"%s\" не запущен %d.%d.%d в %d:%d:%d по времени ПК. ->Ошибка совместного доступа к файлу<-",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));
				Beep(1000, 500);
				WORK = false;
				break;
			default:


				sprintf(T, "Файил \"%s\" успешно запущен %d.%d.%d в %d:%d:%d по времени ПК.",
					(*inf)->name, D, M, Y, hours, minutes, seconds);
				SendMessage(p->hLict2, LB_ADDSTRING, 0, LPARAM(T));

			
				switch ((*inf)->reg)
				{
					case 0:
					{
							  D++;
							  DATES(D,M,Y,0);
					}
						break;
					case 1:
					{
							  M++; 
							  DATES(D, M, Y, 1);
					}
						break;
					case 2:
					{
							  if (st.wDayOfWeek == 0)
								  TiDay=  iDay = 6;
							  else
								  TiDay= iDay = st.wDayOfWeek;

							  for (bool w = true; w; iDay++, TiDay++)
							  {
								  if ((*inf)->inDay[iDay] == BST_CHECKED)
								  {
									  int iD;
									  if (st.wDayOfWeek == 0)
										  iD = 6;
									  else
										  iD = st.wDayOfWeek-1;

									  w = false;
									  D += TiDay - iD;

									  DATES(D, M, Y, 2);
								  }
								  if (iDay == 7)
								  {
									  iDay = 0;
								  }
							  }
					}
						break;
					case 3:
					{
							  WORK = false;
					}
						break;
				}
				
				break;
			}
			//////////////////////////////////////////////////////////////////////////////////
		}

	}
	//dell List proces
	int poz = 0;
	for (std::list<proces*>::iterator inf1 = p->inf.begin(); inf1 != p->inf.end(); inf1++,poz++)
	if ((*inf)->proc == (*inf1)->proc)
		SendMessage(p->hLict1, LB_DELETESTRING, poz, 0);
	//

	//dell Handle and td...
	CloseHandle((*inf)->proc);
	p->inf.erase(inf);
	CancelWaitableTimer(hTimer); // отменяем таймер
	CloseHandle(hTimer); // закрываем дескриптор таймера
	return 0;
}

void Target::LoadData()
{
	HKEY key;
	LONG Result;
	// Creates the specified registry key. If the key already exists, the function opens it. Note that key names are not case sensitive.
	Result = RegCreateKeyEx(
		HKEY_CURRENT_USER /* A handle to an open registry key */,
		"Software\\Pl" /* The name of a subkey that this function opens or creates. */,
		0, 0, 0, // These parameters may be ignored
		KEY_ALL_ACCESS /* A mask that specifies the access rights for the key to be created */,
		0 /* A pointer to a SECURITY_ATTRIBUTES structure. If lpSecurityAttributes is NULL, the handle cannot be inherited. */,
		&key /* A pointer to a variable that receives a handle to the opened or created key */,
		0 /* A pointer to a variable that receives one of the following disposition values */);
	// If the function succeeds, the return value is ERROR_SUCCESS.
	if (Result == ERROR_SUCCESS)
	{
		DWORD len = MAX_PATH, len2 = sizeof(DWORD);
		TCHAR Name[10];
		DWORD size;
		// Retrieves the type and data for the specified value name associated with an open registry key.
		Result = RegQueryValueEx(
			key /* A handle to an open registry key */,
			"Quantity" /* The name of the registry value */,
			0, 0, // These parameters may be ignored
			(BYTE*)&size /* A pointer to a buffer that receives the value's data */,
			&len2 /* A pointer to a variable that specifies the size of the buffer pointed to by the lpData parameter, in bytes */);

		if (Result == ERROR_SUCCESS)
		{
			for (int i = 0; i < size; i++)
			{
				proces* TEM = new proces;
				char *PathName = new char[MAX_PATH];
				ZeroMemory(PathName, MAX_PATH);
				wsprintf(Name, "Path%d", i);
				Result = RegQueryValueEx(key, Name, 0, 0, (BYTE*)PathName, &len);
				if (Result == ERROR_SUCCESS)
				{
					if (_access(PathName, 0))
					{
						char TEMP[MAX_PATH];
						int i = 0, it = 0;
						////////////////////////////////////name
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
						{
							TEMP[i_T] = PathName[i];
						}
						TEM->name = new char[it];
						for (int i_T = 0; i_T<it; i_T++)
						{
							TEM->name[i_T] = TEMP[i_T];
						}
						TEM->name[it] = '\0';
						TEMP[it] = '\0';
						///////////////////////////////////

						///////////////////////////////////put
						i++;
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
						{
							TEMP[i_T] = PathName[i];
						}
						TEM->put = new char[it];
						for (int i_T = 0; i_T<it; i_T++)
						{
							TEM->put[i_T] = TEMP[i_T];
						}
						TEM->put[it] = '\0';
						TEMP[it] = '\0';
						///////////////////////////////////


						///////////////////////////////////reg
						i++;
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
						{
							TEMP[i_T] = PathName[i];
						}
						TEMP[it] = '\0';
						TEM->reg = atoi(TEMP);
						///////////////////////////////////

						///////////////////////////////////H
						i++;
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
						{
							TEMP[i_T] = PathName[i];
						}
						TEMP[it] = '\0';
						TEM->H = atoi(TEMP);
						///////////////////////////////////

						///////////////////////////////////M
						i++;
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
						{
							TEMP[i_T] = PathName[i];
						}
						TEMP[it] = '\0';
						TEM->M = atoi(TEMP);
						///////////////////////////////////

						///////////////////////////////////S
						i++;
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++)
						{
							TEMP[i_T] = PathName[i];
						}
						TEMP[it] = '\0';
						TEM->S = atoi(TEMP);
						///////////////////////////////////

						///////////////////////////////////date
						i++;
						for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
						{
							TEMP[i_T] = PathName[i];
						}
						TEM->date = new char[it];
						for (int i_T = 0; i_T<it; i_T++)
						{
							TEM->date[i_T] = TEMP[i_T];
						}
						TEMP[it] = '\0';
						TEM->date[it] = '\0';
						///////////////////////////////////

						///////////////////////////////////inDay
						
						for (int inDay = 0; inDay < 7; inDay++)
						{
							i++;
							for (int i_T = 0; PathName[i] != '&'; i++, i_T++, it = i_T)
							{
								TEMP[i_T] = PathName[i];
							}
							TEMP[it] = '\0';
							TEM->inDay[inDay] = atoi(TEMP);
						}
						///////////////////////////////////

						std::ifstream in;
						in.open(TEM->put, std::ios::in | std::ios::binary);
						if (in)
						{
							int N = SendMessage(hLict1, LB_ADDSTRING, 0, LPARAM(TEM->name));
							inf.push_back(TEM);
							Sleep(10);
							TEM->proc = CreateThread(NULL, 0, Thread, this, 0, NULL);

							SendMessage(hLict1, LB_SETITEMDATA, N, LPARAM(TEM->proc));

							inf.pop_back();
							inf.push_back(TEM);
						}
						in.close();
					}

				}
				len = MAX_PATH;
			}
		}
	}
	RegCloseKey(key); // Closes a handle to the specified registry key.
}

void Target::SaveData()
{
	RegDeleteTree(HKEY_CURRENT_USER, "Software\\Pl");
	HKEY key;
	LONG Result;
	// Creates the specified registry key. If the key already exists, the function opens it. Note that key names are not case sensitive.
	Result = RegCreateKeyEx(
		HKEY_CURRENT_USER /* A handle to an open registry key */,
		"Software\\Pl" /* The name of a subkey that this function opens or creates. */,
		0, 0, 0, // These parameters may be ignored
		KEY_ALL_ACCESS /* A mask that specifies the access rights for the key to be created */,
		0 /* A pointer to a SECURITY_ATTRIBUTES structure. If lpSecurityAttributes is NULL, the handle cannot be inherited. */,
		&key /* A pointer to a variable that receives a handle to the opened or created key */,
		0 /* A pointer to a variable that receives one of the following disposition values */);
	// If the function succeeds, the return value is ERROR_SUCCESS.
	if (Result != ERROR_SUCCESS)
		return;
	TCHAR Name[10];


	DWORD size = inf.size();
	if (size != 0)
	{
		// Sets the data and type of a specified value under a registry key.
		RegSetValueEx(key /* A handle to an open registry key */,
			"Quantity" /* he name of the value to be set */,
			0 /* This parameter is reserved and must be zero. */,
			REG_DWORD /* The type of data pointed to by the lpData parameter */,
			(const BYTE*)&size /* The data to be stored */,
			sizeof(size) /* The size of the information pointed to by the lpData parameter */);

		std::list<proces*>::iterator inf_T = inf.begin();
		for (int i = 0; inf_T != inf.end() && i < size; inf_T++, i++)
		{
			wsprintf(Name, "Path%d", i);

			char TEMP[260];
			strcpy(TEMP, (*inf_T)->name);
			strcat(TEMP, "&");

			strcat(TEMP, (*inf_T)->put);
			strcat(TEMP, "&");

			char TEM[50];
			strcat(TEMP, _itoa((*inf_T)->reg, TEM, 10));
			strcat(TEMP, "&");

			strcat(TEMP, _itoa((*inf_T)->H, TEM, 10));
			strcat(TEMP, "&");

			strcat(TEMP, _itoa((*inf_T)->M, TEM, 10));
			strcat(TEMP, "&");

			strcat(TEMP, _itoa((*inf_T)->S, TEM, 10));
			strcat(TEMP, "&");

			strcat(TEMP, (*inf_T)->date);
			strcat(TEMP, "&");
			for (int i = 0; i < 7; i++)
			{
				strcat(TEMP, _itoa((*inf_T)->inDay[i], TEM, 10));
				strcat(TEMP, "&");
			}

			Result = RegSetValueEx(key, Name, 0, REG_SZ, (const BYTE*)TEMP, strlen(TEMP) + 1);
		}

	}
	RegCloseKey(key); // Closes a handle to the specified registry key
}

void Target::Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify)
{
	switch (id)
	{
	case ID_ADD:
	{
				   CAdditionalModalDialog dlg(true);
				   INT_PTR result = DialogBox(GetModuleHandle(NULL), MAKEINTRESOURCE(IDD_DIALOG2), hwnd, CAdditionalModalDialog::DlgProc);
				   if (result == ID_OK)
				   {
					   int N = SendMessage(hLict1, LB_ADDSTRING, 0, LPARAM(dlg.temp->name));
					  
					   inf.push_back(dlg.temp);
					   Sleep(10);
					   dlg.temp->proc = CreateThread(NULL, 0, Thread, this, 0, NULL);

					   SendMessage(hLict1, LB_SETITEMDATA, N, LPARAM(dlg.temp->proc));

					   inf.pop_back();
					   inf.push_back(dlg.temp);
				   }
	}
		break;
	case ID_IZ:
	{
				  int res = SendMessage(hLict1, LB_GETCURSEL, 0, 0);
				  if (res != LB_ERR)
				  {
					  CAdditionalModalDialog dlg(false);

					  int res = SendMessage(hLict1, LB_GETCURSEL, 0, 0);
					  HANDLE temp_proc = (HANDLE)SendMessage(hLict1, LB_GETITEMDATA, res, 0);
					  std::list<proces*>::iterator inf1 = inf.begin();
					  for (; inf1 != inf.end() && temp_proc != (*inf1)->proc; inf1++);
					  dlg.temp = (*inf1);

					  INT_PTR result = DialogBox(GetModuleHandle(NULL), MAKEINTRESOURCE(IDD_DIALOG2), hwnd, CAdditionalModalDialog::DlgProc);
					  if (result == ID_OK)
					  {
						  // (*inf1) = dlg.temp;
						  int N = SendMessage(hLict1, LB_GETCURSEL, 0, 0);

						  inf.erase(inf1);
						  inf.push_back(dlg.temp);
						  Sleep(10);

						  TerminateThread(temp_proc, 0);
						  dlg.temp->proc = CreateThread(NULL, 0, Thread, this, 0, NULL);

						  //(*inf1) = dlg.temp;
						  SendMessage(hLict1, LB_SETITEMDATA, N, LPARAM(dlg.temp->proc));
						  inf.pop_back();
						  inf.push_back(dlg.temp);
					  }
				  }
	}
		break;
	case ID_DELL:
	{
					int res = SendMessage(hLict1, LB_GETCURSEL, 0, 0);
					if (res != LB_ERR)
					{
						int result = MessageBox(0, TEXT("Вы уверены что хотите удалить?"), TEXT("Планеровщик заданий"), MB_YESNO | MB_ICONINFORMATION);
						if (result == IDYES)
						{
							HANDLE temp_proc = (HANDLE)SendMessage(hLict1, LB_GETITEMDATA, res, 0);

							std::list<proces*>::iterator inf1 = inf.begin();
							for (; inf1 != inf.end() && temp_proc != (*inf1)->proc; inf1++);

							TerminateThread(temp_proc, 0);

							DWORD dwError = GetLastError();
							if (dwError != 0)
								MessageAboutError(dwError);

							CloseHandle((*inf1)->proc);
							inf.erase(inf1);
						

							SendMessage(hLict1, LB_DELETESTRING, res, 0);
						}
					}
	}
		break;
	case ID_CL:
	{
				  SendMessage(hLict2, LB_RESETCONTENT, 0, 0);
	}
		break;
	case ID_EXIT:
	{
					int result = MessageBox(0, TEXT("Вы уверены что хотите выйти?"), TEXT("Планеровщик заданий"), MB_YESNO | MB_ICONINFORMATION);
					if (result == IDYES)
					{
						Cls_OnClose(hwnd);
					}
	}
		break;
	}


}

BOOL CALLBACK Target::DlgProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
		HANDLE_MSG(hwnd, WM_CLOSE, ptr->Cls_OnClose);
		HANDLE_MSG(hwnd, WM_INITDIALOG, ptr->Cls_OnInitDialog);
		HANDLE_MSG(hwnd, WM_COMMAND, ptr->Cls_OnCommand);
		HANDLE_MSG(hwnd, WM_SIZE, ptr->Cls_OnSize);
	}
	if (message == WM_ICON)
	{
		ptr->OnTrayIcon(wParam, lParam);
		return TRUE;
	}
	return FALSE;
}