using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            Stack<string> reverse = new Stack<string>();
            List<string> sik = new List<string>();

            string result = "5 + 2 - 3";

            string[] splited = result.Split(' ');

            for (int i = 0; i < splited.Length; i++)
            {
                double a = 0;
                if (!double.TryParse(splited[i], out a))
                {
                    stack.Push(splited[i]);
                }
                else
                {
                    sik.Add(splited[i]);
                }
            }
            int count = stack.Count;
            for (int i = 0; i < count; i++)
            {
                sik.Add(stack.Pop());
            }

     //       foreach (var item in sik)
     //       {
    //            Write(item + " ");
    //        }

            foreach (var item in sik)
            {
                double a = 0;

                if (double.TryParse(item, out a))
                {
                    stack.Push(item);
                }
                else
                {

                    string arg1 = stack.Pop();
                    string arg2 = stack.Pop();
                    string oper = item;
                    //계산식
                    double dummyResult = double.Parse(arg1) + double.Parse(arg2);
                    stack.Push(dummyResult.ToString());

                }


            }

            Write(stack.Pop());
        }
    }
}
