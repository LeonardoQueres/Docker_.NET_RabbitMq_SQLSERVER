using ItemService_Api.Models;
using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ItemService_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController(IActionResultConverter actionResultConverter,
                                        IGetRestauranteUseCase getRestauranteUseCase) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRestauranteResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Get()
        {
            var response = await getRestauranteUseCase.Execute();

            return actionResultConverter.Convert(response);
        }
    }
}
