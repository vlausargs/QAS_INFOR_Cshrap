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
	public class HighCharacter : IHighCharacter
	{
		IApplicationDB appDB;


		public HighCharacter(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string HighCharacterFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HighCharacter]()";

				var Output = appDB.ExecuteScalar<string>(cmd);
                int validReservedDigits = 10;
                if (string.IsNullOrEmpty(Output) == false && Output.Length > validReservedDigits)
                    return Output.Substring(0, validReservedDigits);
                return Output;
			}
		}
	}
}
