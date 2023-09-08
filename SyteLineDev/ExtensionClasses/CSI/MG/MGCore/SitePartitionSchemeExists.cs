using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class SitePartitionSchemeExists : ISitePartitionSchemeExists
	{
		IApplicationDB appDB;


		public SitePartitionSchemeExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? SitePartitionSchemeExistsFn(string PSitePartitionScheme = "SitePScheme")
		{
			StringType _PSitePartitionScheme = PSitePartitionScheme;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SitePartitionSchemeExists](@PSitePartitionScheme)";

				appDB.AddCommandParameter(cmd, "PSitePartitionScheme", _PSitePartitionScheme, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
