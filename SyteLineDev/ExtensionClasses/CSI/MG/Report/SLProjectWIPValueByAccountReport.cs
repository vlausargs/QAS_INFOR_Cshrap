//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectWIPValueByAccountReport.cs

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
    [IDOExtensionClass("SLProjectWIPValueByAccountReport")]
    public class SLProjectWIPValueByAccountReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectWIPValueByAccountSp([Optional] string StartingAccount,
		[Optional] string EndingAccount,
		[Optional] string StartingProdCode,
		[Optional] string EndingProdCode,
		[Optional] string ProjectStatus,
		[Optional, DefaultParameterValue(0)] int? PUnitCode1,
		[Optional, DefaultParameterValue(0)] int? PUnitCode2,
		[Optional, DefaultParameterValue(0)] int? PUnitCode3,
		[Optional, DefaultParameterValue(0)] int? PUnitCode4,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectWIPValueByAccountExt = new Rpt_ProjectWIPValueByAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectWIPValueByAccountExt.Rpt_ProjectWIPValueByAccountSp(StartingAccount,
				EndingAccount,
				StartingProdCode,
				EndingProdCode,
				ProjectStatus,
				PUnitCode1,
				PUnitCode2,
				PUnitCode3,
				PUnitCode4,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
