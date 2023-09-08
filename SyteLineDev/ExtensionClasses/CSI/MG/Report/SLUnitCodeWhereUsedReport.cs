//PROJECT NAME: ReportExt
//CLASS NAME: SLUnitCodeWhereUsedReport.cs

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
	[IDOExtensionClass("SLUnitCodeWhereUsedReport")]
	public class SLUnitCodeWhereUsedReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_UnitCodeWhereUsedSp([Optional] string UnitCode1Starting,
		[Optional] string UnitCode1Ending,
		[Optional] string UnitCode2Starting,
		[Optional] string UnitCode2Ending,
		[Optional] string UnitCode3Starting,
		[Optional] string UnitCode3Ending,
		[Optional] string UnitCode4Starting,
		[Optional] string UnitCode4Ending,
		[Optional] int? DisplayHeader,
		[Optional] string MessageLanguage,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_UnitCodeWhereUsedExt = new Rpt_UnitCodeWhereUsedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_UnitCodeWhereUsedExt.Rpt_UnitCodeWhereUsedSp(UnitCode1Starting,
				UnitCode1Ending,
				UnitCode2Starting,
				UnitCode2Ending,
				UnitCode3Starting,
				UnitCode3Ending,
				UnitCode4Starting,
				UnitCode4Ending,
				DisplayHeader,
				MessageLanguage,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
