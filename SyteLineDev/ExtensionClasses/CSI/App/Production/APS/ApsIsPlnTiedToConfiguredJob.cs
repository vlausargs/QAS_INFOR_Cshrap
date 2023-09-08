//PROJECT NAME: Production
//CLASS NAME: ApsIsPlnTiedToConfiguredJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsIsPlnTiedToConfiguredJob : IApsIsPlnTiedToConfiguredJob
	{
		readonly IApplicationDB appDB;
		
		public ApsIsPlnTiedToConfiguredJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsIsPlnTiedToConfiguredJobFn(
			int? pMatltag)
		{
			ApsItemTagType _pMatltag = pMatltag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsIsPlnTiedToConfiguredJob](@pMatltag)";
				
				appDB.AddCommandParameter(cmd, "pMatltag", _pMatltag, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
