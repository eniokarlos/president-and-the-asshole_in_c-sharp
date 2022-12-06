using presidentAndAssHole.Domain.Identifiers;
using PresidentAndAssHole.Domain.Interfaces;

namespace PresidentAndAssHole.Application.Retrive
{
    public class RetrieveRoomByIdUseCaseImpl : IRetrieveRoomByIdUseCase
    {
        private readonly IRoomRepository _repository;

        public RetrieveRoomByIdUseCaseImpl(IRoomRepository repository)
        {
            this._repository = repository;
        }
        public RetrieveRoomByIdOut Execute(RoomId anIn)
        {
            return RetrieveRoomByIdOut.of(
                _repository.GetById(anIn)
            );
        }
    }
}