using System;
using System.Collections.Generic;
using System.Text;

namespace CepHtpp
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





        public override string ToString()
        {
            return $"Cep: {Cep} Logradouro: {Logradouro} Complemento: {Complemento} Localidade: {Localidade} UF: {Uf} Unidade: {Unidade}" ;
            




        }
    }
   
}
