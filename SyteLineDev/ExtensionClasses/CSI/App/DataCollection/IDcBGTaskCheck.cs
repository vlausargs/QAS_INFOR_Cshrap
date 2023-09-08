//PROJECT NAME: DataCollection
//CLASS NAME: IDcBGTaskCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcBGTaskCheck
	{
		(int? ReturnCode, int? PostPoReceving,
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
		string Infobar);
	}
}

