using president.entity;
using president.valueObjects;
using president.valueObjects.identifier;
using System.Linq;

namespace president
{
    public class Program
    {
        static void Main(String[] args)
        {
            var room = Room.of(PlayerId.of(), AccessConfig.of(5, 9));
            room.AddPlayer(PlayerId.of());
            room.AddPlayer(PlayerId.of());
            room.AddPlayer(PlayerId.of());
            room.AddPlayer(PlayerId.of());

            var cardsValues = Enum.GetValues<CardValue>();
            var cardsClub = new List<Card>();

            foreach(var cardValue in cardsValues){
                cardsClub.Add(Card.of(cardValue, Suit.CLUBS));
            }
            
            ShuffleCards(ref cardsClub);
            
            var p1 = cardsClub[12];
            var p2 = cardsClub[11];

            System.Console.WriteLine(p1.GetCardValue());
            System.Console.WriteLine(p2.GetCardValue());

            print(room);
            
        }

        public static void ShuffleCards(ref List<Card> l)
        {

            l = l.OrderBy( x => Guid.NewGuid()).ToList();
        }

        public static void print(Room room)
        {
            System.Console.WriteLine("Room id: " + room.RoomId.GetValue());
            System.Console.WriteLine("Owner id: " + room.OwnerId.GetValue());
            room.Players.ForEach(p =>
            {
                System.Console.WriteLine("Players: " + p.GetValue());
            });
            System.Console.WriteLine("Link value: " + room.RoomLink.GetValue());
            System.Console.WriteLine("Min players: " + room.AccessConfig.MinPlayers);
            System.Console.WriteLine("Max players " + room.AccessConfig.MaxPlayers);
            System.Console.WriteLine("Time of next player:" + room.AccessConfig.TimeOfNextPlayer);
            System.Console.WriteLine("Visibility: " + room.AccessConfig.GetVisibility());
        }
    }
}