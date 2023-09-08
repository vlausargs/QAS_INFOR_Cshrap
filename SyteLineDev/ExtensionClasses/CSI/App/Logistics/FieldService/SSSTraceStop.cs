//PROJECT NAME: Logistics
//CLASS NAME: SSSTraceStop.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSTraceStop : ISSSTraceStop
	{
		readonly IApplicationDB appDB;


		public SSSTraceStop(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) SSSTraceStopSp(
			int? iTraceID,
			string Infobar)
		{
			IntType _iTraceID = iTraceID;
			StringType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSTraceStopSp";

				appDB.AddCommandParameter(cmd, "iTraceID", _iTraceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
