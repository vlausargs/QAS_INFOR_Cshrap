//PROJECT NAME: Finance
//CLASS NAME: ARPaymentPostingPostChargebacks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARPaymentPostingPostChargebacks : IARPaymentPostingPostChargebacks
	{
		readonly IApplicationDB appDB;
		
		public ARPaymentPostingPostChargebacks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ARPaymentPostingPostChargebacksSp(
			Guid? PSessionID,
			string PCustNum,
			string PBankCode,
			int? PCheckNum,
			string Infobar,
			string ArpmtType,
			string ArpmtCreditMemoNum)
		{
			RowPointer _PSessionID = PSessionID;
			CustNumType _PCustNum = PCustNum;
			BankCodeType _PBankCode = PBankCode;
			ArCheckNumType _PCheckNum = PCheckNum;
			Infobar _Infobar = Infobar;
			ArpmtTypeType _ArpmtType = ArpmtType;
			InvNumType _ArpmtCreditMemoNum = ArpmtCreditMemoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentPostingPostChargebacksSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtType", _ArpmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCreditMemoNum", _ArpmtCreditMemoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
