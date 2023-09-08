//PROJECT NAME: Logistics
//CLASS NAME: THAGetPurcAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAGetPurcAcct : ITHAGetPurcAcct
	{
		readonly IApplicationDB appDB;
		
		
		public THAGetPurcAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Acct,
		string Unit1,
		string Unit2,
		string Unit3,
		string Unit4,
		string Desc,
		string Infobar) THAGetPurcAcctSp(string Acct,
		string Unit1,
		string Unit2,
		string Unit3,
		string Unit4,
		string Desc,
		string Infobar)
		{
			AcctType _Acct = Acct;
			UnitCode1Type _Unit1 = Unit1;
			UnitCode2Type _Unit2 = Unit2;
			UnitCode3Type _Unit3 = Unit3;
			UnitCode4Type _Unit4 = Unit4;
			DescriptionType _Desc = Desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAGetPurcAcctSp";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit1", _Unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit2", _Unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit3", _Unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit4", _Unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				Unit1 = _Unit1;
				Unit2 = _Unit2;
				Unit3 = _Unit3;
				Unit4 = _Unit4;
				Desc = _Desc;
				Infobar = _Infobar;
				
				return (Severity, Acct, Unit1, Unit2, Unit3, Unit4, Desc, Infobar);
			}
		}
	}
}
