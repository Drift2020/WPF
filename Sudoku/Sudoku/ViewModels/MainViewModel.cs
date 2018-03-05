using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sudoku
{
    class MainViewModel : ViewModelBase
    {
        #region Pole
        private Сontainer list_game = new Сontainer();
        private Info temp_game = new Info();


        public int Levl
        {
            get { return temp_game.Levl; }
            set
            {
                temp_game.Levl = value;
                OnPropertyChanged(nameof(Levl));
            }
        }
        public List<List<int>> Pole
        {
            get { return temp_game.Pole; }
            set
            {
                temp_game.Pole = value;
                OnPropertyChanged(nameof(Pole));
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
            Levl = 5;
        }
        private bool CanExecute_1(object o)
        {
            if (!_is_start)
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
            Levl = 7;

        }
        private bool CanExecute_2(object o)
        {
            if (!_is_start)
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
            Levl = 9;
        }
        private bool CanExecute_3(object o)
        {
            if (!_is_start)
                return true;
            else
                return false;

        }










        #region Command 
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
            



            for (int y =0; y < Levl; y++)
            {
                for(int x = 0; y < Levl; x++)
                {
                    
                }
            }


            

        }     
        private bool CanExecute_Start(object o)
        {
            if (_is_start)
                return true;
            else
                return false;

        }
        #endregion Command


    }
}
