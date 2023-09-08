//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetElapsedBusinessHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetElapsedBusinessHrs
	{
		decimal? SSSFSGetElapsedBusinessHrsFn(
			DateTime? iOpenDate,
			DateTime? iCloseDate);
	}
}

