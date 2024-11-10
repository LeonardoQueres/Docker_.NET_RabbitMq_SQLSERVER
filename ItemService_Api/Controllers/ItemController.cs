using ItemService_Api.Models;
using ItemService_Borders.DTO.Internal;
using ItemService_Borders.Shared;
using ItemService_Borders.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ItemService_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IActionResultConverter actionResultConverter,
                                ICreateItemUseCase createItemUseCase,
                                IUpdateItemUseCase updateItemUseCase,
                                IGetItemUseCase getItemUseCase,
                                IGetByIdItemUseCase getByIdItemUseCase) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateItemResponse))]
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetItemResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> Get()
        {
            var response = await getItemUseCase.Execute();
            return actionResultConverter.Convert(response);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetItemResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await getByIdItemUseCase.Execute(id);
            return actionResultConverter.Convert(response);
        }
    }
}
