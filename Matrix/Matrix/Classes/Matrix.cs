using Matrix;
using Matrix.Classes;
using System;
using System.Threading;

namespace Matrix
{
    class Matrix
    {
        private int[,] matrix;
        private int rows;
        private int columns;


        public Matrix(int r_, int c_)
        {
            rows = r_;
            columns = c_;
            matrix = new int[rows, columns];
        }

        public Matrix(int M_)
        {
            rows = columns = M_;
            matrix = new int[rows, columns];
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }

            set
            {
                columns = value;
            }
        }


        public void Init_Def(int x)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    matrix[i, j] = x;
                }
            }
        }

        public void Init_User()
        {
            Console.WriteLine("Enter_matrix_elements: ", rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Int32.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
        }

        public void Init_Random(int min, int max)
        {
            if (min > max) { min = 0; max = 100; }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Randomer.Next(min, max);
                }
            }
        }

        public void Init_Random_avto()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Randomer.Next(0, 10);
                }
            }
        }

        public bool Swap_Diagonal()
        {
            if (rows != columns) { return false; }
            int i = 0, k = rows - 1;
            int x;
            for (int j = 0; j < rows; j++)
            {
                x = matrix[i, j];
                matrix[i++, j] = matrix[k, j];
                matrix[k--, j] = x;
            }
            return true;
        }


        public void toString()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static Matrix Transponer(Matrix arr)
        {
            Matrix array = new Matrix(arr.columns, arr.rows);
            for (int i = 0; i < array.rows; i++)
            {
                for (int j = 0; j < array.columns; j++)
                {
                    array.matrix[i, j] = arr.matrix[j, i];
                }
            }
            return array;
        }

        public static Matrix Sort_Rows(Matrix arr)
        {
            int[] arr_ = new int[arr.columns];
            for (int i = 0; i < arr.rows; i++)
            {
                for (int j = 0; j < arr.columns; j++)
                {
                    arr_[j] = arr.matrix[i, j];
                }
                Array.Sort(arr_);
                for (int j = 0; j < arr.columns; j++)
                {
                    arr.matrix[i, j] = arr_[j];
                }
            }
            return arr;
        }

        public static Matrix Sort_Col(Matrix arr)
        {
            int[] arr_ = new int[arr.rows]; ;
            for (int i = 0; i < arr.columns; i++)
            {
                for (int j = 0; j < arr.rows; j++)
                {
                    arr_[j] = arr.matrix[j, i];
                }
                Array.Sort(arr_);
                for (int j = 0; j < arr.rows; j++)
                {
                    arr.matrix[j, i] = arr_[j];
                }
            }
            return arr;
        }

        public static Matrix Sort(Matrix arr)
        {
            int[] arr_ = new int[arr.rows * arr.columns];
            int k = 0;
            for (int i = 0; i < arr.rows; i++)
            {
                for (int j = 0; j < arr.columns; j++)
                {
                    arr_[k++] = arr.matrix[i, j];
                }
            }
            Array.Sort(arr_);
            k = 0;
            for (int i = 0; i < arr.rows; i++)
            {
                for (int j = 0; j < arr.columns; j++)
                {
                    arr.matrix[i, j] = arr_[k++];
                }
            }
            return arr;
        }

        public static Matrix Copy(Matrix arr)
        {
            Matrix arr_ = new Matrix(arr.rows, arr.columns);
            for (int i = 0; i < arr.rows; i++)
            {
                for (int j = 0; j < arr.columns; j++)
                {
                    arr_.matrix[i, j] = arr.matrix[i, j];
                }
            }
            return arr_;
        }

        public static Matrix operator *(Matrix arr1, Matrix arr2)
        {
            Matrix arr_;
            if (arr1.rows != arr2.columns)
            { throw new ExceptionExit("Invalid_size"); }
            else
            {
                int x = arr1.rows;
                arr_ = new Matrix(x, x);
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        for (int k = 0; k < x; k++)
                        {
                            arr_.matrix[i, j] += arr1.matrix[i, k] * arr2.matrix[k, j];
                        }
                    }
                }
            }
            return arr_;
        }

        public static void Start()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            int menu = 0; bool menu_b = true;

            while (menu_b)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Init_Def");
                Console.WriteLine("2. Init_User");
                Console.WriteLine("3. Init_Random");
                Console.WriteLine("4. Swap_Diagonal");
                Console.WriteLine("5. Transponer");
                Console.WriteLine("6. Sort_Rows");
                Console.WriteLine("7. Sort_Col");
                Console.WriteLine("8. Sort");
                Console.WriteLine("9. Copy");
                Console.WriteLine("10. Multiplication");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Enter_point_menu: ");
                try
                {
                    menu = Int32.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.Write("Enter_default_value: ");
                                int y = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Def(y);
                                arr.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_User();
                                Console.WriteLine();
                                arr.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.Write("Enter_min_value: ");
                                int min = Int32.Parse(Console.ReadLine());
                                Console.Write("Enter_max_value: ");
                                int max = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random(min, max);
                                Console.WriteLine();
                                arr.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                arr.Swap_Diagonal();
                                arr.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 5:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                Matrix arr_ = Matrix.Transponer(arr);
                                arr_.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 6:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                Matrix arr_ = Matrix.Sort_Rows(arr);
                                arr_.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 7:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                Matrix arr_ = Matrix.Sort_Col(arr);
                                arr_.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 8:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                Matrix arr_ = Matrix.Sort(arr);
                                arr_.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 9:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                Matrix arr_ = Matrix.Copy(arr);
                                arr_.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 10:
                            {
                                Console.Write("Enter_matrix_size: ");
                                int x = Int32.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Matrix arr = new Matrix(x);
                                arr.Init_Random_avto();
                                arr.toString();
                                Console.WriteLine();
                                Matrix arr2 = new Matrix(x);
                                arr2.Init_Random_avto();
                                arr2.toString();
                                Console.WriteLine();
                                Matrix arr_ = arr * arr2;
                                arr_.toString();
                                Console.WriteLine();
                                Console.Write("Enter_for_continue;");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 0:
                            {
                                menu = 0; menu_b = false; break;
                            }
                        default:
                            {
                                throw new ExceptionExit("Invalid_input_data");
                            }
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(500);
                    Console.Clear();
                }
                catch (ExceptionExit ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
        }
    }
}