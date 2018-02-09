using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlanWork.Class
{
    class Plan_Work
    {
        private Model.Сontainer myInfo;
        private string path;
       
        private DateTime dateThis;
        private Model.Work myWork;
        private bool[] days_of_the_week;

        private List<DispatcherTimer> timer;

        public string Path { get { return path; } set { path = value; } }
        public DateTime DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
       
        public Model.Work MyWork { get { return myWork; } set { myWork = value; } }


        public void Add(Interfese.IAdd viwe)
        {
            path = viwe.Path;
            dateThis = viwe.DateThis;         
            myWork = viwe.MyWork;
            days_of_the_week = viwe.Days_of_the_week;
            myInfo.Add(new Model.Info(path, dateThis, myWork, days_of_the_week));

            DispatcherTimer tempTimer = new DispatcherTimer();
            
            DateTime date1 = new DateTime(); 

            switch (MyWork)
            {
                case Model.Work.daily:
                    DateThis = DateThis.AddDays(1);
                    TimeSpan tempSpan(                    
                    tempTimer.Interval = tempSpan;

                    break;
                case Model.Work.weekly:
                    TimeSpan tempSpan = DateThis.Subtract(date1);
                    break;
                case Model.Work.monthly:

                    break;
                case Model.Work.once:

                    break;

            }
            tempTimer.Tick += new EventHandler(timer_Tick);
            //timer.Add();
        }

        public void Save()
        {
            myInfo.Save();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Model.Info InfoThisTime = (sender as Model.Info);

            //if (InfoThisTime != null)
            //{
                switch (InfoThisTime.MyWork)
                {
                    case Model.Work.daily:
                      
                            System.Diagnostics.Process.Start(InfoThisTime.Path);                    

                        break;
                    case Model.Work.weekly:

                        break;
                    case Model.Work.monthly:

                        break;
                    case Model.Work.once:
                        
                        break;

                }
                
           // }
        }

        public Plan_Work(List<string> workList)
        {
         

            myInfo = new Model.Сontainer();
            myInfo.SetSerializer(new Model.XMLSerializer());
            timer = new List<DispatcherTimer>();

            myInfo.Load();

            for (int i = 0; i < myInfo.Count(); i++)
                workList.Add(myInfo.Element(i).Path);


        }
    }
}
