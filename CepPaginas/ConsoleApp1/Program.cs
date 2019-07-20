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
            List<Local> Ceps = new List<Local>();
            int contador = 0, decisao;

            #region "lista"

           
            List<string> cepsguarda = new List<string>();

            cepsguarda.Add("05102000");
            cepsguarda.Add("41390200");
            cepsguarda.Add("36021240");
            cepsguarda.Add("78140205");
            cepsguarda.Add("57080100");
            cepsguarda.Add("58410387");
            cepsguarda.Add("77433200");
            cepsguarda.Add("58087040");
            cepsguarda.Add("88816262");
            cepsguarda.Add("69912645");
            cepsguarda.Add("76870690");
            cepsguarda.Add("17053520");
            cepsguarda.Add("72425143");
            cepsguarda.Add("57038050");
            cepsguarda.Add("12947260");
            cepsguarda.Add("75802315");
            cepsguarda.Add("18705850");
            cepsguarda.Add("77064110");
            cepsguarda.Add("65919290");
            cepsguarda.Add("76962303");
            cepsguarda.Add("35700279");
            cepsguarda.Add("29900850");
            cepsguarda.Add("60020295");
            cepsguarda.Add("64207670");
            cepsguarda.Add("69036666");
            cepsguarda.Add("68901341");
            cepsguarda.Add("29104451");
            cepsguarda.Add("17210563");
            cepsguarda.Add("78148594");
            cepsguarda.Add("57039640");
            cepsguarda.Add("77805020");
            cepsguarda.Add("91440026");
            cepsguarda.Add("29015320");
            cepsguarda.Add("65061237");
            cepsguarda.Add("75145115");
            cepsguarda.Add("78043394");
            cepsguarda.Add("65055622");
            cepsguarda.Add("13481233");
            cepsguarda.Add("70631902");
            cepsguarda.Add("69093096");
            cepsguarda.Add("74925390");
            cepsguarda.Add("78050518");
            cepsguarda.Add("64083220");
            cepsguarda.Add("72806190");
            cepsguarda.Add("57086139");
            cepsguarda.Add("57602335");
            cepsguarda.Add("57081012");
            cepsguarda.Add("76814170");
            cepsguarda.Add("49015400");
            cepsguarda.Add("73365160"); 
            cepsguarda.Add("49042240");
            #endregion

            
            
       

            while (true)
            {
                Console.WriteLine("Seja bem vindo, quantos registros você deseja por pagina?");
                int registro = int.Parse(Console.ReadLine());

                Console.WriteLine("Qual pagina "); 



                #region "Json?"
                foreach (var ceps in cepsguarda)
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
                            //  Console.WriteLine(objResponse.ToString());
                            var local = JsonConvert.DeserializeObject<Local>(objResponse.ToString());

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
