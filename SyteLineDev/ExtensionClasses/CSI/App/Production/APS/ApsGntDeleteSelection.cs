//PROJECT NAME: Production
//CLASS NAME: ApsGntDeleteSelection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGntDeleteSelection : IApsGntDeleteSelection
	{
		readonly IApplicationDB appDB;
		
		
		public ApsGntDeleteSelection(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGntDeleteSelectionSp(string PUsername,
		string PSelection,
		int? PMbrsOnly)
		{
			UsernameType _PUsername = PUsername;
			ApsGntSelectionType _PSelection = PSelection;
			FlagNyType _PMbrsOnly = PMbrsOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGntDeleteSelectionSp";
				
				appDB.AddCommandParameter(cmd, "PUsername", _PUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSelection", _PSelection, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMbrsOnly", _PMbrsOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
