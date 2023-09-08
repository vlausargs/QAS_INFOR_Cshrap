//PROJECT NAME: ReportExt
//CLASS NAME: SLEmployeeEEOStatusReport.cs

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
    [IDOExtensionClass("SLEmployeeEEOStatusReport")]
    public class SLEmployeeEEOStatusReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EmployeeEEOStatusSp([Optional] string SEeoClass,
		                                         [Optional] string EEeoClass,
		                                         [Optional] string SEmpNum,
		                                         [Optional] string EEmpNum,
		                                         [Optional] string SDept,
		                                         [Optional] string EDept,
		                                         [Optional] DateTime? SHireDate,
		                                         [Optional] DateTime? EHireDate,
		                                         [Optional] string EmpStatus,
		                                         [Optional] string SortBy,
		                                         [Optional] short? SHireDateOffset,
		                                         [Optional] short? EHireDateOffset,
		                                         [Optional] byte? DisplayHeader,
		                                         [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EmployeeEEOStatusExt = new Rpt_EmployeeEEOStatusFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EmployeeEEOStatusExt.Rpt_EmployeeEEOStatusSp(SEeoClass,
				                                                               EEeoClass,
				                                                               SEmpNum,
				                                                               EEmpNum,
				                                                               SDept,
				                                                               EDept,
				                                                               SHireDate,
				                                                               EHireDate,
				                                                               EmpStatus,
				                                                               SortBy,
				                                                               SHireDateOffset,
				                                                               EHireDateOffset,
				                                                               DisplayHeader,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
