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
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());

            return Ok(categories);
        }

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateCategory(CreateCategoryCommand category)
        {

            var id = await _mediator.Send(category);

            var response = new ApiResponse(Messages.CREATE_SUCCESS, category);

            return id != 0 ? Created(Messages.CREATE_SUCCESS, response) : BadRequest(Messages.HAS_ERROR);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]        
        public async Task<ActionResult<int>> UpdateCategory(UpdateCategoryCommand category)
        {

            var id = await _mediator.Send(category);                        
            return NoContent();
        }

        [HttpDelete("{id:int}",Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));

            return NoContent();
        }

    }
}
