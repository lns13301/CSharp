using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPG
{
    class Stats
    {
        private int xp, hp, mp, str, con, wis, dex, luck, money, lv;
        private string uid;
        public Stats(string uid)
        {
            this.uid = uid;
            
            ReadStats();
        }
        public void WriteStats()
        {
            char comma = ',';
            string[] statlist = File.ReadAllLines(@"C:\Users\DB\Desktop\코딩\TurnRPGData\statlist.txt");
            string list = null;
            foreach (string line in statlist)
            {
                list = list + line;
            }
            string[] datalist = list.Split(comma);
            for (int i = 0; i < datalist.Length; i++)
            {
                if (datalist[i].Equals(uid))
                {
                    using (StreamWriter PlayerStats = new StreamWriter(@"C:\Users\DB\Desktop\코딩\TurnRPGData\statlist.txt", true))
                    {
                        datalist[i + 1] = xp.ToString();
                        datalist[i + 2] = hp.ToString();
                        datalist[i + 3] = mp.ToString();
                        datalist[i + 4] = str.ToString();
                        datalist[i + 5] = con.ToString();
                        datalist[i + 6] = wis.ToString();
                        datalist[i + 7] = dex.ToString();
                        datalist[i + 8] = luck.ToString();
                        datalist[i + 9] = money.ToString();
                        datalist[i + 10] = lv.ToString();
                    }
                }
            }
        }
        public void ReadStats()
        {
            int idx = 0;
            string[] datalist = null;
            string[] statlist = File.ReadAllLines(@"C:\Users\DB\Desktop\코딩\TurnRPGData\statlist.txt");

            for (int i = 0; i < statlist.Length; i++)
            {
                if (statlist[i].Split(',')[0].Equals(uid))
                {
                    idx = i;
                    datalist = statlist[idx].Split(',');
                    break;

                }
                else if(i == statlist.Length -1)
                {
                    if (!statlist[i].Split(',')[0].Equals(uid))
                    {
                        Console.WriteLine("일치하는 계정데이터가 없습니다. 새로 생성합니다.");
                        string[] writestat = { this.uid, "0", "50", "20", "0", "0", "0", "0", "0", "0", "1" };
                        using (StreamWriter PlayerStats = new StreamWriter(@"C:\Users\DB\Desktop\코딩\TurnRPGData\statlist.txt", true))
                        {
                            PlayerStats.WriteLine();
                            foreach (string line in writestat)
                            {
                                PlayerStats.Write(line + ",");
                            }
                        }
                        datalist = writestat;
                    }
                }
            }
            this.xp = int.Parse(datalist[1]);
            this.hp = int.Parse(datalist[2]);
            this.mp = int.Parse(datalist[3]);
            this.str = int.Parse(datalist[4]);
            this.con = int.Parse(datalist[5]);
            this.wis = int.Parse(datalist[6]);
            this.dex = int.Parse(datalist[7]);
            this.luck = int.Parse(datalist[8]);
            this.money = int.Parse(datalist[9]);
            this.lv = int.Parse(datalist[10]);
        }
        public int get_xp()
        {
            return this.xp;
        }
        public int get_hp()
        {
            return this.hp;
        }
        public int get_mp()
        {
            return this.mp;
        }
        public int get_str()
        {
            return this.str;
        }
        public int get_con()
        {
            return this.con;
        }
        public int get_wis()
        {
            return this.wis;
        }
        public int get_dex()
        {
            return this.dex;
        }
        public int get_luck()
        {
            return this.luck;
        }
        public int get_money()
        {
            return this.money;
        }
        public int get_lv()
        {
            return this.lv;
        }
        public string get_uid()
        {
            return this.uid;
        }
        public void set_xp(int xp)
        {
            this.xp = xp;
        }
        public void set_hp(int hp)
        {
            this.hp = hp;
        }
        public void set_mp(int mp)
        {
            this.mp = mp;
        }
        public void set_str(int str)
        {
            this.str = str;
        }
        public void set_con(int con)
        {
            this.con = con;
        }
        public void set_wis(int wis)
        {
            this.wis = wis;
        }
        public void set_dex(int dex)
        {
            this.dex = dex;
        }
        public void set_luck(int luck)
        {
            this.luck = luck;
        }
        public void set_money(int money)
        {
            this.money = money;
        }
        public void set_lv(int lv)
        {
            this.lv = lv;
        }
        public void set_uid(string uid)
        {
            this.uid = uid;
        }
    }
}
