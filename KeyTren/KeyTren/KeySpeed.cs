using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KeyTren
{
  
    class KeySpeed
    {

   
        IFront _viwe;
       
        public KeySpeed(IFront viwe)
        {
            _viwe = viwe;
            _viwe.DownKey += new EventHandler<EventArgs>(DownKey);
            _viwe.Fails += new EventHandler<EventArgs>(Fails);
            _viwe.Speed_Chars += new EventHandler<EventArgs>(Speed_Chars);
            _viwe.Start+= new EventHandler<EventArgs>(Start);
            _viwe.Stop += new EventHandler<EventArgs>(Stop);
            _viwe.Start_program+= new EventHandler<EventArgs>(Start_program);
            _viwe.is_Start = false;
            _viwe.is_Enable_text_box = false;
            _viwe.is_Stop_button = false;
        }

        private void DownKey(object sender, EventArgs e)
        {

        }
        private void Fails(object sender, EventArgs e)
        {

        }
        private void PrintElement(object sender, EventArgs e)
        {

        }
        private void Speed_Chars(object sender, EventArgs e)
        {

        }
        private void Start(object sender, EventArgs e)
        {
            _viwe.is_Stop_button = _viwe.is_Start = true;
            _viwe.is_Start_button = false;
            _viwe.is_Enable_text_box = true;
            _viwe.is_Enable_slad_box = false;
            _viwe.is_Enable_chek_box = false;

            _viwe.prow_str = Add_String(_viwe.level);
        }
        private void Stop(object sender, EventArgs e)
        {
            _viwe.is_Start_button = true;
            _viwe.is_Stop_button = _viwe.is_Start = false;

            _viwe.is_Enable_text_box = false;
            _viwe.is_Enable_slad_box = true;
            _viwe.is_Enable_chek_box = true;
        }
        private void Start_program(object sender, EventArgs e)
        {

        }

        private string Add_String(int level)
        {
            string my_str="";
            string temp = "";
            Random my_rand=new Random();
            int lengh;
            
          
            for (int i = 0; i < 50; i++)
            {
                temp = "";
                lengh = my_rand.Next(1, 2*level);

                switch (level)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 128);
                        }
                        break;
                }

               

                my_str+=" " + temp;

            }
            return my_str;
        }
    }
}
