//PROJECT NAME: Data
//CLASS NAME: ISqlFilter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ISqlFilter
    {
        string SqlFilterFn(
            string Filter,
            string PropertyList,
            string ColumnList,
            string Delim);
    }
}

