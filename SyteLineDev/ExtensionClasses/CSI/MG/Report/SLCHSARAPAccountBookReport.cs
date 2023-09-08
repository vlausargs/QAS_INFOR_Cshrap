//PROJECT NAME: ReportExt
//CLASS NAME: SLCHSARAPAccountBookReport.cs

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
    [IDOExtensionClass("SLCHSARAPAccountBookReport")]
    public class SLCHSARAPAccountBookReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_ARAPAccountBookSp([Optional] string AccountUnit,
		                                          [Optional] string CustVend,
		                                          [Optional] string Account,
		                                          [Optional] string Unit1,
		                                          [Optional] string Unit2,
		                                          [Optional] string Unit3,
		                                          [Optional] string Unit4,
		                                          [Optional] string BegCust,
		                                          [Optional] string EndCust,
		                                          [Optional] string BegVend,
		                                          [Optional] string EndVend,
		                                          [Optional] DateTime? BegDate,
		                                          [Optional] DateTime? EndDate,
		                                          [Optional, DefaultParameterValue((byte)1)] byte? DetailShow,
		[Optional, DefaultParameterValue((byte)1)] byte? Currency,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_ARAPAccountBookExt = new CHSRpt_ARAPAccountBookFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_ARAPAccountBookExt.CHSRpt_ARAPAccountBookSp(AccountUnit,
				                                                                 CustVend,
				                                                                 Account,
				                                                                 Unit1,
				                                                                 Unit2,
				                                                                 Unit3,
				                                                                 Unit4,
				                                                                 BegCust,
				                                                                 EndCust,
				                                                                 BegVend,
				                                                                 EndVend,
				                                                                 BegDate,
				                                                                 EndDate,
				                                                                 DetailShow,
				                                                                 Currency,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
