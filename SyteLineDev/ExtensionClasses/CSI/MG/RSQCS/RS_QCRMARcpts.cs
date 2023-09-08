//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCRMARcpts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCRMARcpts")]
	public class RS_QCRMARcpts : CSIExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckQCItemhSp(string Item,
		string RefType,
		string Entity,
		int? TestSeq,
		ref int? Status,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckQCItemhExt = new RSQC_CheckQCItemhFactory().Create(appDb);
				
				var result = iRSQC_CheckQCItemhExt.RSQC_CheckQCItemhSp(Item,
				RefType,
				Entity,
				TestSeq,
				Status,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Status = result.Status;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetRmaparmsLocSp(ref string Loc,
			ref int? NeedsQC)
		{
			var iRSQC_GetRmaparmsLocExt = this.GetService<IRSQC_GetRmaparmsLoc>();
			
			var result = iRSQC_GetRmaparmsLocExt.RSQC_GetRmaparmsLocSp(Loc,
				NeedsQC);
			
			Loc = result.Loc;
			NeedsQC = result.NeedsQC;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateRMAReceiverSp(decimal? QtyReceived,
		string Whse,
		string RMANum,
		int? RMALine,
		string Loc,
		string Lot,
		string Item,
		string CustNum,
		DateTime? TransDate,
		int? AutoQCHold,
		string CallingFunction,
		string QCLot,
		string UserCode,
		ref string RcvrNum,
		ref int? PopUp,
		ref int? PrintTag,
		ref string TagStatus,
		ref string Messages,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_CreateRMAReceiverExt = new RSQC_CreateRMAReceiverFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateRMAReceiverExt.RSQC_CreateRMAReceiverSp(QtyReceived,
				Whse,
				RMANum,
				RMALine,
				Loc,
				Lot,
				Item,
				CustNum,
				TransDate,
				AutoQCHold,
				CallingFunction,
				QCLot,
				UserCode,
				RcvrNum,
				PopUp,
				PrintTag,
				TagStatus,
				Messages,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RcvrNum = result.RcvrNum;
				PopUp = result.PopUp;
				PrintTag = result.PrintTag;
				TagStatus = result.TagStatus;
				Messages = result.Messages;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
