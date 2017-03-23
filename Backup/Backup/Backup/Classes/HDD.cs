using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Classes
{
    class HDD : Storage
    {
        double speed_usb_2 = 25;
        double v_memory;
        double free_memory;

        public HDD(string Name_, string Model_, double v_memory_)
            : base(Name_, Model_)
        {
            V_memory = v_memory_;
        }

        public double V_memory
        {
            get
            {
                return v_memory;
            }

            set
            {
                v_memory = value;
            }
        }

        public double Free_memory
        {
            get
            {
                return free_memory;
            }

            set
            {
                if (value >= 0) free_memory = value;
            }
        }

        public override void Copy_Data(ref double V)
        {
            double local = 0; int count = 0;
            while (local <= V_memory)
            {
                if (local + File_Memory > V_memory) break;
                {
                    V -= File_Memory;
                    local += File_Memory;
                    ++count;
                }
            }
            Free_memory = v_memory - local;
        }

        public override double Get_Free_Mem()
        {
            return free_memory;
        }

        public override double Get_Memory()
        {
            return v_memory;
        }

        public override double Get_Speed_rec()
        {
            return V_memory / speed_usb_2;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}s\t{3} ", Name, Model, V_memory, speed_usb_2);
        }
    }
}
