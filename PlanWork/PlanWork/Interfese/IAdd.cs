﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanWork.Interfese
{
   public interface IAdd
   {
         string Path { get; set; }
         string DateThis { get; set; }
         bool[] Days_of_the_week { get; set; }
         string TimeThis { get; set; }
         Model.Work MyWork { get; set; }
    }
}
