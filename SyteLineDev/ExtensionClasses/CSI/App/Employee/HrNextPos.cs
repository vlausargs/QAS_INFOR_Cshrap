//PROJECT NAME: Employee
//CLASS NAME: HrNextPos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class HrNextPos : IHrNextPos
	{
		readonly IApplicationDB appDB;
		
		
		public HrNextPos(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PosDefault,
		string Infobar) HrNextPosSp(string PosDefault,
		string Infobar)
		{
			JobIdType _PosDefault = PosDefault;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HrNextPosSp";
				
				appDB.AddCommandParameter(cmd, "PosDefault", _PosDefault, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PosDefault = _PosDefault;
				Infobar = _Infobar;
				
				return (Severity, PosDefault, Infobar);
			}
		}
	}
}
