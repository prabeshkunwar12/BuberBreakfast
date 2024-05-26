namespace BuberBreakfast.Contracts.Breakfast;

public record UpsertBreakfastRequest(
    string name,
    string description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);