//PROJECT NAME: ReportExt
//CLASS NAME: SLInactiveAccountNumbersReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLInactiveAccountNumbersReport")]
    public class SLInactiveAccountNumbersReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InactiveAccountNumbersSp([Optional] DateTime? PStartingEffectiveDate,
		                                              [Optional] DateTime? PEndingEffectiveDate,
		                                              [Optional] DateTime? PStartingObsoleteDate,
		                                              [Optional] DateTime? PEndingObsoleteDate,
		                                              [Optional, DefaultParameterValue("ALORE")] string PAccountType,
		[Optional, DefaultParameterValue((byte)1)] byte? PDisplayHeader,
		[Optional] short? PStartingEffectiveDateOffset,
		[Optional] short? PEndingEffectiveDateOffset,
		[Optional] short? PStartingObsoleteDateOffset,
		[Optional] short? PEndingObsoleteDateOffset,
		[Optional] string PMessageLanguage,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InactiveAccountNumbersExt = new Rpt_InactiveAccountNumbersFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InactiveAccountNumbersExt.Rpt_InactiveAccountNumbersSp(PStartingEffectiveDate,
				                                                                         PEndingEffectiveDate,
				                                                                         PStartingObsoleteDate,
				                                                                         PEndingObsoleteDate,
				                                                                         PAccountType,
				                                                                         PDisplayHeader,
				                                                                         PStartingEffectiveDateOffset,
				                                                                         PEndingEffectiveDateOffset,
				                                                                         PStartingObsoleteDateOffset,
				                                                                         PEndingObsoleteDateOffset,
				                                                                         PMessageLanguage,
				                                                                         pSite,
				                                                                         BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
