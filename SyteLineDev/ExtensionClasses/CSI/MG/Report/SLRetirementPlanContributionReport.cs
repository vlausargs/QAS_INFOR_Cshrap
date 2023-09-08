//PROJECT NAME: ReportExt
//CLASS NAME: SLRetirementPlanContributionReport.cs

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
    [IDOExtensionClass("SLRetirementPlanContributionReport")]
    public class SLRetirementPlanContributionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RetirementPlanContributionSp([Optional] string DeparmentStarting,
		[Optional] string DeparmentEnding,
		[Optional] string EmployeeStarting,
		[Optional] string EmployeeEnding,
		[Optional] DateTime? CheckDateStarting,
		[Optional] DateTime? CheckDateEnding,
		[Optional] string DECodeStarting,
		[Optional] string DECodeEnding,
		[Optional] string DECodeType,
		[Optional] string EmployeeTypes,
		[Optional] int? CheckDateStartingOffset,
		[Optional] int? CheckDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RetirementPlanContributionExt = new Rpt_RetirementPlanContributionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RetirementPlanContributionExt.Rpt_RetirementPlanContributionSp(DeparmentStarting,
				DeparmentEnding,
				EmployeeStarting,
				EmployeeEnding,
				CheckDateStarting,
				CheckDateEnding,
				DECodeStarting,
				DECodeEnding,
				DECodeType,
				EmployeeTypes,
				CheckDateStartingOffset,
				CheckDateEndingOffset,
				DisplayHeader,
				PStartEmpCate,
				PEndEmpCate,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
