//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCCORcpts.cs

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
    [IDOExtensionClass("RS_QCCORcpts")]
    public class RS_QCCORcpts : CSIExtensionClassBase
    {




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckCustomerSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		string CustNum,
		decimal? QtyToShip,
		string CoitemUM,
		ref int? NeedsQC,
		ref int? HoldCertificateRequired,
		ref string Messages,
		ref int? Status,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckCustomerExt = new RSQC_CheckCustomerFactory().Create(appDb);
				
				var result = iRSQC_CheckCustomerExt.RSQC_CheckCustomerSp(CoNum,
				CoLine,
				CoRelease,
				Item,
				CustNum,
				QtyToShip,
				CoitemUM,
				NeedsQC,
				HoldCertificateRequired,
				Messages,
				Status,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				NeedsQC = result.NeedsQC;
				HoldCertificateRequired = result.HoldCertificateRequired;
				Messages = result.Messages;
				Status = result.Status;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ParmcuSp(ref string o_prompt_item_order,
			ref string Infobar)
		{
			var iRSQC_ParmcuExt = this.GetService<IRSQC_Parmcu>();
			
			var result = iRSQC_ParmcuExt.RSQC_ParmcuSp(o_prompt_item_order,
				Infobar);
			
			o_prompt_item_order = result.o_prompt_item_order;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_QtyOnHandSp([Optional] string i_item,
		[Optional] string i_whse,
		ref decimal? o_qtyonhand,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_QtyOnHandExt = new RSQC_QtyOnHandFactory().Create(appDb);
				
				var result = iRSQC_QtyOnHandExt.RSQC_QtyOnHandSp(i_item,
				i_whse,
				o_qtyonhand,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_qtyonhand = result.o_qtyonhand;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateCustomerReceiverSp(decimal? QtyReceived,
		string Whse,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Loc,
		DateTime? DueDate,
		string Lot,
		string Item,
		string CustNum,
		DateTime? HoldDate,
		int? AutoAccept,
		string CallingFunction,
		string QCLot,
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
				
				var iRSQC_CreateCustomerReceiverExt = new RSQC_CreateCustomerReceiverFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_CreateCustomerReceiverExt.RSQC_CreateCustomerReceiverSp(QtyReceived,
				Whse,
				CoNum,
				CoLine,
				CoRelease,
				Loc,
				DueDate,
				Lot,
				Item,
				CustNum,
				HoldDate,
				AutoAccept,
				CallingFunction,
				QCLot,
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
    }
}
