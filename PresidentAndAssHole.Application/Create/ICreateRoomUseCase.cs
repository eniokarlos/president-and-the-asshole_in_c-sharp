namespace PresidentAndAssHole.Application.Create
{
    public interface ICreateRoomUseCase
    {
        CreateRoomOut Execute(CreateRoomIn anIn);
    }
}