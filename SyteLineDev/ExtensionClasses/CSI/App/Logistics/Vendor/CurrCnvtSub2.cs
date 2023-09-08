//PROJECT NAME: Logistics
//CLASS NAME: CurrCnvtSub2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CurrCnvtSub2 : ICurrCnvtSub2
	{
		readonly IApplicationDB appDB;
		
		public CurrCnvtSub2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CurrCnvtSub2Sp(
			int? TRateD,
			int? FromDomestic,
			int? RoundResult,
			int? RoundPlaces,
			decimal? TRate,
			decimal? Amount)
		{
			Flag _TRateD = TRateD;
			Flag _FromDomestic = FromDomestic;
			Flag _RoundResult = RoundResult;
			GenericIntType _RoundPlaces = RoundPlaces;
			AmountType _TRate = TRate;
			AmtTotType _Amount = Amount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CurrCnvtSub2Sp](@TRateD, @FromDomestic, @RoundResult, @RoundPlaces, @TRate, @Amount)";
				
				appDB.AddCommandParameter(cmd, "TRateD", _TRateD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDomestic", _FromDomestic, ParameterDirection.Input);
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
