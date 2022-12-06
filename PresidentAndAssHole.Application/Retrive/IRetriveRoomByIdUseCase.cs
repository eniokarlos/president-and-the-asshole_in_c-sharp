using presidentAndAssHole.Domain.Identifiers;

namespace PresidentAndAssHole.Application.Retrive
{
    public interface IRetrieveRoomByIdUseCase 
    {
        RetrieveRoomByIdOut Execute(RoomId anIn);
    }
}