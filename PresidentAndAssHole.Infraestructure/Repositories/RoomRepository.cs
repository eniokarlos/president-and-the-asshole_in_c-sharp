using presidentAndAssHole.Domain.Entity;
using presidentAndAssHole.Domain.Identifiers;
using PresidentAndAssHole.Domain.Interfaces;
using PresidentAndAssHole.Infraestructure.Context;

namespace PresidentAndAssHole.Infraestructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly static Dictionary<String, Room> ROOMS = new Dictionary<string, Room>();

        public void Delete(RoomId roomId)
        {
            ROOMS.Remove(roomId.Value);
        }

        public Room GetById(RoomId roomId)
        {
            return ROOMS[roomId.Value];
        }

        public IEnumerable<Room> GetRooms()
        {
            return ROOMS.Values;
        }

        public Room Save(Room room)
        {
            ROOMS.Add(room.RoomId.Value, room);
            return room;
        }
    }
}