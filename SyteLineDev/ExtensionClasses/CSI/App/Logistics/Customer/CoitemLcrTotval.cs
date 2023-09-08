//PROJECT NAME: Logistics
//CLASS NAME: CoitemLcrTotval.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemLcrTotval : ICoitemLcrTotval
	{
		readonly IApplicationDB appDB;
		
		public CoitemLcrTotval(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? RetCoPrice,
			string Infobar,
			decimal? RetShipPrice) CoitemLcrTotvalSp(
			string LcrNum,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? ItemPrice,
			decimal? ItemDisc,
			decimal? QtyOrdered,
			decimal? QtyInvoiced,
			decimal? QtyReturned,
			decimal? QtyShipped,
			string CoItem,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			string ShipSite,
			string FromCurrCode,
			string ToCurrCode,
			decimal? RetCoPrice,
			string Infobar,
			int? NeedShipPrice = 0,
			decimal? RetShipPrice = 0)
		{
			LcrNumType _LcrNum = LcrNum;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			AmountType _ItemPrice = ItemPrice;
			AmountType _ItemDisc = ItemDisc;
			QtyUnitType _QtyOrdered = QtyOrdered;
			QtyUnitType _QtyInvoiced = QtyInvoiced;
			QtyUnitType _QtyReturned = QtyReturned;
			QtyUnitType _QtyShipped = QtyShipped;
			ItemType _CoItem = CoItem;
			TaxCodeType _CoitemTaxCode1 = CoitemTaxCode1;
			TaxCodeType _CoitemTaxCode2 = CoitemTaxCode2;
			SiteType _ShipSite = ShipSite;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			AmountType _RetCoPrice = RetCoPrice;
			Infobar _Infobar = Infobar;
			ListYesNoType _NeedShipPrice = NeedShipPrice;
			AmountType _RetShipPrice = RetShipPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemLcrTotvalSp";
				
				appDB.AddCommandParameter(cmd, "LcrNum", _LcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPrice", _ItemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDisc", _ItemDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyInvoiced", _QtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReturned", _QtyReturned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItem", _CoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode1", _CoitemTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemTaxCode2", _CoitemTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RetCoPrice", _RetCoPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NeedShipPrice", _NeedShipPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RetShipPrice", _RetShipPrice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RetCoPrice = _RetCoPrice;
				Infobar = _Infobar;
				RetShipPrice = _RetShipPrice;
				
				return (Severity, RetCoPrice, Infobar, RetShipPrice);
			}
		}
	}
}
