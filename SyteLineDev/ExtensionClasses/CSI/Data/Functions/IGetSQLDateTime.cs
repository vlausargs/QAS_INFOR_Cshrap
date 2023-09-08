//PROJECT NAME: Data
//CLASS NAME: IGetSQLDateTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IGetSQLDateTime
    {
        (int? ReturnCode, DateTime? DateTime) GetSQLDateTimeSp(DateTime? DateTime);
    }
}
