using System;
using System.Collections.Generic;

namespace FindHouse.Business.Models
{
    public class Anunciante : Entity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Creci { get; set; }

        public string Imagem { get; set; }



        /*EF Relations*/

        public IEnumerable<Imovel> Imoveis { get; set; }
    }
}
