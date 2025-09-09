using System.ComponentModel.DataAnnotations;

namespace Simulado.Validations;

public class TextAttributes : ValidationAttribute
{
    //valores default
    public int MaxLines { get; set; } = 100;
    public int MaxWords { get; set; } = 1000;
    public int MaxChar { get; set; } = 600;

    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        if (value is not string text || string.IsNullOrWhiteSpace(text))
            return ValidationResult.Success;

        if (text.Split('\n').Length > MaxLines)
            return new ValidationResult($"Text must have less than {MaxLines} lines");

        if (text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length > MaxWords)
            return new ValidationResult($"Text must have less than {MaxWords} words");

        if (text.Length > MaxChar)
            return new ValidationResult($"Text must have less than {MaxChar} charcaters");

        return ValidationResult.Success;
    }
}