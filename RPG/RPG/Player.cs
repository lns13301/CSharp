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
        private Inventory inventory;

        public Player(string uid)
        {
            stats = new Stats(uid);
            inventory = new Inventory(uid);
        }

        public Stats get_stats()
        {
            return this.stats;
        }
        public Inventory get_inventory()
        {
            return this.inventory;
        }
    }
}
