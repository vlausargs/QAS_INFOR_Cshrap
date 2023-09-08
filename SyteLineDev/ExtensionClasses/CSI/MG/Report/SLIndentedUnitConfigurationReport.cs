//PROJECT NAME: ReportExt
//CLASS NAME: SLIndentedUnitConfigurationReport.cs

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
	[IDOExtensionClass("SLIndentedUnitConfigurationReport")]
	public class SLIndentedUnitConfigurationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_IndentedUnitConfigurationSp(string StartingSerNum,
		string EndingSerNum,
		string StartingItem,
		string EndingItem,
		int? IncludeWarranty,
		int? tLevel,
		DateTime? ConfigDate,
		int? tpage,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_IndentedUnitConfigurationExt = new SSSFSRpt_IndentedUnitConfigurationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_IndentedUnitConfigurationExt.SSSFSRpt_IndentedUnitConfigurationSp(StartingSerNum,
				EndingSerNum,
				StartingItem,
				EndingItem,
				IncludeWarranty,
				tLevel,
				ConfigDate,
				tpage,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
