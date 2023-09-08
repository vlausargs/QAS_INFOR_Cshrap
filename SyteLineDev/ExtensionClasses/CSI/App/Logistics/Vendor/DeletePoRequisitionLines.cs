//PROJECT NAME: CSIVendor
//CLASS NAME: DeletePoRequisitionLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IDeletePoRequisitionLines
	{
		(int? ReturnCode, int? LinesDeleted, string Infobar) DeletePoRequisitionLinesSp(string BegReqNum,
		string EndReqNum,
		short? BegReqLine,
		short? EndReqLine,
		string BegRequester,
		string EndRequester,
		string BegApprover,
		string EndApprover,
		DateTime? BegReqDate,
		DateTime? EndReqDate,
		int? LinesDeleted,
		string Infobar,
		short? StartRequestDateOffset = null,
		short? EndRequestDateOffset = null);
	}
	
	public class DeletePoRequisitionLines : IDeletePoRequisitionLines
	{
		readonly IApplicationDB appDB;
		
		public DeletePoRequisitionLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? LinesDeleted, string Infobar) DeletePoRequisitionLinesSp(string BegReqNum,
		string EndReqNum,
		short? BegReqLine,
		short? EndReqLine,
		string BegRequester,
		string EndRequester,
		string BegApprover,
		string EndApprover,
		DateTime? BegReqDate,
		DateTime? EndReqDate,
		int? LinesDeleted,
		string Infobar,
		short? StartRequestDateOffset = null,
		short? EndRequestDateOffset = null)
		{
			ReqNumType _BegReqNum = BegReqNum;
			ReqNumType _EndReqNum = EndReqNum;
			ReqLineType _BegReqLine = BegReqLine;
			ReqLineType _EndReqLine = EndReqLine;
			UsernameType _BegRequester = BegRequester;
			UsernameType _EndRequester = EndRequester;
			UsernameType _BegApprover = BegApprover;
			UsernameType _EndApprover = EndApprover;
			DateType _BegReqDate = BegReqDate;
			DateType _EndReqDate = EndReqDate;
			IntType _LinesDeleted = LinesDeleted;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartRequestDateOffset = StartRequestDateOffset;
			DateOffsetType _EndRequestDateOffset = EndRequestDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeletePoRequisitionLinesSp";
				
				appDB.AddCommandParameter(cmd, "BegReqNum", _BegReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqNum", _EndReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegReqLine", _BegReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqLine", _EndReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegRequester", _BegRequester, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRequester", _EndRequester, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegApprover", _BegApprover, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndApprover", _EndApprover, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegReqDate", _BegReqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndReqDate", _EndReqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LinesDeleted", _LinesDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartRequestDateOffset", _StartRequestDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRequestDateOffset", _EndRequestDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LinesDeleted = _LinesDeleted;
				Infobar = _Infobar;
				
				return (Severity, LinesDeleted, Infobar);
			}
		}
	}
}
