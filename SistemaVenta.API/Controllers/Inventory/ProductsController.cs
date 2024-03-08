using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Application.Constants;
using SistemaVenta.Application.Features.Products.Commands.CreateProduct;
using SistemaVenta.Application.Features.Products.Commands.DeleteProduct;
using SistemaVenta.Application.Features.Products.Commands.UpdateProduct;
using SistemaVenta.Application.Features.Products.Queries.GetProductById;
using SistemaVenta.Application.Features.Products.Queries.GetProductList;
using SistemaVenta.Application.Models;

namespace SistemaVenta.API.Controllers.Inventory
{
    //[Route("api/[controller]")]
    [Route("api/inventory/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProductList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>>> GetProductList()
        {
            var productList = await _mediator.Send(new GetProductListQuery());

            var response = new ApiResponse<IEnumerable<ProductDTO>>(Messages.QUERY_SUCCESS, productList);

            return Ok(response);
        }

        [HttpGet("{productId:int}",Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> GetProductById(int productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));

            var response = new ApiResponse<ProductDTO>(Messages.QUERY_SUCCESS, product);

            return Ok(response);
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<CreateProductCommand>>> CreateProduct(CreateProductCommand newProduct)
        {

            var id = await _mediator.Send(newProduct);

            object savedProduc = new
            {
                Id = id,
                newProduct.Name,
                newProduct.Description,
                newProduct.SalePrice,
                newProduct.PurchasePrice,
                newProduct.Stock,
            };

            var response = new ApiResponse(Messages.CREATE_SUCCESS, savedProduc);

            return Created(Messages.CREATE_SUCCESS, response);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UpdateProductCommand>>> UpdateProduct(UpdateProductCommand product)
        {

            var result = await _mediator.Send(product);

            var response = new ApiResponse(Messages.UPDATE_SUCCESS, product);

            return Accepted(Messages.UPDATE_SUCCESS, response);

        }

        [HttpDelete("{Id:int}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult>  DeleteProduct(int Id)
        {
            if (Id <= 0) return BadRequest(new ApiResponse(Messages.INVALID_ID));

            var result = await _mediator.Send(new DeleteProductCommand(Id));

            return NoContent();
        }
    }
}
