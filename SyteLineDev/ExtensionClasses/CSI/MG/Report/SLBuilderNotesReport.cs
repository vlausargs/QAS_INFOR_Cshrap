//PROJECT NAME: ReportExt
//CLASS NAME: SLBuilderNotesReport.cs

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
    [IDOExtensionClass("SLBuilderNotesReport")]
    public class SLBuilderNotesReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BuilderNotesSp([Optional] Guid? pProcessId,
		                                    [Optional] string pSiteRef,
		                                    [Optional] Guid? pRefRowPointer,
		                                    [Optional] byte? pShowInternal,
		                                    [Optional] byte? pShowExternal,
		                                    [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_BuilderNotesExt = new Rpt_BuilderNotesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_BuilderNotesExt.Rpt_BuilderNotesSp(pProcessId,
				                                                     pSiteRef,
				                                                     pRefRowPointer,
				                                                     pShowInternal,
				                                                     pShowExternal,
				                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
