//PROJECT NAME: Material
//CLASS NAME: GetUnitPricing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetUnitPricing : IGetUnitPricing
	{
		readonly IApplicationDB appDB;
		
		
		public GetUnitPricing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? UnitPrice,
		decimal? DiscPercent,
		decimal? DiscUnitPrice,
		string Infobar,
		string ErrorMessage) GetUnitPricingSp(string CustNum,
		string Item,
		decimal? UnitPrice,
		decimal? DiscPercent,
		decimal? DiscUnitPrice,
		string Infobar,
		string ErrorMessage = null)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			CostPrcType _UnitPrice = UnitPrice;
			LineDiscType _DiscPercent = DiscPercent;
			CostPrcType _DiscUnitPrice = DiscUnitPrice;
			InfobarType _Infobar = Infobar;
			MessageType _ErrorMessage = ErrorMessage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetUnitPricingSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscPercent", _DiscPercent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscUnitPrice", _DiscUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ErrorMessage", _ErrorMessage, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitPrice = _UnitPrice;
				DiscPercent = _DiscPercent;
				DiscUnitPrice = _DiscUnitPrice;
				Infobar = _Infobar;
				ErrorMessage = _ErrorMessage;
				
				return (Severity, UnitPrice, DiscPercent, DiscUnitPrice, Infobar, ErrorMessage);
			}
		}
	}
}
