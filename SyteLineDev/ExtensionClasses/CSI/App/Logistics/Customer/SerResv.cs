using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface ISerResv
    {
        int SerResvSp(RsvdNumType resvNum, QtyUnitType qty, Flag add, ref Infobar infobar, RowPointerType curSumId, ItemType item, ListYesNoType clearUnusedSerials = null /* 0 */);
    }
}
