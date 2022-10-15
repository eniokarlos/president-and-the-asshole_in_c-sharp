using president.valueObjects;
using president.valueObjects.identifier;


namespace president.entity
{
    public class Room
    {
        private readonly RoomId roomId;
        private PlayerId ownerId;
        private readonly RoomLink roomLink;
        private AccessConfig accessConfig;

        private List<PlayerId> players;

        private Room(
            RoomId roomId,
            PlayerId ownerId,
            RoomLink roomLink,
            AccessConfig accessConfig,
            List<PlayerId> players)
        {
            this.roomId = roomId;
            this.ownerId = ownerId;
            this.roomLink = roomLink;
            this.accessConfig = accessConfig;
            this.players = players;
        }

        public static Room of(PlayerId ownerId, AccessConfig accessConfig)
        {
            var roomId = RoomId.of();
            var roomLink = RoomLink.of();
            var players = new List<PlayerId>();
            players.Add(ownerId);

            return new Room(
                roomId,
                ownerId,
                roomLink,
                accessConfig,
                players
            );
        }
        public void AddPlayer(PlayerId playerId)
        {
            if (players.Count() >= accessConfig.MaxPlayers) {
                throw new Exception("This room is full!");
            }

            this.players.Add(playerId);
        }

        public RoomId RoomId
        {
            get { return this.roomId; }
        }

        public PlayerId OwnerId
        {
            get { return ownerId; }
        }
        
        public RoomLink RoomLink 
        {
            get { return roomLink; }
        }

        public AccessConfig AccessConfig
        {
            get { return accessConfig; }
        }

        public List<PlayerId> Players 
        {
            get { return players; }
        }

        public enum status
        {
            IN_LOBBY, SORTING, READY, ROUND, ROUND_FINISHED, FINISHED
        }
    }
}