//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSResourceException.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSResourceException
	{
		(int? ReturnCode,
			string Infobar) SSSFSResourceExceptionSp(
			string SroNum,
			string Action,
			string Infobar,
			int? SchedDownTime = 0,
			string ShiftID = null,
			DateTime? MaintDate = null,
			decimal? MaintDuration = 0,
			int? OldSchedDownTime = 0,
			string OldShiftID = null,
			DateTime? OldMaintDate = null,
			decimal? OldMaintDuration = 0,
			string RESID = null,
			int? SroLine = null);
	}
}

