using president.valueObjects;
using president.valueObjects.identifier;

namespace president.entity
{
    public class Room
    {
        private readonly RoomId roomId;
        private Player owner;
        private readonly RoomLink roomLink;
        private AccessConfig accessConfig;
        private List<Player> players;
        private List<PlayerId> playersToChoice;
        private List<Card> cardsToChoice;
        private Status status;

        private Room(
            RoomId roomId,
            Player owner,
            RoomLink roomLink,
            AccessConfig accessConfig,
            List<Player> players)
        {
            this.roomId = roomId;
            this.owner = owner;
            this.roomLink = roomLink;
            this.accessConfig = accessConfig;
            this.players = players;
            this.cardsToChoice = new List<Card>();

            this.playersToChoice = new List<PlayerId>(
                players.Select(x => x.PlayerId)
            );

            this.status = Status.WAITING;
        }

        public void ToSorting() {
            if (status != Status.WAITING){
                throw new Exception("Room is not waiting");
            }

            ShuffleCardsToChoice();
            this.status = Status.IN_SORTING;

        }
        
        private void ShuffleCardsToChoice()
        {
            if(players.Count() < accessConfig.MinPlayers)
            {
                throw new Exception("'min players' can't be less than four!");
            }

            foreach(CardValue cardValue in CardValueMethods.Values()){
                cardsToChoice.Add(Card.of(cardValue, Suit.CLUBS));
            }

            cardsToChoice = cardsToChoice.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public static Room of(Player owner, AccessConfig accessConfig)
        {
            var roomId = RoomId.of();
            var roomLink = RoomLink.of();
            var players = new List<Player>();
            players.Add(owner);

            return new Room(
                roomId,
                owner,
                roomLink,
                accessConfig,
                players
            );
        }

        public Card ChoiceCard(Player player) {

            if (status != Status.IN_SORTING) {
                throw new Exception("Room is not in sorting");
            }

            if (!playersToChoice.Contains(player.PlayerId))
            {
                throw new Exception("Can't choice card for player " + player.PlayerId.Value);
            }

            var card = cardsToChoice!.ElementAt(0);
            player.ChoiceCard(card);
            cardsToChoice.Remove(card);
            playersToChoice.Remove(player.PlayerId);

            if (playersToChoice.Count == 0) {
                ToInGame();
            }

            return card;
        }

        public void SortPlayers()
        {
            players.Sort((x, y) => y.ChoicedCard!.CardValue.CompareTo(x.ChoicedCard!.CardValue));
        }

        public void ToInGame() {

            if (status != Status.IN_SORTING && status != Status.ROUND_FINISHED) {
                throw new Exception("Room is not in sorting or round finished");
            }

            status = Status.IN_GAME;

        }


        public void AddPlayer(Player player)
        {
            if (players.Count() >= accessConfig.MaxPlayers) {
                throw new Exception("This room is full!");
            }

            this.players.Add(player);
            this.playersToChoice.Add(player.PlayerId);
        }

        public RoomId RoomId
        {
            get { return roomId; }
        }

        public Player Owner
        {
            get { return owner; }
        }
        
        public RoomLink RoomLink 
        {
            get { return roomLink; }
        }

        public AccessConfig AccessConfig
        {
            get { return accessConfig; }
        }

        public List<Player> Players 
        {
            get { return players; }
        }

    }
}
