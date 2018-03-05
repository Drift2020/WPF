using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sudoku
{
   
    [Serializable(), XmlInclude(typeof(Info))]
    public class Info
    {
        private int levl;

        ObservableCollection<ObservableCollection<int>> list_Game;
        ObservableCollection<ObservableCollection<int>> view_list_Game;


        public Info(int Levl, ObservableCollection<ObservableCollection<int>> Pole, ObservableCollection<ObservableCollection<int>> View_list_Game)
        {       
            levl = Levl;
            list_Game = Pole;
            view_list_Game = View_list_Game;
        }

        public Info()
        {
            view_list_Game = new ObservableCollection<ObservableCollection<int>>();
            ObservableCollection<int> t = new ObservableCollection<int>();
            for (int y = 0; y < 9; y++)
            {
                t = new ObservableCollection<int>();

                for (int x = 0; x < 9; x++)
                {
                    t.Add(0);
                }
                view_list_Game.Add(t);
            }

            list_Game = new ObservableCollection<ObservableCollection<int>>();
         
            for (int y = 0; y < 9; y++)
            {
                t = new ObservableCollection<int>();

                for (int x = 0; x < 9; x++)
                {
                    t.Add(0);
                }
                list_Game.Add(t);
            }
        }

        public ObservableCollection<ObservableCollection<int>> List_Game { get { return list_Game; } set { list_Game = value; } }
        public ObservableCollection<ObservableCollection<int>> View_list_Game { get { return view_list_Game; } set { view_list_Game = value; } }
        public int Levl { get { return levl; } set { levl = value; } }


    }
}
