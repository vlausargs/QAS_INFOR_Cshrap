//PROJECT NAME: Finance
//CLASS NAME: ICHSCheckAccountCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
    public interface ICHSCheckAccountCode
    {
        (int? ReturnCode,
        string InfoBar) CHSCheckAccountCodeSp(
            string Acct,
            string InfoBar);
    }
}

