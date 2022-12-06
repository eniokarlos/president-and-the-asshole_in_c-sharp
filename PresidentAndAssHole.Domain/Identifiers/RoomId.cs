namespace presidentAndAssHole.Domain.Identifiers
{
    public class RoomId : BaseId
    {
        private RoomId(Guid value)
        :base(value){}

        public static RoomId of()
        {
            return new RoomId(Guid.NewGuid());
        }

        public static RoomId of(String value)
        {
            return new RoomId(Guid.Parse(value));
        }
    }

    
}