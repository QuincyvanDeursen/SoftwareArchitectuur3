using Newtonsoft.Json;
using SoaApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoaApp.Core.ExportHandler
{
    public class PlainTextExport : IExport
    {
        public void PrintReceipt(Order order)
        {
          StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach(var ticket in order.GetMovieTickets())
            {
                i++;
                sb.Append("ticket: " + i + " " + ticket.ToString());
                sb.Append("\n");
            }
            string fileName = "Order.txt";
            File.WriteAllText("C:/Users/Gebruiker/Downloads/" + fileName, sb.ToString());
        }
    }
}
