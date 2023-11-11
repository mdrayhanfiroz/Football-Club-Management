using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayerManagementSystem
{
    public class PlayersDB
    {
        public static List<Players> players = new List<Players>();
    }
    public class Players
    {
        public string Name { get; set; }
        public string JerseyNo { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }     
    }
    public class PlayerRepository : IRepository
    {
        public void Add(Players player)
        {
            PlayersDB.players.Add(player);
        }

        public void Delete(Players player)
        {
            Players playerToDelete = PlayersDB.players.FirstOrDefault(c => c.Name.Equals(player.Name, StringComparison.OrdinalIgnoreCase) || c.JerseyNo.Equals(player.JerseyNo, StringComparison.OrdinalIgnoreCase));
            PlayersDB.players.Remove(playerToDelete);
        }

        public IEnumerable<Players> GetAll()
        {
            return PlayersDB.players;
        }

        public Players GetByName(string name)
        {
            Players player = PlayersDB.players.FirstOrDefault(c => c.Name == name);
            return player;
        }

        public void Update(Players player)
        {
            Players playerToUpdate = PlayersDB.players.FirstOrDefault(c => c.Name.Equals(player.Name, StringComparison.OrdinalIgnoreCase));

            if (playerToUpdate.Name != null)
            {
                playerToUpdate.Name = player.Name;
            }
            if (playerToUpdate.JerseyNo != null)
            {
                playerToUpdate.JerseyNo = player.JerseyNo;
            }
            if (playerToUpdate.Position != null)
            {
                playerToUpdate.Position = player.Position;
            }
            if (playerToUpdate.Club != null)
            {
                playerToUpdate.Club = player.Club;
            }
            if (playerToUpdate.Email != null)
            {
                playerToUpdate.Email = player.Email;
            }
            if (playerToUpdate.Address != null)
            {
                playerToUpdate.Address = player.Address;
            }
            
        }
    }
}
