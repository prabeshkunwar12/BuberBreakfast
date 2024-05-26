using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService){
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request){

        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        //TODO:Save the item to the database
        ErrorOr<Created> createdResult = _breakfastService.CreateBreakfast(breakfast);

        return createdResult.Match(
            created => CreatedAtGetBreakfast(breakfast),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id){
        ErrorOr<Breakfast> getResult = _breakfastService.GetBreakfast(id);

        return getResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request){
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        ErrorOr<UpsertedBreakfast> updatedResult = _breakfastService.UpsertBreakfast(breakfast);
        
        updatedResult.Match(
            upserted => upserted.IsNewlyCreated ? 
                CreatedAtGetBreakfast(breakfast): 
                NoContent(),
            errors => Problem(errors)
        );

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id){
        ErrorOr<Deleted> deletedResult = _breakfastService.DeleteBreakfast(id);

        deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );

        return NoContent();
    }

    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast) {
        return new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
    }

    private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast) {
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id},
            value: MapBreakfastResponse(breakfast)
        );
    }
}