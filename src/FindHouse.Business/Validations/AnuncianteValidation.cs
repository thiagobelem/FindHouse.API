using FluentValidation;
using FindHouse.Business.Models;

namespace FindHouse.Business.Validations
{
    public class AnuncianteValidation : AbstractValidator<Anunciante>
    {
        public AnuncianteValidation()
        {
            RuleFor(i => i.Nome)
                   .NotEmpty()
                   .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(i => i.Descricao)
                   .NotEmpty()
                   .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(i => i.Email)
                   .NotEmpty()
                   .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                   .EmailAddress();


            RuleFor(i => i.Telefone)
                   .NotEmpty()
                   .Length(10, 11).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(i => i.Creci)
                   .NotEmpty()
                   .Length(2, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(i => i.Imagem)
                   .NotEmpty()
                   .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
