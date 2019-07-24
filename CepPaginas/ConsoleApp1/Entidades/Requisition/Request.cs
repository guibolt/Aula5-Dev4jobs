using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades.Requisition
{
    class Request
    {
       static HttpClient cliente = new HttpClient();
        public static async Task<string> GetUser(string cep, List<Local> locais)
        {
            try
            {
                HttpResponseMessage response = await cliente.GetAsync($"http://viacep.com.br/ws/{cep}/json");
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadAsStringAsync();
                return resultado;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static void PulaLinha()
        {
            Console.WriteLine("");
        }

        public static void LotarLista(List<string> lst)
        {
            lst.Add("05102000");
            lst.Add("41390200");
            lst.Add("36021240");
            lst.Add("78140205");
            lst.Add("57080100");
            lst.Add("58410387");
            lst.Add("77433200");
            lst.Add("58087040");
            lst.Add("88816262");
            lst.Add("69912645");
            lst.Add("76870690");
            lst.Add("17053520");
            lst.Add("72425143");
            lst.Add("57038050");
            lst.Add("12947260");
            lst.Add("75802315");
            lst.Add("18705850");
            lst.Add("77064110");
            lst.Add("65919290");
            lst.Add("76962303");
            lst.Add("35700279");
            lst.Add("29900850");
            lst.Add("60020295");
            lst.Add("64207670");
            lst.Add("69036666");
            lst.Add("68901341");
            lst.Add("29104451");
            lst.Add("17210563");
            lst.Add("78148594");
            lst.Add("57039640");
            lst.Add("77805020");
            lst.Add("91440026");
            lst.Add("29015320");
            lst.Add("65061237");
            lst.Add("75145115");
            lst.Add("78043394");
            lst.Add("65055622");
            lst.Add("13481233");
            lst.Add("70631902");
            lst.Add("69093096");
            lst.Add("74925390");
            lst.Add("78050518");
            lst.Add("64083220");
            lst.Add("72806190");
            lst.Add("57086139");
            lst.Add("57608010");
            lst.Add("57081012");
            lst.Add("76814170");
            lst.Add("49015400");
            lst.Add("73365160");
            
        }
    }
}
