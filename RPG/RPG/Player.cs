using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Player
    {
        private Stats stats;       
        public Player(string uid)
        {
            Console.WriteLine("여기");
            stats = new Stats(uid);
            Console.WriteLine("여기2");
        }

        public Stats get_stats()
        {
            Console.WriteLine("여기3");
            return this.stats;
        }
    }
}
