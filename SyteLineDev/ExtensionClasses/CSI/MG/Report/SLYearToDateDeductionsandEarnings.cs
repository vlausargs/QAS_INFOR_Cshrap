//PROJECT NAME: ReportExt
//CLASS NAME: SLYearToDateDeductionsandEarnings.cs

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
	[IDOExtensionClass("SLYearToDateDeductionsandEarnings")]
	public class SLYearToDateDeductionsandEarnings : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_YearToDateDeductionsandEarningsSp([Optional] string ExBegDepart,
		[Optional] string ExEndDepart,
		[Optional] string ExBegEmp,
		[Optional] string ExEndEmp,
		[Optional] DateTime? ExBegCheckDate,
		[Optional] DateTime? ExEndCheckDate,
		[Optional] string ExOptdfEmplType,
		[Optional] string ExBegPrdecdCode,
		[Optional] string ExEndPrdecdCode,
		[Optional] string ExOptdfDeCodeType,
		[Optional] string ExOptprPrSortBy,
		[Optional] int? DisplayHeader,
		[Optional] int? DateStartingOffset,
		[Optional] int? DateEndingOffset,
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
				
				var iRpt_YearToDateDeductionsandEarningsExt = new Rpt_YearToDateDeductionsandEarningsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_YearToDateDeductionsandEarningsExt.Rpt_YearToDateDeductionsandEarningsSp(ExBegDepart,
				ExEndDepart,
				ExBegEmp,
				ExEndEmp,
				ExBegCheckDate,
				ExEndCheckDate,
				ExOptdfEmplType,
				ExBegPrdecdCode,
				ExEndPrdecdCode,
				ExOptdfDeCodeType,
				ExOptprPrSortBy,
				DisplayHeader,
				DateStartingOffset,
				DateEndingOffset,
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
