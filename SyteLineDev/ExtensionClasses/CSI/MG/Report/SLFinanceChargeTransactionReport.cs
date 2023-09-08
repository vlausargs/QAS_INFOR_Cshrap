//PROJECT NAME: ReportExt
//CLASS NAME: SLFinanceChargeTransactionReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLFinanceChargeTransactionReport")]
	public class SLFinanceChargeTransactionReport : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ArSumFinanceChargeTransactionSp([Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? PDisplayHeader,
		[Optional] Guid? PSessionID,
		[Optional] string pSite,
		[Optional] string GroupBy)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ArSumFinanceChargeTransactionExt = new Rpt_ArSumFinanceChargeTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ArSumFinanceChargeTransactionExt.Rpt_ArSumFinanceChargeTransactionSp(CustomerStarting,
				CustomerEnding,
				PDisplayHeader,
				PSessionID,
				pSite,
				GroupBy);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FinanceChargeTransactionSp([Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? PDisplayHeader,
		[Optional] Guid? PSessionID,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_FinanceChargeTransactionExt = new Rpt_FinanceChargeTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_FinanceChargeTransactionExt.Rpt_FinanceChargeTransactionSp(CustomerStarting,
				CustomerEnding,
				PDisplayHeader,
				PSessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
