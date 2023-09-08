//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCPORcpts.cs

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
	[IDOExtensionClass("RS_QCPORcpts")]
	public class RS_QCPORcpts : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateSupplierReceiverSp(decimal? QtyReceived,
		string Whse,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string Loc,
		DateTime? DueDate,
		string Lot,
		string Item,
		string VendNum,
		DateTime? TransDate,
		int? AutoAccept,
		string CallingFunction,
		string QCLot,
		string UserCode,
		int? firstarticleonly,
		ref string RcvrNum,
		ref int? PopUp,
		ref int? PrintTag,
		ref string Messages,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateSupplierReceiverExt = new RSQC_CreateSupplierReceiverFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateSupplierReceiverExt.RSQC_CreateSupplierReceiverSp(QtyReceived,
				Whse,
				PoNum,
				PoLine,
				PoRelease,
				Loc,
				DueDate,
				Lot,
				Item,
				VendNum,
				TransDate,
				AutoAccept,
				CallingFunction,
				QCLot,
				UserCode,
				firstarticleonly,
				RcvrNum,
				PopUp,
				PrintTag,
				Messages,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RcvrNum = result.RcvrNum;
				PopUp = result.PopUp;
				PrintTag = result.PrintTag;
				Messages = result.Messages;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_PrintReceiptTagsp(int? i_RcvrNum,
		DateTime? i_TransDate,
		string i_UserCode,
		decimal? i_TagQty,
		string i_Stat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_PrintReceiptTagExt = new RSQC_PrintReceiptTagFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_PrintReceiptTagExt.RSQC_PrintReceiptTagsp(i_RcvrNum,
				i_TransDate,
				i_UserCode,
				i_TagQty,
				i_Stat);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
