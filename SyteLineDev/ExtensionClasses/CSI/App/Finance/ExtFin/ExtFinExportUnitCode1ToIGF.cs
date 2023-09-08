//PROJECT NAME: Finance
//CLASS NAME: ExtFinExportUnitCode1ToIGF.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinExportUnitCode1ToIGF : IExtFinExportUnitCode1ToIGF
	{
		readonly IApplicationDB appDB;
		
		public ExtFinExportUnitCode1ToIGF(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinExportUnitCode1ToIGFSp(
			string UnitCode1,
			string Infobar)
		{
			UnitCode1Type _UnitCode1 = UnitCode1;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinExportUnitCode1ToIGFSp";
				
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
