//PROJECT NAME: Codes
//CLASS NAME: ICheckAndAddUserLocal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
    public interface ICheckAndAddUserLocal
    {
        int? CheckAndAddUserLocalSp();
    }
}

