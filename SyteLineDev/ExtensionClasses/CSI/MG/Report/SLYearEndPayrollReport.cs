//PROJECT NAME: ReportExt
//CLASS NAME: SLYearEndPayrollReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLYearEndPayrollReport")]
    public class SLYearEndPayrollReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_YearEndPayrollSp([Optional] string ExBegDepart,
		[Optional] string ExEndDepart,
		[Optional] string ExBegEmp,
		[Optional] string ExEndEmp,
		[Optional] string ExOptdfEmplType,
		[Optional] int? ExOptprPageBetween,
		[Optional] DateTime? ExBegQuarter1,
		[Optional] DateTime? ExEndQuarter1,
		[Optional] DateTime? ExOptprQuarter2,
		[Optional] DateTime? ExOptprQuarter3,
		[Optional] DateTime? ExOptprQuarter4,
		[Optional] int? DateStartingOffSET,
		[Optional] int? DateEndingOffSET,
		[Optional] int? DateQuarter2OffSET,
		[Optional] int? DateQuarter3OffSET,
		[Optional] int? DateQuarter4OffSET,
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
				
				var iRpt_YearEndPayrollExt = new Rpt_YearEndPayrollFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_YearEndPayrollExt.Rpt_YearEndPayrollSp(ExBegDepart,
				ExEndDepart,
				ExBegEmp,
				ExEndEmp,
				ExOptdfEmplType,
				ExOptprPageBetween,
				ExBegQuarter1,
				ExEndQuarter1,
				ExOptprQuarter2,
				ExOptprQuarter3,
				ExOptprQuarter4,
				DateStartingOffSET,
				DateEndingOffSET,
				DateQuarter2OffSET,
				DateQuarter3OffSET,
				DateQuarter4OffSET,
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
