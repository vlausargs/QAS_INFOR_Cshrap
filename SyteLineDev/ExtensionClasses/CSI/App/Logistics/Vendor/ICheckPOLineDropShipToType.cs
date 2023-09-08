//PROJECT NAME: Logistics
//CLASS NAME: ICheckPOLineDropShipToType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface ICheckPOLineDropShipToType
    {
            (int? ReturnCode,
            int? ReturnFlag,
            string Infobar) 
        CheckPOLineDropShipToTypeSp(
            string PoNum,
            int? ReturnFlag,
            string Infobar);
    }
}
