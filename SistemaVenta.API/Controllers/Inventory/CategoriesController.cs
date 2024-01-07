using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Application.Constants;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Features.Categories.Commands.CreateCategory;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.API.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IAsyncRepository<Category> _categories;
        private readonly IMediator _mediator;

        public CategoriesController(IAsyncRepository<Category> categories, IMediator mediator)
        {
            _categories = categories;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categories.GetAllAsync();

            return categories.Count() > 0 ? Ok(categories) : NoContent();
        }

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateCategory(CreateCategoryCommand category)
        {

            var response = await _mediator.Send(category);

            return response != 0 ? Ok(Messages.CREATE_SUCCESS) : BadRequest(Messages.HAS_ERROR);
        }


    }
}
