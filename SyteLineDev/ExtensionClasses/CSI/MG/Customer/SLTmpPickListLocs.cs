//PROJECT NAME: CustomerExt
//CLASS NAME: SLTmpPickListLocs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLTmpPickListLocs")]
	public class SLTmpPickListLocs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PickConfirmationCompleteSp(Guid? ProcessId,
		                                      decimal? PPickListID,
		                                      byte? RecordDiff,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPickConfirmationCompleteExt = new PickConfirmationCompleteFactory().Create(appDb);
				
				int Severity = iPickConfirmationCompleteExt.PickConfirmationCompleteSp(ProcessId,
				                                                                       PPickListID,
				                                                                       RecordDiff,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PickConfirmationSp(Guid? ProcessId,
		                              decimal? PPickListID,
		                              int? RecordDiff,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPickConfirmationExt = new PickConfirmationFactory().Create(appDb);
				
				int Severity = iPickConfirmationExt.PickConfirmationSp(ProcessId,
				                                                       PPickListID,
				                                                       RecordDiff,
				                                                       ref Infobar);
				
				return Severity;
			}
		}









		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UnpickPickListPopulateSp(decimal? picklistid,
		Guid? processid,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUnpickPickListPopulateExt = new UnpickPickListPopulateFactory().Create(appDb);
				
				var result = iUnpickPickListPopulateExt.UnpickPickListPopulateSp(picklistid,
				processid,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UnpickPickListProcessSp(Guid? processid,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUnpickPickListProcessExt = new UnpickPickListProcessFactory().Create(appDb);
				
				var result = iUnpickPickListProcessExt.UnpickPickListProcessSp(processid,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
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
		public int ValidateRestrictedTransSp([Optional] string Item,
		[Optional] string Lot,
		[Optional] string SerialNums,
		string MatlTransType,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] decimal? RefId,
		[Optional] string RefType,
		[Optional] Guid? ProcessId,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateRestrictedTransExt = new ValidateRestrictedTransFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateRestrictedTransExt.ValidateRestrictedTransSp(Item,
				Lot,
				SerialNums,
				MatlTransType,
				Infobar,
				RefId,
				RefType,
				ProcessId,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
