//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcmNumPers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcmNumPers
	{
		(int? ReturnCode,
			int? NumPeriods,
			string Infobar) SSSFSAcmNumPersSp(
			DateTime? StartDate,
			DateTime? EndDate,
			int? NumPeriods,
			string Infobar);
	}
}

