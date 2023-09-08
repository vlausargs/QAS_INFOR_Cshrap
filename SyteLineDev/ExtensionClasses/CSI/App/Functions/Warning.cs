//PROJECT NAME: Data
//CLASS NAME: Warning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Warning : IWarning
	{
		readonly IApplicationDB appDB;
		
		public Warning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WarningSp(
			string Infobar)
		{
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WarningSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
