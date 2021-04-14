using System;
using System.ComponentModel.DataAnnotations;

namespace FindHouse.API.ViewModels
{
    public class ImovelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid AnuncianteId { get; set; }

        public EnderecoViewModel Endereco { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal AreaTotal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal AreaUtil { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quartos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Banheiros { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Garagens { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Suites { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        public decimal? ValorCondominio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoContrato { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TipoImovel { get; set; }

        public string ImagemUpload { get; set; }

        public string Imagem { get; set; }

        public string NomeAnunciante { get; set; }
    }
}
