using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class ReplicationFilters : IReplicationFilters
	{
		IApplicationDB appDB;


		public ReplicationFilters(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string ReplicationFiltersFn(string SourceSite,
		string TargetSite,
		string TableName)
		{
			SiteType _SourceSite = SourceSite;
			SiteType _TargetSite = TargetSite;
			StringType _TableName = TableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ReplicationFilters](@SourceSite, @TargetSite, @TableName)";

				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetSite", _TargetSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
