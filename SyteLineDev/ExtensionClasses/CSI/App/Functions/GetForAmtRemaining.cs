//PROJECT NAME: Data
//CLASS NAME: GetForAmtRemaining.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetForAmtRemaining : IGetForAmtRemaining
	{
		readonly IApplicationDB appDB;
		
		public GetForAmtRemaining(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetForAmtRemainingFn(
			string BankCode,
			string VendNum,
			decimal? CheckSeq,
			decimal? Remaining)
		{
			StringType _BankCode = BankCode;
			StringType _VendNum = VendNum;
			DecimalType _CheckSeq = CheckSeq;
			DecimalType _Remaining = Remaining;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetForAmtRemaining](@BankCode, @VendNum, @CheckSeq, @Remaining)";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Remaining", _Remaining, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
