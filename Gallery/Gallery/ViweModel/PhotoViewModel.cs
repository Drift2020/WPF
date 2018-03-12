using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
   public class PhotoViewModel : ViewModelBase ,ICloneable
    {
        public object Clone()
        {
            return new PhotoViewModel(Name, Path, Date, Autor,Mark);
        }
        private Photos Photo;

        public PhotoViewModel(Photos photo)
        {
            Photo = photo;
        }

       

        public PhotoViewModel(string _name, string _path, string _date, string _author, int _mark)
        {
            Name = _name;
            Path = _path;
            Date = _date;
            Autor = _author;
            Mark = _mark;
        }

        public PhotoViewModel()
        {
            Photo = new Photos();
        }


        public string Name
        {
            get
            {
                return Photo.name;
            }
            set
            {
                Photo.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Date
        {
            get
            {
                return Photo.date;
            }
            set
            {
                Photo.date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Autor
        {
            get
            {
                return Photo.author;
            }
            set
            {
                Photo.author = value;
                OnPropertyChanged(nameof(Autor));
            }
        }

        public string Path
        {
            get
            {
                return Photo.path;
            }
            set
            {
                Photo.path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public int Mark
        {
            get
            {
                return Photo.mark;
            }
            set
            {
                Photo.mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }
    }
}
