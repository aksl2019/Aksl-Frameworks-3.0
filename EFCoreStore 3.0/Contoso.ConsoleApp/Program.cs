using System;
using System.Threading.Tasks;

namespace Contoso.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await WebApiSender.Instance.InitializeTask();

            #region TableSplitting
            // await WebApiSender.Instance.InsertOrdersAsync();

            // await WebApiSender.Instance.GetPagedOrdersAsync();
            #endregion

            #region Owned
             await WebApiSender.Instance.InsertSaleOrderLoopTasksAsync(taskCount:10, count: 5, orderCount: 2);

            //await WebApiSender.Instance.GetPagedSaleOrdersAsync();
            #endregion

            //  Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
