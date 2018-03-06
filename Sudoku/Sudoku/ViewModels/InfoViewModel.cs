using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Sudoku
{
    [Serializable(), XmlInclude(typeof(InfoViewModel))]
    public class InfoViewModel : ViewModelBase
    {


        private Info _info;
        public InfoViewModel()
        {
            _info = new Info();
        }
        public InfoViewModel(Info info)
        {
            this._info = info;
        }
        public InfoViewModel(InfoViewModel info)
        {
            this._info = new Info(info.Levl, info.List_Game, info.View_list_Game);

        }
        public InfoViewModel(int Levl, ObservableCollection<ObservableCollection<int>> List_ingridient, ObservableCollection<ObservableCollection<int>> View_list_Game)
        {
            this._info = new Info(Levl, List_ingridient, View_list_Game);

        }
        public int Levl
        {
            get { return _info.Levl; }
            set
            {
                _info.Levl = value;
                OnPropertyChanged(nameof(Levl));
            }
        }


        public ObservableCollection<ObservableCollection<int>> List_Game
        {
            get { return _info.List_Game; }
            set
            {
                _info.List_Game = value;
                OnPropertyChanged(nameof(List_Game));
            }
        }
        public ObservableCollection<ObservableCollection<int>> View_list_Game
        {
            get { return _info.View_list_Game; }
            set
            {
                _info.View_list_Game = value;
                OnPropertyChanged(nameof(View_list_Game));
            }
        }



        #region HELL

        #region Tabl_1
        public int El00
        {
            get { return _info.List_Game[0][0]; }
            set
            {
                _info.List_Game[0][0] = value;
                OnPropertyChanged(nameof(El00));
            }
        }
        public int El01
        {
            get { return _info.List_Game[0][1]; }
            set
            {
                _info.List_Game[0][1] = value;
                OnPropertyChanged(nameof(El01));
            }
        }
        public int El02
        {
            get { return _info.List_Game[0][2]; }
            set
            {
                _info.List_Game[0][2] = value;
                OnPropertyChanged(nameof(El02));
            }
        }
        public int El03
        {
            get { return _info.List_Game[0][3]; }
            set
            {
                _info.List_Game[0][3] = value;
                OnPropertyChanged(nameof(El03));
            }
        }
        public int El04
        {
            get { return _info.List_Game[0][4]; }
            set
            {
                _info.List_Game[0][4] = value;
                OnPropertyChanged(nameof(El04));
            }
        }
        public int El05
        {
            get { return _info.List_Game[0][5]; }
            set
            {
                _info.List_Game[0][5] = value;
                OnPropertyChanged(nameof(El05));
            }
        }
        public int El06
        {
            get { return _info.List_Game[0][6]; }
            set
            {
                _info.List_Game[0][6] = value;
                OnPropertyChanged(nameof(El06));
            }
        }
        public int El07
        {
            get { return _info.List_Game[0][7]; }
            set
            {
                _info.List_Game[0][7] = value;
                OnPropertyChanged(nameof(El07));
            }
        }
        public int El08
        {
            get { return _info.List_Game[0][8]; }
            set
            {
                _info.List_Game[0][8] = value;
                OnPropertyChanged(nameof(El08));
            }
        }
        #endregion Tabl_1
        #region Tabl_2
        public int El10
        {
            get { return _info.List_Game[1][0]; }
            set
            {
                _info.List_Game[1][0] = value;
                OnPropertyChanged(nameof(El10));
            }
        }
        public int El11
        {
            get { return _info.List_Game[1][1]; }
            set
            {
                _info.List_Game[1][1] = value;
                OnPropertyChanged(nameof(El11));
            }
        }
        public int El12
        {
            get { return _info.List_Game[1][2]; }
            set
            {
                _info.List_Game[1][2] = value;
                OnPropertyChanged(nameof(El12));
            }
        }
        public int El13
        {
            get { return _info.List_Game[1][3]; }
            set
            {
                _info.List_Game[1][3] = value;
                OnPropertyChanged(nameof(El13));
            }
        }
        public int El14
        {
            get { return _info.List_Game[1][4]; }
            set
            {
                _info.List_Game[1][4] = value;
                OnPropertyChanged(nameof(El14));
            }
        }
        public int El15
        {
            get { return _info.List_Game[1][5]; }
            set
            {
                _info.List_Game[1][5] = value;
                OnPropertyChanged(nameof(El15));
            }
        }
        public int El16
        {
            get { return _info.List_Game[1][6]; }
            set
            {
                _info.List_Game[1][6] = value;
                OnPropertyChanged(nameof(El16));
            }
        }
        public int El17
        {
            get { return _info.List_Game[1][7]; }
            set
            {
                _info.List_Game[1][7] = value;
                OnPropertyChanged(nameof(El17));
            }
        }
        public int El18
        {
            get { return _info.List_Game[1][8]; }
            set
            {
                _info.List_Game[1][8] = value;
                OnPropertyChanged(nameof(El18));
            }
        }
        #endregion Tabl_2
        #region Tabl_3
        public int El20
        {
            get { return _info.List_Game[2][0]; }
            set
            {
                _info.List_Game[2][0] = value;
                OnPropertyChanged(nameof(El20));
            }
        }
        public int El21
        {
            get { return _info.List_Game[2][1]; }
            set
            {
                _info.List_Game[2][1] = value;
                OnPropertyChanged(nameof(El21));
            }
        }
        public int El22
        {
            get { return _info.List_Game[2][2]; }
            set
            {
                _info.List_Game[2][2] = value;
                OnPropertyChanged(nameof(El22));
            }
        }
        public int El23
        {
            get { return _info.List_Game[2][3]; }
            set
            {
                _info.List_Game[2][3] = value;
                OnPropertyChanged(nameof(El23));
            }
        }
        public int El24
        {
            get { return _info.List_Game[2][4]; }
            set
            {
                _info.List_Game[2][4] = value;
                OnPropertyChanged(nameof(El24));
            }
        }
        public int El25
        {
            get { return _info.List_Game[2][5]; }
            set
            {
                _info.List_Game[2][5] = value;
                OnPropertyChanged(nameof(El25));
            }
        }
        public int El26
        {
            get { return _info.List_Game[2][6]; }
            set
            {
                _info.List_Game[2][6] = value;
                OnPropertyChanged(nameof(El26));
            }
        }
        public int El27
        {
            get { return _info.List_Game[2][7]; }
            set
            {
                _info.List_Game[2][7] = value;
                OnPropertyChanged(nameof(El27));
            }
        }
        public int El28
        {
            get { return _info.List_Game[2][8]; }
            set
            {
                _info.List_Game[2][8] = value;
                OnPropertyChanged(nameof(El28));
            }
        }
        #endregion Tabl_3
        #region Tabl_4
        public int El30
        {
            get { return _info.List_Game[3][0]; }
            set
            {
                _info.List_Game[3][0] = value;
                OnPropertyChanged(nameof(El30));
            }
        }
        public int El31
        {
            get { return _info.List_Game[3][1]; }
            set
            {
                _info.List_Game[3][1] = value;
                OnPropertyChanged(nameof(El31));
            }
        }
        public int El32
        {
            get { return _info.List_Game[3][2]; }
            set
            {
                _info.List_Game[3][2] = value;
                OnPropertyChanged(nameof(El32));
            }
        }
        public int El33
        {
            get { return _info.List_Game[3][3]; }
            set
            {
                _info.List_Game[3][3] = value;
                OnPropertyChanged(nameof(El33));
            }
        }
        public int El34
        {
            get { return _info.List_Game[3][4]; }
            set
            {
                _info.List_Game[3][4] = value;
                OnPropertyChanged(nameof(El34));
            }
        }
        public int El35
        {
            get { return _info.List_Game[3][5]; }
            set
            {
                _info.List_Game[3][5] = value;
                OnPropertyChanged(nameof(El35));
            }
        }
        public int El36
        {
            get { return _info.List_Game[3][6]; }
            set
            {
                _info.List_Game[3][6] = value;
                OnPropertyChanged(nameof(El36));
            }
        }
        public int El37
        {
            get { return _info.List_Game[3][7]; }
            set
            {
                _info.List_Game[3][7] = value;
                OnPropertyChanged(nameof(El37));
            }
        }
        public int El38
        {
            get { return _info.List_Game[3][8]; }
            set
            {
                _info.List_Game[3][8] = value;
                OnPropertyChanged(nameof(El38));
            }
        }
        #endregion Tabl_4
        #region Tabl_5
        public int El40
        {
            get { return _info.List_Game[4][0]; }
            set
            {
                _info.List_Game[4][0] = value;
                OnPropertyChanged(nameof(El40));
            }
        }
        public int El41
        {
            get { return _info.List_Game[4][1]; }
            set
            {
                _info.List_Game[4][1] = value;
                OnPropertyChanged(nameof(El41));
            }
        }
        public int El42
        {
            get { return _info.List_Game[4][2]; }
            set
            {
                _info.List_Game[4][2] = value;
                OnPropertyChanged(nameof(El42));
            }
        }
        public int El43
        {
            get { return _info.List_Game[4][3]; }
            set
            {
                _info.List_Game[4][3] = value;
                OnPropertyChanged(nameof(El43));
            }
        }
        public int El44
        {
            get { return _info.List_Game[4][4]; }
            set
            {
                _info.List_Game[4][4] = value;
                OnPropertyChanged(nameof(El44));
            }
        }
        public int El45
        {
            get { return _info.List_Game[4][5]; }
            set
            {
                _info.List_Game[4][5] = value;
                OnPropertyChanged(nameof(El45));
            }
        }
        public int El46
        {
            get { return _info.List_Game[4][6]; }
            set
            {
                _info.List_Game[4][6] = value;
                OnPropertyChanged(nameof(El46));
            }
        }
        public int El47
        {
            get { return _info.List_Game[4][7]; }
            set
            {
                _info.List_Game[4][7] = value;
                OnPropertyChanged(nameof(El47));
            }
        }
        public int El48
        {
            get { return _info.List_Game[4][8]; }
            set
            {
                _info.List_Game[4][8] = value;
                OnPropertyChanged(nameof(El48));
            }
        }
        #endregion Tabl_5
        #region Tabl_6
        public int El50
        {
            get { return _info.List_Game[5][0]; }
            set
            {
                _info.List_Game[5][0] = value;
                OnPropertyChanged(nameof(El50));
            }
        }
        public int El51
        {
            get { return _info.List_Game[5][1]; }
            set
            {
                _info.List_Game[5][1] = value;
                OnPropertyChanged(nameof(El51));
            }
        }
        public int El52
        {
            get { return _info.List_Game[5][2]; }
            set
            {
                _info.List_Game[5][2] = value;
                OnPropertyChanged(nameof(El52));
            }
        }
        public int El53
        {
            get { return _info.List_Game[5][3]; }
            set
            {
                _info.List_Game[5][3] = value;
                OnPropertyChanged(nameof(El53));
            }
        }
        public int El54
        {
            get { return _info.List_Game[5][4]; }
            set
            {
                _info.List_Game[5][4] = value;
                OnPropertyChanged(nameof(El54));
            }
        }
        public int El55
        {
            get { return _info.List_Game[5][5]; }
            set
            {
                _info.List_Game[5][5] = value;
                OnPropertyChanged(nameof(El55));
            }
        }
        public int El56
        {
            get { return _info.List_Game[5][6]; }
            set
            {
                _info.List_Game[5][6] = value;
                OnPropertyChanged(nameof(El56));
            }
        }
        public int El57
        {
            get { return _info.List_Game[5][7]; }
            set
            {
                _info.List_Game[5][7] = value;
                OnPropertyChanged(nameof(El57));
            }
        }
        public int El58
        {
            get { return _info.List_Game[5][8]; }
            set
            {
                _info.List_Game[5][8] = value;
                OnPropertyChanged(nameof(El58));
            }
        }
        #endregion Tabl_6
        #region Tabl_7
        public int El60
        {
            get { return _info.List_Game[6][0]; }
            set
            {
                _info.List_Game[6][0] = value;
                OnPropertyChanged(nameof(El60));
            }
        }
        public int El61
        {
            get { return _info.List_Game[6][1]; }
            set
            {
                _info.List_Game[6][1] = value;
                OnPropertyChanged(nameof(El61));
            }
        }
        public int El62
        {
            get { return _info.List_Game[6][2]; }
            set
            {
                _info.List_Game[6][2] = value;
                OnPropertyChanged(nameof(El62));
            }
        }
        public int El63
        {
            get { return _info.List_Game[6][3]; }
            set
            {
                _info.List_Game[6][3] = value;
                OnPropertyChanged(nameof(El63));
            }
        }
        public int El64
        {
            get { return _info.List_Game[6][4]; }
            set
            {
                _info.List_Game[6][4] = value;
                OnPropertyChanged(nameof(El64));
            }
        }
        public int El65
        {
            get { return _info.List_Game[6][5]; }
            set
            {
                _info.List_Game[6][5] = value;
                OnPropertyChanged(nameof(El65));
            }
        }
        public int El66
        {
            get { return _info.List_Game[6][6]; }
            set
            {
                _info.List_Game[6][6] = value;
                OnPropertyChanged(nameof(El66));
            }
        }
        public int El67
        {
            get { return _info.List_Game[6][7]; }
            set
            {
                _info.List_Game[6][7] = value;
                OnPropertyChanged(nameof(El67));
            }
        }
        public int El68
        {
            get { return _info.List_Game[6][8]; }
            set
            {
                _info.List_Game[6][8] = value;
                OnPropertyChanged(nameof(El68));
            }
        }
        #endregion Tabl_7
        #region Tabl_8
        public int El70
        {
            get { return _info.List_Game[7][0]; }
            set
            {
                _info.List_Game[7][0] = value;
                OnPropertyChanged(nameof(El70));
            }
        }
        public int El71
        {
            get { return _info.List_Game[7][1]; }
            set
            {
                _info.List_Game[7][1] = value;
                OnPropertyChanged(nameof(El71));
            }
        }
        public int El72
        {
            get { return _info.List_Game[7][2]; }
            set
            {
                _info.List_Game[7][2] = value;
                OnPropertyChanged(nameof(El72));
            }
        }
        public int El73
        {
            get { return _info.List_Game[7][3]; }
            set
            {
                _info.List_Game[7][3] = value;
                OnPropertyChanged(nameof(El73));
            }
        }
        public int El74
        {
            get { return _info.List_Game[7][4]; }
            set
            {
                _info.List_Game[7][4] = value;
                OnPropertyChanged(nameof(El74));
            }
        }
        public int El75
        {
            get { return _info.List_Game[7][5]; }
            set
            {
                _info.List_Game[7][5] = value;
                OnPropertyChanged(nameof(El75));
            }
        }
        public int El76
        {
            get { return _info.List_Game[7][6]; }
            set
            {
                _info.List_Game[7][6] = value;
                OnPropertyChanged(nameof(El76));
            }
        }
        public int El77
        {
            get { return _info.List_Game[7][7]; }
            set
            {
                _info.List_Game[7][7] = value;
                OnPropertyChanged(nameof(El77));
            }
        }
        public int El78
        {
            get { return _info.List_Game[7][8]; }
            set
            {
                _info.List_Game[7][8] = value;
                OnPropertyChanged(nameof(El78));
            }
        }
        #endregion Tabl_8
        #region Tabl_9
        public int El80
        {
            get { return _info.List_Game[8][0]; }
            set
            {
                _info.List_Game[8][0] = value;
                OnPropertyChanged(nameof(El80));
            }
        }
        public int El81
        {
            get { return _info.List_Game[8][1]; }
            set
            {
                _info.List_Game[8][1] = value;
                OnPropertyChanged(nameof(El81));
            }
        }
        public int El82
        {
            get { return _info.List_Game[8][2]; }
            set
            {
                _info.List_Game[8][2] = value;
                OnPropertyChanged(nameof(El82));
            }
        }
        public int El83
        {
            get { return _info.List_Game[8][3]; }
            set
            {
                _info.List_Game[8][3] = value;
                OnPropertyChanged(nameof(El83));
            }
        }
        public int El84
        {
            get { return _info.List_Game[8][4]; }
            set
            {
                _info.List_Game[8][4] = value;
                OnPropertyChanged(nameof(El84));
            }
        }
        public int El85
        {
            get { return _info.List_Game[8][5]; }
            set
            {
                _info.List_Game[8][5] = value;
                OnPropertyChanged(nameof(El85));
            }
        }
        public int El86
        {
            get { return _info.List_Game[8][6]; }
            set
            {
                _info.List_Game[8][6] = value;
                OnPropertyChanged(nameof(El86));
            }
        }
        public int El87
        {
            get { return _info.List_Game[8][7]; }
            set
            {
                _info.List_Game[8][7] = value;
                OnPropertyChanged(nameof(El87));
            }
        }
        public int El88
        {
            get { return _info.List_Game[8][8]; }
            set
            {
                _info.List_Game[8][8] = value;
                OnPropertyChanged(nameof(El88));
            }
        }
        #endregion Tabl_1
        #endregion HELL
    }
}
