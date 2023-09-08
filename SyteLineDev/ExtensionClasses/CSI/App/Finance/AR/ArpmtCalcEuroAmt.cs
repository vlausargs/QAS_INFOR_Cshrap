//PROJECT NAME: Finance
//CLASS NAME: ArpmtCalcEuroAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtCalcEuroAmt : IArpmtCalcEuroAmt
	{
		readonly IApplicationDB appDB;
		
		public ArpmtCalcEuroAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ArpmtCalcEuroAmtFn(
			decimal? PCheckAmt,
			string PCurrCode)
		{
			AmountType _PCheckAmt = PCheckAmt;
			CurrCodeType _PCurrCode = PCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArpmtCalcEuroAmt](@PCheckAmt, @PCurrCode)";
				
				appDB.AddCommandParameter(cmd, "PCheckAmt", _PCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
