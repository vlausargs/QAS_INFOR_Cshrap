//PROJECT NAME: ReportExt
//CLASS NAME: SLTaxInterfacePostRegisterReport.cs

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
	[IDOExtensionClass("SLTaxInterfacePostRegisterReport")]
	public class SLTaxInterfacePostRegisterReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSVTXPostRegisterSp(string FormCaption,
		int? BGTaskID,
		DateTime? StartingInvDate,
		DateTime? EndingInvDate,
		[Optional] int? StartINV_dateOffSET,
		[Optional] int? ENDINV_dateOffSET,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSVTXPostRegisterExt = new SSSVTXPostRegisterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSVTXPostRegisterExt.SSSVTXPostRegisterSp(FormCaption,
				BGTaskID,
				StartingInvDate,
				EndingInvDate,
				StartINV_dateOffSET,
				ENDINV_dateOffSET,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
