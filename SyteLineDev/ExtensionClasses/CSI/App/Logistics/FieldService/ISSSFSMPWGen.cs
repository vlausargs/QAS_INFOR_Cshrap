//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSMPWGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSMPWGen
	{
		(int? ReturnCode,
			string InfobarSave,
			string Infobar) SSSFSMPWGenSp(
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

