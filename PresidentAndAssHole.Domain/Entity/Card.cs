using presidentAndAssHole.Domain.ValueObjects;
using presidentAndAssHole.Domain.Identifiers;
namespace presidentAndAssHole.Domain.Entity
{
    public class Card
    {
        private readonly CardId cardId;
        private readonly CardValue cardValue;
        private readonly Suit suit;

        private Card(CardId cardId, CardValue cardValue, Suit suit)
        {
            this.cardId = cardId;
            this.cardValue = cardValue;
            this.suit = suit;
        }

        public static Card of(CardValue cardValue, Suit suit)
        {
            return new Card(CardId.of(), cardValue, suit);
        }

        public CardId CardId{
            get { return cardId; }
        }
        
        public CardValue CardValue
        {
            get { return cardValue; }
        }
        
        public Suit Suit
        {
            get { return suit; }
        }
    }
}