using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPG
{
    class LoginPage
    {
        string uid;
        public LoginPage()
        {

        }
        public int loginpage()
        {
            Console.Clear();
            Console.WriteLine("턴 알피지 시즌 2\n");
            Console.WriteLine("1. 로그인");
            Console.WriteLine("2. 계정생성");
            Console.WriteLine("3. 종료");
            Console.Write("입력 > ");
            string select = Console.ReadLine();

            if (select == "1")
            {
                return 1;
            }
            else if (select == "2")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        public int Login()
        {
            string id, pw;

            Console.Clear();
            Console.WriteLine("턴 알피지 시즌 2");
            Console.WriteLine("로그인 페이지 입니다.\n");
            Console.Write("아이디       : ");
            id = Console.ReadLine();
            Console.Write("비밀번호     : ");
            pw = Console.ReadLine();
            string[] accountID = File.ReadAllLines(@"C:\Users\DB\Desktop\코딩\TurnRPGData\accountID.txt");
            string[] accountPW = File.ReadAllLines(@"C:\Users\DB\Desktop\코딩\TurnRPGData\accountPW.txt");
            for (int i = 0; i < accountID.Length; i++)
            {
                if (!accountID[i].Equals(id))
                {
                    if (i == accountID.Length-1)
                    {
                        Console.WriteLine("아이디가 일치하지 않습니다.");
                        string next = Console.ReadLine();
                        return 1;
                    }
                    
                }
                else if (accountID[i].Equals(id))
                {
                    
                    if (!accountPW[i].Equals(pw))
                    {
                        Console.WriteLine("비밀번호가 일치하지 않습니다.");
                        string next = Console.ReadLine();
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("로그인 성공!");
                        Console.WriteLine("\n서버에 접속합니다.");
                        this.uid = id;
                        string next = Console.ReadLine();
                        return 0;
                    }
                    
                }
            }
            return -1;

        }
        public string get_userID()
        {
            return this.uid;
        }
        public int Register()
        {
            string id, pw, pw2;

            Console.Clear();
            Console.WriteLine("턴 알피지 시즌 2");
            Console.WriteLine("계정생성 페이지 입니다.\n");
            Console.Write("아이디       : ");
            id = Console.ReadLine();
            Console.Write("비밀번호     : ");
            pw = Console.ReadLine();
            Console.Write("비밀번호확인 : ");
            pw2 = Console.ReadLine();
            if (id.Length < 4 || pw.Length < 4)
            {
                Console.WriteLine("\n너무짧소.");
                Console.WriteLine("계속하려면 아무키나 누르시오.");
                string select2 = Console.ReadLine();
                return 2;
            }
            if (pw != pw2)
            {
                Console.WriteLine("\n두 비밀번호가 일치하지않습니다.");
                Console.WriteLine("계속하려면 아무키나 누르시오.");
                string select2 = Console.ReadLine();
                return 2;
            }
            else
            {
                string[] overlap = File.ReadAllLines(@"C:\Users\DB\Desktop\코딩\TurnRPGData\accountID.txt");
                for (int i = 0; i < overlap.Length; i++)
                {
                    if (overlap[i].Equals(id))
                    {
                        Console.WriteLine("이미 등록된 아이디입니다.");
                        string next2 = Console.ReadLine();
                        return 2;
                    }
                    else if(i == overlap.Length - 1)
                    {
                        Console.WriteLine("계정이 성공적으로 생성되었습니다.");
                        string next2 = Console.ReadLine();
                        string[] accountID = { id };
                        using (StreamWriter AccountID = new StreamWriter(@"C:\Users\DB\Desktop\코딩\TurnRPGData\accountID.txt", true))
                        {
                            foreach (string line in accountID)
                            {
                                AccountID.WriteLine(line);
                            }
                        }
                        string[] accountPW = { pw };
                        using (StreamWriter AccountPW = new StreamWriter(@"C:\Users\DB\Desktop\코딩\TurnRPGData\accountPW.txt", true))
                        {
                            foreach (string line in accountPW)
                            {
                                AccountPW.WriteLine(line);
                            }
                        }
                        return -1;
                    }
                }
            }
            return -1;
        }
    }
}
