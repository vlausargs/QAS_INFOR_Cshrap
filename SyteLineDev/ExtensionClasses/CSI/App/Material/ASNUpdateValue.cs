//PROJECT NAME: Material
//CLASS NAME: ASNUpdateValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ASNUpdateValue : IASNUpdateValue
	{
		readonly IApplicationDB appDB;
		
		
		public ASNUpdateValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PValueAmount) ASNUpdateValueSp(string PTrnNum,
		string PBolNum,
		decimal? PValueAmount)
		{
			TrnNumType _PTrnNum = PTrnNum;
			BolNumType _PBolNum = PBolNum;
			AmountType _PValueAmount = PValueAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ASNUpdateValueSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBolNum", _PBolNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PValueAmount", _PValueAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PValueAmount = _PValueAmount;
				
				return (Severity, PValueAmount);
			}
		}
	}
}
