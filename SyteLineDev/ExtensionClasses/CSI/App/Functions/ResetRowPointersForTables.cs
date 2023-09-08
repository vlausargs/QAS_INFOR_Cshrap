//PROJECT NAME: Data
//CLASS NAME: ResetRowPointersForTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ResetRowPointersForTables : IResetRowPointersForTables
	{
		readonly IApplicationDB appDB;
		
		public ResetRowPointersForTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ResetRowPointersForTablesSp(
			string SiteName,
			string TableName,
			string Infobar)
		{
			SiteType _SiteName = SiteName;
			StringType _TableName = TableName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ResetRowPointersForTablesSp";
				
				appDB.AddCommandParameter(cmd, "SiteName", _SiteName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
