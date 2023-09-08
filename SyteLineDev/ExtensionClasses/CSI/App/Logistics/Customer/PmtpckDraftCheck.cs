//PROJECT NAME: Logistics
//CLASS NAME: PmtpckDraftCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckDraftCheck : IPmtpckDraftCheck
	{
		readonly IApplicationDB appDB;
		
		
		public PmtpckDraftCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmtpckDraftCheckSp(string PCustNum,
		string PType,
		int? PCheckNum,
		DateTime? PArpmtDueDate,
		DateTime? PPmtpckDueDate,
		string PPmtpckCustNum,
		string PPmtpckInvNum,
		int? PDateCheck,
		string Infobar)
		{
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			DateType _PArpmtDueDate = PArpmtDueDate;
			DateType _PPmtpckDueDate = PPmtpckDueDate;
			CustNumType _PPmtpckCustNum = PPmtpckCustNum;
			InvNumType _PPmtpckInvNum = PPmtpckInvNum;
			FlagNyType _PDateCheck = PDateCheck;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckDraftCheckSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtDueDate", _PArpmtDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPmtpckDueDate", _PPmtpckDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPmtpckCustNum", _PPmtpckCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPmtpckInvNum", _PPmtpckInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDateCheck", _PDateCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
