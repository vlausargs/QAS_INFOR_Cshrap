//PROJECT NAME: MG.MGCore
//CLASS NAME: ITransferNotesToSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ITransferNotesToSite
    {
        (int? ReturnCode, string Infobar) TransferNotesToSiteSp(string ToSite,
        string TableName,
        Guid? RowPointer,
        string ToWhereClause,
        Guid? ToRowPointer,
        int? DeleteFirst,
        string Infobar);
    }
}

