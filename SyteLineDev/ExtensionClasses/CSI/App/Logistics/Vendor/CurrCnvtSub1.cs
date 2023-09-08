//PROJECT NAME: Logistics
//CLASS NAME: CurrCnvtSub1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CurrCnvtSub1 : ICurrCnvtSub1
	{
		readonly IApplicationDB appDB;
		
		public CurrCnvtSub1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CurrCnvtSub1Sp(
			int? FromDomestic,
			int? FRateD,
			int? TEuroBasis,
			int? DRateD,
			decimal? Amount,
			decimal? FRate,
			decimal? DRate,
			int? RoundResult,
			int? RoundPlaces)
		{
			Flag _FromDomestic = FromDomestic;
			Flag _FRateD = FRateD;
			Flag _TEuroBasis = TEuroBasis;
			Flag _DRateD = DRateD;
			AmtTotType _Amount = Amount;
			ExchRateType _FRate = FRate;
			ExchRateType _DRate = DRate;
			Flag _RoundResult = RoundResult;
			GenericIntType _RoundPlaces = RoundPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CurrCnvtSub1Sp](@FromDomestic, @FRateD, @TEuroBasis, @DRateD, @Amount, @FRate, @DRate, @RoundResult, @RoundPlaces)";
				
				appDB.AddCommandParameter(cmd, "FromDomestic", _FromDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FRateD", _FRateD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroBasis", _TEuroBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DRateD", _DRateD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FRate", _FRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DRate", _DRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundResult", _RoundResult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RoundPlaces", _RoundPlaces, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
