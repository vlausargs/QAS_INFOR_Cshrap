using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class GetTimeByDateTime : IGetTimeByDateTime
	{
		IApplicationDB appDB;


		public GetTimeByDateTime(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string GetTimeByDateTimeFn(DateTime? InputDateTime,
		int? Use24Hour = 0)
		{
			DateTimeType _InputDateTime = InputDateTime;
			ListYesNoType _Use24Hour = Use24Hour;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetTimeByDateTime](@InputDateTime, @Use24Hour)";

				appDB.AddCommandParameter(cmd, "InputDateTime", _InputDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Use24Hour", _Use24Hour, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
