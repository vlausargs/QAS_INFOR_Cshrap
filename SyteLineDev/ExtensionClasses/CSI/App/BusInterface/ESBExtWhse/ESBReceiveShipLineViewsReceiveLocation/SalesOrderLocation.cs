using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ISalesOrderLocation
    {
        void UpdateSalesOrderLocation(Guid sessionID, string itemNonNetLoc);
    }

    public class SalesOrderLocation : ISalesOrderLocation
    {

        readonly ISalesOrderLocationCRUD iSalesOrderLocationCRUD;

        public SalesOrderLocation(
            ISalesOrderLocationCRUD iSalesOrderLocationCRUD)
        {
            this.iSalesOrderLocationCRUD = iSalesOrderLocationCRUD;
        }

        public void UpdateSalesOrderLocation(Guid sessionID, string itemNonNetLoc)
        {
            var tmp_shipLocResponse = iSalesOrderLocationCRUD.LoadLocationTmp_ship(sessionID);
            iSalesOrderLocationCRUD.UpdateLocationTmp_ship(itemNonNetLoc, tmp_shipLocResponse);
        }
    }
}
