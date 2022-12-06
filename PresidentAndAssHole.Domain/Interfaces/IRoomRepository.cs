using presidentAndAssHole.Domain.Entity;
using presidentAndAssHole.Domain.Identifiers;

namespace PresidentAndAssHole.Domain.Interfaces
{
    public interface IRoomRepository
    {
        public Room Save(Room room);
        public void Delete(RoomId roomId);
        public Room GetById(RoomId roomId);

        public IEnumerable<Room> GetRooms();

    }
}