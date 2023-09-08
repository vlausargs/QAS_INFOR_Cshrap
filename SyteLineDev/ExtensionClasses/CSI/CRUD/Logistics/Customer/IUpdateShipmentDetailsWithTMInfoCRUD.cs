using System;

namespace CSI.Logistics.Customer
{
    public interface IUpdateShipmentDetailsWithTMInfoCRUD
    {
        bool ShipmentExists(decimal? shipmentId);
        bool ShipmentIsRated(decimal? shipmentId);

        (string ShipmentCurrCode, DateTime? ShipmentDate, string CORefNum, decimal? CarrierUpchargePercent, int? CustSeq) GetShipmentCustAddrDetailMethod(decimal? shipmentID);
        (int Count, string Infobar) UpdateCoExternalShipmentFreight(string coRefNum, decimal? externalFreightChargeAmount);
        (int Count, string Infobar) UpdateExternalShipmentFreight(decimal? shipmentID, decimal? externalFreightChargeAmount, char externalCarrierShipmentStatus, string externalShipmentMessage);
        (int Count, string Infobar) UpdateExternalCarrierShipmentStatus(decimal? shipmentID, char externalCarrierShipmentStatus, string externalShipmentMessage);

    }
}