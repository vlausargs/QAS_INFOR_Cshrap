using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
	public class VariableIsDefinedBySessionId : IVariableIsDefinedBySessionId
	{
		IApplicationDB appDB;


		public VariableIsDefinedBySessionId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? VariableIsDefinedBySessionIdFn(Guid? SessionID,
		string VariableName)
		{
			RowPointerType _SessionID = SessionID;
			StringType _VariableName = VariableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[VariableIsDefinedBySessionId](@SessionID, @VariableName)";

				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
