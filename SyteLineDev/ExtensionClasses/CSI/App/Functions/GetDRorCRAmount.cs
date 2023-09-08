//PROJECT NAME: Data
//CLASS NAME: GetDRorCRAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetDRorCRAmount : IGetDRorCRAmount
	{
		readonly IApplicationDB appDB;
		
		public GetDRorCRAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetDRorCRAmountFn(
			decimal? DomAmount,
			int? IsDR,
			int? Cancellation)
		{
			AmountType _DomAmount = DomAmount;
			ListYesNoType _IsDR = IsDR;
			ListYesNoType _Cancellation = Cancellation;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetDRorCRAmount](@DomAmount, @IsDR, @Cancellation)";
				
				appDB.AddCommandParameter(cmd, "DomAmount", _DomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsDR", _IsDR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cancellation", _Cancellation, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
