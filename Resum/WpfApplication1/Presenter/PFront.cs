using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.Presenter
{
    class PFront
    {
        private Model.Сontainer myContainer=new Model.Сontainer();
        private readonly Interfese.IFront _view;
        public PFront(Interfese.IFront view)
        {

            myContainer.SetSerializer(new Model.XMLSerializer());
            myContainer.Load();

            _view = view;
            // Презентер подписывается на уведомления о событиях Представления

            _view.AddResum += new EventHandler<EventArgs>(AddResum);
            _view.OpenList += new EventHandler<EventArgs>(OpenList);
           
            // UpdateView();
        }
        private void AddResum(object sender, EventArgs e)
        {
            if (_view.Nfo != "" && _view.Nfo != null)
                myContainer.Add(new Model.Info(_view.Nfo, _view.Value, _view.FamelyStatys, _view.Adress, _view.E_mail, _view.ChecBoxs));
            else
                throw new Exception("поле ФИО должо быть заполненно");
        }
        private void OpenList(object sender, EventArgs e)
        {
            for(int i=0;i<myContainer.Count();i++)
            {
                _view.ElementResum.Add(myContainer.Element(i).Nfo);
            }
            
        }
        
    }
}
