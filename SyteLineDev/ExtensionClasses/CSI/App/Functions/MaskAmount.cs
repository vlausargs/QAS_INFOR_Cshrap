//PROJECT NAME: Data
//CLASS NAME: MaskAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaskAmount : IMaskAmount
	{
		readonly IApplicationDB appDB;
		
		public MaskAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MaskAmountFn(
			string Value,
			int? number_of_implied_decimals)
		{
			StringType _Value = Value;
			IntType _number_of_implied_decimals = number_of_implied_decimals;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaskAmount](@Value, @number_of_implied_decimals)";
				
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "number_of_implied_decimals", _number_of_implied_decimals, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
