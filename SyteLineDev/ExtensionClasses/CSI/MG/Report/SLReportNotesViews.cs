//PROJECT NAME: ReportExt
//CLASS NAME: SLReportNotesViews.cs

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
    [IDOExtensionClass("SLReportNotesViews")]
    public class SLReportNotesViews : CSIExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_NotesSp([Optional] Guid? pRefRowPointer,
			[Optional, DefaultParameterValue(1)] int? pShowExternal,
			[Optional, DefaultParameterValue(1)] int? pShowInternal)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_NotesExt = new Rpt_NotesFactory().Create(appDb,
					bunchedLoadCollection,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);
				
				var result = iRpt_NotesExt.Rpt_NotesSp(pRefRowPointer,
					pShowExternal,
					pShowInternal);
				
				if (result.Data is null)
					return new DataTable();
				else
				{
					IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
					return recordCollectionToDataTable.ToDataTable(result.Data.Items);
				}
			}
		}
    }
}
