﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public interface ISerializer
    {        
            void Save(ICollection<Info> collection);
            ICollection<Info> Load();
        
    }
}
