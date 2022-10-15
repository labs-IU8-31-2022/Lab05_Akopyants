using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05_Akopyants
{
    class My_Matrix
    {

        public My_Matrix()
        {
            rows = 0;
            columns = 0;
            matrix = new int[rows, columns];
        }
        public My_Matrix(uint _rows)
        {
            rows = _rows;
            columns = 0;
            matrix = new int[rows, columns];
        }

        public My_Matrix(uint _rows, uint _columns)
        {
            rows = _rows;
            columns = _columns;
            matrix = new int[rows, columns];
        }
        public void Fill_Random_Matrix()
        {
            Random rand = new Random();
            Console.WriteLine("Введите диапазон генерации чисел");
            int begin = Convert.ToInt32(Console.ReadLine());
            int end = Convert.ToInt32(Console.ReadLine());
            for (uint i = 0; i < rows; ++i)
            {
                for (uint j = 0; i < columns; ++j)
                {
                    matrix[i, j] = rand.Next(begin, end);
                }
            }

        }
        public int this[int _rows, int _columns]
        {
            get => matrix[_rows, columns];
            set => matrix[_rows, columns] = value;
        }

        public void ChangeSize(uint m, uint n)
        {
            My_Matrix New_Matrix = new My_Matrix();
            New_Matrix.rows = m;
            New_Matrix.columns = n;
            New_Matrix.matrix = new int[m, n];
            for (int i = 0; i < rows && i < m; ++i)
            {
                for (int j = 0; j < columns && j < n; ++j)
                {
                    New_Matrix[i, j] = this[i, j];
                }
            }
            New_Matrix.Fill_Random_Matrix();
            matrix = New_Matrix.matrix;
            rows = m;
            columns = n;
        }


        public void ShowPartialy(int m1, int m2, int n1, int n2)
        {
            var t = n1;
            for (; m1 <= m2; ++m1, Console.WriteLine())
            {
                for (n1 = t; n1 <= n2; ++n1)
                {
                    Console.Write("{0,3}", this[m1, n1]);
                }
            }
            Console.WriteLine();
        }
        int[,] matrix;  
        uint rows;
        uint columns;
    }
}
