namespace presidentAndAssHole.Domain.Identifiers
{
    public class PlayerId : BaseId
    {
        private PlayerId(Guid value)
        :base(value){}

        public static PlayerId of()
        {
            return new PlayerId(Guid.NewGuid());
        }

        public static PlayerId of(Guid value)
        {
            return new PlayerId(value);
        }
    }
}