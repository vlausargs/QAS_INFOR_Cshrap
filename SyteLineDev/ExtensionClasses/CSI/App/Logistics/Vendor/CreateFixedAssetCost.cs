//PROJECT NAME: Logistics
//CLASS NAME: CreateFixedAssetCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreateFixedAssetCost : ICreateFixedAssetCost
	{
		readonly IApplicationDB appDB;
		
		public CreateFixedAssetCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateFixedAssetCostSp(
			string FaNum,
			string VendNum,
			decimal? Amount,
			string PoNum,
			int? PoLine,
			string Infobar)
		{
			FaNumType _FaNum = FaNum;
			VendNumType _VendNum = VendNum;
			AmountType _Amount = Amount;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateFixedAssetCostSp";
				
				appDB.AddCommandParameter(cmd, "FaNum", _FaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
