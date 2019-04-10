using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Weapons : Equipments
    {
        private string name;
        private int itemcode, type, grade, lv_limit;
        private int power, atkspeed, crit_rate, crit_power, boss_power;
        private int armor;

        public Weapons()
        {

        }
        public Weapons(int itemcode, string name, int type, int grade, int lv_limit, int power, int atkspeed)
        {
            this.itemcode = itemcode;
            this.name = name;
            this.type = type;
            this.grade = grade;
            this.lv_limit = lv_limit;
            this.power = power;
            this.atkspeed = atkspeed;
        }
        public Weapons(int itemcode, string name, int type, int grade, int lv_limit, int power, int atkspeed, int crit_rate)
        {
            this.itemcode = itemcode;
            this.name = name;
            this.type = type;
            this.grade = grade;
            this.lv_limit = lv_limit;
            this.power = power;
            this.atkspeed = atkspeed;
            this.crit_rate = crit_rate;
        }
        public Weapons(int itemcode, string name, int type, int grade, int lv_limit, int power, int atkspeed, int crit_rate, int crit_power)
        {
            this.itemcode = itemcode;
            this.name = name;
            this.type = type;
            this.grade = grade;
            this.lv_limit = lv_limit;
            this.power = power;
            this.atkspeed = atkspeed;
            this.crit_rate = crit_rate;
            this.crit_power = crit_power;
        }
        public Weapons(int itemcode, string name, int type, int grade, int lv_limit, int power, int atkspeed, int crit_rate, int crit_power, int boss_power)
        {
            this.itemcode = itemcode;
            this.name = name;
            this.type = type;
            this.grade = grade;
            this.lv_limit = lv_limit;
            this.power = power;
            this.atkspeed = atkspeed;
            this.crit_rate = crit_rate;
            this.crit_power = crit_power;
            this.boss_power = boss_power;
        }
        public void generate_Weapons()
        {
            List<Item> list_of_item = new List<Item>();

            list_of_item.Add(new Weapons(0, "무딘 몽둥이", 0, 0, 0, 10, 1));
            list_of_item.Add(new Weapons(1, "굵은 몽둥이", 0, 0, 5, 18, 1));
            list_of_item.Add(new Weapons(2, "단단한 몽둥이", 0, 0, 10, 27, 1, 10));
            list_of_item.Add(new Weapons(3, "소문난 몽둥이", 0, 0, 15, 39, 1, 30));
        }
    }
}
