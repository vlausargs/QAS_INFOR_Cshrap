//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBTrialBalanceReport.cs

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
	[IDOExtensionClass("SLMultiFSBTrialBalanceReport")]
	public class SLMultiFSBTrialBalanceReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MultiFSBAccountBalancesSp([Optional] DateTime? ExOptacAsOfDate,
		[Optional] string ExStartingAccount,
		[Optional] string ExEndingAccount,
		[Optional, DefaultParameterValue(0)] int? PUnitCode1,
		[Optional, DefaultParameterValue(0)] int? PUnitCode2,
		[Optional, DefaultParameterValue(0)] int? PUnitCode3,
		[Optional, DefaultParameterValue(0)] int? PUnitCode4,
		[Optional] string UnitCode1Starting,
		[Optional] string UnitCode1Ending,
		[Optional] string UnitCode2Starting,
		[Optional] string UnitCode2Ending,
		[Optional] string UnitCode3Starting,
		[Optional] string UnitCode3Ending,
		[Optional] string UnitCode4Starting,
		[Optional] string UnitCode4Ending,
		[Optional] string ExOptacChartType,
		[Optional] int? DateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string FSBName,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MultiFSBAccountBalancesExt = new Rpt_MultiFSBAccountBalancesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MultiFSBAccountBalancesExt.Rpt_MultiFSBAccountBalancesSp(ExOptacAsOfDate,
				ExStartingAccount,
				ExEndingAccount,
				PUnitCode1,
				PUnitCode2,
				PUnitCode3,
				PUnitCode4,
				UnitCode1Starting,
				UnitCode1Ending,
				UnitCode2Starting,
				UnitCode2Ending,
				UnitCode3Starting,
				UnitCode3Ending,
				UnitCode4Starting,
				UnitCode4Ending,
				ExOptacChartType,
				DateOffset,
				DisplayHeader,
				FSBName,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
