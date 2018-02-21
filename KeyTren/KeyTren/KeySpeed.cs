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
        DateTime starts, now;
        public KeySpeed(IFront viwe)
        {
            starts = new DateTime();
            now = new DateTime();
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
            if(_viwe.is_Sensitive==false)
            {

                if(_viwe.my_chars.ToLower()[0] != _viwe.prow_str.ToLower()[(_viwe.my_str.Length)])
                {
                    _viwe.is_Fail = true;
                }
                else
                {

                    _viwe.is_Fail = false;

                    _viwe.my_str += _viwe.my_chars;

                    _viwe.ScrollToHOffset();
                }
            }
            else
            if(_viwe.my_chars[0]!=_viwe.prow_str[(_viwe.my_str.Length)])
            {
                _viwe.is_Fail = true;
            }
            else
            {
                _viwe.is_Fail = false;

                _viwe.my_str += _viwe.my_chars;

                _viwe.ScrollToHOffset();
            }

        }
        void PrintLins()
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
            now = DateTime.Now;
            TimeSpan f = now - starts;
            double m, s;
            m = f.Minutes * 60;
            s = f.Seconds;

            _viwe.speed_chars = Convert.ToDouble(_viwe.my_str.Length) / (m+s)/60 ;
        }
        private void Start(object sender, EventArgs e)
        {
            _viwe.is_Stop_button = _viwe.is_Start = true;
            _viwe.is_Start_button = false;
            _viwe.is_Enable_text_box = true;
            _viwe.is_Enable_slad_box = false;
            _viwe.is_Enable_chek_box = false;

            _viwe.prow_str = Add_String(_viwe.level);
            _viwe.fails = 0;

            _viwe.my_str = "";
            _viwe.my_chars = "";

            starts = DateTime.Now;
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
                lengh = my_rand.Next(1, my_rand.Next(1,5)+level);

                switch (level)
                {
                    case 1:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 43);
                        }
                        break;
                    case 2:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 54);
                        }
                        break;
                    case 3:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 65);
                        }
                        break;
                    case 4:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 76);
                        }
                        break;
                    case 5:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 87);
                        }
                        break;
                    case 6:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 98);
                        }
                        break;
                    case 7:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 109);
                        }
                        break;
                    case 8:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 110);
                        }
                        break;
                    case 9:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 115);
                        }
                        break;
                    case 10:
                        for (int il = 0; il < lengh; il++)
                        {
                            temp += (char)my_rand.Next(33, 128);
                        }
                        break;
                }

               

                my_str+= temp+ " " ;

            }
            return my_str;
        }
    }
}
