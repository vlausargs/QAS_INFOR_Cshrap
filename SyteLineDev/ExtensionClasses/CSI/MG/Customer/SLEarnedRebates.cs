//PROJECT NAME: CustomerExt
//CLASS NAME: SLEarnedRebates.cs

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
	[IDOExtensionClass("SLEarnedRebates")]
	public class SLEarnedRebates : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpireEarnedRebateSp(decimal? EarnedRebateId,
		                                string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iExpireEarnedRebateExt = new ExpireEarnedRebateFactory().Create(appDb);
				
				int Severity = iExpireEarnedRebateExt.ExpireEarnedRebateSp(EarnedRebateId,
				                                                           Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetEarnedRebateWorkbenchSp(string PromotionCode,
		                                                [Optional] DateTime? ApplicationDate,
		                                                [Optional, DefaultParameterValue("P")] string EarnedRebateStatusString,
		[Optional] string CustNum,
		ref string InfoBar,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetEarnedRebateWorkbenchExt = new CLM_GetEarnedRebateWorkbenchFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_GetEarnedRebateWorkbenchExt.CLM_GetEarnedRebateWorkbenchSp(PromotionCode,
				                                                                             ApplicationDate,
				                                                                             EarnedRebateStatusString,
				                                                                             CustNum,
				                                                                             InfoBar,
				                                                                             FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EarnedRebateCreditProcessingSp(Guid? EarnedRebateRowPointer,
		DateTime? ApplicationDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEarnedRebateCreditProcessingExt = new EarnedRebateCreditProcessingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEarnedRebateCreditProcessingExt.EarnedRebateCreditProcessingSp(EarnedRebateRowPointer,
				ApplicationDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
