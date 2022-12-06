using presidentAndAssHole.Domain.Entity;
using presidentAndAssHole.Domain.ValueObjects;

namespace PresidentAndAssHole.Application.Retrive
{
    public record RetrieveRoomByIdOut
    (String link, String status,
    AccessConfig.Visibility visibility)
    {
        public static RetrieveRoomByIdOut of(Room aRoom)
        {
            return new RetrieveRoomByIdOut(
                aRoom.RoomLink.GetValue(),
                aRoom.Status.ToString(),
                aRoom.AccessConfig.GetVisibility()
            );
        }
    }
}