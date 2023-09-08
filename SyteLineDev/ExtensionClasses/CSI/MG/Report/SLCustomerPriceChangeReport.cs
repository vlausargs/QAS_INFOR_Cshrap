//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerPriceChangeReport.cs

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
	[IDOExtensionClass("SLCustomerPriceChangeReport")]
	public class SLCustomerPriceChangeReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		DateTime? FromEffectDate,
		DateTime? ToEffectDate,
		string FromCustNum,
		string ToCustNum,
		string FromCustType,
		string ToCustType,
		string FromEndUserType,
		string ToEndUserType,
		DateTime? NewEffectDate,
		[Optional, DefaultParameterValue(0)] int? UpdateCreate,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional, DefaultParameterValue("A")] string AmtType,
		[Optional, DefaultParameterValue(0)] decimal? PriAmt,
		[Optional] string FromCurrCode,
		[Optional] string ToCurrCode,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CustomerPriceChangeExt = new Rpt_CustomerPriceChangeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CustomerPriceChangeExt.Rpt_CustomerPriceChangeSp(FromProductCode,
				ToProductCode,
				FromItem,
				ToItem,
				FromEffectDate,
				ToEffectDate,
				FromCustNum,
				ToCustNum,
				FromCustType,
				ToCustType,
				FromEndUserType,
				ToEndUserType,
				NewEffectDate,
				UpdateCreate,
				DisplayHeader,
				AmtType,
				PriAmt,
				FromCurrCode,
				ToCurrCode,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
