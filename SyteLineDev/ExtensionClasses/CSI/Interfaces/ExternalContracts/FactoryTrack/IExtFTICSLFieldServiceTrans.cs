
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLFieldServiceTrans
    {

        int SROLaborUpdate(string partnerId, string sroNum, long sroLine, long sroOper, string startDateTime, string endDateTime, decimal hoursWorked, decimal billHours, string workCode, string billCode, out string Infobar); 

        int SroMaterialIssue(string partnerId, string sroNum, long sroLine, long sroOper, string item, string transType, string transDate, decimal qtyConv, string uom,
                string whse, string loc, string lot, decimal priceConv, string billCode, string noteContent, out string rowPointer, out long transNum, out byte autoPost,
                out string Infobar, string custItem, out string prompt, out string promptButtons, string matlDescription, string SerialsSessionID,string docNum); 

        int SROMaterialIssueWithReason(string partnerId, string sroNum, long sroLine, long sroOper, string item, string transType, string transDate, decimal qtyConv, string uom,
                string whse, string loc, string lot, decimal priceConv, string billCode, string noteContent, out string rowPointer, out long transNum, out byte autoPost,
                out string Infobar, string custItem, out string prompt, out string promptButtons, string matlDescription, string SerialsSessionID, string docNum, string ReasonCode); 

    }
}
    
