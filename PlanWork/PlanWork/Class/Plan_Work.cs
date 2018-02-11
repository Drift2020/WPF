using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlanWork.Class
{
    class Plan_Work : Interfese.ICompliteWork
    {
        public event EventHandler<EventArgs> EditList;

        Interfese.IFront _viwe;
        private Model.Сontainer myInfo;
        private string path;
        DispatcherTimer tempTimer;
        TimeSpan tempSpan;
        private DateTime dateThis;
        private Model.Work myWork;
        private bool[] days_of_the_week;
        private int number;
        private List<DispatcherTimer> timer;

        public string Path { get { return path; } set { path = value; } }
        public DateTime DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
       
        public Model.Work MyWork { get { return myWork; } set { myWork = value; } }

        public void Delete(int i)
        {
              myInfo.Remove(i);                                  
              _viwe.WorkList.RemoveAt(i);
              _viwe.Worc.Items.RemoveAt(i);         
              timer[i].Stop();
              timer.RemoveAt(i);
            myInfo.Save();
        }

        public void Add(Interfese.IAdd viwe)
        {
            path = viwe.Path;
            number = viwe.Number;
            dateThis = viwe.DateThis;         
            myWork = viwe.MyWork;
            days_of_the_week = viwe.Days_of_the_week;
            Model.Info Info = new Model.Info(path, dateThis, myWork, days_of_the_week);
            myInfo.Add(Info);

             tempTimer = new DispatcherTimer();
            
          
             tempSpan=new TimeSpan(100);
            tempTimer.Interval = tempSpan;


           

            tempTimer.Tick += new EventHandler(timer_Tick);
            timer.Add(tempTimer);
            tempTimer.Start();         
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Compare(myInfo.Element(number).DateThis, DateTime.Now) == 0 || DateTime.Compare(myInfo.Element(number).DateThis, DateTime.Now) < 0)
                switch (MyWork)
                {
                    case Model.Work.daily:


                        try
                        {
                            System.Diagnostics.Process.Start(myInfo.Element(number).Path);
                            //_viwe.ComplitWork.Items.Add(new Label().Content = string.Format("Задача была выполнена в {0}", myInfo.Element(number).DateThis));
                                //if (myInfo.Element(number).Path == Path &&
                                //    myInfo.Element(number).MyWork == MyWork &&
                                //    myInfo.Element(number).DateThis.CompareTo(DateThis) == 0 &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[0] &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[1] &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[2] &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[3] &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[4] &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[5] &&
                                //    myInfo.Element(number).Days_of_the_week[0] == Days_of_the_week[6])
                                //{
                            myInfo.Element(number).DateThis = DateThis = myInfo.Element(number).DateThis.AddDays(1);
                            _viwe.NewMesege = string.Format("Задача {0} была выполнена в {1}", myInfo.Element(number).Path, DateTime.Now);
                            EditList?.Invoke(this, EventArgs.Empty);

                         
                        }
                        
                        catch (Exception ex)
                        {
                            
                            Delete(number);
                            _viwe.NewMesege = string.Format("Задача {0} была прорваленна в {1}, информация ошибки: {2}", myInfo.Element(number).Path, DateTime.Now,ex.Message);
                            EditList?.Invoke(this, EventArgs.Empty);
                        }
                        //tempTimer.Stop();
                        // timer.Remove(tempTimer);

                       


                        break;
                    case Model.Work.weekly:

                        break;
                    case Model.Work.monthly:

                        break;
                    case Model.Work.once:


                        System.Diagnostics.Process.Start(Path);
                        Delete(number);


                        break;

                }
        }
        public void Save()
        {
            myInfo.Save();
        }

        

        public Plan_Work(Interfese.IFront viwe)
        {
            _viwe = viwe;

            myInfo = new Model.Сontainer();
            myInfo.SetSerializer(new Model.XMLSerializer());
            timer = new List<DispatcherTimer>();

            myInfo.Load();

            for (int i = 0; i < myInfo.Count(); i++)
            {
                viwe.WorkList.Add(myInfo.Element(i).Path);
                tempTimer = new DispatcherTimer();
                tempSpan = new TimeSpan(100);
                tempTimer.Interval = tempSpan;

                tempTimer.Tick += new EventHandler(timer_Tick);
                timer.Add(tempTimer);
                tempTimer.Start();

            }

            
        }
    }
}
