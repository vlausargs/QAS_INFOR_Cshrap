//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipUnitItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
    public interface ICLM_ESBShipUnitItem
    {
        (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipUnitItemSp(int? ShipmentID, int? PackageID);
    }
}