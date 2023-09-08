using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;


namespace InforCollect.ERP.SL.ICSLShopFloorTrans.Labor
{
   public class AttendanceUpdateDaoImpl : ALaborUtils 
    {
        private string EmpNum;
        private string transDate;
        private string transTime;
        private string transType;
        private string deviceId;
        private string userId;
        private string shift;
        private Int64 nextTransNumber = -1;
        private DateTime currentDateTime = DateTime.Now;
        
       public AttendanceUpdateDaoImpl(string EmpNum, string transDate, string transTime, string transType, string userId, string shift,string deviceId)
       {
           //Initialize();
           //this.Context = context;
           this.EmpNum = EmpNum;
           this.transDate = transDate;
           this.transTime = transTime;
           this.transType = transType;
           this.userId = userId;
           this.shift = shift;
           this.deviceId = deviceId;
           //currentDateTime = Convert.ToDateTime(transDate + " " + transTime);
           currentDateTime=DateTime.ParseExact(transDate + " " + transTime, "MMddyyyy HHmm", CultureInfo.CurrentCulture);
       }

       //public void Initialize()
       //{

       //    this.Initialize();
       //}

       public int PerformUpdate(out string infobar)
       {
           //initialize();
           infobar = "";
           validateInputs();

           if (performTimeAttendanceUpdate(out infobar) == false)
           {
               infobar = errorMessage;
               return 16; 
           }
           return 0;
       }
       private void validateInputs()
       {
           employeeResponseData = GetSLEmployeeDetails(EmpNum);
          

       }
       public LoadCollectionResponseData GetSLEmployeeDetails(string EmpNum)
       {
           LoadCollectionRequestData LoadRequestData = new LoadCollectionRequestData();
           LoadRequestData.IDOName = "SLEmployees";
           LoadRequestData.PropertyList.SetProperties("EmpNum,Name,Lname,ADate, TermDate, Shift, LunchAuto, IndCode, RegRate, OtRate, DtRate, MfgRegRate, MfgOtRate, MfgDtRate");
           string filterString = "EmpNum = '" + EmpNum + "'";
           LoadRequestData.Filter = filterString;
           LoadRequestData.RecordCap = 1;
           LoadRequestData.OrderBy = "EmpNum";

           return ExcuteQueryRequest(LoadRequestData);

       }
     
       private bool performTimeAttendanceUpdate(out string infobar)
       {
           infobar = "";
           
           SxGetAutoNumberMax();
           UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
           updateRequestData.IDOName = "SL.SLDctas";
           updateRequestData.RefreshAfterUpdate = false;
           updateRequestData.CustomUpdate = "STD,AutoLunchCheckSp(EmpNum,Shift,PostDate,PostTime,,TransNum,Termid,,,0,0,,,'TAU',MESSAGE),REF";
           updateRequestData.CustomInsert = "STD,AutoLunchCheckSp(EmpNum,Shift,PostDate,PostTime,,TransNum,Termid,,,0,0,,,'TAU',MESSAGE),REF";


           IDOUpdateItem updateItem = new IDOUpdateItem();
           updateItem.Action = UpdateAction.Insert;

           updateItem.Properties.Add("TransNum", this.nextTransNumber);
           updateItem.Properties.Add("EmpNum", EmpNum);
           updateItem.Properties.Add("EmpName", GetPropertyValue(employeeResponseData, "Name"));
           updateItem.Properties.Add("NoteExistsFlag", "", false);
           //updateItem.Properties.Add("PostDate", currentDateTime.ToString("yyyy/MM/dd"));
           updateItem.Properties.Add("PostDate", currentDateTime.ToString(WMShortDatePattern));//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
           updateItem.Properties.Add("PostTime", currentDateTime.TimeOfDay.TotalSeconds.ToString());
           updateItem.Properties.Add("RowPointer", "", false);
           updateItem.Properties.Add("Shift", shift);
           updateItem.Properties.Add("InWorkflow", "", false);
           updateItem.Properties.Add("_ItemWarnings", "", false);
           updateItem.Properties.Add("Termid", deviceId);
           updateItem.Properties.Add("EmpShift", shift);
           updateItem.Properties.Add("TransType", this.transType);
           updateItem.Properties.Add("ErrorMessage", "");
           updateItem.Properties.Add("Stat", "P");
           updateItem.Properties.Add("Override", "0");
           //updateItem.Properties.Add("derTransTimeFmt", currentDateTime.ToString("hh:mm:ss"));
           updateItem.Properties.Add("derTransTimeFmt", currentDateTime.ToString(WMTimePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
           //updateItem.Properties.Add("derPostTimeFmt", currentDateTime.ToString("HH:mm:ss"));
           updateItem.Properties.Add("derPostTimeFmt", currentDateTime.ToString(WMTimePattern)); //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
           updateItem.Properties.Add("TransTime", currentDateTime.TimeOfDay.TotalSeconds.ToString());
           //updateItem.Properties.Add("TransDate", currentDateTime.ToString("yyyy/MM/dd") + " " + "00:00:00");
           updateItem.Properties.Add("TransDate", currentDateTime.ToString(WMShortDatePattern) + " " + "00:00:00");//MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128


           updateItem.ItemID = "";
           updateItem.ItemNumber = 1;
           updateRequestData.Items.Add(updateItem);
           try
           {
               // UpdateCollectionResponseData updateResponseData = this.sytelineClient.UpdateCollection(updateRequestData);
               UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
               //Console.WriteLine(updateResponseData.ToXml());
           }
           catch (Exception ee)
           {
               errorMessage = constructErrorMessage("Update Failed " + ee.Message, "", null);
               //Console.WriteLine(ee.Message);
               return false;
           }

           string returnString = "<Response>";
           returnString += "<output>";
           returnString += "<row>";
           returnString += "<TRANSACTION_STATUS>0</TRANSACTION_STATUS>";
           returnString += "</row>";
           returnString += "</output>";
           returnString += "</Response>";
           //return returnString;

           return true;
       }
       private bool SxGetAutoNumberMax()
       {
           object[] inputParams = new object[]{
                                                "TransNum",
                                                ""
                                                };

           InvokeResponseData responseData = InvokeIDO("SL.SLDctas", "SxGetAutoNumberMax", inputParams);
           nextTransNumber = Convert.ToInt64(responseData.ReturnValue.ToString(), CultureInfo.InvariantCulture) + 1; // FTDEV-9247
           return true;

       }

    }
}
