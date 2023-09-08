//PROJECT NAME: CustomerExt
//CLASS NAME: SLTmpConInvGenerations.cs

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
	[IDOExtensionClass("SLTmpConInvGenerations")]
	public class SLTmpConInvGenerations : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TmpConInvGenerationCleanupSp(Guid? ProcessId)
		{
			var iTmpConInvGenerationCleanupExt = new TmpConInvGenerationCleanupFactory().Create(this, true);
			
			var result = iTmpConInvGenerationCleanupExt.TmpConInvGenerationCleanupSp(ProcessId);
			
			
			return result??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TmpConInvGenerationUpdSp(Guid? SessionId,
		int? Selected,
		string CoNum,
		int? CoLine,
		int? CoRel,
		string CustPo,
		int? Consolidate,
		string InvFreq,
		DateTime? ShipDate,
		Guid? CoitemRowPointer,
		decimal? ShipmentId,
		string CoCustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTmpConInvGenerationUpdExt = new TmpConInvGenerationUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTmpConInvGenerationUpdExt.TmpConInvGenerationUpdSp(SessionId,
				Selected,
				CoNum,
				CoLine,
				CoRel,
				CustPo,
				Consolidate,
				InvFreq,
				ShipDate,
				CoitemRowPointer,
				ShipmentId,
				CoCustNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CiGenSp(string BeginCustomerNum,
		string EndCustomerNum,
		int? OtherInvFreq,
		int? DailyInvFreq,
		int? WeeklyInvFreq,
		int? BiMonthlyInvFreq,
		int? MonthlyInvFreq,
		int? HoldInvFreq,
		int? ProcessCustOrders,
		string BeginCONum,
		string EndCONum,
		int? ProcessDelOrders,
		string BeginDONum,
		string EndDONum,
		string BeginCustPONum,
		string EndCustPONum,
		int? GenerateByShipDate,
		DateTime? ShipDate,
		int? ProcessShipments,
		decimal? BeginShipment,
		decimal? EndShipment,
		Guid? SessionId,
		string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_CiGenExt = new CLM_CiGenFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_CiGenExt.CLM_CiGenSp(BeginCustomerNum,
				EndCustomerNum,
				OtherInvFreq,
				DailyInvFreq,
				WeeklyInvFreq,
				BiMonthlyInvFreq,
				MonthlyInvFreq,
				HoldInvFreq,
				ProcessCustOrders,
				BeginCONum,
				EndCONum,
				ProcessDelOrders,
				BeginDONum,
				EndDONum,
				BeginCustPONum,
				EndCustPONum,
				GenerateByShipDate,
				ShipDate,
				ProcessShipments,
				BeginShipment,
				EndShipment,
				SessionId,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
