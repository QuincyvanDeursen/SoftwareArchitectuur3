using Newtonsoft.Json;
using SoaApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoaApp.Core.ExportHandler
{
    public class JSONExport : IExport
    {
        public void PrintReceipt(Order order)
        {
            Console.WriteLine(order.ToString());
            var jsonObject = JsonConvert.SerializeObject(order);
            string fileName = "Order.json";
            File.WriteAllText("C:/Users/Gebruiker/Downloads/" + fileName, jsonObject);
        }
    }
}
