//PROJECT NAME: CustomerExt
//CLASS NAME: SLOpportunityItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLOpportunityItems")]
	public class SLOpportunityItems : ExtensionClassBase
	{        
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PriceCalSp(byte? PShowMatrix,
		string PItem,
		string PCustNum,
		string PCustItem,
		DateTime? PEffDate,
		DateTime? PExpDate,
		decimal? PQtyOrdered,
		string POrderPriceCode,
		string PCurrCode,
		string PConfigString,
		decimal? PRate,
		[Optional] ref decimal? PUnitPrice,
		[Optional] ref decimal? PQtyList__1,
		[Optional] ref decimal? PQtyList__2,
		[Optional] ref decimal? PQtyList__3,
		[Optional] ref decimal? PQtyList__4,
		[Optional] ref decimal? PQtyList__5,
		[Optional] ref decimal? PPriceList__1,
		[Optional] ref decimal? PPriceList__2,
		[Optional] ref decimal? PPriceList__3,
		[Optional] ref decimal? PPriceList__4,
		[Optional] ref decimal? PPriceList__5,
		[Optional] ref string PPriceListType,
		ref string Infobar,
		[Optional] string Site,
		[Optional] string PCoNum,
		[Optional] short? PCoLine,
		[Optional, DefaultParameterValue((byte)1)] byte? ConvertPrice,
		[Optional, DefaultParameterValue((byte)0)] ref byte? NeedToConvertPrice,
		[Optional] string ItemUM,
		[Optional] string ItemWhse,
		[Optional, DefaultParameterValue(0)] int? ShipTo,
		[Optional, DefaultParameterValue(0)] ref decimal? LineDisc,
		[Optional] ref string CustItemUM,
		[Optional] string PromotionCode,
		[Optional] string CoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPriceCalExt = new PriceCalFactory().Create(appDb);
				
				var result = iPriceCalExt.PriceCalSp(PShowMatrix,
				PItem,
				PCustNum,
				PCustItem,
				PEffDate,
				PExpDate,
				PQtyOrdered,
				POrderPriceCode,
				PCurrCode,
				PConfigString,
				PRate,
				PUnitPrice,
				PQtyList__1,
				PQtyList__2,
				PQtyList__3,
				PQtyList__4,
				PQtyList__5,
				PPriceList__1,
				PPriceList__2,
				PPriceList__3,
				PPriceList__4,
				PPriceList__5,
				PPriceListType,
				Infobar,
				Site,
				PCoNum,
				PCoLine,
				ConvertPrice,
				NeedToConvertPrice,
				ItemUM,
				ItemWhse,
				ShipTo,
				LineDisc,
				CustItemUM,
				PromotionCode,
				CoNum);
				
				int Severity = result.ReturnCode.Value;
				PUnitPrice = result.PUnitPrice;
				PQtyList__1 = result.PQtyList__1;
				PQtyList__2 = result.PQtyList__2;
				PQtyList__3 = result.PQtyList__3;
				PQtyList__4 = result.PQtyList__4;
				PQtyList__5 = result.PQtyList__5;
				PPriceList__1 = result.PPriceList__1;
				PPriceList__2 = result.PPriceList__2;
				PPriceList__3 = result.PPriceList__3;
				PPriceList__4 = result.PPriceList__4;
				PPriceList__5 = result.PPriceList__5;
				PPriceListType = result.PPriceListType;
				Infobar = result.Infobar;
				NeedToConvertPrice = result.NeedToConvertPrice;
				LineDisc = result.LineDisc;
				CustItemUM = result.CustItemUM;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PricingSP(string CustNum,
		string Item,
		[Optional] string CustItem,
		string CurrCode,
		ref decimal? BrkQty1,
		ref decimal? BrkQty2,
		ref decimal? BrkQty3,
		ref decimal? BrkQty4,
		ref decimal? BrkQty5,
		ref decimal? UnitPrice1,
		ref decimal? UnitPrice2,
		ref decimal? UnitPrice3,
		ref decimal? UnitPrice4,
		ref decimal? UnitPrice5,
		ref decimal? ContPrice,
		ref string PricingBasis,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPricingExt = new PricingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPricingExt.PricingSP(CustNum,
				Item,
				CustItem,
				CurrCode,
				BrkQty1,
				BrkQty2,
				BrkQty3,
				BrkQty4,
				BrkQty5,
				UnitPrice1,
				UnitPrice2,
				UnitPrice3,
				UnitPrice4,
				UnitPrice5,
				ContPrice,
				PricingBasis,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BrkQty1 = result.BrkQty1;
				BrkQty2 = result.BrkQty2;
				BrkQty3 = result.BrkQty3;
				BrkQty4 = result.BrkQty4;
				BrkQty5 = result.BrkQty5;
				UnitPrice1 = result.UnitPrice1;
				UnitPrice2 = result.UnitPrice2;
				UnitPrice3 = result.UnitPrice3;
				UnitPrice4 = result.UnitPrice4;
				UnitPrice5 = result.UnitPrice5;
				ContPrice = result.ContPrice;
				PricingBasis = result.PricingBasis;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
