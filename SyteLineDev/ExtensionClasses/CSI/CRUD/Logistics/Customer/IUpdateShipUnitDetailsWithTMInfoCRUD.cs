using CSI.Data.CRUD;

namespace CSI.Logistics.Customer
{
    public interface IUpdateShipUnitDetailsWithTMInfoCRUD
    {
        (int Count, string Infobar) InsertCarrierShip(decimal? shipmentID, int? packageID, string trackingNumber, string proNumber, string truckloadNum, string siteShipmentId);
        (int Count, string Infobar) UpdateShipmentExternalInfo(decimal? shipmentID, string externalBolNum, string pRONumber, string trackingNumber);
        (int Count, string Infobar) DeleteCarrierShip(decimal? shipmentID);
    }
}