//PROJECT NAME: Data
//CLASS NAME: JxReq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JxReq : IJxReq
	{
		readonly IApplicationDB appDB;
		
		public JxReq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAction,
			string Infobar) JxReqSp(
			string PReqNum,
			int? PReqLine,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PAction,
			string Infobar)
		{
			ReqNumType _PReqNum = PReqNum;
			ReqLineType _PReqLine = PReqLine;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			LongListType _PAction = PAction;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JxReqSp";
				
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqLine", _PReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAction = _PAction;
				Infobar = _Infobar;
				
				return (Severity, PAction, Infobar);
			}
		}
	}
}
