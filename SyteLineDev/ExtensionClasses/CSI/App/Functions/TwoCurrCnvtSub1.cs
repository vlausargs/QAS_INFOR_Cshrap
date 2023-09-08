//PROJECT NAME: Data
//CLASS NAME: TwoCurrCnvtSub1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TwoCurrCnvtSub1 : I2CurrCnvtSub1
	{
		readonly IApplicationDB appDB;
		
		public TwoCurrCnvtSub1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? TwoCurrCnvtSub1Sp(
			int? TRateD,
			int? RoundResult,
			int? RoundPlaces,
			decimal? TRate,
			decimal? Amount)
		{
			Flag _TRateD = TRateD;
			Flag _RoundResult = RoundResult;
			GenericIntType _RoundPlaces = RoundPlaces;
			AmountType _TRate = TRate;
			AmtTotType _Amount = Amount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[2CurrCnvtSub1Sp](@TRateD, @RoundResult, @RoundPlaces, @TRate, @Amount)";
				
				appDB.AddCommandParameter(cmd, "TRateD", _TRateD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundPlaces", _RoundPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate", _TRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
