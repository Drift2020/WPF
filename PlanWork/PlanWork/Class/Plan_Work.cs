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


        DispatcherTimer tempTimer;


        public void Delete(int i)
        {
            myInfo.Remove(i);
            _viwe.WorkList.RemoveAt(i);
            _viwe.Worc.Items.RemoveAt(i);
            if (myInfo.Count() == 0)
                tempTimer.Stop();
            myInfo.Save();
        }

        public void Add(Interfese.IAdd viwe)
        {
        
            Model.Info Info = new Model.Info(viwe.Path, viwe.DateThis, viwe.MyWork, viwe.Days_of_the_week);
            myInfo.Add(Info);
            myInfo.Save();


            tempTimer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            for (int number = 0; number < myInfo.Count(); number++)
                if (DateTime.Compare(myInfo.Element(number).DateThis, DateTime.Now) == 0 || DateTime.Compare(myInfo.Element(number).DateThis, DateTime.Now) < 0)
                    try
                    {
                        switch (myInfo.Element(number).MyWork)
                        {
                            case Model.Work.daily:

                                System.Diagnostics.Process.Start(myInfo.Element(number).Path);

                                myInfo.Element(number).DateThis = myInfo.Element(number).DateThis.AddDays(1);
                                _viwe.NewMesege = string.Format("Задача {0} была выполнена в {1}", myInfo.Element(number).Path, DateTime.Now);
                                EditList?.Invoke(this, EventArgs.Empty);
                                break;
                            case Model.Work.weekly:
                                    System.Diagnostics.Process.Start(myInfo.Element(number).Path);
                                    _viwe.NewMesege = string.Format("Задача {0} была выполнена в {1}", myInfo.Element(number).Path, DateTime.Now);
                                    EditList?.Invoke(this, EventArgs.Empty);

                                    bool isSerhc = true;
                                    int i1 = 0;
                                    int i = (int)myInfo.Element(number).DateThis.DayOfWeek;
                                    do
                                    {
                                        for (; i < 7; i++, i1++)
                                        {
                                            if (myInfo.Element(number).Days_of_the_week[i] == true)
                                            {
                                                myInfo.Element(number).DateThis = myInfo.Element(number).DateThis.AddDays((i1 + i + 1));
                                                isSerhc = false;
                                                break;
                                            }

                                        }
                                        i = 0;
                                    } while (isSerhc == true);

                                break;
                            case Model.Work.monthly:

                                    System.Diagnostics.Process.Start(myInfo.Element(number).Path);

                                    myInfo.Element(number).DateThis = myInfo.Element(number).DateThis.AddMonths(1);
                                    _viwe.NewMesege = string.Format("Задача {0} была выполнена в {1}", myInfo.Element(number).Path, DateTime.Now);
                                    EditList?.Invoke(this, EventArgs.Empty);
                                break;
                            case Model.Work.once:

                                    System.Diagnostics.Process.Start(myInfo.Element(number).Path);
                                    _viwe.NewMesege = string.Format("Задача {0} была выполнена в {1}", myInfo.Element(number).Path, DateTime.Now);
                                    EditList?.Invoke(this, EventArgs.Empty);
                                    Delete(number);

                                break;

                        }

                    }

                    catch (Exception ex)
                    {

                        Delete(number);
                        _viwe.NewMesege = string.Format("Задача {0} была прорваленна в {1}, информация ошибки: {2}", myInfo.Element(number).Path, DateTime.Now, ex.Message);
                        EditList?.Invoke(this, EventArgs.Empty);
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


            myInfo.Load();

            for (int i = 0; i < myInfo.Count(); i++)
            {
                viwe.WorkList.Add(myInfo.Element(i).Path);
            }

            tempTimer = new DispatcherTimer();
            tempTimer.Tick += new EventHandler(timer_Tick);
            TimeSpan tempSpan = new TimeSpan(100);
            tempTimer.Interval = tempSpan;



            tempTimer.Start();

        }
    }
}
