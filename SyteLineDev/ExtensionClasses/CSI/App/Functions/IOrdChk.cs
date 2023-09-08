//PROJECT NAME: Data
//CLASS NAME: IOrdChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IOrdChk
	{
		(int? ReturnCode,
			string Infobar) OrdChkSp(
			string CurItem,
			string ParmsSite,
			int? MrpParmPreqChk,
			int? MrpParmPlanPlannedPs,
			string Infobar,
			int? IncludeCoitem = 0,
			int? IncludeJob = 0,
			int? IncludeJobitem = 0,
			int? IncludePoitem = 0,
			int? IncludePreqitem = 0,
			int? IncludeTrnitem = 0,
			int? BufferExcMesg = 0,
			Guid? ProcessId = null,
			string Whse = null,
			DateTime? Today = null);
	}
}

