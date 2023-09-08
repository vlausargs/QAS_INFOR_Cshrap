//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROGenSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROGenSub
	{
		(int? ReturnCode,
			string Infobar) SSSFSSROGenSubSp(
			string CalledFrom,
			int? CreateSROs,
			string Contract,
			string SerNum,
			string Item,
			int? UnitLastMeterAmt,
			int? StartMeterAmt,
			string SroType,
			int? MntSeq,
			DateTime? ThroughDate,
			string LastSroNum,
			DateTime? StartDate,
			DateTime? StartTime,
			string Frequency,
			int? Duration,
			string DurationType,
			int? Month,
			int? Day,
			int? LeadTime,
			string LeadType,
			decimal? DownTime,
			int? ScheduleFuture,
			string ScheduleBasis,
			string SroNum,
			int? SroLine,
			string CustNum,
			int? CustSeq,
			string SroDescription,
			string Infobar,
			string LeadPartner = null,
			string CustPo = null,
			string ShiftID = null,
			int? KeepOperNums = 0,
			string CustItem = null,
			int? SchedDownTime = 0,
			int? CreateIncident = 0,
			string UsrNum = null,
			int? UsrSeq = null);
	}
}

