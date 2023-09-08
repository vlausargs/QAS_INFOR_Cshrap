//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemPortalPriceAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemPortalPriceAlls")]
	public class SLItemPortalPriceAlls : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetPortalItemPricingOptionsSp(string Item,
		string CustNum,
		int? B2BPricingOptions,
		string CurrCode,
		string PrimarySite,
		string ResellerSlsman,
		string PricingPrecalculationRule,
		int? GenericIfNoCustSpecific,
		string ShipFromSite,
		string LCID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetPortalItemPricingOptionsExt = new CLM_GetPortalItemPricingOptionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetPortalItemPricingOptionsExt.CLM_GetPortalItemPricingOptionsSp(Item,
				CustNum,
				B2BPricingOptions,
				CurrCode,
				PrimarySite,
				ResellerSlsman,
				PricingPrecalculationRule,
				GenericIfNoCustSpecific,
				ShipFromSite,
				LCID,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
