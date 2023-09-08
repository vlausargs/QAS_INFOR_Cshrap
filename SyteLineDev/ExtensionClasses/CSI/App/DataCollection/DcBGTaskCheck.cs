//PROJECT NAME: DataCollection
//CLASS NAME: DcBGTaskCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcBGTaskCheck : IDcBGTaskCheck
	{
		readonly IApplicationDB appDB;
		
		
		public DcBGTaskCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PostPoReceving,
		int? PostCoShipping,
		int? PostCycleCount,
		int? PostMiscAjust,
		int? PostMatlMove,
		int? PostJobMaterial,
		int? PostJobReceipt,
		int? PostTransferShip,
		int? PostTransferReceipt,
		int? PostJob,
		int? PostTimeAttendance,
		int? PostProductionSchedule,
		int? PostJIT,
		int? PostWCMaterial,
		string Infobar) DcBGTaskCheckSp(int? PostPoReceving,
		int? PostCoShipping,
		int? PostCycleCount,
		int? PostMiscAjust,
		int? PostMatlMove,
		int? PostJobMaterial,
		int? PostJobReceipt,
		int? PostTransferShip,
		int? PostTransferReceipt,
		int? PostJob,
		int? PostTimeAttendance,
		int? PostProductionSchedule,
		int? PostJIT,
		int? PostWCMaterial,
		string Infobar)
		{
			ListYesNoType _PostPoReceving = PostPoReceving;
			ListYesNoType _PostCoShipping = PostCoShipping;
			ListYesNoType _PostCycleCount = PostCycleCount;
			ListYesNoType _PostMiscAjust = PostMiscAjust;
			ListYesNoType _PostMatlMove = PostMatlMove;
			ListYesNoType _PostJobMaterial = PostJobMaterial;
			ListYesNoType _PostJobReceipt = PostJobReceipt;
			ListYesNoType _PostTransferShip = PostTransferShip;
			ListYesNoType _PostTransferReceipt = PostTransferReceipt;
			ListYesNoType _PostJob = PostJob;
			ListYesNoType _PostTimeAttendance = PostTimeAttendance;
			ListYesNoType _PostProductionSchedule = PostProductionSchedule;
			ListYesNoType _PostJIT = PostJIT;
			ListYesNoType _PostWCMaterial = PostWCMaterial;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcBGTaskCheckSp";
				
				appDB.AddCommandParameter(cmd, "PostPoReceving", _PostPoReceving, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostCoShipping", _PostCoShipping, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostCycleCount", _PostCycleCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostMiscAjust", _PostMiscAjust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostMatlMove", _PostMatlMove, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostJobMaterial", _PostJobMaterial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostJobReceipt", _PostJobReceipt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostTransferShip", _PostTransferShip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostTransferReceipt", _PostTransferReceipt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostJob", _PostJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostTimeAttendance", _PostTimeAttendance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostProductionSchedule", _PostProductionSchedule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostJIT", _PostJIT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostWCMaterial", _PostWCMaterial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PostPoReceving = _PostPoReceving;
				PostCoShipping = _PostCoShipping;
				PostCycleCount = _PostCycleCount;
				PostMiscAjust = _PostMiscAjust;
				PostMatlMove = _PostMatlMove;
				PostJobMaterial = _PostJobMaterial;
				PostJobReceipt = _PostJobReceipt;
				PostTransferShip = _PostTransferShip;
				PostTransferReceipt = _PostTransferReceipt;
				PostJob = _PostJob;
				PostTimeAttendance = _PostTimeAttendance;
				PostProductionSchedule = _PostProductionSchedule;
				PostJIT = _PostJIT;
				PostWCMaterial = _PostWCMaterial;
				Infobar = _Infobar;
				
				return (Severity, PostPoReceving, PostCoShipping, PostCycleCount, PostMiscAjust, PostMatlMove, PostJobMaterial, PostJobReceipt, PostTransferShip, PostTransferReceipt, PostJob, PostTimeAttendance, PostProductionSchedule, PostJIT, PostWCMaterial, Infobar);
			}
		}
	}
}
