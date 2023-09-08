using System;
//using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using CSI.ExternalContracts.FactoryTrack;

//Imports System.Threading.Thread

namespace InforCollect.ERP.SL.ICSLTimeAttendanceTrans
{
    public class TimeAttendanceTransactions : ExtensionClassBase, IExtFTICSLTimeAttendanceTrans
    {
        private int retVal = -1;
        public int TimeAttendanceUpdate(string EmpNum, string transDate, string transTime, string transType, string userId, string shift,string deviceId,string stopLaborRecords,
                    string recordMachineTime, string processRealTime, string taImplemented, string validatePreviousTARecord ,string skipAutoLunchcheck, out string Infobar)
        {
            Infobar = "";
            //transDate = DateTime.Parse(transDate).ToString(System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern);
            //transDate = "2015-06-22";
            //transTime = "11:15";

            
            TimeAttendanceUpdate TimeAttendanceUpdate = new TimeAttendanceUpdate(EmpNum, transDate, transTime, transType, userId, shift, deviceId, stopLaborRecords,
                                                            recordMachineTime, processRealTime, taImplemented, validatePreviousTARecord,skipAutoLunchcheck, out Infobar);
            TimeAttendanceUpdate.Initialize();//Initilize the base class.
            TimeAttendanceUpdate.SetContext(this.Context);
            retVal = TimeAttendanceUpdate.PerformUpdate(out Infobar);
            return retVal;
            
        }
        //When Labor Start a Job based on Grace time Adjusting the Labor Record Endtime.
        public int AdjustLaborReocrds(string EmpNum, string transDate, string TransTime, string userId, string shift, string deviceId, string IsGapJobCreated, out string Infobar)
        {
            //IsGapJobCreated ; This is Spliting the Records to Reg,OT,DT after creating GapRecord Form Labor Start
            TimeAttendanceUpdate TimeAttendanceUpdate = new TimeAttendanceUpdate(EmpNum, transDate, TransTime, userId, shift, deviceId, out Infobar);
            TimeAttendanceUpdate.Initialize();//Initilize the base class.
            TimeAttendanceUpdate.SetContext(this.Context);
            if (IsGapJobCreated == "1")
            {
                retVal = TimeAttendanceUpdate.PerformSpiltRecords(out Infobar);
            }
            else
            {
                //Adjust last labor Record End time with Current Job Starttime.
                retVal = TimeAttendanceUpdate.PerformAdjustLaborRecords(out Infobar);
            }
            return retVal;
        }
       
    }
}
