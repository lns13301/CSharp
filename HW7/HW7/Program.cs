using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HW7
{
    class DataTable
    {
        public DataTable(string name, int studentNum, float height, float vision, float score)
        {
            Name = name;
            StudentNum = studentNum;
            Height = height;
            Vision = vision;
            Score = score;
        }

        public string Name { get; set; }
        public int StudentNum { get; set; }
        public float Height { get; set; }
        public float Vision { get; set; }
        public float Score { get; set; }
    }

    class Program
    {
        public Program()
        {
            string path = "userdata.txt";
            string[] create = { };
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string line in create)
                    {
                        Console.WriteLine(create);
                    }
                }
            }
            string read_data = "";
            StreamReader sr = new StreamReader(new FileStream("userdata.txt", FileMode.Open));
            while (sr.EndOfStream == false)
            {
                read_data = sr.ReadLine();
                string[] splited = read_data.Split('#');
                table.Add(new DataTable(splited[0], int.Parse(splited[1]), float.Parse(splited[2]),
                    float.Parse(splited[3]), float.Parse(splited[4])));
            }
            sr.Close();
        }

        private List<DataTable> table = new List<DataTable>();
        static void Main(string[] args)
        {
            Program program = new Program(); // 프로그램이 시작하면서 인스턴스를 생성함
            string select = "";

            while (select.Equals("3") == false)
            {
                Console.Clear();
                Console.WriteLine("***************************");
                Console.WriteLine("***학생 데이터 조회 메뉴***");
                Console.WriteLine("***************************\n");

                try
                {
                    if (select.Equals("") || select.Equals("1") || select.Equals("2") || select.Equals("3"))
                    {
                        Console.WriteLine("1. 입력하기");
                        Console.WriteLine("2. 출력하기");
                        Console.WriteLine("3. 종료하기");
                        Console.Write("\n입력 : ");
                        select = Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"오류 코드 : {e.Message}");
                    Console.WriteLine("잘못된 값을 입력했습니다.");
                    Console.WriteLine("계속하려면 Enter를 입력하세요...");
                    string temp = Console.ReadLine();
                    select = "";
                }
                if (select.Equals("1"))
                {
                    program.input();
                    select = "";

                }
                else if (select.Equals("2"))
                {
                    program.output();
                    select = "";
                }
            }
        }

        public bool input()
        {
            Console.Clear();
            Console.WriteLine("***************************");
            Console.WriteLine("***학생 데이터 입력 메뉴***");
            Console.WriteLine("***************************\n");
            Console.WriteLine("이름#학번#키#시력#점수 순으로 입력하세요.");
            Console.Write("\n입력 : ");
            char isNull = '@';
            string inputdata = "";
            inputdata = Console.ReadLine();

            char[] inputdata_check = inputdata.ToCharArray();
            int sharp_check = 0;

            for (int i = 0; i < inputdata_check.Length; i++)
            {
                if ((isNull.Equals(inputdata_check[i])).Equals('#'))
                {
                    Console.WriteLine("\n필드 값에 'NULL'을 포함할 수 없습니다.");
                    Console.WriteLine("계속하려면 엔터키를 누르시오.");
                    string temp = Console.ReadLine();
                    return true;
                }
                if (inputdata_check[i].Equals('#'))
                    sharp_check++;
                isNull = inputdata_check[i];
            }
            if (sharp_check > 4)
            {
                Console.WriteLine("\n필드 값에 입력 데이터가 4개가 넘습니다.");
                Console.WriteLine("계속하려면 엔터키를 누르시오.");
                string temp = Console.ReadLine();
                return true;
            }
            else if (sharp_check < 4)
            {
                Console.WriteLine("\n필드 값에 입력 데이터가 4개보다 적습니다.");
                Console.WriteLine("계속하려면 엔터키를 누르시오.");
                string temp = Console.ReadLine();
                return true;
            }
            foreach (char i in inputdata_check)
            {
                if (i == ' ' || inputdata.Equals(null))
                {
                    Console.WriteLine("\n필드 값에 공백을 포함할 수 없습니다.");
                    Console.WriteLine("계속하려면 엔터키를 누르시오.");
                    string temp = Console.ReadLine();
                    return true;
                }
                else if (inputdata.Length > 21 && inputdata.Length < 28)
                {
                    StreamWriter sw = new StreamWriter("userdata.txt", true); // 오류검사를 마치고 정상적인 값이 입력된 경우 파일에 작성

                    sw.WriteLine(inputdata);
                    sw.Close();
                    string[] splited = inputdata.Split('#');
                    try
                    {
                        int type_1 = int.Parse(splited[1]);
                        float type_2 = float.Parse(splited[1]);
                        float type_3 = float.Parse(splited[2]);
                        float type_4 = float.Parse(splited[3]);
                    }
                    catch
                    {
                        Console.WriteLine("잘못된 값을 입력하였습니다.");
                        string temp = Console.ReadLine();
                        return true;
                    }
                    Console.WriteLine("레코드가 성공적으로 추가되었습니다.");
                    table.Add(new DataTable(splited[0], int.Parse(splited[1]), float.Parse(splited[2]), float.Parse(splited[3]), float.Parse(splited[4])));
                    string temp2 = Console.ReadLine();

                    return true;
                }
                else
                {
                    Console.WriteLine("\n필드 값에 입력된 값이 작습니다.");
                    Console.WriteLine("계속하려면 엔터키를 누르시오.");
                    string temp = Console.ReadLine();
                    return true;
                }
            }
            return true;
        }

        public void output()
        {
            Console.Clear();
            Console.WriteLine("            ***************************");
            Console.WriteLine("            ***학생 데이터 출력 메뉴***");
            Console.WriteLine("            ***************************\n");

            Console.WriteLine("1. 테이블 보기");
            Console.WriteLine("2. 정렬 검색하기");
            Console.WriteLine("3. 조건 검색하기");
            Console.Write("\n입력 : ");
            string menu = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("            ***************************");
            Console.WriteLine("            ***학생 데이터 출력 메뉴***");
            Console.WriteLine("            ***************************\n");
            int number = 1;
            if (menu.Equals("1"))
            {
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                table.ForEach((x) =>
                {
                    Console.Write(string.Format("{0:000}",number)); // 인덱스를 넣어 식별하기 쉽게 구현함
                    Console.WriteLine(string.Format(" {0,4} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}",
                        x.Name, x.StudentNum, x.Height, x.Vision, x.Score));
                    number++;
                }); // 람다식을 활용하여 출력
                Console.WriteLine("\n계속하려면 엔터키를 누르시오.");
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("2"))
            {
                sort();
            }
            else if (menu.Equals("3"))
            {
                linq();
            }
            else
            {
                Console.WriteLine("잘못 입력하였습니다.");
                Console.WriteLine("계속하시려면 엔터키를 누르시오.");
                string temp = Console.ReadLine();
            }
        }
        public void sort()
        {
            Console.Clear();
            Console.WriteLine("            ***************************");
            Console.WriteLine("            ***학생 데이터 출력 메뉴***");
            Console.WriteLine("            ***************************\n");

            Console.WriteLine("1. 이름순 정렬");
            Console.WriteLine("2. 학번순 정렬");
            Console.WriteLine("3.   키순 정렬");
            Console.WriteLine("4. 시력순 정렬");
            Console.WriteLine("5. 학점순 정렬");
            Console.Write("\n입력 : ");
            string menu = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("            ***************************");
            Console.WriteLine("            ***학생 데이터 출력 메뉴***");
            Console.WriteLine("            ***************************\n");
            int number = 1;

            if (menu.Equals("1"))
            {
                var tableresult = from line in table
                                  orderby line.Name ascending
                                  select line;
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("2"))
            {
                var tableresult = from line in table
                                  orderby line.StudentNum ascending
                                  select line;
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("3"))
            {
                var tableresult = from line in table
                                  orderby line.Height ascending
                                  select line;
                Console.WriteLine(" No.  이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("4"))
            {
                var tableresult = from line in table
                                  orderby line.Vision ascending
                                  select line;
                Console.WriteLine(" No.  이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("5"))
            {
                var tableresult = from line in table
                                  orderby line.Score ascending
                                  select line;
                Console.WriteLine(" No.  이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }

        }
        public void linq()
        {
            Console.Clear();
            Console.WriteLine("            ***************************");
            Console.WriteLine("            ***학생 데이터 출력 메뉴***");
            Console.WriteLine("            ***************************\n");

            Console.WriteLine("1. 키 165이상, 시력 1.5이하, 학점 3.5이상인 학생을 학점의 역순으로 출력");
            Console.WriteLine("2. 성이 홍씨이고 시력 1.0이상이며 학번이 15학번보다 저학번인 학생 출력");
            Console.WriteLine("3. 학번을 나눈 나머지가 0이면서 이름에 수가 들어가는 키가 170이상인 학생 출력");
            Console.WriteLine("4. 학점이 3.0보다 높고 학번이 16학번보다 고학번이며, 키에 소숫점이 있는 학생 출력");
            Console.Write("\n입력 : ");
            string menu = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("            ***************************");
            Console.WriteLine("            ***학생 데이터 출력 메뉴***");
            Console.WriteLine("            ***************************\n");
            int number = 1;

            if (menu.Equals("1"))
            {
                var tableresult = from line in table
                                  where line.Height >= 165
                                  where line.Vision <= 1.5
                                  where line.Score >= 3.5
                                  orderby line.Score descending
                                  select line;
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("2"))
            {
                var tableresult = from line in table
                                  where line.Name.StartsWith("홍")
                                  where line.Vision > 1.0
                                  where line.StudentNum > 2016000000
                                  select line;
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("3"))
            {
                var tableresult = from line in table
                                  where line.StudentNum % 3 == 0
                                  where line.Name.Contains("수")
                                  where line.Height >= 170
                                  select line;
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
            else if (menu.Equals("4"))
            {
                var tableresult = from line in table
                                  where line.Score > 3.0
                                  where line.StudentNum < 2016000000
                                  where line.Height % 1 != 0
                                  select line;
                Console.WriteLine("No.   이름        학번        키       시력     학점\n");
                foreach (var line in tableresult)
                {
                    Console.Write(string.Format("{0:000}", number));
                    Console.WriteLine(string.Format(" {0,4:NO} {1,13}   {2:0.0}      {3:0.0}      {4:0.0}", line.Name, line.StudentNum, line.Height, line.Vision, line.Score));
                    number++;
                }
                string temp = Console.ReadLine();
            }
        }

    }
}
