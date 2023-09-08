//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceContractSROGenerationReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.FieldService;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLServiceContractSROGenerationReport")]
	public class SLServiceContractSROGenerationReport : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSContSROGenSp(string StartContract,
		string EndContract,
		string StartCustNum,
		string EndCustNum,
		DateTime? ThroughDate,
		int? CreateSROs,
		[Optional] int? ThroughDateOffset,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSContSROGenExt = new SSSFSContSROGenFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSContSROGenExt.SSSFSContSROGenSp(StartContract,
				EndContract,
				StartCustNum,
				EndCustNum,
				ThroughDate,
				CreateSROs,
				ThroughDateOffset,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
