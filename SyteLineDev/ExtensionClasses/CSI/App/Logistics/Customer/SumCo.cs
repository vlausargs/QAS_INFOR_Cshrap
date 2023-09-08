//PROJECT NAME: Logistics
//CLASS NAME: SumCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SumCo : ISumCo
	{
		readonly IApplicationDB appDB;
		
		
		public SumCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		decimal? NewTotalPrice,
		decimal? PlannedDiscountOffset) SumCoSp(string PCoNum,
		string Infobar,
		decimal? NewTotalPrice = 0,
		decimal? PlannedDiscountOffset = 0)
		{
			CoNumType _PCoNum = PCoNum;
			InfobarType _Infobar = Infobar;
			AmountType _NewTotalPrice = NewTotalPrice;
			AmountType _PlannedDiscountOffset = PlannedDiscountOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumCoSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewTotalPrice", _NewTotalPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlannedDiscountOffset", _PlannedDiscountOffset, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				NewTotalPrice = _NewTotalPrice;
				PlannedDiscountOffset = _PlannedDiscountOffset;
				
				return (Severity, Infobar, NewTotalPrice, PlannedDiscountOffset);
			}
		}
	}
}
