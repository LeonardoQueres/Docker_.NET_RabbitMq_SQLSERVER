using Microsoft.AspNetCore.Mvc;
using Restaurante_Api.Extensions;
using Restaurante_Borders.DTO.Internal;
using Restaurante_Borders.Shared;
using Restaurante_Borders.UseCases;

namespace Restaurante_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IActionResultConverter actionResultConverter,
                                ICreateItemUseCase createItemUseCase,
                                IUpdateItemUseCase updateItemUseCase) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateItemRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Create([FromBody] CreateItemRequest request)
        {
            var response = await createItemUseCase.Execute(request);
            return actionResultConverter.Convert(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Update([FromBody] UpdateItemRequest request)
        {
            var response = await updateItemUseCase.Execute(request);
            return actionResultConverter.Convert(response, true);
        }
    }
}
