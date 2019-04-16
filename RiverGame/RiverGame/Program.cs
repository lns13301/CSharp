using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverGame
{
    class Boat
    {
        private int boat_return;
        private int po, mu, fa, mo, so, d1, d2;

        public Boat()
        {
            this.po = 0;
            this.mu = 0;
            this.fa = 0;
            this.mo = 0;
            this.so = 0;
            this.d1 = 0;
            this.d2 = 0;
            this.boat_return = 0;
        }

        public void boat_location(int boat_return)
        {
            this.boat_return = boat_return;
        }
        public int boat()
        {
            if (po != mu && (mu == fa || mu== mo || mu== so || mu == d1 || mu==d2))
            {
                Console.WriteLine("살인자가 살인을 했습니다!");
                return 1;
            }
            else if (fa != mo)
            {
                if (mo == so)
                {
                    Console.WriteLine("엄마가 아들을 구타했습니다!!");
                    return 1;
                }
                if (fa == d1 || fa == d2)
                {
                    Console.WriteLine("아빠가 딸을 구타했습니다!!");
                    return 1;
                }
            }
            if (po == 1 && po == fa && fa == mo && mo == mu && mu == so && so == d1 && d1 == d2)
            {
                return 2;
            }
            Console.Clear();
            if (boat_return == 0)
            {
                if (po == 0)
                {
                    Console.Write(" 경찰 ");
                }
                if (mu == 0)
                {
                    Console.Write(" 살인자 ");
                }
                if (fa == 0)
                {
                    Console.Write(" 아빠 ");
                }
                if (mo == 0)
                {
                    Console.Write(" 엄마 ");
                }
                if (so == 0)
                {
                    Console.Write(" 아들 ");
                }
                if (d1 == 0)
                {
                    Console.Write(" 첫째 딸 ");
                }
                if (d2 == 0)
                {
                    Console.Write(" 둘째 딸 ");
                }
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~ (보트) ~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                if (po == 1)
                {
                    Console.Write(" 경찰 ");
                }
                if (mu == 1)
                {
                    Console.Write(" 살인자 ");
                }
                if (fa == 1)
                {
                    Console.Write(" 아빠 ");
                }
                if (mo == 1)
                {
                    Console.Write(" 엄마 ");
                }
                if (so == 1)
                {
                    Console.Write(" 아들 ");
                }
                if (d1 == 1)
                {
                    Console.Write(" 첫째 딸 ");
                }
                if (d2 == 1)
                {
                    Console.Write(" 둘째 딸 ");
                }
                Console.WriteLine();
                return -11;
            }
            else
            {
                if (po == 0)
                {
                    Console.Write(" 경찰 ");
                }
                if (mu == 0)
                {
                    Console.Write(" 살인자 ");
                }
                if (fa == 0)
                {
                    Console.Write(" 아빠 ");
                }
                if (mo == 0)
                {
                    Console.Write(" 엄마 ");
                }
                if (so == 0)
                {
                    Console.Write(" 아들 ");
                }
                if (d1 == 0)
                {
                    Console.Write(" 첫째 딸 ");
                }
                if (d2 == 0)
                {
                    Console.Write(" 둘째 딸 ");
                }
                Console.WriteLine();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~ (보트) ~~~~~~~~~~~~~~~~~~~~~~~~~~");
                if (po == 1)
                {
                    Console.Write(" 경찰 ");
                }
                if (mu == 1)
                {
                    Console.Write(" 살인자 ");
                }
                if (fa == 1)
                {
                    Console.Write(" 아빠 ");
                }
                if (mo == 1)
                {
                    Console.Write(" 엄마 ");
                }
                if (so == 1)
                {
                    Console.Write(" 아들 ");
                }
                if (d1 == 1)
                {
                    Console.Write(" 첫째 딸 ");
                }
                if (d2 == 1)
                {
                    Console.Write(" 둘째 딸 ");
                }
                Console.WriteLine();
                return -12;
            }
        }
        public int drive_boat1()
        {
            Console.WriteLine("보트를 운전할 사람을 선택하세요.\n");

            if (po == 0)
            {
                Console.WriteLine("1. 경찰    (운전가능)");
            }
            if (fa == 0)
            {
                Console.WriteLine("2. 아빠    (운전가능)");
            }
            if (mo == 0)
            {
                Console.WriteLine("3. 엄마    (운전가능)");
            }
            Console.WriteLine();
            Console.Write("운전자 선택 > ");
            string sct1 = Console.ReadLine();
            if (sct1.Equals("1"))
            {
                this.po = -1;
            }
            else if (sct1.Equals("2"))
            {
                this.fa = -1;
            }
            else if (sct1.Equals("3"))
            {
                this.mo = -1;
            }
            return -13;
        }
        public int ride_boat1()
        {
            Console.WriteLine("보트에 탑승할 사람을 선택하세요.\n");

            if (po == 0)
            {
                Console.WriteLine("1. 경찰    (운전가능)");
            }
            if (mu == 0)
            {
                Console.WriteLine("2. 살인자");
            }
            if (fa == 0)
            {
                Console.WriteLine("3. 아빠    (운전가능)");
            }
            if (mo == 0)
            {
                Console.WriteLine("4. 엄마    (운전가능)");
            }
            if (so == 0)
            {
                Console.WriteLine("5. 아들");
            }
            if (d1 == 0)
            {
                Console.WriteLine("6. 첫째 딸");
            }
            if (d2 == 0)
            {
                Console.WriteLine("7. 둘째 딸");
            }
            Console.WriteLine("8. 운전자만 탑승");

            Console.WriteLine();
            Console.Write("탑승자 선택 > ");
            string sct2 = Console.ReadLine();

            if (sct2.Equals("1") && po == 0)
            {
                this.po = 1;
            }
            else if (sct2.Equals("2") && mu == 0)
            {
                this.mu = 1;
            }
            else if (sct2.Equals("3") && fa == 0)
            {
                this.fa = 1;
            }
            else if (sct2.Equals("4") && mo == 0)
            {
                this.mo = 1;
            }
            else if (sct2.Equals("5") && so == 0)
            {
                this.so = 1;
            }
            else if (sct2.Equals("6") && d1 == 0)
            {
                this.d1 = 1;
            }
            else if (sct2.Equals("7") && d2 == 0)
            {
                this.d2 = 1;
            }
            else if (sct2.Equals("8"))
            {
            }
            else
            {
                Console.WriteLine("잘못 입력해서 모두 죽었습니다~~!");
                Environment.Exit(1);
            }
            return -14;
        }
        public int drive_boat2()
        {
            {
                Console.WriteLine("보트를 운전할 사람을 선택하세요.\n");

                if (po == 1)
                {
                    Console.WriteLine("1. 경찰    (운전가능)");
                }
                if (fa == 1)
                {
                    Console.WriteLine("2. 아빠    (운전가능)");
                }
                if (mo == 1)
                {
                    Console.WriteLine("3. 엄마    (운전가능)");
                }
                Console.WriteLine();
                Console.Write("운전자 선택 > ");
                string sct1 = Console.ReadLine();
                if (sct1.Equals("1"))
                {
                    this.po = -2;
                }
                else if (sct1.Equals("2"))
                {
                    this.fa = -2;
                }
                else if (sct1.Equals("3"))
                {
                    this.mo = -2;
                }
                return -15;
            }
        }
        public int ride_boat2()
        {
            Console.WriteLine("보트에 탑승할 사람을 선택하세요.\n");

            if (po == 1)
            {
                Console.WriteLine("1. 경찰    (운전가능)");
            }
            if (mu == 1)
            {
                Console.WriteLine("2. 살인자");
            }
            if (fa == 1)
            {
                Console.WriteLine("3. 아빠    (운전가능)");
            }
            if (mo == 1)
            {
                Console.WriteLine("4. 엄마    (운전가능)");
            }
            if (so == 1)
            {
                Console.WriteLine("5. 아들");
            }
            if (d1 == 1)
            {
                Console.WriteLine("6. 첫째 딸");
            }
            if (d2 == 1)
            {
                Console.WriteLine("7. 둘째 딸");
            }
            Console.WriteLine("8. 운전자만 탑승");

            Console.WriteLine();
            Console.Write("탑승자 선택 > ");
            string sct2 = Console.ReadLine();

            if (sct2.Equals("1") && po == 1)
            {
                this.po = 0;
            }
            else if (sct2.Equals("2") && mu == 1)
            {
                this.mu = 0;
            }
            else if (sct2.Equals("3") && fa == 1)
            {
                this.fa = 0;
            }
            else if (sct2.Equals("4") && mo == 1)
            {
                this.mo = 0;
            }
            else if (sct2.Equals("5") && so == 1)
            {
                this.so = 0;
            }
            else if (sct2.Equals("6") && d1 == 1)
            {
                this.d1 = 0;
            }
            else if (sct2.Equals("7") && d2 == 1)
            {
                this.d2 = 0;
            }
            else if (sct2.Equals("8"))
            {

            }
            else
            {
                Console.WriteLine("잘못 입력해서 모두 죽었습니다~~!");
                Environment.Exit(1);
            }
            return -16;
        }
        public int result()
        {
            if (po == -1)
            {
                this.po = 1;
                this.boat_return = 1;
            }
            if (fa == -1)
            {
                this.fa = 1;
                this.boat_return = 1;
            }
            if (mo == -1)
            {
                this.mo = 1;
                this.boat_return = 1;
            }
            if (po == -2)
            {
                this.po = 0;
                this.boat_return = 0;
            }
            if (fa == -2)
            {
                this.fa = 0;
                this.boat_return = 0;
            }
            if (mo == -2)
            {
                this.mo = 0;
                this.boat_return = 0;
            }
            return 0;
        }
        public void set_boat(int boat_return)
        {
            this.boat_return = boat_return;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int gameresult = 0;
            int result_return;
            Console.WriteLine("강을 건너가자!!!\n");
            Console.WriteLine("!게임 규칙!\n");
            Console.WriteLine("(* 누구하나가 상처입으면 게임오버!!)");
            Console.WriteLine("아빠가 없으면 엄마가 아들을 공격");
            Console.WriteLine("엄마가 없으면 아빠가 딸을 공격");
            Console.WriteLine("경찰이 없으면 살인자가 공격");
            Console.WriteLine("아무키나 눌러서 시작하기!");
            string tmp = Console.ReadLine();
            Boat b = new Boat();

            while (gameresult < 1)
            {
                gameresult = b.boat();
                result_return = gameresult;
                if (result_return == -11)
                    result_return = b.drive_boat1();
                if (result_return == -13)
                    result_return = b.ride_boat1();
                if (result_return == -14)
                {
                    result_return = b.result();
                    b.set_boat(1);
                }
                if (result_return == -12)
                    result_return = b.drive_boat2();
                if (result_return == -15)
                    result_return = b.ride_boat2();
                if (result_return == -16)
                {
                    result_return = b.result();
                    b.set_boat(0);
                }
            }
            if (gameresult == 1)
            {
                Console.WriteLine("게임 오버...\n");
            }
            else
            {
                Console.WriteLine("목적지에 모두 이동하는 것에 성공하였습니다!!!\n");
            }
        }
    }
}
