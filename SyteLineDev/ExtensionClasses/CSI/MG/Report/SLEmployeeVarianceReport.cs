//PROJECT NAME: ReportExt
//CLASS NAME: SLEmployeeVarianceReport.cs

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
    [IDOExtensionClass("SLEmployeeVarianceReport")]
    public class SLEmployeeVarianceReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmployeeVarianceSp([Optional] string ExBegEmpnum,
		                                        [Optional] string ExEndEmpnum,
		                                        [Optional] string ExOptprPostedEmp,
		                                        [Optional] string ExOptdfEmplType,
		                                        [Optional] DateTime? ExBegTrANDate,
		                                        [Optional] DateTime? ExEndTrANDate,
		                                        [Optional] string ExBegJob,
		                                        [Optional] string ExEndJob,
		                                        [Optional] short? ExBegsuffix,
		                                        [Optional] short? ExEndsuffix,
		                                        [Optional] short? TrANDateStartingOffSET,
		                                        [Optional] short? TrANDateENDingOffSET,
		                                        [Optional, DefaultParameterValue((byte)0)] byte? PrintCost,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EmployeeVarianceExt = new Rpt_EmployeeVarianceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EmployeeVarianceExt.Rpt_EmployeeVarianceSp(ExBegEmpnum,
				                                                             ExEndEmpnum,
				                                                             ExOptprPostedEmp,
				                                                             ExOptdfEmplType,
				                                                             ExBegTrANDate,
				                                                             ExEndTrANDate,
				                                                             ExBegJob,
				                                                             ExEndJob,
				                                                             ExBegsuffix,
				                                                             ExEndsuffix,
				                                                             TrANDateStartingOffSET,
				                                                             TrANDateENDingOffSET,
				                                                             PrintCost,
				                                                             DisplayHeader,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
