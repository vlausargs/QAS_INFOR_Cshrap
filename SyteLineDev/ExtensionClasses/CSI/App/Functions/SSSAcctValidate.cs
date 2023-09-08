//PROJECT NAME: Data
//CLASS NAME: SSSAcctValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSAcctValidate : ISSSAcctValidate
	{
		readonly IApplicationDB appDB;
		
		public SSSAcctValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4,
			string Infobar) SSSAcctValidateSp(
			string oAcct,
			string oUnit1,
			string oUnit2,
			string oUnit3,
			string oUnit4,
			string Infobar)
		{
			AcctType _oAcct = oAcct;
			UnitCode1Type _oUnit1 = oUnit1;
			UnitCode2Type _oUnit2 = oUnit2;
			UnitCode3Type _oUnit3 = oUnit3;
			UnitCode4Type _oUnit4 = oUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSAcctValidateSp";
				
				appDB.AddCommandParameter(cmd, "oAcct", _oAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit1", _oUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit2", _oUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit3", _oUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUnit4", _oUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oAcct = _oAcct;
				oUnit1 = _oUnit1;
				oUnit2 = _oUnit2;
				oUnit3 = _oUnit3;
				oUnit4 = _oUnit4;
				Infobar = _Infobar;
				
				return (Severity, oAcct, oUnit1, oUnit2, oUnit3, oUnit4, Infobar);
			}
		}
	}
}
