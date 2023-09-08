//PROJECT NAME: CustomerExt
//CLASS NAME: SLPickLists.cs

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
	[IDOExtensionClass("SLPickLists")]
	public class SLPickLists : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckDelPickSp(decimal? PickListId,
		                          int? Sequence,
		                          ref string Error,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckDelPickExt = new CheckDelPickFactory().Create(appDb);
				
				int Severity = iCheckDelPickExt.CheckDelPickSp(PickListId,
				                                               Sequence,
				                                               ref Error,
				                                               ref Infobar);
				
				return Severity;
			}
		}













		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePickListTmpSp(Guid? ProcessId,
		int? Select,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Whse,
		int? Group,
		string Packer,
		string ParentContainerNum,
		ref string InfoBar,
		[Optional] string RefNum,
		[Optional] int? RefLine,
		[Optional] int? RefRelease,
		[Optional] string RefType,
		[Optional, DefaultParameterValue(0)] decimal? Qty,
		[Optional] string Loc,
		[Optional] string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGeneratePickListTmpExt = new GeneratePickListTmpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGeneratePickListTmpExt.GeneratePickListTmpSp(ProcessId,
				Select,
				PickListId,
				CustNum,
				CustSeq,
				Whse,
				Group,
				Packer,
				ParentContainerNum,
				InfoBar,
				RefNum,
				RefLine,
				RefRelease,
				RefType,
				Qty,
				Loc,
				Lot);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateShipmentSP(Guid? ProcessId,
		string ShipLoc,
		int? Packages,
		decimal? Weight,
		string WeightUm,
		ref string InfoBar,
		[Optional] string ShipmentStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateShipmentExt = new GenerateShipmentFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateShipmentExt.GenerateShipmentSP(ProcessId,
				ShipLoc,
				Packages,
				Weight,
				WeightUm,
				InfoBar,
				ShipmentStatus);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PopulateTmpPickList_ForPrintSp(string Status,
		int? Selected,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Picker,
		int? Printed,
		DateTime? PickDate,
		string Whse,
		string PackLoc,
		Guid? ProcessId1,
		Guid? ProcessId2,
		int? GenerateBulkPickList)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPopulateTmpPickList_ForPrintExt = new PopulateTmpPickList_ForPrintFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPopulateTmpPickList_ForPrintExt.PopulateTmpPickList_ForPrintSp(Status,
				Selected,
				PickListId,
				CustNum,
				CustSeq,
				Picker,
				Printed,
				PickDate,
				Whse,
				PackLoc,
				ProcessId1,
				ProcessId2,
				GenerateBulkPickList);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
