//PROJECT NAME: ReportExt
//CLASS NAME: SLItemPriceChangeReport.cs

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
    [IDOExtensionClass("SLItemPriceChangeReport")]
    public class SLItemPriceChangeReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemPriceChangeSp(string FromProductCode,
		                                       string ToProductCode,
		                                       string FromItem,
		                                       string ToItem,
		                                       DateTime? FromEffectDate,
		                                       DateTime? ToEffectDate,
		                                       string FromPriceCode,
		                                       string ToPriceCode,
		                                       string FromCurrCode,
		                                       string ToCurrCode,
		                                       DateTime? NewEffectDate,
		                                       [Optional, DefaultParameterValue((byte)1)] byte? UpdateCreate,
		[Optional, DefaultParameterValue((byte)0)] byte? ItmPrc1,
		[Optional, DefaultParameterValue((byte)0)] byte? ItmPrc2,
		[Optional, DefaultParameterValue((byte)0)] byte? ItmPrc3,
		[Optional, DefaultParameterValue((byte)0)] byte? ItmPrc4,
		[Optional, DefaultParameterValue((byte)0)] byte? ItmPrc5,
		[Optional, DefaultParameterValue((byte)0)] byte? ItmPrc6,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
		string PriWhole,
		[Optional, DefaultParameterValue("A")] string AmtType,
		[Optional, DefaultParameterValue(0)] decimal? PriAmt,
		[Optional] short? StartingEffectDateOffset,
		[Optional] short? EndingEffectDateOffset,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemPriceChangeExt = new Rpt_ItemPriceChangeFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemPriceChangeExt.Rpt_ItemPriceChangeSp(FromProductCode,
				                                                           ToProductCode,
				                                                           FromItem,
				                                                           ToItem,
				                                                           FromEffectDate,
				                                                           ToEffectDate,
				                                                           FromPriceCode,
				                                                           ToPriceCode,
				                                                           FromCurrCode,
				                                                           ToCurrCode,
				                                                           NewEffectDate,
				                                                           UpdateCreate,
				                                                           ItmPrc1,
				                                                           ItmPrc2,
				                                                           ItmPrc3,
				                                                           ItmPrc4,
				                                                           ItmPrc5,
				                                                           ItmPrc6,
				                                                           DisplayHeader,
				                                                           PriWhole,
				                                                           AmtType,
				                                                           PriAmt,
				                                                           StartingEffectDateOffset,
				                                                           EndingEffectDateOffset,
				                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
