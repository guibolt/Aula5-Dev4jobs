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



            while (true)
            {
                Console.WriteLine("Seja bem vindo, quantos registros você deseja por pagina?");
                int registro = int.Parse(Console.ReadLine());

                Console.WriteLine("Qual pagina ");



                #region "Json?"
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
                            Console.WriteLine(objResponse.ToString());
                            var local = JsonConvert.DeserializeObject<Local>(objResponse.ToString());

                            Ceps.Add(local);
                            contador++;
                        }

                        string path = @"C:\Users\guibo\Desktop\Aula5\Aula5-Dev4jobs\CepPaginas\Arquivo/object";
                        // convertendo e escrevendo o json 
                        StreamWriter sw2 = new StreamWriter(path);
                        string g2 = JsonConvert.SerializeObject(Ceps);
                        sw2.WriteLine(g2);
                        sw2.Close();
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine($"Foram registrados {contador} Ceps");
                }
                #endregion






                Console.ReadLine();
                var result = Ceps.Skip(0).Take(10);

                //foreach (var item in result)
                //{
                //    Console.WriteLine(item.Cep);
                //    Console.ReadLine();
                //}

            }



        }


    }



}
