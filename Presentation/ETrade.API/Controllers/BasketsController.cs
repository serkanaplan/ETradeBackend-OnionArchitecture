using ETrade.Application.Consts;
using ETrade.Application.CQRS.Commands.Basket.AddItemToBasket;
using ETrade.Application.CQRS.Commands.Basket.RemoveBasketItem;
using ETrade.Application.CQRS.Commands.Basket.UpdateQuantity;
using ETrade.Application.CQRS.Queries.Basket.GetBasketItems;
using ETrade.Application.CustomAttributes;
using ETrade.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class BasketsController(IMediator mediator) : ControllerBase
{
    readonly IMediator _mediator = mediator;

    [HttpGet]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Reading, Definition = "Get Basket Items")]
    public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest getBasketItemsQueryRequest)
    {
        List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Writing, Definition = "Add Item To Basket")]
    public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
    {
        AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
        return Ok(response);
    }

    [HttpPut]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Updating, Definition = "Update Quantity")]
    public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
    {
        UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
        return Ok(response);
    }

    [HttpDelete("{BasketItemId}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Deleting, Definition = "Remove Basket Item")]
    public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
    {
        RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
        return Ok(response);
    }
}
