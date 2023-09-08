using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class PickPackShipShipmentPackagePack : OutBoundUtilities
    {
        //Input Variables.
        string shipmentID = "";
        string packageID = "";       //when this is a existing package and RefPackageId is "" then we need to call generatepackage and create new packag
        string refPackageID = "";    //new record or outer most package.
        string packageType = "";
        string rateCode = "";
        string NMFC = "";
        string weight = "";
        string hazard = "";
        string description = "";
        string marksExcept = "";

        private string errorMessage = "";
        #region calculated/internal variables
        string ProcessGUID = "";
        #endregion

        private ICSLOutBoundTrans.SLDAL.SLShipmentPackagesDAL DAL;


        public PickPackShipShipmentPackagePack()
        {//constructor.  initialize the object.
            initialize();            
            
        }
        
        public bool setInputs(string shipmentID, string packageID, string refPackageID, string packageType,
                              string rateCode, string NMFC, string weight, string hazard, string description,
                              string marksExcept)
        {

            bool retval = false;
            this.shipmentID = shipmentID;
            this.packageID = packageID;
            this.refPackageID = refPackageID;
            this.packageType = packageType;
            this.rateCode = rateCode;
            this.NMFC = NMFC;
            this.weight = weight;
            this.hazard = hazard;
            this.description = description;
            this.marksExcept = marksExcept;
            retval = true;
            return retval;
        }

        public void initialize()
        {
            //Input variables initialization
            shipmentID = "";
            packageID = "";
            refPackageID = "";
            packageType = "";
            rateCode = "";

            NMFC = "";
            weight = "";
            hazard = "";
            description = "";
            marksExcept = "";            

        }


        public bool formatInputs()
        {
            if (shipmentID == "")
            {
                errorMessage = "shipmentID input mandatory";
                return false;
            }

            //packageID = queryRequest.GetFieldValue("packageID"); //when this is a existing package and RefPackageId is "" then we need to call generatepackage and create new packag
            if (packageID == "")
            {
                errorMessage = "PackageID input mandatory";
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
        {//converted processMessage to collect PerformUpdate  JH:20130816

            Infobar = "";
            DAL = new ICSLOutBoundTrans.SLDAL.SLShipmentPackagesDAL(this.Context);
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
            string filterString = "";
            InvokeResponseData DALData1;
            //Int32 IDOMethodParamCount = 0;
            //IDOMethodParamCount = GetIDOMethodParameterCount("SLShipmentPackages", "GeneratePackagePackageSp");
            //create the temporary records
            GenerateGUID(ref ProcessGUID, out errorMessage);
            if (errorMessage != "")
            {//we had a error creating the GUID.
                return false;
            }
            DAL.UbSelect = "1";
            //if (IDOMethodParamCount == 3 || IDOMethodParamCount ==0)
            //{
                if (refPackageID == "" || refPackageID == null || refPackageID == "null")
                {
                    DAL.UbSelect = "0";
                   string packageIDFilter;
                    packageIDFilter = "ShipmentId =" + shipmentID;
                    LoadCollectionResponseData packageIDOResponseData;
                    LoadCollectionRequestData packageIDORequestData = new LoadCollectionRequestData("SLShipmentPackages", "PackageId", packageIDFilter, "PackageId Desc", -1);
                    packageIDOResponseData = this.ExcuteQueryRequest(packageIDORequestData);
                    if (packageIDOResponseData.Items.Count > 0)
                    {
                        if (packageIDOResponseData[0, "PackageId"].Value == "")
                        {
                            refPackageID = "1";
                        }
                        else
                        {
                            refPackageID = Convert.ToString(Convert.ToInt32(packageIDOResponseData[0, "PackageId"].Value, CultureInfo.InvariantCulture) + 1); // FTDEV-9247
                    }
                    }
                    if (hazard == "" || hazard == null || hazard == "null")
                    {
                        hazard = "0";
                    }                             
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
                        ShipmentPackage.Properties.Add("PackageId", refPackageID, true);
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
            string packageFilter, sourcePackageType = string.Empty;
            packageFilter = string.Format("ShipmentId = {0} and PackageId = {1}", shipmentID, packageID);
            LoadCollectionResponseData packageTypeIDOResponseData;
            LoadCollectionRequestData packageTypeIDORequestData = new LoadCollectionRequestData("SLShipmentPackages", "PackageType", packageFilter, string.Empty, -1);
            packageTypeIDOResponseData = this.ExcuteQueryRequest(packageTypeIDORequestData);
            if (packageTypeIDOResponseData.Items.Count > 0)
            {
                sourcePackageType = packageTypeIDOResponseData[0, "PackageType"].Value;
            }

            DAL.ProcessId = ProcessGUID;
            //DAL.UbSelect = "1"; //allways 1
            DAL.ShipmentId = shipmentID;
            //PackageId  = record that is changed.
            DAL.PackageId = packageID;   //when this is a existing package and RefPackageId is "" then we need to call generatepackage and create new packag
            DAL.RefPackageId = refPackageID;     //when this is a existing package and PackageId is set to a existing package then GenerateTmpShipSeqPackageSp sets the PackageId record's RefPackageId
            DAL.PackageType = string.IsNullOrWhiteSpace(sourcePackageType) ? packageType : sourcePackageType;    //updates the packageid record.  Warehousemobility should not include this value for now.
            DAL.RateCode = rateCode;        //updates the packageid record.  Warehousemobility should not include this value for now.
            DAL.NMFC = NMFC;                //updates the packageid record.  Warehousemobility should not include this value for now.
            DAL.Weight = weight;            //updates the packageid record.  Warehousemobility should not include this value for now.
            DAL.Hazard = hazard;            //updates the packageid record.  Warehousemobility should not include this value for now.
            DAL.Description = description;  //updates the packageid record.  Warehousemobility should not include this value for now.
            DAL.MarksExcept = marksExcept;
            filterString = DAL.InvokeIDOMethod_GenerateTmpShipSeqPackageSp();

            if (refPackageID == "" || refPackageID ==null)
            {
                //process the temporary records and move the packages.  ref package = outer most package.
                DAL.ProcessId = ProcessGUID;
                DAL.PackageId = refPackageID;  //ref package for main package table reference.  "" = new package.
                //Includes the package details from the PackageID record in the new package.
                filterString = DAL.InvokeIDOMethod_GeneratePackagePackageSp();//returns failure message               
                DALData1 = DAL.InvokeResponse; //data returned.         

                if (filterString == "")
                {
                    DALData1 = DAL.InvokeResponse; //data returned.
                    if (!DALData1.ReturnValue.Equals("0"))
                    {
                        errorMessage = DALData1.Parameters.ElementAt(6).ToString();
                        return retVal;

                    }
                }
            }

            return retVal;
        }
    }
}
