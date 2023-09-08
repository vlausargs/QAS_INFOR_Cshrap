//PROJECT NAME: Production
//CLASS NAME: AsRulesCmpCstI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class AsRulesCmpCstI : IAsRulesCmpCstI
	{
		readonly IApplicationDB appDB;

		public AsRulesCmpCstI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) AsRulesCmpCstISp(
			string JobType,
			Guid? RowPointer,
			string Infobar)
		{
			JobTypeType _JobType = JobType;
			RowPointerType _RowPointer = RowPointer;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AsRulesCmpCstISp";

				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
