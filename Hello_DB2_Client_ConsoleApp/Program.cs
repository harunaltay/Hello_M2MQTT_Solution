using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hello_DB2_Server_ClassLib;
using Hello_DB2_Server_ClassLib.Model;

namespace Hello_DB2_Client_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello DB2 Client!");
            Console.WriteLine(Class1.Message);

            Insert();
            ReadAll();
        }

        private static void Insert()
        {
            using (var context = new TerminalDB2Entities())
            {
                Terminal terminal = new Terminal
                {
                    message = "OFF",
                    datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    //datetime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff"),
                    //datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"),
                    topic = "/terminal-insert"
                };
                context.Terminal.Add(terminal);
                context.SaveChanges();
            }
        }

        private static void ReadAll()
        {
            using (var context = new TerminalDB2Entities())
            {
                var query = from s in context.Terminal
                            orderby s.Id
                            select s;
                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.message, item.datetime, item.topic);
                }
            }
        }
    }
}
