//PROJECT NAME: Data
//CLASS NAME: ICfgGetConfigValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
    public interface ICfgGetConfigValues
    {
        ICollectionLoadResponse CfgGetConfigValuesFn(
            string pConfigId,
            string pPrintFlag);
    }
}

