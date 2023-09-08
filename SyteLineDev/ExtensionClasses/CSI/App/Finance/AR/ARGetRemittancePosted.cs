//PROJECT NAME: Finance
//CLASS NAME: ARGetRemittancePosted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARGetRemittancePosted : IARGetRemittancePosted
	{
		readonly IApplicationDB appDB;
		
		public ARGetRemittancePosted(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ARGetRemittancePostedFn(
			string pBankCode,
			string pCustNum,
			int? pDraftNum,
			string pStat)
		{
			BankCodeType _pBankCode = pBankCode;
			CustNumType _pCustNum = pCustNum;
			DraftNumType _pDraftNum = pDraftNum;
			CustdrftStatusType _pStat = pStat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ARGetRemittancePosted](@pBankCode, @pCustNum, @pDraftNum, @pStat)";
				
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDraftNum", _pDraftNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
