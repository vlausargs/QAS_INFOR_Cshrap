//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCQuickMrrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Production;
using CSI.ExternalContracts.FactoryTrack;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCQuickMrrs")]
    public class RS_QCQuickMrrs : CSIExtensionClassBase, IExtFTRS_QCQuickMrrs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_AutoCreateQCItem2Sp(string i_po,
                                            short? i_line,
                                            ref string o_messages,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_AutoCreateQCItem2Ext = new RSQC_AutoCreateQCItem2Factory().Create(appDb);

                int Severity = iRSQC_AutoCreateQCItem2Ext.RSQC_AutoCreateQCItem2Sp(i_po,
                                                                                   i_line,
                                                                                   ref o_messages,
                                                                                   ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_AutoCreateQCItemSp(string i_item,
        string i_ref_type,
        string i_vend_num,
        string i_job,
        int? i_suffix,
        int? i_oper_num,
        ref string o_messages,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_AutoCreateQCItemExt = new RSQC_AutoCreateQCItemFactory().Create(appDb);

                var result = iRSQC_AutoCreateQCItemExt.RSQC_AutoCreateQCItemSp(i_item,
                i_ref_type,
                i_vend_num,
                i_job,
                i_suffix,
                i_oper_num,
                o_messages,
                Infobar);

                int Severity = result.ReturnCode.Value;
                o_messages = result.o_messages;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_CheckSerialTrackedSp(string i_item,
        string i_ref_type,
        string i_vend_num,
        string i_job,
        int? i_suffix,
        int? i_oper_num,
        ref int? o_serial_tracked,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_CheckSerialTrackedExt = new RSQC_CheckSerialTrackedFactory().Create(appDb);

                var result = iRSQC_CheckSerialTrackedExt.RSQC_CheckSerialTrackedSp(i_item,
                i_ref_type,
                i_vend_num,
                i_job,
                i_suffix,
                i_oper_num,
                o_serial_tracked,
                Infobar);

                int Severity = result.ReturnCode.Value;
                o_serial_tracked = result.o_serial_tracked;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_CreateIPQuickReceiverSp(decimal? i_QtyReceived,
        string i_Whse,
        string i_Job,
        int? i_Suffix,
        int? i_OperNum,
        string i_PSNum,
        string i_CallingFunction,
        string i_UserCode,
        int? firstarticleonly,
        ref int? o_PopUp,
        ref int? o_PrintTag,
        ref string o_RcvrNums,
        ref string o_Messages,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_CreateIPQuickReceiverExt = new RSQC_CreateIPQuickReceiverFactory().Create(appDb);

                var result = iRSQC_CreateIPQuickReceiverExt.RSQC_CreateIPQuickReceiverSp(i_QtyReceived,
                i_Whse,
                i_Job,
                i_Suffix,
                i_OperNum,
                i_PSNum,
                i_CallingFunction,
                i_UserCode,
                firstarticleonly,
                o_PopUp,
                o_PrintTag,
                o_RcvrNums,
                o_Messages,
                Infobar);

                int Severity = result.ReturnCode.Value;
                o_PopUp = result.o_PopUp;
                o_PrintTag = result.o_PrintTag;
                o_RcvrNums = result.o_RcvrNums;
                o_Messages = result.o_Messages;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_CreateQuickMrrSp(int? i_rcvr,
        string i_problem,
        int? i_UseHoldLoc,
        string i_MRRLoc,
        ref string o_Messages,
        ref int? o_rcvr,
        ref string o_mrr,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_CreateQuickMrrExt = new RSQC_CreateQuickMrrFactory().Create(appDb);

                var result = iRSQC_CreateQuickMrrExt.RSQC_CreateQuickMrrSp(i_rcvr,
                i_problem,
                i_UseHoldLoc,
                i_MRRLoc,
                o_Messages,
                o_rcvr,
                o_mrr,
                Infobar);

                int Severity = result.ReturnCode.Value;
                o_Messages = result.o_Messages;
                o_rcvr = result.o_rcvr;
                o_mrr = result.o_mrr;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetEmailParmsSp(ref string CarEMail,
        ref string MrrEMail,
        ref string CcrEMail,
        ref string VrmaEMail)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_GetEmailParmsExt = new RSQC_GetEmailParmsFactory().Create(appDb);

                var result = iRSQC_GetEmailParmsExt.RSQC_GetEmailParmsSp(CarEMail,
                MrrEMail,
                CcrEMail,
                VrmaEMail);

                int Severity = result.ReturnCode.Value;
                CarEMail = result.CarEMail;
                MrrEMail = result.MrrEMail;
                CcrEMail = result.CcrEMail;
                VrmaEMail = result.VrmaEMail;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetHoldLocSp(ref string o_hold_loc,
        ref int? o_use_hold_loc)
        {         
            var iRSQC_GetHoldLocExt = this.GetService<IRSQC_GetHoldLoc>();
            var result = iRSQC_GetHoldLocExt.RSQC_GetHoldLocSp(o_hold_loc,
                o_use_hold_loc);
            o_hold_loc = result.o_hold_loc;
            o_use_hold_loc = result.o_use_hold_loc;
            return result.ReturnCode??0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_GetQuickMrrParmsSp(ref int? QuickQCSAllow,
        ref string QuickAutoCreateMrr,
        ref string QuickMrrReasonCode,
        ref int? QuickCreateItem,
        ref string QuickItemInspFreqId,
        ref string QuickItemAlert,
        ref int? QuickQCSAllowIP,
        ref string QuickAutoCreateMrrIP,
        ref string QuickMrrReasonCodeIP,
        ref int? QuickCreateItemIP,
        ref string QuickItemInspFreqIdIP,
        ref string QuickItemAlertIP,
        ref string QuickItemTestTypeIP,
        ref int? QuickItemTestSeqIP)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRSQC_GetQuickMrrParmsExt = new RSQC_GetQuickMrrParmsFactory().Create(appDb);

                var result = iRSQC_GetQuickMrrParmsExt.RSQC_GetQuickMrrParmsSp(QuickQCSAllow,
                QuickAutoCreateMrr,
                QuickMrrReasonCode,
                QuickCreateItem,
                QuickItemInspFreqId,
                QuickItemAlert,
                QuickQCSAllowIP,
                QuickAutoCreateMrrIP,
                QuickMrrReasonCodeIP,
                QuickCreateItemIP,
                QuickItemInspFreqIdIP,
                QuickItemAlertIP,
                QuickItemTestTypeIP,
                QuickItemTestSeqIP);

                int Severity = result.ReturnCode.Value;
                QuickQCSAllow = result.QuickQCSAllow;
                QuickAutoCreateMrr = result.QuickAutoCreateMrr;
                QuickMrrReasonCode = result.QuickMrrReasonCode;
                QuickCreateItem = result.QuickCreateItem;
                QuickItemInspFreqId = result.QuickItemInspFreqId;
                QuickItemAlert = result.QuickItemAlert;
                QuickQCSAllowIP = result.QuickQCSAllowIP;
                QuickAutoCreateMrrIP = result.QuickAutoCreateMrrIP;
                QuickMrrReasonCodeIP = result.QuickMrrReasonCodeIP;
                QuickCreateItemIP = result.QuickCreateItemIP;
                QuickItemInspFreqIdIP = result.QuickItemInspFreqIdIP;
                QuickItemAlertIP = result.QuickItemAlertIP;
                QuickItemTestTypeIP = result.QuickItemTestTypeIP;
                QuickItemTestSeqIP = result.QuickItemTestSeqIP;
                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RSQC_CreateJITReceiverSp(decimal? i_QtyReceived,
        string i_Whse,
        string i_Item,
        string i_CallingFunction,
        ref int? o_PopUp,
        ref int? o_PrintTag,
        ref string o_RcvrNums,
        ref string o_Messages,
        ref string Infobar)
        {
            var iRSQC_CreateJITReceiverExt = new RSQC_CreateJITReceiverFactory().Create(this, true);

            var result = iRSQC_CreateJITReceiverExt.RSQC_CreateJITReceiverSp(i_QtyReceived,
            i_Whse,
            i_Item,
            i_CallingFunction,
            o_PopUp,
            o_PrintTag,
            o_RcvrNums,
            o_Messages,
            Infobar);

            int Severity = result.ReturnCode.Value;
            o_PopUp = result.o_PopUp;
            o_PrintTag = result.o_PrintTag;
            o_RcvrNums = result.o_RcvrNums;
            o_Messages = result.o_Messages;
            Infobar = result.Infobar;
            return Severity;
        }
    }
}
