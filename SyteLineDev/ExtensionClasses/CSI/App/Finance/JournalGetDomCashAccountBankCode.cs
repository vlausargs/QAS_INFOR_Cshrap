//PROJECT NAME: Finance
//CLASS NAME: JournalGetDomCashAccountBankCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalGetDomCashAccountBankCode : IJournalGetDomCashAccountBankCode
	{
		readonly IApplicationDB appDB;
		
		public JournalGetDomCashAccountBankCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PBankCode) JournalGetDomCashAccountBankCodeSp(
			string PAcct,
			string PBankCode,
			string PCurrCode,
			string AcctUnit1 = null,
			string AcctUnit2 = null,
			string AcctUnit3 = null,
			string AcctUnit4 = null)
		{
			AcctType _PAcct = PAcct;
			BankCodeType _PBankCode = PBankCode;
			CurrCodeType _PCurrCode = PCurrCode;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalGetDomCashAccountBankCodeSp";
				
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PBankCode = _PBankCode;
				
				return (Severity, PBankCode);
			}
		}
	}
}
