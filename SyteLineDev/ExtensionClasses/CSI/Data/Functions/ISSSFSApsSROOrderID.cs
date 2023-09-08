//PROJECT NAME: Data
//CLASS NAME: ISSSFSApsSROOrderID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface ISSSFSApsSROOrderID
    {
        string SSSFSApsSROOrderIDFn(
            string PSroNum,
            int? PSroLine,
            int? PSroOper,
            int? PTransNum);
    }
}

