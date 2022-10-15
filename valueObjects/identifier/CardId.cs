namespace president.valueObjects.identifier
{
    public class CardId : BaseId
    {
        private CardId(Guid value)
        :base(value){}

        public static CardId of()
        {
            return new CardId(Guid.NewGuid());
        }

        public static CardId of(Guid value)
        {
            return new CardId(value);
        }
    }

    
}