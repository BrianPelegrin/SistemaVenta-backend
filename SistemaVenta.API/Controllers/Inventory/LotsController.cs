using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Application.Constants;
using SistemaVenta.Application.Features.Lots.Commands.CreateLot;
using SistemaVenta.Application.Features.Lots.Commands.UpdateLot;
using SistemaVenta.Application.Features.Lots.Queries.GetLotById;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using SistemaVenta.Application.Models;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.API.Controllers.Inventory
{
    [ApiController]
    [Route("api/inventory/[controller]")]
    public class LotsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: LotsController
        [HttpGet(Name = "GetLots")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<LotDTO>>))]
        public async Task<ActionResult<ApiResponse<IEnumerable<Lot>>>> GetLots()
        {
            var result = await _mediator.Send(new GetLotQuery());
            var response = new ApiResponse<IEnumerable<LotDTO>>(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        // GET: LotsController/Details/5
        [HttpGet("{id:int}", Name = "GetLotById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LotDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<LotDTO>))]
        public async Task<ActionResult<ApiResponse<Lot>>> GetLotById(int id)
        {
            var result = await _mediator.Send(new GetLotByIdQuery(id));
            var response = new ApiResponse<LotDTO>(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        // GET: LotsController/Create
        [HttpPost(Name = "CreateLot")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LotDTO>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ApiResponse<LotDTO>))]
        public async Task<ActionResult<ApiResponse<Lot>>> CreateLot(CreateLotDTO model)
        {
            var result = await _mediator.Send(new CreateLotCommand(model));
            var response = new ApiResponse<LotDTO>(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        // POST: LotsController/Edit/5
        [HttpPut(Name = "UpdateLot")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LotDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<LotDTO>))]
        public async Task<ActionResult<ApiResponse<Lot>>> Edit(UpdateLotDTO model)
        {
            var result = await _mediator.Send(new UpdateLotCommand(model));
            var response = new ApiResponse<LotDTO>(Messages.QUERY_SUCCESS, result);
            return Ok(response);
        }

        // GET: LotsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}
    }
}
