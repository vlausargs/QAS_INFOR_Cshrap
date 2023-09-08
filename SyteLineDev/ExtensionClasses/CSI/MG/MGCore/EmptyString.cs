using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CSI.MG.MGCore
{
	public class EmptyString : IEmptyString
	{
		IApplicationDB appDB;


		public EmptyString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string EmptyStringFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EmptyString]()";

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
