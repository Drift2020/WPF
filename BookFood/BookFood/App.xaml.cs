using System;
using System.Collections.Generic;
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
            List<Models.Food> foods = new List<Models.Food>()
            {
                new Models.Food("Рис","C:\\Users\\Buje_jy89\\Documents\\Visual Studio 2017\\Projects\\wpf\\WPF\\BookFood\\BookFood\\bin\\Debug\\image\\062.jpg","Чтобы вкусно приготовить рис нужно знать секреты его приготовления. Хитрость приготовления риса заключается в том, чтобы использовать в процессе при приготовления риса оптимальное количество воды так, чтобы рис не был переваренным… Рис являет практически универсальным в приготовлении разнообразных блюд, как экзотических, так и традиционных. Рис используют для плова или употребляют в качестве гарнира. Например, приготовленный рис может быть смешен с овощами или грибами для получения салата. К готовому рису можно добавить фрукты и сладости – и ваш десерт готов!Разберемся в том, как правильно готовить вкусный рис на примере длиннозернистого риса ТМ «Жменька», являющим наиболее популярным сортом риса и универсальным в применении.", new List<string>{ "1 стакан длиннозернистого риса", " 2 стакана воды", "1/2 чайной ложки соли", "1 столовая ложка сливочного масла (по желанию)", "1 чайная ложка сухих трав или специй (по желанию)"}),
             
            };

            MainWindow view = new MainWindow();
            ViewModels.MainViewModel viewModel = new ViewModels.MainViewModel(foods);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
