//PROJECT NAME: MG.MGCore
//CLASS NAME: ICopyUetColumns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICopyUetColumns
    {
        (int? ReturnCode, string Infobar) CopyUetColumnsSp(string TableName,
        Guid? FromRowPointer,
        Guid? ToRowPointer,
        string Infobar);
    }
}

