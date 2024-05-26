namespace BuberBreakfast.Contracts.Breakfast;

public record CreateBreakfastResponse(
    Guid Id,
    string name,
    string description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet
);