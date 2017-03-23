using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Classes
{
	class Flash : Storage
	{
        double v_memory;
        double speed_usb = 119;
        double free_memory;

        public Flash(string Name_, string Model_, double V_memory_)
            : base(Name_, Model_)
        {
            V_memory = V_memory_;
        }

        public double V_memory
		{
			get
			{
				return v_memory;
			}

			set
			{
				if (value > 0) { v_memory = value; }	
			}
		}

		public double Speed_usb
		{
			get
			{
				return speed_usb;
			}

			set
			{
				if (value > 0) { speed_usb = value; }
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
				if (value >= 0) { free_memory = value; }
			}
		}

		public override double Get_Free_Mem()
		{
			return free_memory;
		}

        public override double Get_Speed_rec()
        {
            return V_memory / Speed_usb;
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
			Free_memory = V_memory - local;
		}

		public override double Get_Memory()
		{
			return v_memory;
		}

		public override string ToString()
		{
			return String.Format("{0}\t{1}\t{2}\t{3}", Name, Model, V_memory, Speed_usb);
		}
	}
}
