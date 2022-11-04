namespace president.valueObjects
{
    public class AccessConfig : IValueObject
    {
        private readonly static int MIN_PLAYERS = 4;
        private readonly int maxPlayers;
        private readonly int timeOfNextPlayer;
        private readonly Visibility visibility;

        private AccessConfig(
            int maxPlayers, 
            int timeOfNextPlayer,
            Visibility visibility)
        {
            this.maxPlayers = maxPlayers;
            this.timeOfNextPlayer = timeOfNextPlayer;
            this.visibility = visibility;
        }

        public static AccessConfig ofPublic(
            int maxPlayers)
        {
            return AccessConfig.of(
                maxPlayers,
                Visibility.PUBLIC);
        }

        public static AccessConfig ofPrivate(
            int maxPlayers) {

        return AccessConfig.of(
                maxPlayers,
                Visibility.PRIVATE
        );
    }

        public static AccessConfig of(
            int maxPlayers,
            Visibility visibility)
        {
                if(maxPlayers < AccessConfig.MIN_PLAYERS)
                {
                    throw new Exception(
                        "'max players' can't be less than 4"
                    );
                }

                if(maxPlayers > 13)
                {
                    throw new Exception(
                        "'max players' can't be greater than 13"
                    );
                }

            return new AccessConfig(
                maxPlayers,
                15,
                visibility
            );
        }


        public int MinPlayers
        {
            get{ return MIN_PLAYERS; }
        }

        public int MaxPlayers
        {
            get { return maxPlayers; }
        }

        public int TimeOfNextPlayer
        {
            get{ return timeOfNextPlayer; }
        }

        public Visibility GetVisibility()
        {
            return visibility;
        }

        public enum Visibility
        {
            PUBLIC, PRIVATE
        }

    }
}