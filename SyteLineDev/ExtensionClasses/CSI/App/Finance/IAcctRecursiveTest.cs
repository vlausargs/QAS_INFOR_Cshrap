//PROJECT NAME: Finance
//CLASS NAME: IAcctRecursiveTest.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface IAcctRecursiveTest
    {
        int? AcctRecursiveTestSp(string PAcct,
        string PDAcct,
        int? NESTLEVEL = 0);
    }
}

