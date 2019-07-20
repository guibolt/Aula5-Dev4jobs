using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Local
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }

        public Local(string cep, string logradouro, string complemento, string localidade, string uf, string unidade, string ibge, string gia)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Localidade = localidade;
            Uf = uf;
            Unidade = unidade;
            Ibge = ibge;
            Gia = gia;
        }
    }
}
