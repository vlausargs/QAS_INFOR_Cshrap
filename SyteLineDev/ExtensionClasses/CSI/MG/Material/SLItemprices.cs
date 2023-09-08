//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemprices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemprices")]
	public class SLItemprices : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItempriceItemValidSp(ref string PItem,
		                                byte? PReprice,
		                                ref string PItemDescription,
		                                ref decimal? PUnitPrice1,
		                                ref string PUM,
		                                ref string PCurCode,
		                                ref decimal? PQtyOnhand,
		                                ref decimal? PUnitCost,
		                                ref decimal? PCurUnitCost,
		                                ref string PPriceCode,
		                                ref string PPricecodeDesc,
		                                ref string PProdcode,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItempriceItemValidExt = new ItempriceItemValidFactory().Create(appDb);
				
				int Severity = iItempriceItemValidExt.ItempriceItemValidSp(ref PItem,
				                                                           PReprice,
				                                                           ref PItemDescription,
				                                                           ref PUnitPrice1,
				                                                           ref PUM,
				                                                           ref PCurCode,
				                                                           ref PQtyOnhand,
				                                                           ref PUnitCost,
				                                                           ref PCurUnitCost,
				                                                           ref PPriceCode,
				                                                           ref PPricecodeDesc,
				                                                           ref PProdcode,
				                                                           ref Infobar);
				
				return Severity;
			}
		}






        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemPriceChangeSp(string SessionIDChar,
            string FromProductCode,
            string ToProductCode,
            string FromItem,
            string ToItem,
            DateTime? FromEffectDate,
            DateTime? ToEffectDate,
            string FromPriceCode,
            string ToPriceCode,
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
            DateTime? NewEffectDate,
            [Optional, DefaultParameterValue(0)] int? UpdateCreate,
            [Optional, DefaultParameterValue(0)] int? ItmPrc1,
            [Optional, DefaultParameterValue(0)] int? ItmPrc2,
            [Optional, DefaultParameterValue(0)] int? ItmPrc3,
            [Optional, DefaultParameterValue(0)] int? ItmPrc4,
            [Optional, DefaultParameterValue(0)] int? ItmPrc5,
            [Optional, DefaultParameterValue(0)] int? ItmPrc6,
            [Optional, DefaultParameterValue("I")] string PriceType,
            [Optional, DefaultParameterValue("PB")] string PriWhole,
            [Optional, DefaultParameterValue("A")] string AmtType,
            [Optional, DefaultParameterValue(0)] decimal? PriAmt,
            ref string Infobar,
            [Optional] int? StartingEffectDateOffset,
            [Optional] int? EndingEffectDateOffset)
        {
            var iItemPriceChangeExt = new ItemPriceChangeFactory().Create(this, true);

            var result = iItemPriceChangeExt.ItemPriceChangeSp(SessionIDChar,
                FromProductCode,
                ToProductCode,
                FromItem,
                ToItem,
                FromEffectDate,
                ToEffectDate,
                FromPriceCode,
                ToPriceCode,
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
                NewEffectDate,
                UpdateCreate,
                ItmPrc1,
                ItmPrc2,
                ItmPrc3,
                ItmPrc4,
                ItmPrc5,
                ItmPrc6,
                PriceType,
                PriWhole,
                AmtType,
                PriAmt,
                Infobar,
                StartingEffectDateOffset,
                EndingEffectDateOffset);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PriceChangeErrorInfoSp([Optional] string SessionIDChar,
		                                  [Optional, DefaultParameterValue((byte)0)] ref byte? ErrorExists,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPriceChangeErrorInfoExt = new PriceChangeErrorInfoFactory().Create(appDb);
				
				var result = iPriceChangeErrorInfoExt.PriceChangeErrorInfoSp(SessionIDChar,
				                                                             ErrorExists,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				ErrorExists = result.ErrorExists;
				Infobar = result.Infobar;
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalcUnitPrice1Sp(string PCurrCode,
		ref decimal? PUnitPrice1,
		[Optional] string PItem,
		[Optional] ref decimal? UnitCost,
		[Optional] ref string Prodcode,
		[Optional] ref string Pricecode,
		[Optional] ref string PricecodeDesc,
		[Optional] ref decimal? CurUCost)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalcUnitPrice1Ext = new CalcUnitPrice1Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalcUnitPrice1Ext.CalcUnitPrice1Sp(PCurrCode,
				PUnitPrice1,
				PItem,
				UnitCost,
				Prodcode,
				Pricecode,
				PricecodeDesc,
				CurUCost);
				
				int Severity = result.ReturnCode.Value;
				PUnitPrice1 = result.PUnitPrice1;
				UnitCost = result.UnitCost;
				Prodcode = result.Prodcode;
				Pricecode = result.Pricecode;
				PricecodeDesc = result.PricecodeDesc;
				CurUCost = result.CurUCost;
				return Severity;
			}
		}





































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItempricePostQuerySp(decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? UnitPrice6,
		decimal? UnitCost,
		string CurItem,
		string CurCurrCode,
		DateTime? CurEffectDate,
		string DolPercent1,
		string DolPercent2,
		string DolPercent3,
		string DolPercent4,
		string DolPercent5,
		string BaseCode1,
		string BaseCode2,
		string BaseCode3,
		string BaseCode4,
		string BaseCode5,
		decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? BrkPrice1,
		decimal? BrkPrice2,
		decimal? BrkPrice3,
		decimal? BrkPrice4,
		decimal? BrkPrice5,
		ref decimal? DerUnitPrice1,
		ref decimal? DerUnitPrice2,
		ref decimal? DerUnitPrice3,
		ref decimal? DerUnitPrice4,
		ref decimal? DerUnitPrice5)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItempricePostQueryExt = new ItempricePostQueryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItempricePostQueryExt.ItempricePostQuerySp(UnitPrice1,
				UnitPrice2,
				UnitPrice3,
				UnitPrice4,
				UnitPrice5,
				UnitPrice6,
				UnitCost,
				CurItem,
				CurCurrCode,
				CurEffectDate,
				DolPercent1,
				DolPercent2,
				DolPercent3,
				DolPercent4,
				DolPercent5,
				BaseCode1,
				BaseCode2,
				BaseCode3,
				BaseCode4,
				BaseCode5,
				BrkQty1,
				BrkQty2,
				BrkQty3,
				BrkQty4,
				BrkQty5,
				BrkPrice1,
				BrkPrice2,
				BrkPrice3,
				BrkPrice4,
				BrkPrice5,
				DerUnitPrice1,
				DerUnitPrice2,
				DerUnitPrice3,
				DerUnitPrice4,
				DerUnitPrice5);
				
				int Severity = result.ReturnCode.Value;
				DerUnitPrice1 = result.DerUnitPrice1;
				DerUnitPrice2 = result.DerUnitPrice2;
				DerUnitPrice3 = result.DerUnitPrice3;
				DerUnitPrice4 = result.DerUnitPrice4;
				DerUnitPrice5 = result.DerUnitPrice5;
				return Severity;
			}
		}






























		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
