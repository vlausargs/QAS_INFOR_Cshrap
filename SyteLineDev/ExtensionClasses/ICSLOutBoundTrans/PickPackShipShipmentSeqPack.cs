using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

using System.Diagnostics;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class PickPackShipShipmentSeqPack : OutBoundUtilities
    {
     
        string shipmentID = "";
        string packQty = "";  //Qty perpackage.  the scanner only allows doing one package at a time so this is allways the perpackage qt
        string lot = "";
        string item = "";
        string packageID = "";//when this is not passed in we are creating a new package.
        string sessionID = ""; //Session ID for serial Hanlding
        string packageType = "";
        string rateCode = "";
        string NMFC = "";
        string weight = "";
        string hazard = "";  //values of 0 or 1 are only allowed. the default is 0
        string description = "";
        private string errorMessage = "";

        #region calculated/internal variables
        private List<string> SerialList = null;

        string ProcessGUID = "";
        #endregion
        private ICSLOutBoundTrans.SLDAL.SLShipmentSeqsDAL DAL;
        private ICSLOutBoundTrans.SLDAL.SLShipmentSeqSerialsDAL DALSeqSerial;

        private void LogMessage(string msg)
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "PickPackShipShipmentSeqPack";
            sLog = "Infor Collect";
            sEvent = msg; // "Event Info";

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, sEvent);
            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Information, 000);


        }
        public PickPackShipShipmentSeqPack()
        {//constructor.  initialize the object.
            initialize();

            //LogMessage("Init Complete");
        }

        public PickPackShipShipmentSeqPack(string shipmentID, string packQty, string lot, string sessionID, string item, string packageID,
                              string packageType, string rateCode, string NMFC, string weight, string hazard, string description, IIDOExtensionClassContext context)
        {//constructor.  initialize the object.
            initialize();
            Context = context; //SetContext(this.Context);

            setInputs(shipmentID, packQty, lot, sessionID, item, packageID, packageType, rateCode, NMFC, weight, hazard, description);

        }

        public bool setInputs(string shipmentID, string packQty, string lot, string sessionID, string item, string packageID,  
                              string packageType,string rateCode, string NMFC, string weight, string hazard, string description)
                                              
        {            
            this.shipmentID = shipmentID;
            this.packQty = packQty;
            this.lot = lot;
            this.item = item;            
            this.packageID = packageID;
            this.sessionID = sessionID;
            this.packageType = packageType;
            this.rateCode = rateCode;
            this.NMFC = NMFC;
            this.weight = weight;
            this.hazard = hazard;
            this.description = description;

            return true;
        }

        public void initialize()
        {
            shipmentID = "";
            packQty = "";  //Qty perpackage.  the scanner only allows doing one package at a time so this is allways the perpackage qt
            lot = "";
            item = "";
            packageID = "";//when this is not passed in we are creating a new package.
            sessionID = "";
            packageType = "";
            rateCode = "";
            NMFC = "";
            weight = "";
            hazard = "";  //values of 0 or 1 are only allowed. the default is 0
            errorMessage = "";
        }


        public bool formatInputs()
        {
           // shipmentID = queryRequest.GetFieldValue("shipmentID");
            if (shipmentID == "")
            {
                errorMessage = "shipmentID input mandatory" ;
                return false;
            }
            if (packQty == "")
            {
                errorMessage =  "Pack qty input mandatory" ;
                return false;
            }
            
            if (item == "")
            {
                errorMessage =  "Item input mandatory";
                return false;
            }
           
            return true;
        }

        private bool validateInputs( )
        {
            bool retVal = true;

            return retVal;
        }
        public int PerformUpdate(out string Infobar)
        {//converted processMessage to collect PerformUpdate  JH:20130820

            Infobar = "";
           
            if (formatInputs( ) == false)
            {
                Infobar = errorMessage;
                return 1;
            }

            validateInputs( );

            if (performUpdate() == false)
            {
                Infobar = errorMessage;
                return 3;
            }
            Infobar = errorMessage;
            return 0;
        }

        private bool performUpdate()
        {
            bool retVal = true;
            string msg = "", customFilter = "", SerialSeqFilter = "", SerialNumDALFilter = "", ShipmentSeqNum = "";
            decimal TotalUnpackedQty = 0, ShipRecordPickedqty = 0, remainingQtytoPack = 0, CurrentItemPackQty = 0;
            //Int32 IDOMethodParamCount = 0;
            //IDOMethodParamCount = GetIDOMethodParameterCount("SLShipmentSeqs", "GeneratePackageSp");
            DAL = new ICSLOutBoundTrans.SLDAL.SLShipmentSeqsDAL(this.Context);
            DALSeqSerial = new ICSLOutBoundTrans.SLDAL.SLShipmentSeqSerialsDAL(this.Context);
                    

            InvokeResponseData DALData1;
            LoadCollectionResponseData DALSeqSerialResp = null;
            LoadCollectionResponseData DALSeqResp = null; //list of sequence records that match the criteria. Can be more than 1 record for a item/lot

            remainingQtytoPack = Convert.ToDecimal(packQty, CultureInfo.InvariantCulture); // FTDEV-9247
            //given the item look for the related shipment records.
            DAL.ShipmentId = shipmentID;
            DAL.CoItem = item;
            DAL.Lot = lot;

            if (sessionID != null && !(sessionID.Equals("")))
            {
                SerialList = this.GetSerialList(this.sessionID);
            //given a serial number we have to look up the ShipmentSeq details.
                //Seriallist = serialNum.Split(',');

                #region Serial Numbers
                DALSeqSerial.ShipmentId = shipmentID;
                if (SerialList != null)
                {
                    for (int i = 0; i < SerialList.Count; i++)
                    {
                      
                        if (SerialNumDALFilter != "")
                        {
                            SerialNumDALFilter += ",";
                        }
                        string serNum = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i)) ;
                        SerialNumDALFilter += "'" + serNum + "'";
                    }
                    SerialNumDALFilter = "SerNum in (" + SerialNumDALFilter + ")";
                }

                /*   if (Seriallist.Length > 1)
                   {
                       for (int i = 0; i < Seriallist.Length; i++)
                       {
                           if (SerialNumDALFilter != "")
                           {
                               SerialNumDALFilter += ",";
                           }
                           SerialNumDALFilter += "'" + Seriallist[i] + "'";
                       }
                       SerialNumDALFilter = "SerNum in (" + SerialNumDALFilter + ")";
                   } 
                   else
                   {
                       DALSeqSerial.SerNum = Seriallist[0];
                   }*/

                if (SerialNumDALFilter != "")
                {
                    msg = DALSeqSerial.QueryRecords(filter: SerialNumDALFilter, standardFilterincludesCustomFilter: true);
                }
                else
                {//SerialNumDALFilter
                    msg = DALSeqSerial.QueryRecords(recordCap: -1);
                }
                if (msg != "")
                {
                    errorMessage = constructErrorMessage("Serial Query Error: " + msg, "PPSPack0004", null);
                    return false;
                }
                DALSeqSerialResp = DALSeqSerial.LoadCollectionResponse;
                if (DALSeqSerialResp.Items.Count <= 0)
                {//we are packing serial so we must have at least 1 serial
                    errorMessage = constructErrorMessage("Unpacked Serial number(s) not found", "PPSPack0005", null);
                    return false;
                }

                //should only return one record but make it flexable to handle more than one record.
                for (int i = 0; i < DALSeqSerialResp.Items.Count; i++)
                {
                    if (ShipmentSeqNum != "")
                    {
                        ShipmentSeqNum += ", ";
                    }
                    ShipmentSeqNum += DALSeqSerialResp[i, "ShipmentSeq"].Value;
                }

                SerialSeqFilter = "ShipmentSeq in (" + ShipmentSeqNum + ")";

                customFilter = SerialSeqFilter + " and ";
                #endregion
            }
            //else
            //{
            customFilter += "PackageId is null";
            msg = DAL.QueryRecords(filter: customFilter, standardFilterincludesCustomFilter: true);
            if (msg != "")
            {
                errorMessage = constructErrorMessage("Shipment Query Error: " + msg, "PPSPack0006", null);
                return false;
            }

            DALSeqResp = DAL.LoadCollectionResponse;

            for (int i = 0; i < DALSeqResp.Items.Count; i++)
            {
                TotalUnpackedQty += Convert.ToDecimal(DALSeqResp[i, "QtyPicked"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
            }

            if (TotalUnpackedQty < Convert.ToDecimal(packQty, CultureInfo.InvariantCulture)) // FTDEV-9247
            {//error do not allow the user to pack more than the unpacked qty
                errorMessage = constructErrorMessage("Packing more qty than is unpacked is not allowed", "PPSPack0007", null);
                return false;
            }
            //}


            GenerateGUID(ref ProcessGUID, out errorMessage);
            if (errorMessage != "")
            {//we had a error
                return false;
            }
            //apply the pack qty provided by the user to each time until all qty is packed.
            for (int i = 0; i < DALSeqResp.Items.Count; i++)
            {
                if (remainingQtytoPack > 0)
                {//only do the packing if we have remaining qty to pack
                    ShipRecordPickedqty = Convert.ToDecimal(DALSeqResp[i, "QtyPicked"].Value, CultureInfo.InvariantCulture); // FTDEV-9247
                    if (ShipRecordPickedqty < remainingQtytoPack)
                    {//the remaining qty to pack is more than the current item so pack this item.
                        CurrentItemPackQty = ShipRecordPickedqty;
                        remainingQtytoPack = remainingQtytoPack - CurrentItemPackQty;  //reduce the pack qty.
                    }
                    else
                    { //the current item picked qty is equal to or more than what we are trying to pack.
                        CurrentItemPackQty = remainingQtytoPack;
                        remainingQtytoPack = 0;
                    }

                    DAL.ProcessId = ProcessGUID;
                    DAL.UbSelect = "1";
                    DAL.ShipmentId = shipmentID;
                    DAL.ShipmentLine = DALSeqResp[i, "ShipmentLine"].Value;
                    DAL.ShipmentSeq = DALSeqResp[i, "ShipmentSeq"].Value;
                    DAL.QtyPackages = "1";
                    DAL.QtyPerPackage = CurrentItemPackQty.ToString();
                    DAL.Loc = DALSeqResp[i, "Loc"].Value;
                    DAL.Lot = DALSeqResp[i, "Lot"].Value;
                    DAL.QtyPicked = DALSeqResp[i, "QtyPicked"].Value;
                    DAL.QtyShipped = DALSeqResp[i, "QtyShipped"].Value;
                    DAL.PackageId = ""; //must allways be blank if not then creating the temp records fails.
                    msg = DAL.InvokeIDOMethod_GenerateTmpShipSeqSp();
                    if (msg != "")
                    {
                        errorMessage = constructErrorMessage("Shipment Seq Generate Error: " + msg, "PPSPack0008", null);
                        return false;
                    }

                    //add serial numbers
                    #region Handle Serial items
                 /*   if ((serialNum != "") & (serialNum != null)) */
                    if (SerialList != null)
                    {
                        DALSeqSerialResp.Filter = "ShipmentSeq = '" + DALSeqResp[i, "ShipmentSeq"].Value + "'";

                        if (DALSeqSerialResp.Items.Count <= 0)
                        {//we are packing serial so we must have at least 1 serial
                            errorMessage = constructErrorMessage("Serial number not found", "PPSPack0009", null);
                            return false;
                        }
                        for (int ii = 0; ii < DALSeqSerialResp.Items.Count; ii++)
                        {
                            DALSeqSerial.ProcessId = ProcessGUID;
                            DALSeqSerial.UbSelect = "1";
                            DALSeqSerial.ShipmentId = shipmentID;
                            DALSeqSerial.ShipmentLine = DALSeqResp[i, "ShipmentLine"].Value;
                            DALSeqSerial.ShipmentSeq = DALSeqResp[i, "ShipmentSeq"].Value;
                            DALSeqSerial.SerNum = DALSeqSerialResp[ii, "SerNum"].Value;
                            msg = DALSeqSerial.InvokeIDOMethod_GenerateTmpShipSeqSerialSp();
                            if (msg != "")
                            {
                                errorMessage = constructErrorMessage("Shipment Serial Query Error: " + msg, "PPSPack0010", null);
                                return false;
                            }
                        }
                    }
                    #endregion
                    string packageInsert="0";
                    //if (IDOMethodParamCount == 3 || IDOMethodParamCount ==0)
                    //{
                        if (packageID == "" || packageID == null || packageID == "null")
                        {
                            packageInsert = "1";
                            string packageIDFilter;
                            packageIDFilter = "ShipmentId =" + shipmentID;
                            LoadCollectionResponseData packageIDOResponseData;
                            LoadCollectionRequestData packageIDORequestData = new LoadCollectionRequestData("SLShipmentPackages", "PackageId", packageIDFilter, "PackageId Desc", -1);
                            packageIDOResponseData = this.ExcuteQueryRequest(packageIDORequestData);
                            if (packageIDOResponseData.Items.Count > 0)
                            {
                                if (packageIDOResponseData[0, "PackageId"].Value == "")
                                {
                                    packageID = "1";
                                }
                                else
                                {
                                    packageID = Convert.ToString(Convert.ToInt32(packageIDOResponseData[0, "PackageId"].Value, CultureInfo.InvariantCulture) + 1); // FTDEV-9247
                            }
                            }
                            else
                            {
                                packageID = "1";
                            }
                    }
                        if (hazard == "" || hazard == null || hazard == "null")
                        {
                            hazard = "0";
                        }
                        DAL.ProcessId = ProcessGUID;
                        DAL.UbSelect = "1";
                        DAL.ShipmentId = shipmentID;
                        DAL.PackageId = packageID;
                        DAL.PackageType = packageType;
                        DAL.RateCode = rateCode;
                        DAL.NMFC = NMFC;
                        DAL.Weight = weight;
                        DAL.Hazard = hazard;
                        DAL.Description = description;
                        msg = DAL.InvokeIDOMethod_GenerateTmpShipSeqPackageSp();//returns failure message               
                        if (msg != "")
                        {
                            errorMessage = constructErrorMessage("Generate Temp Package Error: " + msg, "PPSPack0011", null);
                            return false;
                        }
                   // }
                    DAL.ProcessId = ProcessGUID;
                    DAL.QtyPackages = "1";
                    DAL.QtyPerPackage = CurrentItemPackQty.ToString();
                    DAL.PackageId = packageID;
                    DAL.PackageType = packageType;
                    DAL.RateCode = rateCode;
                    DAL.NMFC = NMFC;
                    DAL.Weight = weight;
                    DAL.Hazard = hazard;
                    DAL.Description = description;
                    IDORuntime.LogUserMessage("InvokeIDOMethod_GeneratePackageSp", UserDefinedMessageType.UserDefined1, "ProcessId {0}", DAL.ProcessId);
                    IDORuntime.LogUserMessage("InvokeIDOMethod_GeneratePackageSp", UserDefinedMessageType.UserDefined1, "QtyPerPackage {0}", DAL.QtyPerPackage);
                    IDORuntime.LogUserMessage("InvokeIDOMethod_GeneratePackageSp", UserDefinedMessageType.UserDefined1, "PackageId {0}", DAL.PackageId);
                    IDORuntime.LogUserMessage("InvokeIDOMethod_GeneratePackageSp", UserDefinedMessageType.UserDefined1, "PackageType {0}", DAL.PackageType);
                    msg = DAL.InvokeIDOMethod_GeneratePackageSp();//returns failure message               
                    if (msg != "")
                    {
                        errorMessage = constructErrorMessage("Generate Package Error: " + msg, "PPSPack0011", null);
                        return false;
                    }
                    //if (IDOMethodParamCount == 3 || IDOMethodParamCount ==0)
                    //{
                        if (packageInsert == "1")
                        {
                            LoadCollectionResponseData siteIDOResponseData;
                            LoadCollectionRequestData siteIDORequestData = new LoadCollectionRequestData("SLSites", "Site", "", "", -1);
                            siteIDOResponseData = this.ExcuteQueryRequest(siteIDORequestData);
                            if (siteIDOResponseData.Items.Count > 0)
                            {
                                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                                updateRequestData.IDOName = "SLShipmentPackages";
                                updateRequestData.RefreshAfterUpdate = true;
                                IDOUpdateItem ShipmentPackage = new IDOUpdateItem();
                                ShipmentPackage.Action = UpdateAction.Insert;
                                ShipmentPackage.Properties.Add("UbSite", siteIDOResponseData[0, "Site"].Value, true);
                                ShipmentPackage.Properties.Add("ShipmentId", shipmentID, true);
                                ShipmentPackage.Properties.Add("PackageId", packageID, true);
                                ShipmentPackage.Properties.Add("PackageType", packageType, true);
                                ShipmentPackage.Properties.Add("RateCode", rateCode, true);
                                ShipmentPackage.Properties.Add("NMFC", NMFC, true);
                                ShipmentPackage.Properties.Add("Weight", weight, true);
                                ShipmentPackage.Properties.Add("Hazard", hazard, true);
                                updateRequestData.Items.Add(ShipmentPackage);
                                UpdateCollectionResponseData updateContResponseData = new UpdateCollectionResponseData();
                                updateContResponseData = this.ExecuteUpdateCollection(updateRequestData);
                            }
                        }
                    //}
                    try
                    {
                        ClearSerailsBySessionID(this.sessionID);
                    }
                    catch (Exception)
                    {
                    }
                    DALData1 = DAL.InvokeResponse; //data returned.  
                }

            }

            return retVal;
        }
    }
}
