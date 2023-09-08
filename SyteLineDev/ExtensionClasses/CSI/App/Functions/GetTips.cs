//PROJECT NAME: Data
//CLASS NAME: GetTips.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTips : IGetTips
	{
		readonly IApplicationDB appDB;
		
		public GetTips(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? tips) GetTipsSp(
			string de_code,
			decimal? de_amt,
			decimal? tips = null)
		{
			DeCodeType _de_code = de_code;
			PrAmountType _de_amt = de_amt;
			DecimalType _tips = tips;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTipsSp";
				
				appDB.AddCommandParameter(cmd, "de_code", _de_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "de_amt", _de_amt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tips", _tips, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				tips = _tips;
				
				return (Severity, tips);
			}
		}
	}
}
