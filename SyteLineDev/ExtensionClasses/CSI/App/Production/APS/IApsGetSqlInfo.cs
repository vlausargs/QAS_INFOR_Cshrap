//PROJECT NAME: Production
//CLASS NAME: IApsGetSqlInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface IApsGetSqlInfo
    {
            (int? ReturnCode,
            string SqlUser,
            string SqlPassword,
            int? SqlAlwaysOn) 
        ApsGetSqlInfoSp(
            string SqlUser,
            string SqlPassword,
            int? SqlAlwaysOn);
    }
}

