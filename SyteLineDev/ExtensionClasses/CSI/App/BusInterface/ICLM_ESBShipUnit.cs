//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
    public interface ICLM_ESBShipUnit
    {
        (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipUnitSp(int? ShipmentID, string ShipmentStatus = null);
    }
}
