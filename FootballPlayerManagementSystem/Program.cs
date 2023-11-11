using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballPlayerManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerRepository repository = new PlayerRepository();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Welcome to Football Player Management System =====\n");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Update Player");
                Console.WriteLine("3. Delete Player");
                Console.WriteLine("4. List All Player");
                Console.WriteLine("5. Search Player");
                Console.WriteLine("6. Exit\n");
                Console.WriteLine("==========================================");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            // Add Player
                            Console.WriteLine("Adding a new contact...");
                            Console.Write("Enter name: ");
                            string Name = Console.ReadLine();
                            Console.Write("Enter jersey number: ");
                            string JerseyNo = Console.ReadLine();
                            Console.Write("Enter position name: ");
                            string Position = Console.ReadLine();
                            Console.Write("Enter club name: ");
                            string Club = Console.ReadLine();
                            Console.Write("Enter email: ");
                            string Email = Console.ReadLine();
                            Console.Write("Enter address: ");
                            string Address = Console.ReadLine();

                            Players player = new Players
                            {
                                Name = Name,
                                JerseyNo = JerseyNo,
                                Position = Position,
                                Club = Club,
                                Email = Email,
                                Address = Address
                            };
                            repository.Add(player);
                            Console.WriteLine("PlayerInfo added successfully.");
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            // Update Player
                            Console.WriteLine("Updating a player...");
                            Console.Write("Enter the name of the player to update: ");
                            string nameToUpdate = Console.ReadLine();
                            var contact = repository.GetByName(nameToUpdate);

                            if (contact == null)
                            {
                                Console.WriteLine("Player not found.");
                                return;
                            }
                            else
                            {
                                Console.Write("Enter new jersey number (leave empty to keep current): ");
                                string newJerseyNumber = Console.ReadLine();

                                Console.Write("Enter new position name (leave empty to keep current): ");
                                string newPositionName = Console.ReadLine();

                                Console.Write("Enter new club name (leave empty to keep current): ");
                                string newClubName = Console.ReadLine();

                                Console.Write("Enter new email (leave empty to keep current): ");
                                string newEmail = Console.ReadLine();

                                Console.Write("Enter new address (leave empty to keep current): ");
                                string newAddress = Console.ReadLine();

                                Players updatePlayer = new Players
                                {
                                    Name = nameToUpdate,
                                    JerseyNo= newJerseyNumber,
                                    Position = newPositionName,
                                    Club = newClubName,
                                    Email = newEmail,
                                    Address = newAddress
                                };

                                repository.Update(updatePlayer);
                                Console.WriteLine("PlayerInfo updated successfully.");
                            }
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            // Delete Player
                            Console.WriteLine("Deleting a Playerinfo...");
                            Console.Write("Enter the name of the player to delete: ");
                            string nameToDelete = Console.ReadLine();
                            var deleteContact = repository.GetByName(nameToDelete);
                            if (deleteContact == null)
                            {
                                Console.WriteLine("player not found.");
                                return;
                            }
                            else
                            {
                                repository.Delete(deleteContact);
                                Console.WriteLine("playerinfo deleted successfully.");
                            }
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            // List All Players
                            PlayerRepository contactRepository = new PlayerRepository();
                            Console.WriteLine("Listing all players...");
                            var playersList = contactRepository.GetAll();
                            if (playersList.Count() > 0)
                            {
                                foreach (var player in playersList)
                                {
                                    Console.WriteLine($"Name: {player.Name}, JerseyNo: {player.JerseyNo}, Position: {player.Position}, Club: {player.Club}, Email: {player.Email}, Address: {player.Address}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No players available.");
                            }
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            // Search Players
                            Console.WriteLine("Searching for players...");
                            Console.Write("Enter search keyword: ");
                            string searchKeyword = Console.ReadLine();
                            var searchResult = PlayersDB.players.Where(p => p.Name.Equals(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                                                                        p.JerseyNo.Equals(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                                                                          p.Position.Equals(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                                                                            p.Club.Equals(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                                                                        p.Email.Equals(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                                                                        p.Address.Equals(searchKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (searchResult.Count > 0)
                            {
                                Console.WriteLine("Search Results: ");
                                foreach (var player in searchResult)
                                {
                                    Console.WriteLine($"Name: {player.Name}, JerseyNo: {player.JerseyNo}, Position: {player.Position}, Club: {player.Club}, Email: {player.Email}, Address: {player.Address}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No matching players found.");
                            }
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            // Exit the program
                            Console.WriteLine("Exiting...");
                            return;
                        }
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
    
}
