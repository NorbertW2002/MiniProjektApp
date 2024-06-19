using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekt
{
    public class Fraction
    {
        public int Name { get; set; }
        public Player GuildMaster { get; set; }
        public List<Player> Players { get; set; }

        public Fraction(int name, Player guildMaster, List<Player> players)
        {
            Name = name;
            GuildMaster = guildMaster;
            Players = players;
        }

        public override string ToString()
        {
            string temp = "";
            foreach(var player in Players)
            {
                temp += player.ToString() +'\n';
            }
            return $"Name: {Name}\nGuildMaster: {GuildMaster}\nPlayers: {temp}";
        }
    }
}
