using System;

namespace FindHouse.Business.Models
{
    public class Imovel : Entity
    {
        public Guid AnuncianteId { get; set; }

        public Endereco Endereco { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal AreaTotal { get; set; }

        public decimal AreaUtil { get; set; }

        public int Quartos { get; set; }

        public int Banheiros { get; set; }

        public int Garagens { get; set; }

        public int Suites { get; set; }

        public decimal Valor { get; set; }

        public decimal? ValorCondominio { get; set; }

        public TipoContrato TipoContrato { get; set; }

        public TipoImovel TipoImovel { get; set; }

        public string Imagem { get; set; }



        /*EF Relations*/

        public Anunciante Anunciante { get; set; }
    }
}
