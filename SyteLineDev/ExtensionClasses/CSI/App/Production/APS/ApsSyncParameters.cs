//PROJECT NAME: Production
//CLASS NAME: ApsSyncParameters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncParameters : IApsSyncParameters
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncParameters(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncParametersSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncParametersSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
