using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
class Number
{
string n;
string nums = "0123456789";
double cel, drob, num;
int countNums;

    public Number(string _n)
        {
        n = _n;
        cel = Convert.ToDouble(n.Split(',')[0]);
        drob = Convert.ToDouble(n) - cel;
        countNums = 0;
        for (int i = 0; i < n.Length; i++) if (nums.Contains(n[i])) countNums++;
        num = Convert.ToDouble(n);
        }
    
    public string convertToBin()
        {
        string ret = "";
        int c = Math.Abs(Convert.ToInt32(cel));
        if (c == 0) ret = "0";
        while (c != 0)
            {
            if (c % 2 == 1) ret = "1" + ret;
                else ret = "0" + ret;
            c /= 2;
            }
        if (num < 0) ret = "-" + ret;
        double d = Math.Abs(drob);
        for (int i = 0; i < 15 && d != 0; i++)
            {
            if (i == 0) ret += ",";
            d *= 2;
            if (d >= 1)
                {
                ret += "1";
                d -= 1;
                }
            else ret += "0";
            }
        return ret;
        }
    
    public void movePoint(int c)
        {
        num *= Math.Pow(10, c);
        n = Convert.ToString(num);
        cel = Convert.ToDouble(n.Split(',')[0]);
        drob = Convert.ToDouble(n) - cel;
        countNums = 0;
        for (int i = 0; i < n.Length; i++) if (nums.Contains(n[i])) countNums++;
        }
    
    public void print()
        {
        Console.WriteLine("Число: {0}, Количество цифр {1}, В двоичной системе: {2}", Num, NumsCount, convertToBin());
        }
    
    public double Cel
        {
        get { return cel; }
        }
    
    public double Drob
        {
        get { return drob; }
        }
    
    public int NumsCount
        {
        get { return countNums; }
        }
    
    public double Num
        {
        get { return num; }
        }
    }
    
    class staticNumber
        {
        public static void PrintList(List<Number> N)
            {
            foreach (Number n in N)
                n.print();
            }
        }
    
    class Program
        {
        static void Main(string[] args)
            {
            Random random = new Random();
            List<Number> numsList = new List<Number>
            {
                new Number(random.Next(1000).ToString()),
                new Number(random.Next(1000).ToString()),
                new Number("42"),
                new Number(random.Next(1000).ToString()),
                new Number(random.Next(1000).ToString())
            };
            Console.WriteLine("Список:");
            staticNumber.PrintList(numsList);
            Console.WriteLine(" Список в обратном порядке:");
            numsList.Reverse();
            staticNumber.PrintList(numsList);
            Console.WriteLine(" Список по количеству цифр:");
            staticNumber.PrintList(numsList.OrderBy(n => n.NumsCount).ToList());
            numsList.Add(new Number(random.Next(1000).ToString()));
            Console.WriteLine(" Список с добавленным в конец элементом:");
            staticNumber.PrintList(numsList);
            numsList.Insert(2, new Number(random.Next(1000).ToString()));
            Console.WriteLine(" Список со вставленным элементом:");
            staticNumber.PrintList(numsList);
            numsList.RemoveAt(2);
            Console.WriteLine(" Список с удаленным вставленным элементом:");
            staticNumber.PrintList(numsList);
            int index = numsList.FindIndex(n => n.Num == 42);
            Console.WriteLine(" Найденный эелемент списка:");
            numsList[index].print();
            numsList.Clear();
            Console.WriteLine(" Пустой список:");
            staticNumber.PrintList(numsList);
            Console.ReadKey();
            }
        }
    }