using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class PrimaryOrUniqueKeyString : IPrimaryOrUniqueKeyString
	{
		IApplicationDB appDB;


		public PrimaryOrUniqueKeyString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string PrimaryOrUniqueKeyStringFn(string ConstraintName)
		{
			StringType _ConstraintName = ConstraintName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PrimaryOrUniqueKeyString](@ConstraintName)";

				appDB.AddCommandParameter(cmd, "ConstraintName", _ConstraintName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
