//PROJECT NAME: Data
//CLASS NAME: ChkUnitAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChkUnitAll : IChkUnitAll
	{
		readonly IApplicationDB appDB;
		
		public ChkUnitAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChkUnitAllSp(
			string acct,
			string p_unit1 = null,
			string p_unit2 = null,
			string p_unit3 = null,
			string p_unit4 = null,
			string pSite = null,
			string Infobar = null)
		{
			AcctType _acct = acct;
			UnitCode1Type _p_unit1 = p_unit1;
			UnitCode2Type _p_unit2 = p_unit2;
			UnitCode3Type _p_unit3 = p_unit3;
			UnitCode4Type _p_unit4 = p_unit4;
			SiteType _pSite = pSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkUnitAllSp";
				
				appDB.AddCommandParameter(cmd, "acct", _acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_unit1", _p_unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_unit2", _p_unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_unit3", _p_unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_unit4", _p_unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
