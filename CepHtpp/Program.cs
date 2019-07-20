using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CepHtpp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Local> Ceps = new List<Local>();
            int contador = 0;

            while (true)
            {
                Console.WriteLine("Escreva o seu Cep ou escreva s para sair");
                string Cep = Console.ReadLine().ToLower();
                if (Cep =="s")
                {
                    break;
                }
                while (Cep.Length < 0 || Cep.Length > 8 || Cep.Length <7)
                {
                    Console.WriteLine("Cep informado inválido, digite novamente!");
                    Cep = Console.ReadLine();
                }
                try
                {
                    var requisicaoWeb = WebRequest.CreateHttp($"https://viacep.com.br/ws/{Cep}/json");
                    requisicaoWeb.Method = "GET";
                    requisicaoWeb.UserAgent = "RequisicaoWebDemo";

                    using (var resposta = requisicaoWeb.GetResponse())
                    {
                        var streamDados = resposta.GetResponseStream();
                        StreamReader reader = new StreamReader(streamDados);
                        object objResponse = reader.ReadToEnd();
                        Console.WriteLine(objResponse.ToString());

                        var local = JsonConvert.DeserializeObject<Local>(objResponse.ToString());
                        Console.WriteLine();
                        Console.WriteLine(local.ToString());
                        Ceps.Add(local);
                        contador++;
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Foram registrados {contador} Ceps");
            }
        }
    }
}
