using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class IsValidURL : IIsValidURL
	{
		IApplicationDB appDB;


		public IsValidURL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? IsValidURLFn(string Url)
		{
			StringType _Url = Url;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsValidURL](@Url)";
				
				appDB.AddCommandParameter(cmd, "Url", _Url, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
