using CSI.Admin;
using CSI.Data;
using CSI.Data.Functions;
using CSI.Logistics.Vendor;
using System;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public class UpdateShipUnitDetailsWithTMInfo : IUpdateShipUnitDetailsWithTMInfo
    {
        IIsAddonAvailable isAddonAvailable;
        IIsFeatureActive isFeatureActive;
        IUpdateShipUnitDetailsWithTMInfoCRUD updateShipUnitDetailsWithTMInfoCRUD;
        IConvertToUtil convertToUtil;
        ISQLValueComparerUtil sQLUtil;
        IShipmentOrderIdGenerator shipmentOrderIdGenerator;
        string productNameCSI = "CSI";

        public UpdateShipUnitDetailsWithTMInfo(IIsAddonAvailable isAddonAvailable
            , IIsFeatureActive isFeatureActive
            , IUpdateShipUnitDetailsWithTMInfoCRUD updateShipUnitDetailsWithTMInfoCRUD
        , IConvertToUtil convertToUtil
        , ISQLValueComparerUtil sQLUtil
        , IShipmentOrderIdGenerator eSBShipmentIdGenerator)
        {
            this.isAddonAvailable = isAddonAvailable;
            this.isFeatureActive = isFeatureActive;
            this.updateShipUnitDetailsWithTMInfoCRUD = updateShipUnitDetailsWithTMInfoCRUD;
            this.convertToUtil = convertToUtil;
            this.sQLUtil = sQLUtil;
            this.shipmentOrderIdGenerator = eSBShipmentIdGenerator;
        }

        public (int? returnCode, string infobar) Process(IShipmentTMResponseHeader shipmentTMResponseHeader)
        {


            string documentID= shipmentTMResponseHeader.OrderCode;
            int? packageID = 0;
            string trackingNumber = "";
            string proNumber = "";
            string truckloadNum = "";
            string externalBolNum = "";
            string firstTrackingNumber=null;
            string firstProNumber = null;
            string firstExternalBolNum = null;
            string siteShipmentId = ""; 

            int? returnCode = 0;
            int? shipUnitTrackingsCount = null;
            string infobar = "";
            int? transportationManagementOn = null;
            decimal? shipmentID = null;
      

            #region RS9222_4
            string featureIDRS9222_4 = "RS9222_4";
            int? featureRS9222_4Active = null;

            var objTMSCountryPack = isAddonAvailable.IsAddonAvailableFn("TransportationManagement");
            var objIsRS9222_4FeatureActive = isFeatureActive.IsFeatureActiveSp(
                 ProductName: productNameCSI
                , FeatureID: featureIDRS9222_4
                , FeatureActive: featureRS9222_4Active
                , InfoBar: infobar);
            returnCode = objIsRS9222_4FeatureActive.ReturnCode;
            featureRS9222_4Active = objIsRS9222_4FeatureActive.FeatureActive;
            infobar = objIsRS9222_4FeatureActive.InfoBar;

            if (returnCode.Equals(0))
            {
                transportationManagementOn = convertToUtil.ToInt32((sQLUtil.SQLEqual(featureRS9222_4Active, 1) == true &&
                    sQLUtil.SQLEqual(objTMSCountryPack, 1) == true ? 1 : 0));

                if (sQLUtil.SQLEqual(transportationManagementOn, 1) == true)
                {

                    shipmentID = shipmentOrderIdGenerator.GenerateShipmentID<decimal>(documentID, "~");
                    siteShipmentId = this.GetSiteShipmentId(
                            shipmentTMResponseHeader.OrganizationCode,
                            shipmentID);

                    var deleteCarrierShip = updateShipUnitDetailsWithTMInfoCRUD.DeleteCarrierShip(shipmentID);

                    if (string.IsNullOrEmpty(infobar) == true)
                    {
                        foreach (var shipUnit in shipmentTMResponseHeader.Plans[0].ShipUnits)
                        {
                            packageID = shipUnit.ShipUnitSequence;

                            (trackingNumber, proNumber, externalBolNum, truckloadNum, shipUnitTrackingsCount) = this.ExtractShipmentTrackingInfo(shipUnit.Trackings);
                            if (shipUnitTrackingsCount != 0 || shipUnitTrackingsCount != null)
                            {

                                if (string.IsNullOrEmpty(infobar) == true)
                                {

                                    if (string.IsNullOrEmpty(trackingNumber))
                                    {
                                        trackingNumber = proNumber;
                                        if (string.IsNullOrEmpty(trackingNumber))
                                        {
                                            trackingNumber = truckloadNum;
                                        }
                                    }
                                    if (packageID == 1)
                                    {
                                        firstTrackingNumber = trackingNumber;
                                        firstProNumber = proNumber;
                                        firstExternalBolNum = externalBolNum;
                                    }

                                    if (!string.IsNullOrEmpty(trackingNumber))
                                    {
                                        var objUpdCarrierShipDatabaseValue = updateShipUnitDetailsWithTMInfoCRUD.InsertCarrierShip(
                                        shipmentID: shipmentID,
                                        packageID: packageID,
                                        trackingNumber: trackingNumber,
                                        proNumber: proNumber,
                                        truckloadNum: truckloadNum,
                                        siteShipmentId: siteShipmentId);
                                        infobar = objUpdCarrierShipDatabaseValue.Infobar;
                                    }
                                }
                            }
                        }
                    }


                    #region CollectionUpdateRequest Shipment
                    if (string.IsNullOrEmpty(infobar) == true)
                    {
                        var objUpdShipmentDatabaseValue = updateShipUnitDetailsWithTMInfoCRUD.UpdateShipmentExternalInfo(
                            shipmentID: shipmentID,
                            externalBolNum: firstExternalBolNum,
                            pRONumber: firstProNumber,
                            trackingNumber: firstTrackingNumber);

                        infobar = objUpdShipmentDatabaseValue.Infobar;
                    }
                    #endregion
                }
            }

            return (returnCode, infobar);
            #endregion RS9222_4
        }

        private (string TrackingNumber, 
            string PRONumber, 
            string ExternalBOLNum,
            string TruckLoadNum,
            int? ShipUnitTrackingsCount) 
            ExtractShipmentTrackingInfo(IList<IShipmentTMResponseTracking> shipUnitTrackings)
        {
            string TrackingNumber =null;
            string PRONumber = null;
            string ExternalBOLNum = null;
            string TruckLoadNum = null;
            int shipUnitTrackingsCount = 0;
            if (shipUnitTrackings != null)
            {
                shipUnitTrackingsCount = shipUnitTrackings.Count;
                foreach (var shipUnitTracking in shipUnitTrackings)
                {
                    if (shipUnitTracking.TrackingType != null)
                    {
                        if (shipUnitTracking.TrackingType.ToUpper() == "PRO")
                        {
                            PRONumber = shipUnitTracking.TrackingNumber;
                        }
                        else if (shipUnitTracking.TrackingType.ToUpper() == "LOAD")
                        {
                            TruckLoadNum = shipUnitTracking.TrackingNumber;
                        }
                        else if (shipUnitTracking.TrackingType.ToUpper() == "BOL")
                        {
                            ExternalBOLNum = shipUnitTracking.TrackingNumber;
                        }
                        else if (shipUnitTracking.TrackingType.ToUpper() == "TRACKING NUMBER")
                        {
                            TrackingNumber = shipUnitTracking.TrackingNumber;
                        }
                    }

                }
            }

            return (TrackingNumber, PRONumber,  ExternalBOLNum,TruckLoadNum, shipUnitTrackingsCount);
        }

        private string GetSiteShipmentId(string site, decimal? shipmentId)
        {
            string SiteShipmentId = "";

            SiteShipmentId = string.Format("{0},{1}",site, shipmentId);

            return SiteShipmentId;
        }
    }
}
