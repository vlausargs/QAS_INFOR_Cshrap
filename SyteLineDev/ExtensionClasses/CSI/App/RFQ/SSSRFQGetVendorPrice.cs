//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQGetVendorPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public interface ISSSRFQGetVendorPrice
	{
		(int? ReturnCode, decimal? SelectedPrice, string Infobar) SSSRFQGetVendorPriceSp(string RFQNum,
		int? RFQLine,
		string VendNum,
		decimal? SelectedQty = null,
		int? PreferredLeadTime = null,
		decimal? SelectedPrice = null,
		string Infobar = null);
	}
	
	public class SSSRFQGetVendorPrice : ISSSRFQGetVendorPrice
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQGetVendorPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? SelectedPrice, string Infobar) SSSRFQGetVendorPriceSp(string RFQNum,
		int? RFQLine,
		string VendNum,
		decimal? SelectedQty = null,
		int? PreferredLeadTime = null,
		decimal? SelectedPrice = null,
		string Infobar = null)
		{
			RFQNumType _RFQNum = RFQNum;
			RFQLineType _RFQLine = RFQLine;
			VendNumType _VendNum = VendNum;
			QtyUnitType _SelectedQty = SelectedQty;
			GenericIntType _PreferredLeadTime = PreferredLeadTime;
			CostPrcType _SelectedPrice = SelectedPrice;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQGetVendorPriceSp";
				
				appDB.AddCommandParameter(cmd, "RFQNum", _RFQNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RFQLine", _RFQLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedQty", _SelectedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreferredLeadTime", _PreferredLeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedPrice", _SelectedPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SelectedPrice = _SelectedPrice;
				Infobar = _Infobar;
				
				return (Severity, SelectedPrice, Infobar);
			}
		}
	}
}
