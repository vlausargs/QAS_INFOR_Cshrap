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
	public class LowCharacter : ILowCharacter
	{
		IApplicationDB appDB;


		public LowCharacter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string LowCharacterFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LowCharacter]()";

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
