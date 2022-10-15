namespace president.valueObjects.identifier
{
    public class RoomId : BaseId
    {
        private RoomId(Guid value)
        :base(value){}

        public static RoomId of()
        {
            return new RoomId(Guid.NewGuid());
        }

        public static RoomId of(Guid value)
        {
            return new RoomId(value);
        }
    }

    
}