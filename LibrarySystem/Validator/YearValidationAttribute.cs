using System.ComponentModel.DataAnnotations;

public class AnoValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            int ano;
            bool isNumber = int.TryParse(value.ToString(), out ano);
            int anoAtual = DateTime.Now.Year;

            if (isNumber && ano >= 1000 && ano <= 9999)
            {
                if (ano <= anoAtual)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"O ano do livro deve ser menor ou igual ao ano atual ({anoAtual}).");
                }
            }
        }
        return new ValidationResult("O ano deve ser um número de quatro dígitos.");
    }
}
