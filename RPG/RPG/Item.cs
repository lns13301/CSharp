using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Item
    {
        protected string name;
        protected int type, lv_limit;
        protected int power, atkspeed, crit_rate, crit_power, boss_power;
        protected int armor;

        private int str_limit, con_limit, wis_limit, dex_limit, luck_limit;

        public Item()
        {
            // type : 0(무기) 1(헬멧) 2(상의) 3(하의) 4(전신) 5(장갑) 6(신발) 7(목걸이) 8(귀고리) 9(반지) 10(방패) 11(칭호)
            // 부여순서 : 아이템코드, 이름, 타입, 등급, 레벨제한, 장비별능력치...
        }
        public void generate_item()
        {
            List<Item> list_of_item = new List<Item>();
        }
    }
}
