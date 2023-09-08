using CSI.Admin;
using CSI.Data;
using CSI.Data.Functions;
using CSI.Logistics.Vendor;
using CSI.Serializer;
using System;

namespace CSI.Logistics.Customer
{
    public class UpdateShipmentWithTMInfo : IUpdateShipmentWithTMInfo
    {
        IIsAddonAvailable isAddonAvailable;
        IIsFeatureActive isFeatureActive;
        IConvertToUtil convertToUtil;
        ISQLValueComparerUtil sQLUtil;
        IShipmentTMResponseDeserializer shipmentTMResponseDeserializer;
        IUpdateShipmentDetailsWithTMInfo updateShipmentDetailsWithTMInfo;
        IUpdateShipUnitDetailsWithTMInfo updateShipUnitDetailsWithTMInfo;
        string productNameCSI = "CSI";

        public UpdateShipmentWithTMInfo(IIsAddonAvailable isAddonAvailable,
                                        IIsFeatureActive isFeatureActive,
                                        IConvertToUtil convertToUtil,
                                        ISQLValueComparerUtil sQLUtil,
                                        IShipmentTMResponseDeserializer shipmentTMResponseDeserializer,
                                        IUpdateShipmentDetailsWithTMInfo updateShipmentDetailsWithTMInfo,
                                        IUpdateShipUnitDetailsWithTMInfo updateShipUnitDetailsWithTMInfo)
        {
            this.isAddonAvailable = isAddonAvailable;
            this.isFeatureActive = isFeatureActive;
            this.convertToUtil = convertToUtil;
            this.sQLUtil = sQLUtil;
            this.shipmentTMResponseDeserializer = shipmentTMResponseDeserializer;
            this.updateShipmentDetailsWithTMInfo = updateShipmentDetailsWithTMInfo;
            this.updateShipUnitDetailsWithTMInfo = updateShipUnitDetailsWithTMInfo;
        }

        public (int? returnCode, string infobar) Process(string tMShipmentInfo)
        {
            int? returnCode = 0;
            string infobar = "";
            int? transportationManagementOn = null;

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
                    var shipmentTMResponse = shipmentTMResponseDeserializer.Deserialize(tMShipmentInfo);
                    if (shipmentTMResponse.ReturnCode != 0)
                    {
                        return (shipmentTMResponse.ReturnCode, shipmentTMResponse.InfoBar);
                    }

                    (returnCode, infobar) = updateShipmentDetailsWithTMInfo.Process(shipmentTMResponse.ShipmentTMResponseHeader);
                    if (returnCode != 0)
                    {
                        return (returnCode, infobar);
                    }

                    (returnCode, infobar) = updateShipUnitDetailsWithTMInfo.Process(shipmentTMResponse.ShipmentTMResponseHeader);
                }

            }
            #endregion RS9222_4

            return (returnCode, infobar);

        }

    }
}
