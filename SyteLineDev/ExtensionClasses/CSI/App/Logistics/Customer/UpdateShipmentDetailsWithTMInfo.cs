using CSI.Admin;
using CSI.Data;
using CSI.Data.Functions;
using CSI.Logistics.Vendor;
using System;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public class UpdateShipmentDetailsWithTMInfo : IUpdateShipmentDetailsWithTMInfo
    {
        IIsAddonAvailable isAddonAvailable;
        IIsFeatureActive isFeatureActive;
        ICalcFreightAmounts calcFreightAmounts;
        IUpdateShipmentDetailsWithTMInfoCRUD updateShipmentDetailsWithTMInfoCRUD;
        IConvertToUtil convertToUtil;
        ISQLValueComparerUtil sQLUtil;
        IShipmentOrderIdGenerator shipmentOrderIdGenerator;
        IMsgApp msgApp;
        string productNameCSI = "CSI";


        public UpdateShipmentDetailsWithTMInfo(IIsAddonAvailable isAddonAvailable
            , IIsFeatureActive isFeatureActive
            , ICalcFreightAmounts calcFreightAmounts
            , IUpdateShipmentDetailsWithTMInfoCRUD load_ESBProcessShipmentCRUD
            , IConvertToUtil convertToUtil
            , ISQLValueComparerUtil sQLUtil
            , IShipmentOrderIdGenerator eSBShipmentIdGenerator
            , IMsgApp msgApp)
        {
            this.isAddonAvailable = isAddonAvailable;
            this.isFeatureActive = isFeatureActive;
            this.calcFreightAmounts = calcFreightAmounts;
            this.updateShipmentDetailsWithTMInfoCRUD = load_ESBProcessShipmentCRUD;
            this.convertToUtil = convertToUtil;
            this.sQLUtil = sQLUtil;
            this.shipmentOrderIdGenerator = eSBShipmentIdGenerator;
            this.msgApp = msgApp;
        }

        public (int? returnCode, string infobar) Process(IShipmentTMResponseHeader shipmentTMResponseHeader)
        {

            string externalCarrierShipmentStatus = shipmentTMResponseHeader.Status;

            decimal? externalFreightChargeAmount = null;
            string externalFreightChargeCurrCode = null;

            string documentID = shipmentTMResponseHeader.OrderCode;

            int? returnCode = 0;
            string infobar = "";
            int? transportationManagementOn = null;
            string shipmentCurrCode = null;
            DateTime? shipmentDate = null;
            string cORefNum = null;
            int custSeq = 0;
            decimal? shipmentID = null;
            decimal externalFreightChargeAmountConv = 0;
            decimal carrierUpchargePercent = 0;
            decimal exchangeRate = 0;
            string externalShipmentMessage = "";
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
                    if (!updateShipmentDetailsWithTMInfoCRUD.ShipmentExists(shipmentID))
                    {
                        (returnCode, infobar) = msgApp.MsgAppSp(infobar, "I=NoExist0", "@shipment");
                        return (returnCode, infobar);
                    }
                    var getShipCustAddrDetail = updateShipmentDetailsWithTMInfoCRUD.GetShipmentCustAddrDetailMethod(
                        shipmentID: shipmentID);
                    shipmentCurrCode = getShipCustAddrDetail.ShipmentCurrCode;
                    shipmentDate = getShipCustAddrDetail.ShipmentDate;
                    cORefNum = getShipCustAddrDetail.CORefNum;
                    custSeq = getShipCustAddrDetail.CustSeq ?? 0;
                    carrierUpchargePercent = getShipCustAddrDetail.CarrierUpchargePercent ?? 0;

                    #region CollectionUpdateRequest Shipment
                    externalCarrierShipmentStatus = (externalCarrierShipmentStatus.ToUpper() == "UNKNOWN") ? "U" :
                    (externalCarrierShipmentStatus.ToUpper() == "RATED") ? "R" :
                    (externalCarrierShipmentStatus.ToUpper() == "BOOKED") ? "B" :
                    (externalCarrierShipmentStatus.ToUpper() == "INTRANSIT") ? "N" :
                    (externalCarrierShipmentStatus.ToUpper() == "DELIVERED") ? "D" :
                    (externalCarrierShipmentStatus.ToUpper() == "TENDERED") ? "T" :
                    (externalCarrierShipmentStatus.ToUpper() == "TENDEREXPIRED") ? "E" :
                    (externalCarrierShipmentStatus.ToUpper() == "TENDERREJECTED") ? "J" :
                    (externalCarrierShipmentStatus.ToUpper() == "CANCELED") ? "C" : externalCarrierShipmentStatus;
                    externalShipmentMessage = this.ConcatProcessErrorMessages(shipmentTMResponseHeader.ProcessErrors);

                    if (externalCarrierShipmentStatus.ToUpper() == "B" && updateShipmentDetailsWithTMInfoCRUD.ShipmentIsRated(shipmentID))
                    {
                        externalFreightChargeAmount = shipmentTMResponseHeader.Plans[0].SelectedRateResponse.TotalAmount;
                        externalFreightChargeCurrCode = shipmentTMResponseHeader.Plans[0].SelectedRateResponse.Currency;

                        var freightAmounts = calcFreightAmounts.CalcTotalFreightAmount(cORefNum,
                                                                                       custSeq,
                                                                                       shipmentDate,
                                                                                       carrierUpchargePercent,
                                                                                       externalFreightChargeAmount,
                                                                                       externalFreightChargeCurrCode,
                                                                                       shipmentCurrCode,
                                                                                       ref externalFreightChargeAmountConv,
                                                                                       ref exchangeRate);


                        var UpdateCoDatabaseValue = updateShipmentDetailsWithTMInfoCRUD.UpdateCoExternalShipmentFreight(
                        coRefNum: cORefNum,
                        externalFreightChargeAmount: externalFreightChargeAmountConv);
                        infobar = UpdateCoDatabaseValue.Infobar;
                        if (!string.IsNullOrEmpty(infobar))
                        {
                            returnCode = 16;
                            return (returnCode, infobar);
                        }

                        var updateExternalShipmentFreight = updateShipmentDetailsWithTMInfoCRUD.UpdateExternalShipmentFreight(
                        shipmentID: shipmentID,
                        externalFreightChargeAmount: externalFreightChargeAmountConv,
                        externalCarrierShipmentStatus: char.Parse(externalCarrierShipmentStatus),
                        externalShipmentMessage: externalShipmentMessage);
                        infobar = updateExternalShipmentFreight.Infobar;

                        if (!string.IsNullOrEmpty(infobar))
                        {
                            returnCode = 16;
                            return (returnCode,infobar);
                        }
                    }
                    else
                    {
                        var objUpdShipmentDatabaseValue = updateShipmentDetailsWithTMInfoCRUD.UpdateExternalCarrierShipmentStatus(
                        shipmentID: shipmentID,
                        externalCarrierShipmentStatus: char.Parse(externalCarrierShipmentStatus),
                        externalShipmentMessage: externalShipmentMessage);
                        infobar = objUpdShipmentDatabaseValue.Infobar;
                        if (!string.IsNullOrEmpty(infobar))
                        {
                            returnCode = 16;
                            return (returnCode, infobar);
                        }
                    }
                    #endregion
                }

            }

            return (returnCode, infobar);
            #endregion RS9222_4
        }


        private string ConcatProcessErrorMessages(IList<IShipmentTMResponseProcessError> ProcessErrors)
        {
            string processErrorMessages = null;
            int processErrorCount = 0;
            string newLine = "";
            foreach (var processError in ProcessErrors)
            {
                processErrorCount++;
                if (processErrorCount > 1)
                { newLine = Environment.NewLine; }
                processErrorMessages += string.Format("{0}{1}-{2}", newLine, processError.ErrorCode, processError.ErrorMessage);

            }
            if (!string.IsNullOrEmpty(processErrorMessages))
            {
                if (processErrorMessages.Length > 4000)
                {
                    processErrorMessages = processErrorMessages.Substring(0, 4000);
                }
            }
            return processErrorMessages;
        }

    }
}
