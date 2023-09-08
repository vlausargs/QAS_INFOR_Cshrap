//PROJECT NAME: Logistics
//CLASS NAME: GetCostWithoutTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetCostWithoutTax : IGetCostWithoutTax
	{
		readonly IApplicationDB appDB;
		
		
		public GetCostWithoutTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? CostWithoutTax,
		string Infobar) GetCostWithoutTaxSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? TransDate,
		decimal? CostAmount,
		decimal? CostWithoutTax,
		string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			DateType _TransDate = TransDate;
			AmountType _CostAmount = CostAmount;
			AmountType _CostWithoutTax = CostWithoutTax;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCostWithoutTaxSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostAmount", _CostAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostWithoutTax", _CostWithoutTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CostWithoutTax = _CostWithoutTax;
				Infobar = _Infobar;
				
				return (Severity, CostWithoutTax, Infobar);
			}
		}
	}
}
