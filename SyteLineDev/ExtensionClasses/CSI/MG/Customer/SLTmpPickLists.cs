//PROJECT NAME: CustomerExt
//CLASS NAME: SLTmpPickLists.cs

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
	[IDOExtensionClass("SLTmpPickLists")]
	public class SLTmpPickLists : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PickListSplittingSp(decimal? OldPickList,
		                               Guid? ProcessId,
		                               ref decimal? NewPickList,
		                               ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPickListSplittingExt = new PickListSplittingFactory().Create(appDb);
				
				int Severity = iPickListSplittingExt.PickListSplittingSp(OldPickList,
				                                                         ProcessId,
				                                                         ref NewPickList,
				                                                         ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PopulateTmpPickList_ForSplitSp(decimal? picklistid,
		                                          Guid? processid)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPopulateTmpPickList_ForSplitExt = new PopulateTmpPickList_ForSplitFactory().Create(appDb);
				
				int Severity = iPopulateTmpPickList_ForSplitExt.PopulateTmpPickList_ForSplitSp(picklistid,
				                                                                               processid);
				
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
