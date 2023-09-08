//PROJECT NAME: MGCore
//CLASS NAME: IGetSiteDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetSiteDate
    {
        DateTime? GetSiteDateFn(DateTime? Date);
    }
}

