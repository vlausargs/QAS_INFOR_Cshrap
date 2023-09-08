using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class SitePartitionFunctionExists : ISitePartitionFunctionExists
	{
		IApplicationDB appDB;


		public SitePartitionFunctionExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? SitePartitionFunctionExistsFn(string PSitePartitionFunction = "SitePFunction")
		{
			StringType _PSitePartitionFunction = PSitePartitionFunction;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SitePartitionFunctionExists](@PSitePartitionFunction)";

				appDB.AddCommandParameter(cmd, "PSitePartitionFunction", _PSitePartitionFunction, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
