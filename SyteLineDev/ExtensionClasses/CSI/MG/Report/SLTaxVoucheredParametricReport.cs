//PROJECT NAME: ReportExt
//CLASS NAME: SLTaxVoucheredParametricReport.cs

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
    [IDOExtensionClass("SLTaxVoucheredParametricReport")]
    public class SLTaxVoucheredParametricReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TaxVoucheredParametricSp([Optional] int? TaxJurTaxSystem,
		[Optional] int? ExOptszShowDetail,
		[Optional] string TaxJurTaxJur,
		[Optional] DateTime? ExBegInvStaxInvDate,
		[Optional] DateTime? ExENDInvStaxInvDate,
		[Optional] int? ExOptgoInclVchPr,
		[Optional] int? TAXDateStartingOffSET,
		[Optional] int? TAXDateENDingOffSET,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TaxVoucheredParametricExt = new Rpt_TaxVoucheredParametricFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TaxVoucheredParametricExt.Rpt_TaxVoucheredParametricSp(TaxJurTaxSystem,
				ExOptszShowDetail,
				TaxJurTaxJur,
				ExBegInvStaxInvDate,
				ExENDInvStaxInvDate,
				ExOptgoInclVchPr,
				TAXDateStartingOffSET,
				TAXDateENDingOffSET,
				DisplayHeader,
				BGSessionId,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
