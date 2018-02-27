using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookFood
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            //List<Models.Food> foods = new List<Models.Food>()
            //{
            //    new Models.Food("Рис","C:\\Users\\Mamory\\Downloads\\1.jpg","Чтобы вкусно приготовить рис нужно знать секреты его приготовления. Хитрость приготовления риса заключается в том, чтобы использовать в процессе при приготовления риса оптимальное количество воды так, чтобы рис не был переваренным… Рис являет практически универсальным в приготовлении разнообразных блюд, как экзотических, так и традиционных. Рис используют для плова или употребляют в качестве гарнира. Например, приготовленный рис может быть смешен с овощами или грибами для получения салата. К готовому рису можно добавить фрукты и сладости – и ваш десерт готов!Разберемся в том, как правильно готовить вкусный рис на примере длиннозернистого риса ТМ «Жменька», являющим наиболее популярным сортом риса и универсальным в применении.", new ObservableCollection<string>{ "1 стакан длиннозернистого риса", " 2 стакана воды", "1/2 чайной ложки соли", "1 столовая ложка сливочного масла (по желанию)", "1 чайная ложка сухих трав или специй (по желанию)"}),
             
            //};

            MainWindow view = new MainWindow();
            
            MainViewModel viewModel = new MainViewModel();
            view.DataContext = viewModel;
            if (viewModel.Not_Element == null)
                viewModel.Not_Element = new Action(view.Show_Sellect_Item);

            if (viewModel.Exit == null)
                viewModel.Exit = new Action(view.Close);

            if (viewModel.Question == null)
                viewModel.Question = new Action(view.Question);
            

            view.Closing += viewModel.OnWindowClosing;
            view.Show();
        }
    }
}
