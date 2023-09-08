//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubSetStartDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubSetStartDay
	{
		(int? ReturnCode,
			int? OStartDay) SSSFSConInvSubSetStartDaySp(
			DateTime? IStartDate,
			DateTime? IBilledThru,
			int? IProrate,
			DateTime? IRenewalDate,
			string IUnitOfRate,
			int? OStartDay);
	}
}

