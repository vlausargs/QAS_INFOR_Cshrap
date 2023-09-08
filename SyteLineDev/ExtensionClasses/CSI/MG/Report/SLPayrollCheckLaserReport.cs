//PROJECT NAME: ReportExt
//CLASS NAME: SLPayrollCheckLaserReport.cs

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
	[IDOExtensionClass("SLPayrollCheckLaserReport")]
	public class SLPayrollCheckLaserReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PR01crpDoChecksSp([Optional] string pSessionIDChar,
		[Optional] int? pNewPrCheck,
		[Optional] int? pMaskEmployeeSSN,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PR01crpDoChecksExt = new Rpt_PR01crpDoChecksFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PR01crpDoChecksExt.Rpt_PR01crpDoChecksSp(pSessionIDChar,
				pNewPrCheck,
				pMaskEmployeeSSN,
				BGSessionId,
				TaskId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
