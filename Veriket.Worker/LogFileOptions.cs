using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veriket.Worker
{
    public class LogFileOptions
    {
        public string FileName { get; set; }
        public string DirectoryName { get; set; }
        public int LogPeriod { get; set; }
    }
}
