//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROInvSubNoneBillable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInvSubNoneBillable
	{
		(int? ReturnCode,
			int? OFoundNone,
			string Infobar) SSSFSSROInvSubNoneBillableSp(
			string PMode,
			int? InclBillHold,
			string OperationStatus = "I",
			string SRONum = null,
			string CustNum = null,
			int? StartSROLine = null,
			int? EndSROLine = null,
			int? StartSROOper = null,
			int? EndSROOper = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			string PInvCred = null,
			int? PInclCalculated = null,
			int? PInclProject = null,
			int? OFoundNone = null,
			string Infobar = null);
	}
}

