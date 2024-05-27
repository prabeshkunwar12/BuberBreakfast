using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors {
    public static class Breakfast {
        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast not found"
        );
        public static Error InvalidName => Error.Validation(
            code: "Breakfast.Validation",
            description: $"Breakfast Name must be at least {Models.Breakfast.MinNameLength} characters and at most {Models.Breakfast.MaxNameLength} characters."
        );
        public static Error InvalidDescription => Error.Validation(
            code: "Breakfast.Validation",
            description: $"Breakfast Description must be at least {Models.Breakfast.MinDescriptionLength} characters and at most {Models.Breakfast.MaxDescriptionLength} characters."
        );
    }
}