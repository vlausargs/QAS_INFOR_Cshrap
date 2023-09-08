//PROJECT NAME: ReportExt
//CLASS NAME: SLCHSThreeBucketReport.cs

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
    [IDOExtensionClass("SLCHSThreeBucketReport")]
    public class SLCHSThreeBucketReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_NotBucketSp(decimal? BookKey,
		                                    string BookType,
		                                    string BeginAccount,
		                                    string EndAccount,
		                                    string BegUnit1,
		                                    string EndUnit1,
		                                    string BegUnit2,
		                                    string EndUnit2,
		                                    string BegUnit3,
		                                    string EndUnit3,
		                                    string BegUnit4,
		                                    string EndUnit4,
		                                    DateTime? BeginDate,
		                                    DateTime? EndDate,
		                                    byte? PrintDayTotal,
		                                    byte? IncludeZeroBalAccount,
		                                    short? RptLines,
		                                    [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_NotBucketExt = new CHSRpt_NotBucketFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_NotBucketExt.CHSRpt_NotBucketSp(BookKey,
				                                                     BookType,
				                                                     BeginAccount,
				                                                     EndAccount,
				                                                     BegUnit1,
				                                                     EndUnit1,
				                                                     BegUnit2,
				                                                     EndUnit2,
				                                                     BegUnit3,
				                                                     EndUnit3,
				                                                     BegUnit4,
				                                                     EndUnit4,
				                                                     BeginDate,
				                                                     EndDate,
				                                                     PrintDayTotal,
				                                                     IncludeZeroBalAccount,
				                                                     RptLines,
				                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
