//PROJECT NAME: Production
//CLASS NAME: JournalImmediate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalImmediate : IJournalImmediate
	{
		readonly IApplicationDB appDB;

		public JournalImmediate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) JournalImmediateSp(
			Guid? Partition,
			string Infobar,
			int? BypassBalanceCheck = 0)
		{
			GuidType _Partition = Partition;
			InfobarType _Infobar = Infobar;
			ListYesNoType _BypassBalanceCheck = BypassBalanceCheck;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalImmediateSp";

				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BypassBalanceCheck", _BypassBalanceCheck, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
