using Microsoft.AspNetCore.Mvc;
using Restaurante_Api.Extensions;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;

namespace Restaurante_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController(IActionResultConverter actionResultConverter,
                                        IGetRestauranteUseCase restauranteUseCase,
                                        ICreateRestauranteUseCase createRestauranteUseCase,
                                        IUpdateRestauranteUseCase updateRestauranteUseCase) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRestauranteResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Get()
        {
            var response = await restauranteUseCase.Execute();

            return actionResultConverter.Convert(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateRestauranteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Create([FromBody] CreateRestauranteRequest request)
        {
            var response = await createRestauranteUseCase.Execute(request);
            return actionResultConverter.Convert(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Update([FromBody] UpdateRestauranteRequest request)
        {
            var response = await updateRestauranteUseCase.Execute(request);
            return actionResultConverter.Convert(response, true);
        }
    }
}
