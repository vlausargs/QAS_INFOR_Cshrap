//PROJECT NAME: Production
//CLASS NAME: JobStatusChange2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobStatusChange2 : IJobStatusChange2
	{
		readonly IApplicationDB appDB;
		
		public JobStatusChange2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobStatusChange2Sp(
			int? DirectClose,
			Guid? JobRowpointer,
			decimal? NewJobQtyReleased,
			decimal? QtyJustMoved,
			string NewJobStat,
			string OldJobStat,
			DateTime? TransDate,
			string CurUserCode,
			string Infobar)
		{
			ListYesNoType _DirectClose = DirectClose;
			RowPointerType _JobRowpointer = JobRowpointer;
			QtyUnitType _NewJobQtyReleased = NewJobQtyReleased;
			QtyUnitType _QtyJustMoved = QtyJustMoved;
			JobStatusType _NewJobStat = NewJobStat;
			JobStatusType _OldJobStat = OldJobStat;
			DateType _TransDate = TransDate;
			UserCodeType _CurUserCode = CurUserCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobStatusChange2Sp";
				
				appDB.AddCommandParameter(cmd, "DirectClose", _DirectClose, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRowpointer", _JobRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJobQtyReleased", _NewJobQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyJustMoved", _QtyJustMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJobStat", _NewJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJobStat", _OldJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
