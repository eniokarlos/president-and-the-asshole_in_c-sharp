using Microsoft.AspNetCore.Mvc;
using presidentAndAssHole.Domain.Identifiers;
using PresidentAndAssHole.Application.Create;
using PresidentAndAssHole.Application.Retrive;
using PresidentAndAssHole.Infraestructure.Repositories;

namespace PresidentAndAssHole.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomRepository repository = new RoomRepository();

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomIn anIn)
        {
            var UseCase = new CreateRoomUseCaseImpl(repository);
            var result =  UseCase.Execute(anIn);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult RetrieveRoomById(String roomId)
        {
            var UseCase = new RetrieveRoomByIdUseCaseImpl(
                repository
            );

            var result = UseCase.Execute(RoomId.of(roomId));
            return Ok(result);
        }

        [HttpGet("ObterSalas")]
        public IActionResult RetrieveRooms()
        {
            var UseCase = new RetrieveRoomsUseCaseImpl(repository);
            var result = UseCase.Execute();

            return Ok(result);
        }
    }
}