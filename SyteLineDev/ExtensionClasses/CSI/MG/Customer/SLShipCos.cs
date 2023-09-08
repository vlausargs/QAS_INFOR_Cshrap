//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipCos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLShipCos")]
    public class SLShipCos : CSIExtensionClassBase
    {



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ShipLcrSp(string PCoNum,
                             DateTime? PTransDate,
                             string PMText,
                             ref string PromptMsg,
                             ref string PromptButtons,
                             ref string Infobar)
        {
            var iShipLcrExt = new ShipLcrFactory().Create(this, true);

            var result = iShipLcrExt.ShipLcrSp(PCoNum,
            PTransDate,
            PMText,
            PromptMsg,
            PromptButtons,
            Infobar);

            int Severity = result.ReturnCode.Value;
            PromptMsg = result.PromptMsg;
            PromptButtons = result.PromptButtons;
            Infobar = result.Infobar;
            return Severity;
        }




        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ShipCoSetGloVarSp(int? PLcrOkFlag)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iShipCoSetGloVarExt = new ShipCoSetGloVarFactory().Create(appDb);

                var result = iShipCoSetGloVarExt.ShipCoSetGloVarSp(PLcrOkFlag);

                int Severity = result.Value;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateShipCoASp(string PShipCoCoNum,
        decimal? PSubColLcrAmt,
        ref int? PShipCoActive,
        ref int? PShipCoLines,
        ref int? PShipCoReadyToProcess,
        ref int? PShipCoPicked,
        ref int? PShipCoShipped,
        ref int? PShipCoPacked,
        ref int? PShipCoInvoiced,
        ref decimal? PLcrAmt,
        ref string PromptMsg,
        ref string PromptButtons,
        ref string Infobar,
        [Optional, DefaultParameterValue(0)] int? RecalcOnly)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateShipCoAExt = new ValidateShipCoAFactory().Create(appDb);

                var result = iValidateShipCoAExt.ValidateShipCoASp(PShipCoCoNum,
                PSubColLcrAmt,
                PShipCoActive,
                PShipCoLines,
                PShipCoReadyToProcess,
                PShipCoPicked,
                PShipCoShipped,
                PShipCoPacked,
                PShipCoInvoiced,
                PLcrAmt,
                PromptMsg,
                PromptButtons,
                Infobar,
                RecalcOnly);

                int Severity = result.ReturnCode.Value;
                PShipCoActive = result.PShipCoActive;
                PShipCoLines = result.PShipCoLines;
                PShipCoReadyToProcess = result.PShipCoReadyToProcess;
                PShipCoPicked = result.PShipCoPicked;
                PShipCoShipped = result.PShipCoShipped;
                PShipCoPacked = result.PShipCoPacked;
                PShipCoInvoiced = result.PShipCoInvoiced;
                PLcrAmt = result.PLcrAmt;
                PromptMsg = result.PromptMsg;
                PromptButtons = result.PromptButtons;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateShipCoLcrSp(string PShipCoCoNum,
        int? PErrorOnly,
        int? PLcrOkFlag,
        ref string PromptMsg,
        ref string PromptButtons,
        ref string Infobar,
        int? PBatchId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateShipCoLcrExt = new ValidateShipCoLcrFactory().Create(appDb);

                var result = iValidateShipCoLcrExt.ValidateShipCoLcrSp(PShipCoCoNum,
                PErrorOnly,
                PLcrOkFlag,
                PromptMsg,
                PromptButtons,
                Infobar,
                PBatchId);

                int Severity = result.ReturnCode.Value;
                PromptMsg = result.PromptMsg;
                PromptButtons = result.PromptButtons;
                Infobar = result.Infobar;
                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ShipCoShipSp(string PShipCoCoNum,
        DateTime? ShipProcGenDate,
        ref int? Posted,
        ref string Infobar,
        int? PBatchId,
        string PDoNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iShipCoShipExt = new ShipCoShipFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iShipCoShipExt.ShipCoShipSp(PShipCoCoNum,
                ShipProcGenDate,
                Posted,
                Infobar,
                PBatchId,
                PDoNum);

                int Severity = result.ReturnCode.Value;
                Posted = result.Posted;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateShipCoCoNumSp(string PCoNum,
            DateTime? PGenDate,
            ref string PromptMsg,
            ref string PromptButtons,
            ref string Infobar)
        {
            var iValidateShipCoCoNumExt = new ValidateShipCoCoNumFactory().Create(this, true);

            var result = iValidateShipCoCoNumExt.ValidateShipCoCoNumSp(PCoNum,
                PGenDate,
                PromptMsg,
                PromptButtons,
                Infobar);

            PromptMsg = result.PromptMsg;
            PromptButtons = result.PromptButtons;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PurgeEDIShipSchedulesSp([Optional] string VendorStarting,
        [Optional] string VendorEnding,
        [Optional] string PoStarting,
        [Optional] string PoEnding,
        [Optional] DateTime? OrderDateStarting,
        [Optional] DateTime? OrderDateEnding,
        [Optional] DateTime? CDateStarting,
        [Optional] DateTime? CDateEnding,
        [Optional] string ExOptprPostedEmp,
        [Optional] int? OrderDateStartingOffset,
        [Optional] int? OrderDateEndingOffset,
        [Optional] int? CDateStartingOffset,
        [Optional] int? CDateEndingOffset,
        [Optional] ref string Message)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iPurgeEDIShipSchedulesExt = new PurgeEDIShipSchedulesFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iPurgeEDIShipSchedulesExt.PurgeEDIShipSchedulesSp(VendorStarting,
                VendorEnding,
                PoStarting,
                PoEnding,
                OrderDateStarting,
                OrderDateEnding,
                CDateStarting,
                CDateEnding,
                ExOptprPostedEmp,
                OrderDateStartingOffset,
                OrderDateEndingOffset,
                CDateStartingOffset,
                CDateEndingOffset,
                Message);

                int Severity = result.ReturnCode.Value;
                Message = result.Message;
                return Severity;
            }
        }
    }
}
