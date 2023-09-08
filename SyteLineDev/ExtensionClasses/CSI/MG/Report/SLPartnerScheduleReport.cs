//PROJECT NAME: ReportExt
//CLASS NAME: SLPartnerScheduleReport.cs

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
	[IDOExtensionClass("SLPartnerScheduleReport")]
	public class SLPartnerScheduleReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_PartnerScheduleSp([Optional] string BeginSRONum,
		[Optional] string EndSRONum,
		[Optional] DateTime? BeginSchedDate,
		[Optional] DateTime? EndSchedDate,
		[Optional] string BeginPartnerID,
		[Optional] string EndPartnerID,
		[Optional] string BeginIncident,
		[Optional] string EndIncident,
		[Optional] int? ScheduleDetailYN,
		[Optional] int? CustomerDetailYN,
		[Optional] int? ScheduleTextYN,
		[Optional] int? PageBreak,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue(1)] int? MiscRef,
		[Optional, DefaultParameterValue(1)] int? SRORef,
		[Optional, DefaultParameterValue(1)] int? IncRef,
		[Optional, DefaultParameterValue("P")] string OrderBy,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_PartnerScheduleExt = new SSSFSRpt_PartnerScheduleFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_PartnerScheduleExt.SSSFSRpt_PartnerScheduleSp(BeginSRONum,
				EndSRONum,
				BeginSchedDate,
				EndSchedDate,
				BeginPartnerID,
				EndPartnerID,
				BeginIncident,
				EndIncident,
				ScheduleDetailYN,
				CustomerDetailYN,
				ScheduleTextYN,
				PageBreak,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				MiscRef,
				SRORef,
				IncRef,
				OrderBy,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
