//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPQuoteLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.PrintingPackaging;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PPIndPack
{
	[IDOExtensionClass("PPQuoteLines")]
	public class PPQuoteLines : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_GetItemInfoAndPriceSp(string Item,
		string CustNum,
		decimal? ItemQtyOrdered,
		string MaterialSource,
		string PaperSource,
		ref string ItemItem,
		ref string ItemUM,
		ref decimal? ItemLengthLinearDimension,
		ref decimal? ItemWidthLinearDimension,
		ref decimal? ItemHeightLinearDimension,
		ref string ItemLinearDimensionUM,
		ref decimal? ItemWeight,
		ref string ItemWeightUM,
		ref decimal? ItemPrice)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_GetItemInfoAndPriceExt = new PP_GetItemInfoAndPriceFactory().Create(appDb);
				
				var result = iPP_GetItemInfoAndPriceExt.PP_GetItemInfoAndPriceSp(Item,
				CustNum,
				ItemQtyOrdered,
				MaterialSource,
				PaperSource,
				ItemItem,
				ItemUM,
				ItemLengthLinearDimension,
				ItemWidthLinearDimension,
				ItemHeightLinearDimension,
				ItemLinearDimensionUM,
				ItemWeight,
				ItemWeightUM,
				ItemPrice);
				
				int Severity = result.ReturnCode.Value;
				ItemItem = result.ItemItem;
				ItemUM = result.ItemUM;
				ItemLengthLinearDimension = result.ItemLengthLinearDimension;
				ItemWidthLinearDimension = result.ItemWidthLinearDimension;
				ItemHeightLinearDimension = result.ItemHeightLinearDimension;
				ItemLinearDimensionUM = result.ItemLinearDimensionUM;
				ItemWeight = result.ItemWeight;
				ItemWeightUM = result.ItemWeightUM;
				ItemPrice = result.ItemPrice;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetPrintQuoteSectionPriceSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		int? SectionNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetPrintQuoteSectionPriceExt = new SetPrintQuoteSectionPriceFactory().Create(appDb);
				
				var result = iSetPrintQuoteSectionPriceExt.SetPrintQuoteSectionPriceSp(CoNum,
				CoLine,
				CoRelease,
				SectionNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PP_CLM_LoadEstimateWorksheetDataSp(string CoNum,
		int? CoLine,
		decimal? CompQty2,
		decimal? CompQty3,
		decimal? CompQty4,
		decimal? CompQty5,
		ref string Infobar,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPP_CLM_LoadEstimateWorksheetDataExt = new PP_CLM_LoadEstimateWorksheetDataFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPP_CLM_LoadEstimateWorksheetDataExt.PP_CLM_LoadEstimateWorksheetDataSp(CoNum,
				CoLine,
				CompQty2,
				CompQty3,
				CompQty4,
				CompQty5,
				Infobar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
