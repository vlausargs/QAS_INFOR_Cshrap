//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemsNonInventoryItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Customer;
using CSI.Material;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLItemsNonInventoryItems")]
    public class SLItemsNonInventoryItems : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetItemsForPOBuilderItemSp([Optional] string Item,
		string SiteRef,
		string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetItemsForPOBuilderItemExt = new CLM_GetItemsForPOBuilderItemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetItemsForPOBuilderItemExt.CLM_GetItemsForPOBuilderItemSp(Item,
				SiteRef,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNonInvItemInfoSp(string Item,
		[Optional] ref string Description,
		[Optional] ref string UM,
		[Optional] ref string MatlType,
		[Optional] ref string Revision,
		[Optional] ref string ProductCode,
		[Optional] ref string DrawingNum,
		[Optional] ref string FamilyCode,
		[Optional] ref string Buyer,
		[Optional] ref string CommCode,
		[Optional] ref string Origin,
		[Optional] ref int? SubjectToNaftaRvc,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitCost,
		[Optional] ref string PrefCrit,
		[Optional] ref int? Producer,
		[Optional] ref string WeightUnit,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitWeight,
		[Optional, DefaultParameterValue(0)] ref decimal? UnitPrice,
		[Optional] ref int? AllowOnPickList,
		[Optional] ref string Infobar,
		[Optional] string CurrCode,
		[Optional] string OrderType,
		[Optional] string OrderKey1)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNonInvItemInfoExt = new GetNonInvItemInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNonInvItemInfoExt.GetNonInvItemInfoSp(Item,
				Description,
				UM,
				MatlType,
				Revision,
				ProductCode,
				DrawingNum,
				FamilyCode,
				Buyer,
				CommCode,
				Origin,
				SubjectToNaftaRvc,
				UnitCost,
				PrefCrit,
				Producer,
				WeightUnit,
				UnitWeight,
				UnitPrice,
				AllowOnPickList,
				Infobar,
				CurrCode,
				OrderType,
				OrderKey1);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				UM = result.UM;
				MatlType = result.MatlType;
				Revision = result.Revision;
				ProductCode = result.ProductCode;
				DrawingNum = result.DrawingNum;
				FamilyCode = result.FamilyCode;
				Buyer = result.Buyer;
				CommCode = result.CommCode;
				Origin = result.Origin;
				SubjectToNaftaRvc = result.SubjectToNaftaRvc;
				UnitCost = result.UnitCost;
				PrefCrit = result.PrefCrit;
				Producer = result.Producer;
				WeightUnit = result.WeightUnit;
				UnitWeight = result.UnitWeight;
				UnitPrice = result.UnitPrice;
				AllowOnPickList = result.AllowOnPickList;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
