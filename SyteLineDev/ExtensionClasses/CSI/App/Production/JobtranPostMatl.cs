//PROJECT NAME: Production
//CLASS NAME: JobtranPostMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtranPostMatl : IJobtranPostMatl
	{
		readonly IApplicationDB appDB;

		public JobtranPostMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) JobtranPostMatlSp(
			Guid? SessionID,
			decimal? JobtranTransNum,
			string CallFrom = null,
			int? Coby = null,
			int? CreateMatPost = 0,
			string Infobar = null)
		{
			RowPointerType _SessionID = SessionID;
			HugeTransNumType _JobtranTransNum = JobtranTransNum;
			LongListType _CallFrom = CallFrom;
			ListYesNoType _Coby = Coby;
			ListYesNoType _CreateMatPost = CreateMatPost;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranPostMatlSp";

				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobtranTransNum", _JobtranTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Coby", _Coby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateMatPost", _CreateMatPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
