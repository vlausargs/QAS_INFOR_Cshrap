using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;



namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class PickPackShipShipmentConfirmUpdate : OutBoundUtilities
    {
        //Input Variables.
        string shipmentID = "";
        string errorMessage = "";
        
        private ICSLOutBoundTrans.SLDAL.SLShipmentsDAL DAL;
        public PickPackShipShipmentConfirmUpdate()
        {//constructor.  initialize the object.
            initialize();            
            
        }
        public bool setInputs(string shipmentID)
        {
            bool retval = false;

            this.shipmentID = shipmentID;

            retval = true;
            return retval;
        }

        public void initialize()
        {
            //Input variables initialization
            shipmentID = "";
            errorMessage = "";
            

        }


        public bool formatInputs()
        {
           // shipmentID = queryRequest.GetFieldValue("shipmentID");
            if (shipmentID == "")
            {
                errorMessage = constructErrorMessage("shipmentID input mandatory", "PPSS0001", null);
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
            
            if (formatInputs() == false)
            {
                Infobar = errorMessage;
                return 1;
            }

            validateInputs();

            if (preformUpdate() == false)
            {
                Infobar = errorMessage;
                return 3;
            }
            Infobar = errorMessage;
            return 0;
        }

        private bool preformUpdate()
        {
            bool retVal = true;
            string msg = "";

            DAL = new ICSLOutBoundTrans.SLDAL.SLShipmentsDAL(this.Context);


            LoadCollectionResponseData DALResponseData = null;

            LoadCollectionRequestData DALRequest = null;

            DAL.ShipmentId = shipmentID;

            DALRequest = DAL.GetQueryRquest();

            DALResponseData = ExcuteQueryRequest(DALRequest);

            if (DALResponseData.Items.Count == 0)
            {
                constructErrorMessage("Shipment details not found", "PPSS0002", null);
                return false;
            }

            DAL.UbSelect = "1";
            DAL.Status = "R";
            DAL.RowPointer = GetPropertyValue(DALResponseData, "RowPointer");
            DAL.RecordDate = GetPropertyValue(DALResponseData, "RecordDate");

            msg = DAL.Update();

            if (msg != "")
            {
                errorMessage = msg;
                return false;
            }


            DAL.ShipmentId = shipmentID;

            msg = DAL.InvokeIDOMethod_UpdateShipmentValueSp();
            if (msg != "")
            {
                errorMessage = constructErrorMessage(msg, "PPSC0002", null);
                return false;
            }

            return retVal;
        }
    }
}
