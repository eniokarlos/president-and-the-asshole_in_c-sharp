using PresidentAndAssHole.Domain.Interfaces;

namespace PresidentAndAssHole.Application.Create
{
    public class CreateRoomUseCaseImpl : ICreateRoomUseCase
    {

        private readonly IRoomRepository _repository;

        public CreateRoomUseCaseImpl(IRoomRepository repository)
        {
            this._repository = repository;
        }

        public CreateRoomOut Execute(CreateRoomIn anIn)
        {
            return CreateRoomOut.of(
                _repository.Save(anIn.ToRoom())
            );
        }
    }
}