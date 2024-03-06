using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Application.Constants;
using SistemaVenta.Application.Features.Categories.Commands.CreateCategory;
using SistemaVenta.Application.Features.Categories.Commands.DeleteCategory;
using SistemaVenta.Application.Features.Categories.Commands.UpdateCategory;
using SistemaVenta.Application.Features.Categories.Queries.GetCategoryList;
using SistemaVenta.Application.Models;

namespace SistemaVenta.API.Controllers.Inventory
{
    //[Route("api/[controller]")]
    [Route("api/inventory/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {        
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {            
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        public async Task<ActionResult<ApiResponse<IEnumerable<CategoryDTO>>>> GetCategories()
        {
            var result = await _mediator.Send(new GetCategoryListQuery());
            var response = new ApiResponse(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> CreateCategory([FromBody] CreateCategoryCommand category)
        {

            var id = await _mediator.Send(category);

            object newCategory = new { Id = id, category.Name };
            var response = new ApiResponse(Messages.CREATE_SUCCESS, newCategory);

            return Created(Messages.CREATE_SUCCESS, response);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateCategory([FromBody] UpdateCategoryCommand category)
        {

            var id = await _mediator.Send(category);
            var response = new ApiResponse(Messages.UPDATE_SUCCESS, category);
            return Accepted(response);
        }

        [HttpDelete("{id:int}",Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteCategory([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));

            return NoContent();
        }

    }
}
