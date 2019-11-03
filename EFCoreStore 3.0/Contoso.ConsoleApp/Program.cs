using System;
using System.Threading.Tasks;

namespace Contoso.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebApiSender.Instance.InitializeTask();

            #region Dataflow Retry
      
            #endregion

            //  Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
