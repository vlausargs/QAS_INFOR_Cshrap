//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCIPRcpts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCIPRcpts")]
    public class RS_QCIPRcpts : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateIPReceiverSp(decimal? i_QtyReceived,
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
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateIPReceiverExt = new RSQC_CreateIPReceiverFactory().Create(appDb);
				
				var result = iRSQC_CreateIPReceiverExt.RSQC_CreateIPReceiverSp(i_QtyReceived,
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
		public int RSQC_CreatePSReceiverSp(decimal? i_QtyReceived,
		string i_Whse,
		string i_PSNum,
		string i_CallingFunction,
		string i_UserCode,
		ref int? o_PopUp,
		ref int? o_PrintTag,
		ref string o_RcvrNums,
		ref string o_Messages,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreatePSReceiverExt = new RSQC_CreatePSReceiverFactory().Create(appDb);
				
				var result = iRSQC_CreatePSReceiverExt.RSQC_CreatePSReceiverSp(i_QtyReceived,
				i_Whse,
				i_PSNum,
				i_CallingFunction,
				i_UserCode,
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
		public int RSQC_GetIPparmsSp(ref int? NeedsQC)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
                var iRSQC_GetIPparmsExt = new RSQC_GetIPparmsFactory().Create(this, true);

                var result = iRSQC_GetIPparmsExt.RSQC_GetIPparmsSp(NeedsQC);

                NeedsQC = result.NeedsQC;

                return result.ReturnCode ?? 0;
            }
		}
    }
}
