//PROJECT NAME: Material
//CLASS NAME: IMtCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IMtCodes
    {
        (int? ReturnCode,
            string Infobar) MtCodesSp(
            int? CalculateTotalCost = 1,
            int? HyperspeedMode = 0,
            string Infobar = null);
    }
}

