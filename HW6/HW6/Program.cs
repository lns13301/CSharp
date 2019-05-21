using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    /*delegate void MyDelegate(int a);

    class Market
    {
        public event MyDelegate CustomerEvent;

        public void BuySomething(int CustomerNo)
        {
            if (CustomerNo == 30)
                CustomerEvent(CustomerNo);
        }
    }
    class Program
    {
        static public void MyHandler(int a)
        {
            Console.WriteLine($"축하합니다! {a}번째 고객 이벤트에 당첨되셨습니다.");
        }
        public static void Main(string[] args)
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate(MyHandler);

            for (int customerNo = 0; customerNo < 100; customerNo += 10)
                market.BuySomething(customerNo);
        }
        
    }*/



    class Car
    {
        public int Cost
        {
            get; set;
        }
        public int MaxSpeed
        {
            get; set;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {

            Car[] cars =
            {
                new Car(){Cost= 56, MaxSpeed= 120},
                new Car(){Cost= 70, MaxSpeed= 150},
                new Car(){Cost= 45, MaxSpeed= 180},
                new Car(){Cost= 32, MaxSpeed= 200},
                new Car(){Cost= 82, MaxSpeed= 280}
            };

            var selected = cars.Where(c => c.Cost < 60).OrderBy(c => c.Cost);
            Console.WriteLine("기본 값");
            foreach (var line in selected)
                Console.WriteLine($"{line.Cost},{line.MaxSpeed}");
            Console.WriteLine();

            var selected2 = from line in cars
                            where line.Cost < 60
                            orderby line.Cost
                            select line;
            Console.WriteLine("작성한 LINQ 값");
            foreach (var line in selected2)
                Console.WriteLine($"{line.Cost},{line.MaxSpeed}");
            Console.WriteLine();
        }
    }











    /*class Program
    {
        public static void Main(String[] args)
        {
            
        }
    }*/
}
