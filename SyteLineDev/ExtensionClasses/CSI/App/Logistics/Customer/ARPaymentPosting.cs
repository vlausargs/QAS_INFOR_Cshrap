//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPaymentPosting : IARPaymentPosting
	{
		readonly IApplicationDB appDB;
		
		
		public ARPaymentPosting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ARPaymentPostingSp(Guid? PSessionID,
		Guid? PProcessID,
		string PCustNum,
		string PBankCode,
		string PType,
		int? PCheckNum,
		string Infobar,
		string CreditMemoNum = null)
		{
			RowPointer _PSessionID = PSessionID;
			RowPointer _PProcessID = PProcessID;
			CustNumType _PCustNum = PCustNum;
			BankCodeType _PBankCode = PBankCode;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			Infobar _Infobar = Infobar;
			InvNumType _CreditMemoNum = CreditMemoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentPostingSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditMemoNum", _CreditMemoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
