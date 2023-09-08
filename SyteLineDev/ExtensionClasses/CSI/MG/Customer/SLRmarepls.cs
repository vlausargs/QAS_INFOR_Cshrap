//PROJECT NAME: CustomerExt
//CLASS NAME: SLRmarepls.cs

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
	[IDOExtensionClass("SLRmarepls")]
	public class SLRmarepls : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplUpdateSp(string PRmaNum,
		int? PRmaLine,
		string PItem,
		string PItemDesc,
		string PCustItem,
		decimal? PQtyToReturnConv,
		string PItemUM,
		decimal? PUnitPriceConv,
		string PCoNum,
		int? PCoLine,
		int? PRepair,
		string PPricecode,
		string PCustNum,
		ref string Infobar,
		int? IncludeTaxInPrice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplUpdateExt = new RmaReplUpdateFactory().Create(appDb);
				
				var result = iRmaReplUpdateExt.RmaReplUpdateSp(PRmaNum,
				PRmaLine,
				PItem,
				PItemDesc,
				PCustItem,
				PQtyToReturnConv,
				PItemUM,
				PUnitPriceConv,
				PCoNum,
				PCoLine,
				PRepair,
				PPricecode,
				PCustNum,
				Infobar,
				IncludeTaxInPrice);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplCoLineSp(string PRmaNum,
		int? PRmaLine,
		string PCoNum,
		int? PCoLine,
		string PItem,
		ref decimal? RUnitPrice,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplCoLineExt = new RmaReplCoLineFactory().Create(appDb);
				
				var result = iRmaReplCoLineExt.RmaReplCoLineSp(PRmaNum,
				PRmaLine,
				PCoNum,
				PCoLine,
				PItem,
				RUnitPrice,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RUnitPrice = result.RUnitPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplCoNumSp(string PRmaNum,
		ref string PCoNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplCoNumExt = new RmaReplCoNumFactory().Create(appDb);
				
				var result = iRmaReplCoNumExt.RmaReplCoNumSp(PRmaNum,
				PCoNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PCoNum = result.PCoNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplLoadDefaultsSp(string PRmaNum,
		int? PRmaLine,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		ref string PItem,
		decimal? PQtyToReturnConv,
		string PPricecode,
		ref string RCustItem,
		ref string RItemDesc,
		ref string RItemUM,
		ref decimal? RUnitPrice,
		ref int? RItemSerTrack,
		ref int? IncludeTaxInPrice,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplLoadDefaultsExt = new RmaReplLoadDefaultsFactory().Create(appDb);
				
				var result = iRmaReplLoadDefaultsExt.RmaReplLoadDefaultsSp(PRmaNum,
				PRmaLine,
				PCoNum,
				PCoLine,
				PCoRelease,
				PItem,
				PQtyToReturnConv,
				PPricecode,
				RCustItem,
				RItemDesc,
				RItemUM,
				RUnitPrice,
				RItemSerTrack,
				IncludeTaxInPrice,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PItem = result.PItem;
				RCustItem = result.RCustItem;
				RItemDesc = result.RItemDesc;
				RItemUM = result.RItemUM;
				RUnitPrice = result.RUnitPrice;
				RItemSerTrack = result.RItemSerTrack;
				IncludeTaxInPrice = result.IncludeTaxInPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RmaReplUMSp(string POldUM,
		string PNewUM,
		string PItem,
		string PCustNum,
		ref decimal? RQtyConv,
		ref decimal? RUnitPrice,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRmaReplUMExt = new RmaReplUMFactory().Create(appDb);
				
				var result = iRmaReplUMExt.RmaReplUMSp(POldUM,
				PNewUM,
				PItem,
				PCustNum,
				RQtyConv,
				RUnitPrice,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RQtyConv = result.RQtyConv;
				RUnitPrice = result.RUnitPrice;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
