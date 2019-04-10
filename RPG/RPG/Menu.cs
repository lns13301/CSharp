using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Menu
    {
        Player player;
        Stats my_stats;
        Inventory my_inven;

        private string uid;
        static int return_value;

        public Menu()
        {
            LoginPage lp = new LoginPage();
            do
            {

                return_value = lp.loginpage();
                if (return_value == 1)
                {
                    return_value = lp.Login();
                }
                else if (return_value == 2)
                {
                    return_value = lp.Register();
                }
                else
                {
                    Environment.Exit(-1);
                }
            } while (return_value != 0);
            Console.Clear();
            Console.WriteLine("접속완료!!!!");
            Console.WriteLine("접속중아이디 : " + lp.get_userID());
            this.uid = lp.get_userID();
            player = new Player(uid);
            my_stats = player.get_stats();
            my_inven = player.get_inventory();

            show_menu();
        }

        public void show_menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("메뉴를 선택하시오.\n");
                Console.WriteLine("1. 캐릭터");
                Console.WriteLine("2. 퀘스트");
                Console.WriteLine("3. 이동");
                Console.WriteLine("4. 상점");
                Console.WriteLine("5. 미구현");
                Console.WriteLine("6. 로그아웃");
                Console.Write("입력 > ");
                string select = Console.ReadLine();
                if (select.Equals("1"))
                {
                    character_menu();
                }
                else if (select.Equals("2"))
                {
                    quest_menu();
                }
                else if (select.Equals("3"))
                {
                    adventure_menu();
                }
                else if (select.Equals("4"))
                {
                    shop_menu();
                }
                else if (select.Equals("5"))
                {

                }
                else if (select.Equals("6"))
                {

                }
            }
        }
        public void character_menu()
        {
            Console.Clear();
            Console.WriteLine("메뉴를 선택하시오.\n");
            Console.WriteLine("1. 상태");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 스킬");
            Console.WriteLine("4. 받은 퀘스트");
            Console.WriteLine("5. 돌아가기");
            Console.Write("입력 > ");
            string select = Console.ReadLine();
            if (select.Equals("1"))
            {
                character_status();
            }
            else if (select.Equals("2"))
            {

            }
            else if (select.Equals("3"))
            {

            }
            else if (select.Equals("4"))
            {

            }
            else if (select.Equals("5"))
            {

            }
        }
        public void quest_menu()
        {
            Console.Clear();
            Console.WriteLine("메뉴를 선택하시오.\n");
            Console.WriteLine("1. 진행 가능한 퀘스트");
            Console.WriteLine("2. 진행중인 퀘스트");
            Console.WriteLine("3. 완료한 퀘스트");
            Console.WriteLine("4. 대화하기");
            Console.WriteLine("5. 돌아가기");
            Console.Write("입력 > ");
            string select = Console.ReadLine();
            if (select.Equals("1"))
            {
                character_status();
            }
            else if (select.Equals("2"))
            {

            }
            else if (select.Equals("3"))
            {

            }
            else if (select.Equals("4"))
            {

            }
            else if (select.Equals("5"))
            {

            }
        }
        public void adventure_menu()
        {
            Console.Clear();
            Console.WriteLine("메뉴를 선택하시오.\n");
            Console.WriteLine("1. 던전 탐험");
            Console.WriteLine("2. 다른 마을가기");
            Console.WriteLine("3. 스페셜 던전가기");
            Console.WriteLine("4. 미구현");
            Console.WriteLine("5. 돌아가기");
            Console.Write("입력 > ");
            string select = Console.ReadLine();
            if (select.Equals("1"))
            {
                character_status();
            }
            else if (select.Equals("2"))
            {

            }
            else if (select.Equals("3"))
            {

            }
            else if (select.Equals("4"))
            {

            }
            else if (select.Equals("5"))
            {

            }
        }
        public void shop_menu()
        {
            Console.Clear();
            Console.WriteLine("메뉴를 선택하시오.\n");
            Console.WriteLine("1. 구매");
            Console.WriteLine("2. 판매");
            Console.WriteLine("3. 호감도 확인");
            Console.WriteLine("4. 스페셜 상점");
            Console.WriteLine("5. 돌아가기");
            Console.Write("입력 > ");
            string select = Console.ReadLine();
            if (select.Equals("1"))
            {
                character_status();
            }
            else if (select.Equals("2"))
            {

            }
            else if (select.Equals("3"))
            {

            }
            else if (select.Equals("4"))
            {

            }
            else if (select.Equals("5"))
            {

            }
        }
        public void character_status()
        {
            Console.Clear();
            Console.WriteLine("플레이어 정보\n");
            Console.WriteLine($"아이디 : {my_stats.get_uid()}");
            Console.WriteLine($"레벨   : {my_stats.get_lv()}");
            Console.WriteLine($"체력   : {my_stats.get_hp()}");
            Console.WriteLine($"마력   : {my_stats.get_mp()}");
            Console.WriteLine($"경험치 : {my_stats.get_xp()}");
            Console.WriteLine($"힘     : {my_stats.get_str()}");
            Console.WriteLine($"지구력 : {my_stats.get_con()}");
            Console.WriteLine($"지혜   : {my_stats.get_wis()}");
            Console.WriteLine($"민첩   : {my_stats.get_dex()}");
            Console.WriteLine($"행운   : {my_stats.get_luck()}");
            Console.WriteLine($"소지금 : {my_stats.get_money()}+G");
            string select = Console.ReadLine();
        }
        public void inventory_menu()
        {
            Console.Clear();
            Console.WriteLine("메뉴를 선택하시오.\n");
            Console.WriteLine("1. 장비 아이템");
            Console.WriteLine("2. 소비 아이템");
            Console.WriteLine("3. 기타 아이템");
            Console.WriteLine("4. 스페셜 아이템");
            Console.WriteLine("5. 돌아가기");
            Console.Write("입력 > ");
            string select = Console.ReadLine();
            if (select.Equals("1"))
            {
                my_inven.inven_equips();
            }
            else if (select.Equals("2"))
            {
                my_inven.inven_uses();
            }
            else if (select.Equals("3"))
            {
                my_inven.inven_etcs();
            }
            else if (select.Equals("4"))
            {
                my_inven.inven_special();
            }
            else if (select.Equals("5"))
            {

            }
        }
    }
}

