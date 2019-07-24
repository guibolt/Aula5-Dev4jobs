﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using ConsoleApp1.Entidades.Requisition;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> lst = new List<string>();
            List<Local> Ceps = new List<Local>();
            Request.LotarLista(lst);

            Console.WriteLine("Carregando...");
            int contador = 0;
            string cont;
            #region "Json"
            foreach (var ceps in lst)
            {
                try
                {
                    var local = JsonConvert.DeserializeObject<Local>(await Request.GetUser(ceps, Ceps));
                    Ceps.Add(local);
                    contador++;
                    Ceps = Ceps.OrderBy(x => x.Uf).ThenBy(x => x.dataPesquisa).ToList();
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
             
            }
            Console.WriteLine($"Foram registrados {contador} Ceps, aperte enter para começar");
            Console.ReadLine();
            Console.Clear();
             #endregion
        
             
            // definir as paginas 
            Console.WriteLine("Seja bem vindo, quantos registros você deseja por pagina?");
            Request.PulaLinha();
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
                        Request.PulaLinha();
                        Console.WriteLine($"Digite {i} para pagina {i}");
                        Request.PulaLinha();
                    }

                    Int32.TryParse(Console.ReadLine(), out int  decisao);

                    if (decisao <= 0 || decisao > paginas)
                    {
                        Console.WriteLine("Essa pagina nao existe");
                        Request.PulaLinha();
                    }
                    else
                    {
                        var result = Ceps.Skip((decisao - 1) * registro).Take(registro);

                        foreach (var item in result)
                        {
                            Console.WriteLine($"CEP: {item.Cep} Logradouro: {item.Logradouro} Bairro {item.Bairro} UF: {item.Uf} ");
                            Request.PulaLinha();
                        }
                    }
                    Console.WriteLine("Deseja consultar outra pagina ? s para sim e n para nao");
                    Request.PulaLinha();
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
