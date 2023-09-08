using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.ExternalContracts.FactoryTrack;

namespace  InforCollect.ERP.SL.ICSLFieldServiceTrans
{
    class FieldServiceTransactions : ExtensionClassBase, IExtFTICSLFieldServiceTrans
    {

        private int retVal = -1;
       
        public int SroMaterialIssue(string partnerId, string sroNum, long sroLine, long sroOper, string item, string transType, string transDate, decimal qtyConv, string uom,
                                 string whse, string loc, string lot, decimal priceConv, string billCode, string noteContent, out string rowPointer, out long transNum, out byte autoPost,
                                 out string Infobar, string custItem, out string prompt, out string promptButtons, string matlDescription, string SerialsSessionID,string docNum)
        {
            Infobar = "";
            rowPointer = "";
            transNum = 0;
            autoPost = 0;
            prompt = "";
            promptButtons = "";

            SROMaterialIssue SroMaterialIssue = new SROMaterialIssue(partnerId, sroNum, sroLine, sroOper, item, transType, transDate, qtyConv, uom, whse, loc, lot, priceConv, billCode, noteContent, rowPointer,
                                                   transNum, autoPost, custItem, prompt, promptButtons, matlDescription, SerialsSessionID, docNum, "");
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context.
            SroMaterialIssue.Initialize();//Initilize the base class.
            SroMaterialIssue.SetContext(this.Context);
            retVal = SroMaterialIssue.PerformUpdate(out Infobar);
            return retVal;
        }

        public int SROLaborUpdate(string partnerId, string sroNum, long sroLine, long sroOper, string startDateTime, string endDateTime, decimal hoursWorked, decimal billHours, string workCode, string billCode, out string Infobar)
        {
            Infobar = "";

            SROLaborUpdate SroLaborUpdate = new SROLaborUpdate(partnerId, sroNum, sroLine, sroOper, startDateTime, endDateTime, hoursWorked, billHours, workCode, billCode);
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context.
            SroLaborUpdate.Initialize();//Initilize the base class.
            SroLaborUpdate.SetContext(this.Context);
            retVal = SroLaborUpdate.PerformUpdate(out Infobar);
            return retVal;
        }


        public int SROMaterialIssueWithReason(string partnerId, string sroNum, long sroLine, long sroOper, string item, string transType, string transDate, decimal qtyConv, string uom,
                                 string whse, string loc, string lot, decimal priceConv, string billCode, string noteContent, out string rowPointer, out long transNum, out byte autoPost,
                                 out string Infobar, string custItem, out string prompt, out string promptButtons, string matlDescription, string SerialsSessionID, string docNum, string ReasonCode)
        {
            Infobar = "";
            rowPointer = "";
            transNum = 0;
            autoPost = 0;
            prompt = "";
            promptButtons = "";

            if (transType.Trim().ToUpper().Equals("H") && (ReasonCode == null || ReasonCode.Trim().Equals("")))
            {
                Infobar = "ReasonCode input mandatory";
                return 1;
            }

            SROMaterialIssue SroMaterialIssue = new SROMaterialIssue(partnerId, sroNum, sroLine, sroOper, item, transType, transDate, qtyConv, uom, whse, loc, lot, priceConv, billCode, noteContent, rowPointer,
                                                   transNum, autoPost, custItem, prompt, promptButtons, matlDescription, SerialsSessionID, docNum, ReasonCode);
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context.
            SroMaterialIssue.Initialize();//Initilize the base class.
            SroMaterialIssue.SetContext(this.Context);
            retVal = SroMaterialIssue.PerformUpdate(out Infobar);
            return retVal;
        }

    }
}
