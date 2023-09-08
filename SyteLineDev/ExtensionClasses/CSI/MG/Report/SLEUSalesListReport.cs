//PROJECT NAME: ReportExt
//CLASS NAME: SLEUSalesListReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLEUSalesListReport")]
	public class SLEUSalesListReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ECSalesListSP([Optional] string SiteGroup,
		[Optional] DateTime? BeginInvStaxInvDate,
		[Optional] DateTime? EndInvStaxInvDate,
		[Optional] int? BeginInvStaxInvDateOffset,
		[Optional] int? EndInvStaxInvDateOffset,
		[Optional] string Eceslqtr,
		[Optional] int? Eceslfrt,
		[Optional] int? Eceslmsc,
		[Optional] int? ShowDetail,
		[Optional] string BeginCustNum,
		[Optional] string EndCustNum,
		[Optional] string BeginEcCode,
		[Optional] string EndEcCode,
		[Optional] string BeginProcessInd,
		[Optional] string EndProcessInd,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] int? IncludeTransferOrders,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ECSalesListExt = new Rpt_ECSalesListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ECSalesListExt.Rpt_ECSalesListSP(SiteGroup,
				BeginInvStaxInvDate,
				EndInvStaxInvDate,
				BeginInvStaxInvDateOffset,
				EndInvStaxInvDateOffset,
				Eceslqtr,
				Eceslfrt,
				Eceslmsc,
				ShowDetail,
				BeginCustNum,
				EndCustNum,
				BeginEcCode,
				EndEcCode,
				BeginProcessInd,
				EndProcessInd,
				DisplayHeader,
				TaskId,
				IncludeTransferOrders,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
