//PROJECT NAME: Data
//CLASS NAME: UpdateStatistics.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateStatistics : IUpdateStatistics
	{
		readonly IApplicationDB appDB;
		
		public UpdateStatistics(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateStatisticsSp(
			string DatabaseName = null)
		{
			StringType _DatabaseName = DatabaseName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateStatisticsSp";
				
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
