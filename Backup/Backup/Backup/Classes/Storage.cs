using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
	abstract class Storage
	{
		string name;
		string model;
        public double File_Memory = 780;

        public Storage(string Name_, string Model_)
		{
			Name = Name_;
			Model = Model_;
		}

		public string Name { get; set; }
		public string Model { get; set; }

		abstract public double Get_Memory();
		abstract public double Get_Free_Mem();
		abstract public void Copy_Data(ref double V);
		abstract public override string ToString();
        abstract public double Get_Speed_rec();
    }
}
