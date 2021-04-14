using FluentValidation;
using FindHouse.Business.Models;

namespace FindHouse.Business.Validations
{
    public class ImovelValidation : AbstractValidator<Imovel>
    {
        public ImovelValidation()
        {
            RuleFor(i => i.Titulo)
                   .NotEmpty()
                   .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.Descricao)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                   .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.AreaTotal)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.AreaUtil)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.Quartos)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.Banheiros)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.Garagens)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.Suites)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.Valor)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.TipoContrato)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.TipoImovel)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");


            RuleFor(i => i.Imagem)
                   .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
