//PROJECT NAME: CSIFinance
//CLASS NAME: GetFaTransTotal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGetFaTransTotal
	{
		int GetFaTransTotalSp(string pFaNum,
		                      ref decimal? pTotCost,
		                      ref decimal? pTotDepr);
	}
	
	public class GetFaTransTotal : IGetFaTransTotal
	{
		readonly IApplicationDB appDB;
		
		public GetFaTransTotal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetFaTransTotalSp(string pFaNum,
		                             ref decimal? pTotCost,
		                             ref decimal? pTotDepr)
		{
			FaNumType _pFaNum = pFaNum;
			AmountType _pTotCost = pTotCost;
			AmountType _pTotDepr = pTotDepr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFaTransTotalSp";
				
				appDB.AddCommandParameter(cmd, "pFaNum", _pFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTotCost", _pTotCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pTotDepr", _pTotDepr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pTotCost = _pTotCost;
				pTotDepr = _pTotDepr;
				
				return Severity;
			}
		}
	}
}
