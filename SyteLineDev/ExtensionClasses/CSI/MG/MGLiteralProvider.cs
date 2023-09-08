using CSI.Data.SQL;
using Mongoose.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGLiteralProvider : ILiteralProvider
    {
        public string FormatLiteral(object value)
        {
            return SqlLiteral.Format(value);
        }
    }
}
