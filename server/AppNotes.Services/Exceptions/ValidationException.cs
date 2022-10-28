using AppNotes.Models.Validation;

namespace AppNotes.Services.Exceptions;
public class ValidationException : Exception
{
    public ValidationException(ValidationResult result)
        : base(result.Message) { }
}