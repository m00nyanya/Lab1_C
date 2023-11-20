using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Arr a = new Arr(n);
            a.Print();
            a.Finding_sum();
            a.Finding_multiply();

            Console.WriteLine("Введите количество строк: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов: ");
            int m = Convert.ToInt32(Console.ReadLine());

            TwoXArr t = new TwoXArr(n2, m);
            t.Print();
            t.Number_of_Columns();
            t.Print();
            Console.ReadKey();
        }
    }
    class Arr
    {
        public int n = 10;
        public static double[] arr;

        public Arr(int n)
        {
            arr = new double[n];
            Init();
        }
        public void Init()
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                double t = r.Next(-10, 10) + r.NextDouble();
                arr[i] = t;
            }
            Array.Sort(arr, (x, y) => y.CompareTo(x));
        }

        public void Finding_sum()
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    sum += arr[i];
                }
            }
            Console.WriteLine("Сумма: " + sum);
        }

        public void Finding_multiply()
        {
            double mult = 1;
            double min = 1000;
            double max = 0;
            int place_min = 0;
            int place_max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) < min)
                {
                    place_min = i;
                    min = arr[i];
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > max)
                {
                    place_max = i;
                    max = arr[i];
                }
            }
            if (place_min > place_max)
            {
                for (int j = place_max + 1; j < place_min; j++)
                {
                    mult *= arr[j];
                }
            }
            if (place_min < place_max)
            {
                for(int j = place_min + 1; j < place_max; j++)
                {
                    mult *= arr[j];
                }
            }
            Console.WriteLine("Произведение: " + mult);
        }

        public void Print()
        {
            Array.Sort(arr, (x, y) => y.CompareTo(x));
            Array.ForEach(arr, Console.WriteLine);
        }

    }
    class TwoXArr
    {
        private int[,] arr;

        public TwoXArr(int n, int m)
        {
            arr = new int[n, m];
            Init();
        }

        public void Init()
        {
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(-10, 10);
                }
            }
            Sort();
        }

        public void Print()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public int Character(int j)
        {
            if (j > arr.Length) { Console.WriteLine("Что-то не так"); throw new Exception(); }
            int charc = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (arr[j, i] % 2 == 0 && arr[j, i] > 0)
                {
                    charc += arr[j, i];
                }
            }
            return charc;
        }
        public void Number_of_Columns()
        {
            int[] t = new int[arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int l = 0;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] == 0)
                    {
                        l = 1;
                        break;
                    }
                }
                if (l == 0) { t[i] = 1; }
            }
            Console.WriteLine("Количество столбцов без нулей: " + Enumerable.Sum(t));
        }
        public void Sort()
        {
            int[] sums = new int[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sums[i] = Character(i);
            }

            for (int i = 0; i < sums.Length - 1; i++)
            {
                for (int j = i + 1; j < sums.Length; j++)
                {
                    if (sums[i] > sums[j])
                    {
                        int b = sums[i];
                        sums[i] = sums[j];
                        sums[j] = b;
                        for (int m = 0; m < arr.GetLength(1); m++)
                        {
                            b = arr[i, m];
                            arr[i, m] = arr[j, m];
                            arr[j, m] = b;
                        }
                    }
                }
            }
            Console.WriteLine("Массив отфильтрован");


        }
    }
}
