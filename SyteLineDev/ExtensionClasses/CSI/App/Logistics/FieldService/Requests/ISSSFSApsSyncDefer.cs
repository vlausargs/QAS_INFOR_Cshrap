//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSApsSyncDefer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSApsSyncDefer
    {
        (int? ReturnCode, string Infobar) SSSFSApsSyncDeferSp(string Infobar);
    }
}

