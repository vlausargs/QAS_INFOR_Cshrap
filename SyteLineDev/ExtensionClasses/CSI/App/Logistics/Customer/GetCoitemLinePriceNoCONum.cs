//PROJECT NAME: Logistics
//CLASS NAME: GetCoitemLinePriceNoCONum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCoitemLinePriceNoCONum : IGetCoitemLinePriceNoCONum
	{
		readonly IApplicationDB appDB;
		
		
		public GetCoitemLinePriceNoCONum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? CoitemDisc,
		decimal? CoitemLinePrice,
		string Infobar,
		decimal? LineTaxAmount,
		decimal? CoitemPrice,
		int? CurrencyPlaces,
		string TaxAmountLabel,
		string SiteLanguageID) GetCoitemLinePriceNoCONumSp(string PCustomerNum,
		string CoitemItem,
		string PAtlItemUM,
		string PShipSite,
		DateTime? POrderDate,
		decimal? CoitemDisc,
		decimal? CoitemQtyOrdered,
		string CustCurCode,
		string ItemPriceCode,
		decimal? CoitemLinePrice,
		string Infobar,
		decimal? LineTaxAmount = null,
		decimal? CoitemPrice = null,
		int? CurrencyPlaces = null,
		Guid? CoitemRowPointer = null,
		string TaxAmountLabel = null,
		string SiteLanguageID = null)
		{
			CustNumType _PCustomerNum = PCustomerNum;
			ItemType _CoitemItem = CoitemItem;
			UMType _PAtlItemUM = PAtlItemUM;
			SiteType _PShipSite = PShipSite;
			DateType _POrderDate = POrderDate;
			LineDiscType _CoitemDisc = CoitemDisc;
			CostPrcType _CoitemQtyOrdered = CoitemQtyOrdered;
			CurrCodeType _CustCurCode = CustCurCode;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			AmountType _CoitemLinePrice = CoitemLinePrice;
			InfobarType _Infobar = Infobar;
			AmtTotType _LineTaxAmount = LineTaxAmount;
			CostPrcType _CoitemPrice = CoitemPrice;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			RowPointerType _CoitemRowPointer = CoitemRowPointer;
			LangLabelType _TaxAmountLabel = TaxAmountLabel;
			LanguageIDType _SiteLanguageID = SiteLanguageID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoitemLinePriceNoCONumSp";
				
				appDB.AddCommandParameter(cmd, "PCustomerNum", _PCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemItem", _CoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAtlItemUM", _PAtlItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipSite", _PShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderDate", _POrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemDisc", _CoitemDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemQtyOrdered", _CoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustCurCode", _CustCurCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemLinePrice", _CoitemLinePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineTaxAmount", _LineTaxAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemPrice", _CoitemPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoitemRowPointer", _CoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmountLabel", _TaxAmountLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteLanguageID", _SiteLanguageID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoitemDisc = _CoitemDisc;
				CoitemLinePrice = _CoitemLinePrice;
				Infobar = _Infobar;
				LineTaxAmount = _LineTaxAmount;
				CoitemPrice = _CoitemPrice;
				CurrencyPlaces = _CurrencyPlaces;
				TaxAmountLabel = _TaxAmountLabel;
				SiteLanguageID = _SiteLanguageID;
				
				return (Severity, CoitemDisc, CoitemLinePrice, Infobar, LineTaxAmount, CoitemPrice, CurrencyPlaces, TaxAmountLabel, SiteLanguageID);
			}
		}
	}
}
