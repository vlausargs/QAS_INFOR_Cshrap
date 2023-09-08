//PROJECT NAME: ReportExt
//CLASS NAME: CHSPostedVchTrnxByAcctDrilldownReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("CHSPostedVchTrnxByAcctDrilldownReport")]
	public class CHSPostedVchTrnxByAcctDrilldownReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_PostedVchTrnxByAcctSp(string SessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSRpt_PostedVchTrnxByAcctExt = new CHSRpt_PostedVchTrnxByAcctFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSRpt_PostedVchTrnxByAcctExt.CHSRpt_PostedVchTrnxByAcctSp(SessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
