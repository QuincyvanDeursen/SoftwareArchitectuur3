using SoaApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoaApp.Core.ExportHandler
{
    public interface IExport
    {
        public void PrintReceipt(Order order);
    }
}
