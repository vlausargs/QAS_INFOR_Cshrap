//PROJECT NAME: Production
//CLASS NAME: IPmfDataInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
    public interface IPmfDataInit
    {
        (int? ReturnCode, string Infobar) PmfDataInitSp(string Infobar = null);
    }
}

