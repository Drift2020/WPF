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
    }
}
