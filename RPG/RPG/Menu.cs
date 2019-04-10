using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Menu
    {
        private string uid;
        static int return_value;

        public Menu()
        {
            LoginPage lp = new LoginPage();
            do
            {

                return_value = lp.loginpage();
                if(return_value == 1)
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
            Console.WriteLine("접속완료!!!!");
            Console.WriteLine("접속중아이디 : "+ lp.get_userID());
            this.uid = lp.get_userID();
            Player player = new Player(uid);
            Stats my_stats = player.get_stats();
            
            Console.WriteLine("플레이어 정보\n");
            Console.WriteLine($"레벨   : {my_stats.get_lv()}");
            Console.WriteLine($"체력   : {my_stats.get_hp()}");
            Console.WriteLine($"마력   : {my_stats.get_mp()}");
            Console.WriteLine($"경험치 : {my_stats.get_xp()}");
            Console.WriteLine($"힘     : {my_stats.get_str()}");
            Console.WriteLine($"지구력 : {my_stats.get_con()}");
            Console.WriteLine($"지혜   : {my_stats.get_wis()}");
            Console.WriteLine($"민첩   : {my_stats.get_dex()}");
            Console.WriteLine($"행운   : {my_stats.get_luck()}");
            Console.WriteLine($"소지금 : {my_stats.get_money()}");
        }
        
    }
}

