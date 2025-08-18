using Shared.Behaviors.Validation;

namespace Shared.Exceptions;

public class CustomValidationException(List<ValidationErrorDto> errors)
    : Exception("One or more validation failures have occurred.")
{
    public List<ValidationErrorDto> Errors { get; } = errors;
}