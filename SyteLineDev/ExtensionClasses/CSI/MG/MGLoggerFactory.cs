using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public sealed class MGLoggerFactory
    {
        private static readonly ILogger Logger = (new CSI.Logger.LoggerFactory()).Create();
        public ILogger Create() { return MGLoggerFactory.Logger; }
    }
}
