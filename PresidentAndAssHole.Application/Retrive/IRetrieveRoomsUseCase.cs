using presidentAndAssHole.Domain.Entity;

namespace PresidentAndAssHole.Application.Retrive
{
    public interface IRetrieveRoomsUseCase
    {
        public IEnumerable<Room> Execute();
    }
}