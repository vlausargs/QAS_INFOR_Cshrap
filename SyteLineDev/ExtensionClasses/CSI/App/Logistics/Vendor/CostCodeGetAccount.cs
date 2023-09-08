//PROJECT NAME: Logistics
//CLASS NAME: CostCodeGetAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CostCodeGetAccount : ICostCodeGetAccount
	{
		readonly IApplicationDB appDB;
		
		
		public CostCodeGetAccount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string Description,
		int? IsControlAcct) CostCodeGetAccountSp(string CostCode,
		string ProjNum,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string Description,
		int? IsControlAcct)
		{
			CostCodeType _CostCode = CostCode;
			ProjNumType _ProjNum = ProjNum;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			DescriptionType _Description = Description;
			ListYesNoType _IsControlAcct = IsControlAcct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CostCodeGetAccountSp";
				
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsControlAcct", _IsControlAcct, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				AcctUnit1 = _AcctUnit1;
				AcctUnit2 = _AcctUnit2;
				AcctUnit3 = _AcctUnit3;
				AcctUnit4 = _AcctUnit4;
				Description = _Description;
				IsControlAcct = _IsControlAcct;
				
				return (Severity, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, Description, IsControlAcct);
			}
		}
	}
}
