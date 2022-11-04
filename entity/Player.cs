using president.valueObjects.identifier;
using System.Collections.ObjectModel;

namespace president.entity
{
    public class Player
    {
        public PlayerId PlayerId { get; set; }
        public string NickName { get; set; }
        private List<Card> cards;
        public Card? ChoicedCard { get; private set; }

        private Player(
            PlayerId playerId,
            String NickName,
            List<Card> cards,
            Card? choicedCard)
        {
            this.PlayerId = playerId;
            this.NickName = NickName;
            this.cards = cards;
            this.ChoicedCard = choicedCard;
        }

        public static Player of(String NickName)
        {
            return new Player(
                PlayerId.of(), 
                NickName, 
                new List<Card>(), 
                null);
        }

        public void ChoiceCard(Card card)
        {
            this.ChoicedCard = card;
        }

        public ReadOnlyCollection<Card> Cards
        {
            get { return new ReadOnlyCollection<Card>(this.cards); }
        }

    }
}