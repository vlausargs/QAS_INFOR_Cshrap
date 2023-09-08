//PROJECT NAME: Finance
//CLASS NAME: ExtFinExportUnitCode2ToIGF.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinExportUnitCode2ToIGF : IExtFinExportUnitCode2ToIGF
	{
		readonly IApplicationDB appDB;
		
		public ExtFinExportUnitCode2ToIGF(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinExportUnitCode2ToIGFSp(
			string UnitCode2,
			string Infobar)
		{
			UnitCode2Type _UnitCode2 = UnitCode2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinExportUnitCode2ToIGFSp";
				
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
