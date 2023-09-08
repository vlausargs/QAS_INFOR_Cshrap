//PROJECT NAME: Reporting
//CLASS NAME: IGetItemContent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IGetItemContent
    {
        (ICollectionLoadResponse Data, int? ReturnCode) GetItemContentSp(string Item = null,
        string RefType = null,
        string RefNum = null,
        int? RefLine = 0,
        int? RefRelease = 0,
        string InvNum = null,
        int? InvLine = null,
        int? InvSeq = null,
        DateTime? TransDate = null);
    }
}

