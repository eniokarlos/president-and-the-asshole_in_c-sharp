using presidentAndAssHole.Domain.Entity;
using presidentAndAssHole.Domain.ValueObjects;

namespace PresidentAndAssHole.Application.Create
{
    public record CreateRoomIn(
        String nickName, 
        AccessConfig.Visibility visibility,
        int maxPlayers)
    {
        public Room ToRoom()
        {
            return Room.of(
                Player.of(nickName),
                AccessConfig.of(maxPlayers, visibility)
            );
        }
    }
}