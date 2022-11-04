using president.entity;
using president.valueObjects;
using president.valueObjects.identifier;

namespace president
{
    public class Program
    {
        static void Main(String[] args)
        {
            var p1 = Player.of("Enio");
            var p2 = Player.of("Mel");
            var p3 = Player.of("Lara");
            var p4 = Player.of("Feericle");

            var room = Room.of(p1, AccessConfig.ofPrivate(4));

            room.AddPlayer(p2);
            room.AddPlayer(p3);
            room.AddPlayer(p4);

            room.ToSorting();

            room.ChoiceCard(p1);
            room.ChoiceCard(p2);
            room.ChoiceCard(p3);
            room.ChoiceCard(p4);

            room.SortPlayers();

            print(room);
            
        }
        public static void print(Room room)
        {
            System.Console.WriteLine("Room id: " + room.RoomId.Value);
            System.Console.WriteLine("Owner id: " + room.Owner.NickName);
            room.Players.ForEach(p =>
            {
                System.Console.WriteLine("Players: " + p.NickName);
                System.Console.WriteLine("Chosen Card:" + p.ChoicedCard!.CardValue);
            });
            System.Console.WriteLine("Link value: " + room.RoomLink.GetValue());
            System.Console.WriteLine("Min players: " + room.AccessConfig.MinPlayers);
            System.Console.WriteLine("Max players " + room.AccessConfig.MaxPlayers);
            System.Console.WriteLine("Time of next player:" + room.AccessConfig.TimeOfNextPlayer);
            System.Console.WriteLine("Visibility: " + room.AccessConfig.GetVisibility());
        }
    }
}