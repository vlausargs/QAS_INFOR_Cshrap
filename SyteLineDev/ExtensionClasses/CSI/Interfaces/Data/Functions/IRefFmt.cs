using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Functions
{
    public interface IRefFmt
    {
        string RefFmtSp(string RefType,
        string RefNum,
        int? RefLine,
        int? RefRel);
    }
}
