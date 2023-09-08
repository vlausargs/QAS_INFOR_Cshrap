//PROJECT NAME: Material
//CLASS NAME: IItemwhseGetDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IItemwhseGetDetails
    {
        (int? ReturnCode,
        decimal? QtyOnHand,
        decimal? QtyReorder,
        int? CntInProc,
        int? CycleFlag,
        string Loc,
        string Infobar) ItemwhseGetDetailsSp(
            string Item,
            string Whse,
            decimal? QtyOnHand,
            decimal? QtyReorder,
            int? CntInProc,
            int? CycleFlag,
            string Loc,
            string Infobar);
    }
}

