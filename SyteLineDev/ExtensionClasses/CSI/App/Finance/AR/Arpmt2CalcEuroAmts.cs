//PROJECT NAME: Finance
//CLASS NAME: Arpmt2CalcEuroAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class Arpmt2CalcEuroAmts : IArpmt2CalcEuroAmts
	{
		readonly IApplicationDB appDB;
		
		public Arpmt2CalcEuroAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? Arpmt2CalcEuroAmtsFn(
			string PCustCurrCode,
			string PBnkCurrCode,
			decimal? PForCheckAmount,
			decimal? PDomCheckAmount)
		{
			CurrCodeType _PCustCurrCode = PCustCurrCode;
			CurrCodeType _PBnkCurrCode = PBnkCurrCode;
			AmountType _PForCheckAmount = PForCheckAmount;
			AmountType _PDomCheckAmount = PDomCheckAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Arpmt2CalcEuroAmts](@PCustCurrCode, @PBnkCurrCode, @PForCheckAmount, @PDomCheckAmount)";
				
				appDB.AddCommandParameter(cmd, "PCustCurrCode", _PCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBnkCurrCode", _PBnkCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForCheckAmount", _PForCheckAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCheckAmount", _PDomCheckAmount, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
