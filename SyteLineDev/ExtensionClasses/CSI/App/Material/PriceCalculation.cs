//PROJECT NAME: Material
//CLASS NAME: PriceCalculation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PriceCalculation : IPriceCalculation
	{
		readonly IApplicationDB appDB;
		
		
		public PriceCalculation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? pPrice,
		string pCurrencyCode,
		string Infobar) PriceCalculationSp(string pSite,
		string pItem,
		string pCustNum,
		DateTime? pOrderDate,
		decimal? pQuantityOrdered,
		string pUOM,
		decimal? pPrice,
		string pCurrencyCode,
		string Infobar)
		{
			SiteType _pSite = pSite;
			ItemType _pItem = pItem;
			CustNumType _pCustNum = pCustNum;
			DateType _pOrderDate = pOrderDate;
			QtyUnitNoNegType _pQuantityOrdered = pQuantityOrdered;
			UMType _pUOM = pUOM;
			CostPrcType _pPrice = pPrice;
			CurrCodeType _pCurrencyCode = pCurrencyCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PriceCalculationSp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderDate", _pOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQuantityOrdered", _pQuantityOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUOM", _pUOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrice", _pPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurrencyCode", _pCurrencyCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pPrice = _pPrice;
				pCurrencyCode = _pCurrencyCode;
				Infobar = _Infobar;
				
				return (Severity, pPrice, pCurrencyCode, Infobar);
			}
		}
	}
}
