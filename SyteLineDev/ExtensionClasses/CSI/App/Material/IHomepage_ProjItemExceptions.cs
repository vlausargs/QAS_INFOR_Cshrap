//PROJECT NAME: Material
//CLASS NAME: IHomepage_ProjItemExceptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IHomepage_ProjItemExceptions
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_ProjItemExceptionsSp(string ProjMgr);
    }
}

