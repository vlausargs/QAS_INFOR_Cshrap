//PROJECT NAME: Data
//CLASS NAME: Diag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Diag : IDiag
	{
		readonly IApplicationDB appDB;
		
		public Diag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DiagSp(
			string PDiagLevl,
			string PDiagMesg)
		{
			LongListType _PDiagLevl = PDiagLevl;
			LongListType _PDiagMesg = PDiagMesg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DiagSp";
				
				appDB.AddCommandParameter(cmd, "PDiagLevl", _PDiagLevl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiagMesg", _PDiagMesg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
