using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public class Local
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string dataPesquisa { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ff");

        public Local() { }
        public Local(string cep, string logradouro, string complemento, string bairro ,string localidade, string uf, string unidade, string ibge, string gia)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Unidade = unidade;
            Ibge = ibge;
            Gia = gia;
        } 


    }
} 
