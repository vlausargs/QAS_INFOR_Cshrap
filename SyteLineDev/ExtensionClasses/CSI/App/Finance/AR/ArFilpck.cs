//PROJECT NAME: Finance
//CLASS NAME: ArFilpck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArFilpck : IArFilpck
	{
		readonly IApplicationDB appDB;
		
		public ArFilpck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ArFilpckSp(
			string PBankCode,
			string PCustNum,
			string PType,
			int? PCheckNum,
			string InvoiceSite,
			string Infobar,
			string PCreditMemoNum,
			Guid? PProcessId)
		{
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			SiteType _InvoiceSite = InvoiceSite;
			InfobarType _Infobar = Infobar;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			RowPointerType _PProcessId = PProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArFilpckSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSite", _InvoiceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
