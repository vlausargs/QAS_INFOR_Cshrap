//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSMPWGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSMPWGen
	{
		(int? ReturnCode,
			string InfobarSave,
			string Infobar) EXTSSSFSMPWGenSp(
			DateTime? EndDate,
			string Source,
			string PlannerCode,
			string Buyer,
			string ThingsToProcess,
			decimal? UserId,
			string InfobarSave,
			string Infobar);
	}
}

