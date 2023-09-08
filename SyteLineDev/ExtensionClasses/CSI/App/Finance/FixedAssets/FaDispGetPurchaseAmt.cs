//PROJECT NAME: Finance
//CLASS NAME: FaDispGetPurchaseAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
	public class FaDispGetPurchaseAmt : IFaDispGetPurchaseAmt
	{
		readonly IApplicationDB appDB;
		
		public FaDispGetPurchaseAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FaDispGetPurchaseAmtFn(
			string pFaNum)
		{
			FaNumType _pFaNum = pFaNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FaDispGetPurchaseAmt](@pFaNum)";
				
				appDB.AddCommandParameter(cmd, "pFaNum", _pFaNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
