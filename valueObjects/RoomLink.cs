
namespace president.valueObjects
{
    public class RoomLink : IValueObject
    {
        private Guid value;

        private RoomLink(Guid value)
        {
            this.value = value;
        }

        public static RoomLink of()
        {
            return new RoomLink(Guid.NewGuid());
        }

        public Guid GetValue()
        {
            return value;
        }
    }
}