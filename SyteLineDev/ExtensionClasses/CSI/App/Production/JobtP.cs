//PROJECT NAME: Production
//CLASS NAME: JobtP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtP : IJobtP
	{
		readonly IApplicationDB appDB;

		public JobtP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) JobtPSp(
			string CallFrom,
			decimal? PTransNum,
			Guid? SessionId = null,
			Guid? RiJobtMat = null,
			string Infobar = null)
		{
			StringType _CallFrom = CallFrom;
			HugeTransNumType _PTransNum = PTransNum;
			RowPointerType _SessionId = SessionId;
			RowPointerType _RiJobtMat = RiJobtMat;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtPSp";

				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RiJobtMat", _RiJobtMat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
