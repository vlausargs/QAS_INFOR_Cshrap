
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLTimeAttendanceTrans
    {

        int AdjustLaborReocrds(string EmpNum, string transDate, string TransTime, string userId, string shift, string deviceId, string IsGapJobCreated, out string Infobar); 

        int TimeAttendanceUpdate(string EmpNum, string transDate, string transTime, string transType, string userId, string shift,string deviceId,string stopLaborRecords,
                string recordMachineTime, string processRealTime, string taImplemented, string validatePreviousTARecord ,string skipAutoLunchcheck, out string Infobar); 

    }
}
    
