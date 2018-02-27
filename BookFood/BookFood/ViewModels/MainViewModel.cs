using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookFood.Models;
using System.Windows.Controls;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace BookFood
{
    class MainViewModel : ViewModelBase
    {
        public Action Question { get; set; }
        public Action Not_Element { get; set; }
        public Action Exit { get; set; }
        public ObservableCollection<FoodViewModel> FoodsList { get; set; }

        #region
        FileStream stream = null;
        XmlSerializer serializer = null;
        public void Save()
        {
            try
            {
                stream = new FileStream("../../list.xml", FileMode.Create);
            serializer = new XmlSerializer(typeof(ObservableCollection<FoodViewModel>));
            serializer.Serialize(stream, FoodsList);
            stream.Close();
             }
             catch (Exception ex)
            {

                if (stream != null)
                    stream.Close();
            };

        }
        public void Load()
        {
           
            try
            {
                stream = new FileStream("../../list.xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(ObservableCollection<FoodViewModel>));
                FoodsList = (ObservableCollection<FoodViewModel>)serializer.Deserialize(stream);


                stream.Close();

                
            }
            catch (Exception ex)
            {

                if (stream != null)
                    stream.Close();
            };

           
        }

        #endregion

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Save();
        }
        public MainViewModel()
        {
            FoodsList = new ObservableCollection<FoodViewModel>();
            Load();
        }

        public MainViewModel(List<Food> Foods)
        {
            FoodsList = new ObservableCollection<FoodViewModel>(Foods.Select(f => new FoodViewModel(f)));
            Load();
        }
       
        FoodViewModel _select_Item;
        public FoodViewModel Select_Item
        {
            get { return _select_Item; }
            set
            {
                _select_Item = value;
                OnPropertyChanged(nameof(Select_Item));
            }
        }


        private DelegateCommand _Command;
        public ICommand ButtonClick_New_Food
        {
            get
            {
                if (_Command == null)
                {
                    _Command = new DelegateCommand(Execute, CanExecute);
                }
                return _Command;
            }
        }
        private void Execute(object o)
        {

            Add_food myAdd = new Add_food();
            myAdd.Title = "Создание рецепта";
            AddViewModel myViewModel = new AddViewModel();
            myAdd.DataContext = myViewModel;

            if (myViewModel.CloseAction == null)
                myViewModel.CloseAction = new Action(myAdd.Close);


            myAdd.ShowDialog();

            if (myViewModel.is_ok == true)
            {
             
                FoodsList.Add(new FoodViewModel(new Food(myViewModel.Name_food, myViewModel.Image_path, myViewModel.Info_food, myViewModel.List_ingridient)));
            }

          

        }
        private bool CanExecute(object o)
        {                
                return true;
          
        }


        private DelegateCommand _Command_edit;
        public ICommand ButtonClick_Edit_Food
        {
            get
            {
                if (_Command_edit == null)
                {
                    _Command_edit = new DelegateCommand(Execute_Edit, CanExecute_Edit);
                }
                return _Command_edit;
            }
        }
        private void Execute_Edit(object o)
        {
            if (_select_Item != null)
            {
                Add_food myEdit = new Add_food();
                myEdit.Title = "Изменение рецепта";
                EditViewModel myViewModel = new EditViewModel((FoodViewModel)_select_Item.Clone());
                myEdit.DataContext = myViewModel;

                if (myViewModel.CloseAction == null)
                    myViewModel.CloseAction = new Action(myEdit.Close);


                myEdit.ShowDialog();

                if (myViewModel.is_ok == true)
                {
                    _select_Item.Image_path = myViewModel.Image_path;
                    _select_Item.Info_food = myViewModel.Info_food;
                    _select_Item.List_ingridient = myViewModel.List_ingridient;
                    _select_Item.Name_food = myViewModel.Name_food;
                }
            }
            else
            {
                Not_Element();
            }
        }
        private bool CanExecute_Edit(object o)
        {
            return true;

        }



        private DelegateCommand _Command_Exit;
        public ICommand ButtonClick_Exit
        {
            get
            {
                if (_Command_Exit == null)
                {
                    _Command_Exit = new DelegateCommand(Execute_Exit, CanExecute_Exit);
                }
                return _Command_Exit;
            }
        }
        private void Execute_Exit(object o)
        {
            Save();
            Exit();
        }       
        private bool CanExecute_Exit(object o)
        {
            return true;

        }


        

              private DelegateCommand _Command_Delete;
        public ICommand ButtonClick_New_Delete
        {
            get
            {
                if (_Command_Delete == null)
                {
                    _Command_Delete = new DelegateCommand(Execute_Delete, CanExecute_Delete);
                }
                return _Command_Delete;
            }
        }
        private void Execute_Delete(object o)
        {
            // Question();
            FoodsList.Remove(_select_Item);
            _select_Item = null;
        }
      
        private bool CanExecute_Delete(object o)
        {
            
            if (_select_Item == null)
                return false;
            return true;

        }
    }
}
