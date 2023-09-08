//PROJECT NAME: Data
//CLASS NAME: VoidDrf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VoidDrf : IVoidDrf
	{
		readonly IApplicationDB appDB;
		
		public VoidDrf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) VoidDrfSp(
			string PBankCode,
			string PCurBankCode = null,
			int? PCheckNum = null,
			int? PProcessFlag = 0,
			string Infobar = null)
		{
			BankCodeType _PBankCode = PBankCode;
			BankCodeType _PCurBankCode = PCurBankCode;
			ApCheckNumType _PCheckNum = PCheckNum;
			ListYesNoType _PProcessFlag = PProcessFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoidDrfSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurBankCode", _PCurBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessFlag", _PProcessFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
