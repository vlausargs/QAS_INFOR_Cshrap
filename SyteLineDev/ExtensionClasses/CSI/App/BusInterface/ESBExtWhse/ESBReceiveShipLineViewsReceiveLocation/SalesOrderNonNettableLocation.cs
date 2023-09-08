using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ISalesOrderNonNettableLocation
    {
        void CheckAndUpdateSOLoc(Guid sessionID, string itemNonNetLoc);
    }

    public class SalesOrderNonNettableLocation : ISalesOrderNonNettableLocation
    {

        readonly ISalesOrderLocation iSalesOrderLocation;
        readonly ISalesOrderLocationCRUD iSalesOrderLocationCRUD;

        public SalesOrderNonNettableLocation(
            ISalesOrderLocation iSalesOrderLocation,
            ISalesOrderLocationCRUD iSalesOrderLocationCRUD)
        {
            this.iSalesOrderLocation = iSalesOrderLocation;
            this.iSalesOrderLocationCRUD = iSalesOrderLocationCRUD;
        }

        public void CheckAndUpdateSOLoc(Guid sessionID, string itemNonNetLoc)
        {
            string loc = iSalesOrderLocationCRUD.LoadTopOneLocationTmp_ship(sessionID);
            if (loc != itemNonNetLoc)
                iSalesOrderLocation.UpdateSalesOrderLocation(sessionID, itemNonNetLoc);
        }
    }
}
