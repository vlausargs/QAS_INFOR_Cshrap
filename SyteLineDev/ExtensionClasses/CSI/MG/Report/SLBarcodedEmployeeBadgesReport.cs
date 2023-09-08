//PROJECT NAME: ReportExt
//CLASS NAME: SLBarcodedEmployeeBadgesReport.cs

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
    [IDOExtensionClass("SLBarcodedEmployeeBadgesReport")]
    public class SLBarcodedEmployeeBadgesReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BarcodedEmployeeBadgesSp([Optional, DefaultParameterValue(2)] int? LabelSets,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayText,
		[Optional] string EmployeeStarting,
		[Optional] string EmployeeEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_BarcodedEmployeeBadgesExt = new Rpt_BarcodedEmployeeBadgesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_BarcodedEmployeeBadgesExt.Rpt_BarcodedEmployeeBadgesSp(LabelSets,
				                                                                         DisplayText,
				                                                                         EmployeeStarting,
				                                                                         EmployeeEnding,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
