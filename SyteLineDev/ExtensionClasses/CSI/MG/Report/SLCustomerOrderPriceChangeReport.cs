//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerOrderPriceChangeReport.cs

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
	[IDOExtensionClass("SLCustomerOrderPriceChangeReport")]
	public class SLCustomerOrderPriceChangeReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerOrderPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		string FromCurrCode,
		string ToCurrCode,
		string FromCustNum,
		string ToCustNum,
		string FromCustType,
		string ToCustType,
		string FromEndUserType,
		string ToEndUserType,
		DateTime? FromDueDate,
		DateTime? ToDueDate,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional, DefaultParameterValue("A")] string AmtType,
		[Optional, DefaultParameterValue(0)] decimal? PriAmt,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CustomerOrderPriceChangeExt = new Rpt_CustomerOrderPriceChangeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CustomerOrderPriceChangeExt.Rpt_CustomerOrderPriceChangeSp(FromProductCode,
				ToProductCode,
				FromItem,
				ToItem,
				FromCurrCode,
				ToCurrCode,
				FromCustNum,
				ToCustNum,
				FromCustType,
				ToCustType,
				FromEndUserType,
				ToEndUserType,
				FromDueDate,
				ToDueDate,
				DisplayHeader,
				AmtType,
				PriAmt,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
