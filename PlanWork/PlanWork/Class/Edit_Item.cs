using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanWork.Class
{
    public class Edit_Item 
    {

        private readonly Model.Сontainer myInfo;
        private readonly Interfese.IEdit _view;

        public Edit_Item(Interfese.IEdit view)
        {
            _view = view;
            _view.PoleInfo += new EventHandler<EventArgs>(PrintElement);
            _view.Edit_Save += new EventHandler<EventArgs>(Edit_Save);
            myInfo = new Model.Сontainer();
            myInfo.SetSerializer(new Model.XMLSerializer());
            myInfo.Load();
        }
        private void PrintElement(object sender, EventArgs e)
        {

            _view.Path = myInfo.Element(_view.Number).Path;
            _view.DateThis = myInfo.Element(_view.Number).DateThis;
            _view.Days_of_the_week = myInfo.Element(_view.Number).Days_of_the_week;
            _view.MyWork = myInfo.Element(_view.Number).MyWork;
       
        }
        private void Edit_Save(object sender, EventArgs e)
        {
            myInfo.Element(_view.Number).Number = _view.Number;
            myInfo.Element(_view.Number).DateThis = _view.DateThis;
            myInfo.Element(_view.Number).Days_of_the_week = _view.Days_of_the_week;
            myInfo.Element(_view.Number).MyWork = _view.MyWork;
            myInfo.Save();
        }

    }
}
