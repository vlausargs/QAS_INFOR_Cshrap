using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;
using CSI.MG;

namespace CSI.Data.SQL
{
	public class DefaultToLocalSite : IDefaultToLocalSite
	{
		IApplicationDB appDB;


		public DefaultToLocalSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string DefaultToLocalSiteFn(string Site)
		{
			SiteType _Site = Site;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DefaultToLocalSite](@Site)";

				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
