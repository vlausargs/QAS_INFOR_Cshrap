//PROJECT NAME: Codes
//CLASS NAME: ShiftExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class ShiftExists : IShiftExists
	{
		readonly IApplicationDB appDB;
		
		
		public ShiftExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ShiftExists,
		string Infobar) ShiftExistsSp(string Shift,
		int? ShiftExists,
		string Infobar)
		{
			ApsShiftType _Shift = Shift;
			ListYesNoType _ShiftExists = ShiftExists;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShiftExistsSp";
				
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftExists", _ShiftExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShiftExists = _ShiftExists;
				Infobar = _Infobar;
				
				return (Severity, ShiftExists, Infobar);
			}
		}
	}
}
