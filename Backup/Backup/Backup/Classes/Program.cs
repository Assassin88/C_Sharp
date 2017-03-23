using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backup.Classes;

namespace Backup
{
	class Program
	{
        static void Main(string[] args)
		{
            double V_Mem = 565000;

            //Storage[] GB = {
            //    new Flash("USB_3.0", "Flop", 32000),
            //    new Flash("USB_3.0", "Flop", 8000),
            //    new Flash("USB_3.0", "Flop", 16000),
            //    new Flash("USB_3.0", "Flop", 32000),
            //    new Flash("USB_3.0", "Flop", 16000),
            //    new Flash("USB_3.0", "Flop", 64000)
            //    };

            //Storage[] GB = {
            //    new DVD("DVD", "RW", 1),
            //    new DVD("DVD", "RW", 1),
            //    new DVD("DVD", "RW", 1),
            //    new DVD("DVD", "RW", 2),
            //    new DVD("DVD", "RW", 2),
            //    new DVD("DVD", "RW", 2)
            //    };


            //Storage[] GB = {
            //    new HDD("HDD", "2.0", 120000),
            //    new HDD("HDD", "2.0", 120000),
            //    new HDD("HDD", "2.0", 120000),
            //    new HDD("HDD", "2.0", 60000),
            //    new HDD("HDD", "2.0", 60000),
            //    new HDD("HDD", "2.0", 20000)
            //    };


            Storage[] GB = {
                new Flash("USB", "3.0", 32000),
                new Flash("USB", "3.0", 64000),
                new DVD("DVD", "RW", 1),
                new DVD("DVD", "RW", 2),
                new HDD("HDD", "2.0", 240000),
                new HDD("HDD", "2.0", 120000)
                };

            Console.WriteLine("Fuul_information_memories_in_STORAGE!!!\n");
            Information.Type_Invorm(GB);
            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("Calculation_information_by_STORAGE!!!\n");
            Information.All_Inform(GB, ref V_Mem);
            Console.WriteLine();
            Console.Read();
		}
	}
}
