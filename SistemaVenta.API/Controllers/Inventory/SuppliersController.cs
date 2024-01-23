using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Application.Constants;
using SistemaVenta.Application.Features.Suppliers.Commands.CreateProvider;
using SistemaVenta.Application.Features.Suppliers.Commands.DeleteSupplier;
using SistemaVenta.Application.Features.Suppliers.Commands.UpdateSupplier;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliertById;
using SistemaVenta.Application.Models;

namespace SistemaVenta.API.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSuppliersList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetSuppliersList()
        {
            var result = await _mediator.Send(new GetSuppliersListQuery());
            var response = new ApiResponse(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        [HttpGet("{id:int}",Name = "GetSupplierById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<SupplierDTO>>> GetSupplierById(int id)
        {
            var result = await _mediator.Send(new GetSupplierByIdQuery(id));
            var response = new ApiResponse<SupplierDTO>(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        [HttpPost(Name = "CreateSupplier")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> CreateSupplier([FromBody] CreateSupplierCommand newSupplier)
        {
            var savedSupplierId = await _mediator.Send(newSupplier);

            object createdSupplier = new
            {
                 Id = savedSupplierId,
                 newSupplier.Name,
                 newSupplier.Email,
                 newSupplier.PhoneNumber
            };

            var response = new ApiResponse(Messages.CREATE_SUCCESS, createdSupplier);
            return Created(string.Empty, response);
        }

        [HttpPut(Name = "UpdateSupplier")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateSupplier([FromBody] UpdateSupplierCommand supplier)
        {

            var response = await _mediator.Send(supplier);

            return Accepted(new ApiResponse(Messages.UPDATE_SUCCESS, response));

        }

        [HttpDelete("{Id:int}",Name = "DeleteSupplier")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteSupplier([FromRoute] int Id)
        {
            bool IsSuccess = await _mediator.Send(new DeleteSupplierCommand(Id));

            return NoContent();
        }

    }
}
