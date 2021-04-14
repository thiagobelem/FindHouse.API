﻿using System;

namespace FindHouse.Business.Models
{
    public class Endereco : Entity
    {
        public Guid ImovelId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }



        /*EF Relations*/

        public Imovel Imovel { get; set; }
    }
}