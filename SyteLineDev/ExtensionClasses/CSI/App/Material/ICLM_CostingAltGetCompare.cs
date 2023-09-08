//PROJECT NAME: Material
//CLASS NAME: ICLM_CostingAltGetCompare.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface ICLM_CostingAltGetCompare
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_CostingAltGetCompareSp(
            string CostingAlt,
            string CostType = null,
            string Whse = null,
            string CostingAlt2Compare = null,
            string ItemCompare = null,
            string FilterString = null,
            string Infobar = null);
    }
}

