using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Local L = new Local();
            List<string> lst = new List<string>();
            List<Local> Ceps = new List<Local>();
            L.LotarLista(lst);
            int contador = 0, decisao;
            #region "Json"
            foreach (var ceps in lst)
            {
                try
                {

                    var requisicaoWeb = WebRequest.CreateHttp($"https://viacep.com.br/ws/{ceps}/json");
                    requisicaoWeb.Method = "GET";
                    requisicaoWeb.UserAgent = "RequisicaoWebDemo";

                    using (var resposta = requisicaoWeb.GetResponse())
                    {
                        var streamDados = resposta.GetResponseStream();
                        StreamReader reader = new StreamReader(streamDados);
                        object objResponse = reader.ReadToEnd();
                        var local = JsonConvert.DeserializeObject<Local>(objResponse.ToString());
                        local.dataPesquisa = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ff");
                        Ceps.Add(local);
                        contador++;
                    }
                    Ceps = Ceps.OrderBy(x => x.Uf).ThenBy(x => x.dataPesquisa).ToList();
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Foram registrados {contador} Ceps");
            }
            #endregion

            L.PulaLinha();
           
            string cont;
            // definir as paginas 
            Console.WriteLine("Seja bem vindo, quantos registros você deseja por pagina?");
            L.PulaLinha();
            try
            {
                int registro = int.Parse(Console.ReadLine());
                int paginas = 50 / registro;
                if (50 % registro != 0) { paginas += 1; }

                do
                {
                    // imprimir o menu 
                    for (int i = 1; i <= paginas; i++)
                    {
                        L.PulaLinha();
                        Console.WriteLine($"Digite {i} para pagina {i}");
                        L.PulaLinha();
                    }

                    Int32.TryParse(Console.ReadLine(), out decisao);

                    if (decisao <= 0 || decisao > paginas)
                    {
                        Console.WriteLine("Essa pagina nao existe");
                        L.PulaLinha();
                    }
                    else
                    {
                        var result = Ceps.Skip((decisao - 1) * registro).Take(registro);

                        foreach (var item in result)
                        {
                            Console.WriteLine($"CEP: {item.Cep} Logradouro: {item.Logradouro} Bairro {item.Bairro} UF: {item.Uf} Hora de registro {item.dataPesquisa}");
                            L.PulaLinha();
                        }
                    }
                    Console.WriteLine("Deseja continuar?");
                    L.PulaLinha();
                    cont = Console.ReadLine().ToLower();

                } while (cont == "s");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }
    }
}
