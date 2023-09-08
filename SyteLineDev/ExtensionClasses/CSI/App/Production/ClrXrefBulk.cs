//PROJECT NAME: Production
//CLASS NAME: ClrXrefBulk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ClrXrefBulk : IClrXrefBulk
	{
		readonly IApplicationDB appDB;


		public ClrXrefBulk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) ClrXrefBulkSp(
			Guid? ProcessId,
			string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClrXrefBulkSp";

				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
