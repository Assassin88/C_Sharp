using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Classes
{
    class DVD : Storage
    {
        int type;
        double v_memory;
        double speed_dvd = 1.32;
        double free_memory;

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                if(value == 1 || value == 2) type = value;
            }
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
                if(value >= 0) free_memory = value;
            }
        }

        public DVD(string Name_, string Model_, int type_)
            : base(Name_, Model_)
        {
            Type = type_;
            if (type == 1) v_memory = 4700;
            else v_memory = 9000;
        }

        public override double Get_Speed_rec()
        {
            return V_memory / speed_dvd;
        }

        public override double Get_Free_Mem()
        {
            return free_memory;
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

        public override double Get_Memory()
        {
            return v_memory;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}", Name, Model, V_memory, speed_dvd);
        }
    }
}
