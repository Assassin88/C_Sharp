using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Classes
{
    class Information
    {
        public static void Type_Invorm(Storage[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Name == "USB") Console.WriteLine((Flash)array[i]);
                if (array[i].Name == "DVD") Console.WriteLine((DVD)array[i]);
                if (array[i].Name == "HDD") Console.WriteLine((HDD)array[i]);
            }
        } 

        public static void All_Inform(Storage[] array, ref double V)
        {
            double copy_V = V;
            double count_all_mem_ = 0;
            double count_all_free_ = 0;
            double count_time_ = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                array[i].Copy_Data(ref V);
                count_all_mem_ += array[i].Get_Memory();
                count_all_free_ += array[i].Get_Free_Mem();
                count_time_ += array[i].Get_Speed_rec();
            }
            Console.WriteLine("All_memory = {0}", count_all_mem_ / 1000 + " GB");
            Console.WriteLine("V_after_copy = {0}", V + " MB");
            Console.WriteLine("All_free_mem = {0}", count_all_free_ + " MB");

            Console.WriteLine("\nCount_memory_disc = " + array.Length);
            Console.WriteLine("Count_all_time_record = " + (int)((count_time_ / 60) / 60) + " hours " + 
                (int)((count_time_ % 60)) + " minuts ");           
            Console.WriteLine("Count_repetition: = " + (int)(copy_V / count_all_mem_) +
                " or " + (int)(array.Length * (copy_V / count_all_mem_)) + " memory_disc");
            Console.WriteLine("Free_memory_after_copy = " + (int)(count_all_free_ * (copy_V / count_all_mem_)) + " MB");
        }
    }
}
