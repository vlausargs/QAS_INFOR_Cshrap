//PROJECT NAME: Data
//CLASS NAME: IHighDecimal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IHighDecimal
    {
        decimal? HighDecimalFn(
            string DataType);
    }
}

