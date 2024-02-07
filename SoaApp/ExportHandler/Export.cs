using SoaApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoaApp.Core.ExportHandler
{
    public class Export
    {
        private IExport exportMethod;

        public void ExportToFile(Order order)
        {
            exportMethod.PrintReceipt(order);
        }

        public void SetExport(IExport exportMethod)
        {
            this.exportMethod = exportMethod;
        }
    }
}
