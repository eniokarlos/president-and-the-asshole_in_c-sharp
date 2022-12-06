using presidentAndAssHole.Domain.Entity;

namespace PresidentAndAssHole.Application.Create
{
    public record CreateRoomOut(String roomId, String link, String status)
    {
        public static CreateRoomOut of(Room aRoom) {
        return new CreateRoomOut(
                aRoom.RoomId.Value,
                aRoom.RoomLink.GetValue(),
                aRoom.Status.ToString()
        );
    }
    }
}