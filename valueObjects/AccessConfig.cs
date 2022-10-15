namespace president.valueObjects
{
    public class AccessConfig : IValueObject
    {
        private readonly int minPlayers;
        private readonly int maxPlayers;
        private readonly int timeOfNextPlayer;
        private readonly Visibility visibility;

        private AccessConfig(
            int minPlayers,
            int maxPlayers, 
            int timeOfNextPlayer,
            Visibility visibility)
        {
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.timeOfNextPlayer = timeOfNextPlayer;
            this.visibility = visibility;
        }

        public static AccessConfig of(
            int minPlayers,
            int maxPlayers)
        {
            return AccessConfig.of(
                minPlayers,
                maxPlayers,
                Visibility.PUBLIC);
        }

        public static AccessConfig of(
            int minPlayers,
            int maxPlayers,
            Visibility visibility)
        {
                if(minPlayers < 4)
                {
                    throw new Exception(
                        "'min players' can't be less than 4"
                    );
                }

                if(minPlayers > 13)
                {
                    throw new Exception(
                        "'min players' can't be greater than 13"
                    );
                }

                if(maxPlayers > 13)
                {
                    throw new Exception(
                        "'max players' can't be greater than 13"
                    );
                }

                if(maxPlayers < minPlayers)
                {
                    throw new Exception(
                        "'max players' can't be less than " + minPlayers
                    );                    
                }

            return new AccessConfig(
                minPlayers,
                maxPlayers,
                15,
                visibility
            );
        }


        public int MinPlayers
        {
            get{ return minPlayers; }
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