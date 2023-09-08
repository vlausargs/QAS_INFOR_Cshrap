//PROJECT NAME: ReportExt
//CLASS NAME: SLUnitofMeasureConversionErrorReport.cs

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
	[IDOExtensionClass("SLUnitofMeasureConversionErrorReport")]
	public class SLUnitofMeasureConversionErrorReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_UmCheckSp(string Selection,
		string OldUM,
		string NewUM,
		string Item,
		string ConvType,
		string CustVendType,
		decimal? ConvFactor,
		decimal? ConvDivisor,
		int? RptFlag,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_UmCheckExt = new Rpt_UmCheckFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_UmCheckExt.Rpt_UmCheckSp(Selection,
				OldUM,
				NewUM,
				Item,
				ConvType,
				CustVendType,
				ConvFactor,
				ConvDivisor,
				RptFlag,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
