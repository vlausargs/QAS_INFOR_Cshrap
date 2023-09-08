//PROJECT NAME: Data
//CLASS NAME: IHighString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IHighString
    {
        string HighStringFn(
            string DataType);
    }
}

