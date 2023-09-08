//PROJECT NAME: CustomerExt
//CLASS NAME: SLPickWorkbenchs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLPickWorkbenchs")]
	public class SLPickWorkbenchs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckAssignedLocationsSp(Guid? ProcessId,
			ref string Infobar)
		{
			var iCheckAssignedLocationsExt = this.GetService<ICheckAssignedLocations>();

			var result = iCheckAssignedLocationsExt.CheckAssignedLocationsSp(ProcessId,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteTmpPickListSp(Guid? ProcessID,
		                               string CoNum,
		                               short? CoLIne,
		                               short? CoRelease,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeleteTmpPickListExt = new DeleteTmpPickListFactory().Create(appDb);
				
				int Severity = iDeleteTmpPickListExt.DeleteTmpPickListSp(ProcessID,
				                                                         CoNum,
				                                                         CoLIne,
				                                                         CoRelease,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

        








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePickListLocSerialSp(Guid? ProcessId,
		                                       byte? AssignLoc,
		                                       byte? AssignSerial,
		                                       byte? SkipOrderLineCycCnt,
		                                       byte? SkipOrderLineQtyNotAvail,
		                                       byte? IncludeZeroQuantityAvailableKitItems,
		                                       ref string Infobar,
		                                       [Optional, DefaultParameterValue((byte)0)] byte? AvailableParmChanged)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGeneratePickListLocSerialExt = new GeneratePickListLocSerialFactory().Create(appDb);
				
				var result = iGeneratePickListLocSerialExt.GeneratePickListLocSerialSp(ProcessId,
				                                                                       AssignLoc,
				                                                                       AssignSerial,
				                                                                       SkipOrderLineCycCnt,
				                                                                       SkipOrderLineQtyNotAvail,
				                                                                       IncludeZeroQuantityAvailableKitItems,
				                                                                       Infobar,
				                                                                       AvailableParmChanged);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePickListSp(Guid? ProcessId,
		                              string PPicker,
		                              string PPackLoc,
		                              ref Guid? BGTaskProcessId1,
		                              ref Guid? BGTaskProcessId2,
		                              ref decimal? StartingPickListId,
		                              ref decimal? EndingPickListId,
		                              byte? PrintPickList,
		                              byte? GenerateBulkPickList,
		                              ref string InfoBar,
		                              [Optional] string WareHouse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGeneratePickListExt = new GeneratePickListFactory().Create(appDb);
				
				var result = iGeneratePickListExt.GeneratePickListSp(ProcessId,
				                                                     PPicker,
				                                                     PPackLoc,
				                                                     BGTaskProcessId1,
				                                                     BGTaskProcessId2,
				                                                     StartingPickListId,
				                                                     EndingPickListId,
				                                                     PrintPickList,
				                                                     GenerateBulkPickList,
				                                                     InfoBar,
				                                                     WareHouse);
				
				int Severity = result.ReturnCode.Value;
				BGTaskProcessId1 = result.BGTaskProcessId1;
				BGTaskProcessId2 = result.BGTaskProcessId2;
				StartingPickListId = result.StartingPickListId;
				EndingPickListId = result.EndingPickListId;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SkipOrderLinesWithAvailableIs0Sp(Guid? ProcessId,
		int? SkipOrderLineWhenQuantityAvailableIs0,
		int? IncludeZeroQuantityAvailableKitItems,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSkipOrderLinesWithAvailableIs0Ext = new SkipOrderLinesWithAvailableIs0Factory().Create(appDb);
				
				var result = iSkipOrderLinesWithAvailableIs0Ext.SkipOrderLinesWithAvailableIs0Sp(ProcessId,
				SkipOrderLineWhenQuantityAvailableIs0,
				IncludeZeroQuantityAvailableKitItems,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SkipRemainingOrderLineSp(Guid? ProcessId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSkipRemainingOrderLineExt = new SkipRemainingOrderLineFactory().Create(appDb);
				
				var result = iSkipRemainingOrderLineExt.SkipRemainingOrderLineSp(ProcessId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePickSerialCountSp(Guid? ProcessId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePickSerialCountExt = new ValidatePickSerialCountFactory().Create(appDb);
				
				var result = iValidatePickSerialCountExt.ValidatePickSerialCountSp(ProcessId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AddTmpPickListSp(Guid? ProcessID,
		string CoNum,
		int? CoLIne,
		int? CoRelease,
		DateTime? DueDate,
		string Item,
		string UM,
		decimal? PickQty,
		string CustNum,
		int? CustSeq,
		int? Group,
		string Whse,
		string PackLoc,
		string Picker,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAddTmpPickListExt = new AddTmpPickListFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAddTmpPickListExt.AddTmpPickListSp(ProcessID,
				CoNum,
				CoLIne,
				CoRelease,
				DueDate,
				Item,
				UM,
				PickQty,
				CustNum,
				CustSeq,
				Group,
				Whse,
				PackLoc,
				Picker,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeTmpPickListLocSerialSp(Guid? processid)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPurgeTmpPickListLocSerialExt = new PurgeTmpPickListLocSerialFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPurgeTmpPickListLocSerialExt.PurgeTmpPickListLocSerialSp(processid);
				
				int Severity = result.Value;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeTmpPickListSp(Guid? processid)
		{
			var iPurgeTmpPickListExt = new PurgeTmpPickListFactory().Create(this, true);

			var result = iPurgeTmpPickListExt.PurgeTmpPickListSp(processid);

			return result ?? 0;
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
    }
}
