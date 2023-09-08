//PROJECT NAME: CustomerExt
//CLASS NAME: SLTmpCoShips.cs

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
	[IDOExtensionClass("SLTmpCoShips")]
	public class SLTmpCoShips : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PurgeTmpCoShipSp(Guid? ProcessId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPurgeTmpCoShipExt = new PurgeTmpCoShipFactory().Create(appDb);
				
				var result = iPurgeTmpCoShipExt.PurgeTmpCoShipSp(ProcessId);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TmpCoShipUpdSp(Guid? RowPointer,
		int? Selected)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTmpCoShipUpdExt = new TmpCoShipUpdFactory().Create(appDb);
				
				var result = iTmpCoShipUpdExt.TmpCoShipUpdSp(RowPointer,
				Selected);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BuildTmpCoShipSp(Guid? ProcessId,
		int? COTypeA,
		int? COTypeB,
		string Status,
		string StartingOrder,
		string EndingOrder,
		string StartingCustomer,
		string EndingCustomer,
		DateTime? StartingOrderDate,
		DateTime? EndingOrderDate,
		DateTime? StartingDueDate,
		DateTime? EndingDueDate,
		string CoitemStatus,
		int? StartingLine,
		int? EndingLine,
		int? StartingRelease,
		int? EndingRelease,
		int? SelectShipments,
		string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBuildTmpCoShipExt = new BuildTmpCoShipFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBuildTmpCoShipExt.BuildTmpCoShipSp(ProcessId,
				COTypeA,
				COTypeB,
				Status,
				StartingOrder,
				EndingOrder,
				StartingCustomer,
				EndingCustomer,
				StartingOrderDate,
				EndingOrderDate,
				StartingDueDate,
				EndingDueDate,
				CoitemStatus,
				StartingLine,
				EndingLine,
				StartingRelease,
				EndingRelease,
				SelectShipments,
				Whse);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TmpCoShipSp(Guid? ProcessId,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_TmpCoShipExt = new CLM_TmpCoShipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_TmpCoShipExt.CLM_TmpCoShipSp(ProcessId,
				PCoNum,
				PCoLine,
				PCoRelease,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
