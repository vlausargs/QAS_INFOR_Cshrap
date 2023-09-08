//PROJECT NAME: Production
//CLASS NAME: IIsApsSiteRecordExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface IIsApsSiteRecordExist
    {
            (int? ReturnCode,
            int? IsExist,
        string Infobar) IsApsSiteRecordExistSp(
            int? IsExist,
            string Infobar);
    }
}

