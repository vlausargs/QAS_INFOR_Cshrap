//PROJECT NAME: ReportExt
//CLASS NAME: CHSDetailLeftOverAmountReport.cs

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
    [IDOExtensionClass("CHSDetailLeftOverAmountReport")]
    public class CHSDetailLeftOverAmountReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_DetailLeftOverSp(int? PYear,
		                                         int? PPeriod,
		                                         string PText,
		                                         int? PrintZeroBal,
		                                         [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_DetailLeftOverExt = new CHSRpt_DetailLeftOverFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_DetailLeftOverExt.CHSRpt_DetailLeftOverSp(PYear,
				                                                               PPeriod,
				                                                               PText,
				                                                               PrintZeroBal,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
