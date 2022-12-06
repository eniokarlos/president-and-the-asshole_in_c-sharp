using presidentAndAssHole.Domain.Entity;
using presidentAndAssHole.Domain.Identifiers;
using PresidentAndAssHole.Domain.Interfaces;

namespace PresidentAndAssHole.Application.Retrive
{
    public class RetrieveRoomsUseCaseImpl : IRetrieveRoomsUseCase
    {
        private readonly IRoomRepository _repository;

        public RetrieveRoomsUseCaseImpl(IRoomRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Room> Execute()
        {
            return _repository.GetRooms();
        }
    }
}