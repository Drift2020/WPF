using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku
{
    class MainViewModel : ViewModelBase
    {

        #region Pole
        int value_IQ=0;
        int _row = 9;
        int _coll = 9;
        bool is_win = false;
        bool is_error = false;
        public Action Show_Win { get; set; }
        public Action Show_M { get; set; }
        public Action Stop { get; set; }
        public Action Start { get; set; }

        private InfoViewModel temp_game = new InfoViewModel();
      
        public int Levl
        {
            get { return temp_game.Levl; }
            set
            {
                temp_game.Levl = value;
                OnPropertyChanged(nameof(Levl));
            }
        }

        public ObservableCollection<ObservableCollection<int>> List_Game
        {
            get { return temp_game.List_Game; }
            set
            {
                temp_game.List_Game = value;
                OnPropertyChanged(nameof(List_Game));
            }
        }

        public ObservableCollection<ObservableCollection<int>> View_list_Game
        {
            get { return temp_game.View_list_Game; }
            set
            {
                temp_game.View_list_Game = value;
                OnPropertyChanged(nameof(View_list_Game));
            }
        }

        bool _is_start=true;
        public bool Is_Start
        {
            get { return _is_start; }
            set
            {
                _is_start = value;
                OnPropertyChanged(nameof(Is_Start));
            }
        }


        #endregion Pole

        #region ProgramLogic

        void Value_IQ()
        {
            switch (Levl)
            {
                case 1:
                    value_IQ = 2;
                    break;
                case 2:
                    value_IQ = 6;
                    break;
                case 3:
                    value_IQ = 15;
                    break;

            }

        }

        void Input_List()
        {
           // View_list_Game = new ObservableCollection<ObservableCollection<int>>();

            ObservableCollection<int> t;

            for (int y = 0, probel = 0, otstyp = 0, kryg = 0; y < _row; y++, probel += 3, kryg++)
            {

               // t = new ObservableCollection<int>();
                for (int x = 0; x < _coll; x++)
                {

                    switch (Levl)
                    {
                        case 1:
                            {
                                if (x + 1 + otstyp + probel <= 9)
                                    View_list_Game[y][x] = x + 1 + otstyp + probel;
                                // t.Add(x + 1 + otstyp + probel);
                                else
                                    View_list_Game[y][x] = x + 1 + otstyp + probel-9;
                                // t.Add(x + 1 + probel + otstyp - 9);
                            }
                            break;
                        case 3:
                        case 2:
                            {
                                if (x + 1 + otstyp + probel <= 9)
                                    View_list_Game[x][y] = x + 1 + otstyp + probel;
                                //  t.Add(x + 1 + otstyp + probel);
                                else
                                    View_list_Game[x][y] = x + 1 + otstyp + probel-9;
                                //  t.Add(x + 1 + probel + otstyp - 9);
                            }
                            break;
                        
                           
                    }

                    List_Game[y][x]= 0;
                }
               // View_list_Game.Add(t);

                if (kryg == 2)
                {
                    kryg = -1;
                    probel = -3;
                    otstyp++;
                }
            }
        }
        void Output_List()
        {
            bool pow = true;
            int x;
            int y;
            Random t = new Random();
            switch (Levl)
            {
                case 1:
                    {
                        for(int i=0;i<30;i++)
                        {
                            pow = true;
                            do
                            {
                               

                                 y = t.Next(1, 9);
                                 x = t.Next(1, 9);

                                if (List_Game[y][x] == 0)
                                {
                                    List_Game[y][x] = View_list_Game[y][x];
                                    pow = false;
                                }
                               

                            } while (pow);
                        }
                      
                    }
                    break;
                case 2:
                    for (int i = 0; i < 25; i++)
                    {
                        pow = true;
                        do
                        {


                            y = t.Next(1, 9);
                            x = t.Next(1, 9);

                            if (List_Game[x][y] == 0)
                            {
                                List_Game[x][y] = View_list_Game[x][y];
                                pow = false;
                            }


                        } while (pow);
                      
                    }
                   
                    break;
                case 3:
                    for (int i = 0; i < 10; i++)
                    {
                        pow = true;
                        do
                        {


                            y = t.Next(1, 9);
                            x = t.Next(1, 9);

                            if (List_Game[x][y] == 0)
                            {
                                List_Game[x][y] = View_list_Game[x][y];
                                pow = false;
                            }


                        } while (pow);

                    }
                    break;
            }

        }
        #endregion ProgramLogic


        #region Command 

        
        private DelegateCommand _Command_Stop;
        public ICommand ButtonClick_Stop_Game
        {
            get
            {
                if (_Command_Stop == null)
                {
                    _Command_Stop = new DelegateCommand(Execute_Stop, CanExecute_Stop);
                }
                return _Command_Stop;
            }
        }
        private void Execute_Stop(object o)
        {


            MessegBoxs view = new MessegBoxs();

            MessegeViewModel viewModel = new MessegeViewModel(System.Windows.Visibility.Visible, System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden);
            view.DataContext = viewModel;

            if (viewModel._OK == null)
                viewModel._OK = new Action(view.Close);
            if (viewModel._NO == null)
                viewModel._NO = new Action(view.Close);

            view.ShowDialog();
            if (viewModel.is_ok)
            {
                _is_start = true;
                Stop();
            }
        }
        private bool CanExecute_Stop(object o)
        {
            if (!_is_start)
                return true;
            else
                return false;

        }

        private DelegateCommand _Command_Start;
        public ICommand ButtonClick_Start_Game
        {
            get
            {
                if (_Command_Start == null)
                {
                    _Command_Start = new DelegateCommand(Execute_Start, CanExecute_Start);
                }
                return _Command_Start;
            }
        }
        private void Execute_Start(object o)
        {
            _is_start = false;
            Value_IQ();


            Input_List();
            Output_List();
            Update();
        }
        private bool CanExecute_Start(object o)
        {
            if (_is_start && Levl!=0)
                return true;
            else
                return false;

        }



        private DelegateCommand _Command_is_true;
        public ICommand ButtonClick_is_true
        {
            get
            {
                if (_Command_is_true == null)
                {
                    _Command_is_true = new DelegateCommand(Execute_is_true, CanExecute_is_true);
                }
                return _Command_is_true;
            }
        }
        private void Execute_is_true(object o)
        {
            is_error = false;
            for (int y=0;y<_row;y++)
            {
                for(int x=0;x<_coll;x++)
                {
                    if (List_Game[y][x] != View_list_Game[y][x])
                    {
                        is_error = true;
                        List_Game[y][x] = 0;
                    }
                        
                }
            }
            if(is_error)
            {

                Show_M();
            }
            else
            {
                is_win = true;
                Show_Win();
                Stop();
               
            }
            if (value_IQ == 0)
                Update();
            else
                value_IQ--;

        }
        private bool CanExecute_is_true(object o)
        {
           
                return true;
           
        }

      




        private DelegateCommand _Command_1;
        public ICommand ButtonClick_1
        {
            get
            {
                if (_Command_1 == null)
                {
                    _Command_1 = new DelegateCommand(Execute_1, CanExecute_1);
                }
                return _Command_1;
            }
        }
        private void Execute_1(object o)
        {
            Levl = 1;
        }
        private bool CanExecute_1(object o)
        {
            if (_is_start)
                return true;
            else
                return false;

        }

        private DelegateCommand _Command_2;
        public ICommand ButtonClick_2
        {
            get
            {
                if (_Command_2 == null)
                {
                    _Command_2 = new DelegateCommand(Execute_2, CanExecute_2);
                }
                return _Command_2;
            }
        }
        private void Execute_2(object o)
        {
            Levl = 2;

        }
        private bool CanExecute_2(object o)
        {
            if (_is_start)
                return true;
            else
                return false;

        }

        private DelegateCommand _Command_3;
        public ICommand ButtonClick_3
        {
            get
            {
                if (_Command_3 == null)
                {
                    _Command_3 = new DelegateCommand(Execute_3, CanExecute_3);
                }
                return _Command_3;
            }
        }
        private void Execute_3(object o)
        {
            Levl = 3;
        }
        private bool CanExecute_3(object o)
        {
            if (_is_start)
                return true;
            else
                return false;

        }


        #endregion Command


        void Update()
        {
            for (int y = 0; y < _row; y++)
            {
                for (int x = 0; x < _coll; x++)

                    OnPropertyChanged("EL"+y+x);
            }
        }


        #region HELL

        #region Tabl_1
        public int El00
        {
            get { return temp_game.List_Game[0][0]; }
            set
            {
                temp_game.List_Game[0][0] = value;
                OnPropertyChanged(nameof(El00));
            }
        }
        public int El01
        {
            get { return temp_game.List_Game[0][1]; }
            set
            {
                temp_game.List_Game[0][1] = value;
                OnPropertyChanged(nameof(El01));
            }
        }
        public int El02
        {
            get { return temp_game.List_Game[0][2]; }
            set
            {
                temp_game.List_Game[0][2] = value;
                OnPropertyChanged(nameof(El02));
            }
        }
        public int El03
        {
            get { return temp_game.List_Game[0][3]; }
            set
            {
                temp_game.List_Game[0][3] = value;
                OnPropertyChanged(nameof(El03));
            }
        }
        public int El04
        {
            get { return temp_game.List_Game[0][4]; }
            set
            {
                temp_game.List_Game[0][4] = value;
                OnPropertyChanged(nameof(El04));
            }
        }
        public int El05
        {
            get { return temp_game.List_Game[0][5]; }
            set
            {
                temp_game.List_Game[0][5] = value;
                OnPropertyChanged(nameof(El05));
            }
        }
        public int El06
        {
            get { return temp_game.List_Game[0][6]; }
            set
            {
                temp_game.List_Game[0][6] = value;
                OnPropertyChanged(nameof(El06));
            }
        }
        public int El07
        {
            get { return temp_game.List_Game[0][7]; }
            set
            {
                temp_game.List_Game[0][7] = value;
                OnPropertyChanged(nameof(El07));
            }
        }
        public int El08
        {
            get { return temp_game.List_Game[0][8]; }
            set
            {
                temp_game.List_Game[0][8] = value;
                OnPropertyChanged(nameof(El08));
            }
        }
        #endregion Tabl_1
        #region Tabl_2
        public int El10
        {
            get { return temp_game.List_Game[1][0]; }
            set
            {
                temp_game.List_Game[1][0] = value;
                OnPropertyChanged(nameof(El10));
            }
        }
        public int El11
        {
            get { return temp_game.List_Game[1][1]; }
            set
            {
                temp_game.List_Game[1][1] = value;
                OnPropertyChanged(nameof(El11));
            }
        }
        public int El12
        {
            get { return temp_game.List_Game[1][2]; }
            set
            {
                temp_game.List_Game[1][2] = value;
                OnPropertyChanged(nameof(El12));
            }
        }
        public int El13
        {
            get { return temp_game.List_Game[1][3]; }
            set
            {
                temp_game.List_Game[1][3] = value;
                OnPropertyChanged(nameof(El13));
            }
        }
        public int El14
        {
            get { return temp_game.List_Game[1][4]; }
            set
            {
                temp_game.List_Game[1][4] = value;
                OnPropertyChanged(nameof(El14));
            }
        }
        public int El15
        {
            get { return temp_game.List_Game[1][5]; }
            set
            {
                temp_game.List_Game[1][5] = value;
                OnPropertyChanged(nameof(El15));
            }
        }
        public int El16
        {
            get { return temp_game.List_Game[1][6]; }
            set
            {
                temp_game.List_Game[1][6] = value;
                OnPropertyChanged(nameof(El16));
            }
        }
        public int El17
        {
            get { return temp_game.List_Game[1][7]; }
            set
            {
                temp_game.List_Game[1][7] = value;
                OnPropertyChanged(nameof(El17));
            }
        }
        public int El18
        {
            get { return temp_game.List_Game[1][8]; }
            set
            {
                temp_game.List_Game[1][8] = value;
                OnPropertyChanged(nameof(El18));
            }
        }
        #endregion Tabl_2
        #region Tabl_3
        public int El20
        {
            get { return temp_game.List_Game[2][0]; }
            set
            {
                temp_game.List_Game[2][0] = value;
                OnPropertyChanged(nameof(El20));
            }
        }
        public int El21
        {
            get { return temp_game.List_Game[2][1]; }
            set
            {
                temp_game.List_Game[2][1] = value;
                OnPropertyChanged(nameof(El21));
            }
        }
        public int El22
        {
            get { return temp_game.List_Game[2][2]; }
            set
            {
                temp_game.List_Game[2][2] = value;
                OnPropertyChanged(nameof(El22));
            }
        }
        public int El23
        {
            get { return temp_game.List_Game[2][3]; }
            set
            {
                temp_game.List_Game[2][3] = value;
                OnPropertyChanged(nameof(El23));
            }
        }
        public int El24
        {
            get { return temp_game.List_Game[2][4]; }
            set
            {
                temp_game.List_Game[2][4] = value;
                OnPropertyChanged(nameof(El24));
            }
        }
        public int El25
        {
            get { return temp_game.List_Game[2][5]; }
            set
            {
                temp_game.List_Game[2][5] = value;
                OnPropertyChanged(nameof(El25));
            }
        }
        public int El26
        {
            get { return temp_game.List_Game[2][6]; }
            set
            {
                temp_game.List_Game[2][6] = value;
                OnPropertyChanged(nameof(El26));
            }
        }
        public int El27
        {
            get { return temp_game.List_Game[2][7]; }
            set
            {
                temp_game.List_Game[2][7] = value;
                OnPropertyChanged(nameof(El27));
            }
        }
        public int El28
        {
            get { return temp_game.List_Game[2][8]; }
            set
            {
                temp_game.List_Game[2][8] = value;
                OnPropertyChanged(nameof(El28));
            }
        }
        #endregion Tabl_3
        #region Tabl_4
        public int El30
        {
            get { return temp_game.List_Game[3][0]; }
            set
            {
                temp_game.List_Game[3][0] = value;
                OnPropertyChanged(nameof(El30));
            }
        }
        public int El31
        {
            get { return temp_game.List_Game[3][1]; }
            set
            {
                temp_game.List_Game[3][1] = value;
                OnPropertyChanged(nameof(El31));
            }
        }
        public int El32
        {
            get { return temp_game.List_Game[3][2]; }
            set
            {
                temp_game.List_Game[3][2] = value;
                OnPropertyChanged(nameof(El32));
            }
        }
        public int El33
        {
            get { return temp_game.List_Game[3][3]; }
            set
            {
                temp_game.List_Game[3][3] = value;
                OnPropertyChanged(nameof(El33));
            }
        }
        public int El34
        {
            get { return temp_game.List_Game[3][4]; }
            set
            {
                temp_game.List_Game[3][4] = value;
                OnPropertyChanged(nameof(El34));
            }
        }
        public int El35
        {
            get { return temp_game.List_Game[3][5]; }
            set
            {
                temp_game.List_Game[3][5] = value;
                OnPropertyChanged(nameof(El35));
            }
        }
        public int El36
        {
            get { return temp_game.List_Game[3][6]; }
            set
            {
                temp_game.List_Game[3][6] = value;
                OnPropertyChanged(nameof(El36));
            }
        }
        public int El37
        {
            get { return temp_game.List_Game[3][7]; }
            set
            {
                temp_game.List_Game[3][7] = value;
                OnPropertyChanged(nameof(El37));
            }
        }
        public int El38
        {
            get { return temp_game.List_Game[3][8]; }
            set
            {
                temp_game.List_Game[3][8] = value;
                OnPropertyChanged(nameof(El38));
            }
        }
        #endregion Tabl_4
        #region Tabl_5
        public int El40
        {
            get { return temp_game.List_Game[4][0]; }
            set
            {
                temp_game.List_Game[4][0] = value;
                OnPropertyChanged(nameof(El40));
            }
        }
        public int El41
        {
            get { return temp_game.List_Game[4][1]; }
            set
            {
                temp_game.List_Game[4][1] = value;
                OnPropertyChanged(nameof(El41));
            }
        }
        public int El42
        {
            get { return temp_game.List_Game[4][2]; }
            set
            {
                temp_game.List_Game[4][2] = value;
                OnPropertyChanged(nameof(El42));
            }
        }
        public int El43
        {
            get { return temp_game.List_Game[4][3]; }
            set
            {
                temp_game.List_Game[4][3] = value;
                OnPropertyChanged(nameof(El43));
            }
        }
        public int El44
        {
            get { return temp_game.List_Game[4][4]; }
            set
            {
                temp_game.List_Game[4][4] = value;
                OnPropertyChanged(nameof(El44));
            }
        }
        public int El45
        {
            get { return temp_game.List_Game[4][5]; }
            set
            {
                temp_game.List_Game[4][5] = value;
                OnPropertyChanged(nameof(El45));
            }
        }
        public int El46
        {
            get { return temp_game.List_Game[4][6]; }
            set
            {
                temp_game.List_Game[4][6] = value;
                OnPropertyChanged(nameof(El46));
            }
        }
        public int El47
        {
            get { return temp_game.List_Game[4][7]; }
            set
            {
                temp_game.List_Game[4][7] = value;
                OnPropertyChanged(nameof(El47));
            }
        }
        public int El48
        {
            get { return temp_game.List_Game[4][8]; }
            set
            {
                temp_game.List_Game[4][8] = value;
                OnPropertyChanged(nameof(El48));
            }
        }
        #endregion Tabl_5
        #region Tabl_6
        public int El50
        {
            get { return temp_game.List_Game[5][0]; }
            set
            {
                temp_game.List_Game[5][0] = value;
                OnPropertyChanged(nameof(El50));
            }
        }
        public int El51
        {
            get { return temp_game.List_Game[5][1]; }
            set
            {
                temp_game.List_Game[5][1] = value;
                OnPropertyChanged(nameof(El51));
            }
        }
        public int El52
        {
            get { return temp_game.List_Game[5][2]; }
            set
            {
                temp_game.List_Game[5][2] = value;
                OnPropertyChanged(nameof(El52));
            }
        }
        public int El53
        {
            get { return temp_game.List_Game[5][3]; }
            set
            {
                temp_game.List_Game[5][3] = value;
                OnPropertyChanged(nameof(El53));
            }
        }
        public int El54
        {
            get { return temp_game.List_Game[5][4]; }
            set
            {
                temp_game.List_Game[5][4] = value;
                OnPropertyChanged(nameof(El54));
            }
        }
        public int El55
        {
            get { return temp_game.List_Game[5][5]; }
            set
            {
                temp_game.List_Game[5][5] = value;
                OnPropertyChanged(nameof(El55));
            }
        }
        public int El56
        {
            get { return temp_game.List_Game[5][6]; }
            set
            {
                temp_game.List_Game[5][6] = value;
                OnPropertyChanged(nameof(El56));
            }
        }
        public int El57
        {
            get { return temp_game.List_Game[5][7]; }
            set
            {
                temp_game.List_Game[5][7] = value;
                OnPropertyChanged(nameof(El57));
            }
        }
        public int El58
        {
            get { return temp_game.List_Game[5][8]; }
            set
            {
                temp_game.List_Game[5][8] = value;
                OnPropertyChanged(nameof(El58));
            }
        }
        #endregion Tabl_6
        #region Tabl_7
        public int El60
        {
            get { return temp_game.List_Game[6][0]; }
            set
            {
                temp_game.List_Game[6][0] = value;
                OnPropertyChanged(nameof(El60));
            }
        }
        public int El61
        {
            get { return temp_game.List_Game[6][1]; }
            set
            {
                temp_game.List_Game[6][1] = value;
                OnPropertyChanged(nameof(El61));
            }
        }
        public int El62
        {
            get { return temp_game.List_Game[6][2]; }
            set
            {
                temp_game.List_Game[6][2] = value;
                OnPropertyChanged(nameof(El62));
            }
        }
        public int El63
        {
            get { return temp_game.List_Game[6][3]; }
            set
            {
                temp_game.List_Game[6][3] = value;
                OnPropertyChanged(nameof(El63));
            }
        }
        public int El64
        {
            get { return temp_game.List_Game[6][4]; }
            set
            {
                temp_game.List_Game[6][4] = value;
                OnPropertyChanged(nameof(El64));
            }
        }
        public int El65
        {
            get { return temp_game.List_Game[6][5]; }
            set
            {
                temp_game.List_Game[6][5] = value;
                OnPropertyChanged(nameof(El65));
            }
        }
        public int El66
        {
            get { return temp_game.List_Game[6][6]; }
            set
            {
                temp_game.List_Game[6][6] = value;
                OnPropertyChanged(nameof(El66));
            }
        }
        public int El67
        {
            get { return temp_game.List_Game[6][7]; }
            set
            {
                temp_game.List_Game[6][7] = value;
                OnPropertyChanged(nameof(El67));
            }
        }
        public int El68
        {
            get { return temp_game.List_Game[6][8]; }
            set
            {
                temp_game.List_Game[6][8] = value;
                OnPropertyChanged(nameof(El68));
            }
        }
        #endregion Tabl_7
        #region Tabl_8
        public int El70
        {
            get { return temp_game.List_Game[7][0]; }
            set
            {
                temp_game.List_Game[7][0] = value;
                OnPropertyChanged(nameof(El70));
            }
        }
        public int El71
        {
            get { return temp_game.List_Game[7][1]; }
            set
            {
                temp_game.List_Game[7][1] = value;
                OnPropertyChanged(nameof(El71));
            }
        }
        public int El72
        {
            get { return temp_game.List_Game[7][2]; }
            set
            {
                temp_game.List_Game[7][2] = value;
                OnPropertyChanged(nameof(El72));
            }
        }
        public int El73
        {
            get { return temp_game.List_Game[7][3]; }
            set
            {
                temp_game.List_Game[7][3] = value;
                OnPropertyChanged(nameof(El73));
            }
        }
        public int El74
        {
            get { return temp_game.List_Game[7][4]; }
            set
            {
                temp_game.List_Game[7][4] = value;
                OnPropertyChanged(nameof(El74));
            }
        }
        public int El75
        {
            get { return temp_game.List_Game[7][5]; }
            set
            {
                temp_game.List_Game[7][5] = value;
                OnPropertyChanged(nameof(El75));
            }
        }
        public int El76
        {
            get { return temp_game.List_Game[7][6]; }
            set
            {
                temp_game.List_Game[7][6] = value;
                OnPropertyChanged(nameof(El76));
            }
        }
        public int El77
        {
            get { return temp_game.List_Game[7][7]; }
            set
            {
                temp_game.List_Game[7][7] = value;
                OnPropertyChanged(nameof(El77));
            }
        }
        public int El78
        {
            get { return temp_game.List_Game[7][8]; }
            set
            {
                temp_game.List_Game[7][8] = value;
                OnPropertyChanged(nameof(El78));
            }
        }
        #endregion Tabl_8
        #region Tabl_9
        public int El80
        {
            get { return temp_game.List_Game[8][0]; }
            set
            {
                temp_game.List_Game[8][0] = value;
                OnPropertyChanged(nameof(El80));
            }
        }
        public int El81
        {
            get { return temp_game.List_Game[8][1]; }
            set
            {
                temp_game.List_Game[8][1] = value;
                OnPropertyChanged(nameof(El81));
            }
        }
        public int El82
        {
            get { return temp_game.List_Game[8][2]; }
            set
            {
                temp_game.List_Game[8][2] = value;
                OnPropertyChanged(nameof(El82));
            }
        }
        public int El83
        {
            get { return temp_game.List_Game[8][3]; }
            set
            {
                temp_game.List_Game[8][3] = value;
                OnPropertyChanged(nameof(El83));
            }
        }
        public int El84
        {
            get { return temp_game.List_Game[8][4]; }
            set
            {
                temp_game.List_Game[8][4] = value;
                OnPropertyChanged(nameof(El84));
            }
        }
        public int El85
        {
            get { return temp_game.List_Game[8][5]; }
            set
            {
                temp_game.List_Game[8][5] = value;
                OnPropertyChanged(nameof(El85));
            }
        }
        public int El86
        {
            get { return temp_game.List_Game[8][6]; }
            set
            {
                temp_game.List_Game[8][6] = value;
                OnPropertyChanged(nameof(El86));
            }
        }
        public int El87
        {
            get { return temp_game.List_Game[8][7]; }
            set
            {
                temp_game.List_Game[8][7] = value;
                OnPropertyChanged(nameof(El87));
            }
        }
        public int El88
        {
            get { return temp_game.List_Game[8][8]; }
            set
            {
                temp_game.List_Game[8][8] = value;
                OnPropertyChanged(nameof(El88));
            }
        }
        #endregion Tabl_1
        #endregion HELL
    }
}
